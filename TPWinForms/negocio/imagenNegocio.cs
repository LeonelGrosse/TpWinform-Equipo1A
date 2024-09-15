using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dominio;

namespace negocio
{
    public class imagenNegocio
    {
        List<imagen> lista = new List<imagen>();
        accesoDatos datos = new accesoDatos();

        public List<imagen> listar()
        {

            string consulta = " Select Id, IdArticulo, ImagenUrl from IMAGENES";

            try
            {
                datos.setConsulta(consulta);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    imagen aux = new imagen();

                    aux.idImagen = (int)datos.Lector["Id"];
                    aux.idArticulo = (int)datos.Lector["IdArticulo"];
                    aux.urlImagen = (string)datos.Lector["ImagenUrl"];

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
            string insert = " Insert into IMAGENES values (@idArticulo, @urlImagen)";
            try
            {
                datos.setConsulta(insert);
                datos.setParametro("@idArticulo", nuevo.idArticulo);
                datos.setParametro("@urlImagen", nuevo.imagen.urlImagen);
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
        public void eliminar(int id)
        {
            string consulta = " Delete from IMAGENES where Id = @Id";
            try
            {
                datos.setConsulta(consulta);
                datos.setParametro("@ID", id);
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
