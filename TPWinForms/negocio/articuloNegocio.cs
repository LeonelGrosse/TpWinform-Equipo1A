using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.SqlServer.Server;
using dominio;

namespace negocio
{
    public class articuloNegocio
    {
        List<articulo> lista = new List<articulo>();
        accesoDatos datos = new accesoDatos();

        public List<articulo> listar()
        {
            //string consutla = "Select id, Codigo, Nombre, Descripcion, Precio, idMarca, IdCategoria from ARTICULOS";

            string select = "SELECT A.Id, Codigo, Nombre, A.Descripcion, M.Id marcID, M.Descripcion marcDesc, C.Id catID, C.Descripcion catDesc, Precio, I.Id imgID, I.ImagenUrl imgUrl";
            string from = " FROM ARTICULOS A INNER JOIN MARCAS M ON A.IdMarca = M.Id INNER JOIN CATEGORIAS C ON A.IdCategoria = C.Id LEFT JOIN IMAGENES AS I ON I.IdArticulo = A.Id";

            try
            {
                datos.setConsulta(select + from);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    articulo aux = new articulo();
                    aux.idArticulo = (int)datos.Lector["Id"];
                    aux.codigo = (string)datos.Lector["Codigo"];
                    aux.nombre = (string)datos.Lector["Nombre"];
                    aux.descripcion = (string)datos.Lector["Descripcion"];
                    aux.precio = (decimal)datos.Lector["Precio"];

                    aux.marca = new marca();
                    aux.marca.idMarca = (int)datos.Lector["marcID"];
                    aux.marca.nombre = (string)datos.Lector["marcDesc"];

                    aux.categoria = new categoria();
                    aux.categoria.idCategoria = (int)datos.Lector["catID"];
                    aux.categoria.nombre = (string)datos.Lector["catDesc"];

                    aux.imagen = new imagen();
                    if (!(datos.Lector["imgID"] is DBNull))
                    {
                        aux.imagen.idImagen = (int)datos.Lector["imgID"];
                        aux.imagen.urlImagen = (string)datos.Lector["imgUrl"];
                    }

                    lista.Add(aux);
                }

                return lista;

            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public void agregar(articulo nuevo)
        {
            accesoDatos datos = new accesoDatos();

            try
            {
                datos.setConsulta("Insert into ARTICULOS (Codigo, Nombre, Descripcion, IdMarca, IdCategoria, Precio) values (@cod, @nom, @desc, @idMarca, @idCategoria, @precio)");
                datos.setParametro("@cod", nuevo.codigo);
                datos.setParametro("@nom", nuevo.nombre);            
                datos.setParametro("@desc", nuevo.descripcion);
                datos.setParametro("@idMarca", nuevo.marca.idMarca);
                datos.setParametro("@idCategoria", nuevo.categoria.idCategoria);
                datos.setParametro("@precio", nuevo.precio);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public void modificar(articulo art)
        {
            accesoDatos datos = new accesoDatos();
            try
            {
                datos.setConsulta("update ARTICULOS set Codigo = @cod, Nombre = @nom, Descripcion = @desc, IdMarca = @idMarca, IdCategoria = @idCategoria, Precio = @precio where Id = @id");
                datos.setParametro("@cod", art.codigo);
                datos.setParametro("@nom", art.nombre);
                datos.setParametro("@desc", art.descripcion);
                datos.setParametro("@idMarca", art.marca.idMarca);
                datos.setParametro("@idCategoria", art.categoria.idCategoria);
                datos.setParametro("@precio", art.precio);
                datos.setParametro("@id", art.idArticulo);

                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }
    }
}
