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
            string consutla = "Select id, Codigo, Nombre, Descripcion, Precio, idMarca, IdCategoria from ARTICULOS";
            
            try
            {
                datos.setConsulta(consutla);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    articulo aux = new articulo();
                    aux.idArticulo = (int)datos.Lector["Id"];
                    aux.codigo = (string)datos.Lector["Codigo"];
                    aux.nombre = (string)datos.Lector["Nombre"];
                    aux.descripcion = (string)datos.Lector["Descripcion"];
                    aux.precio = (decimal)datos.Lector["Precio"];

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
    }
}
