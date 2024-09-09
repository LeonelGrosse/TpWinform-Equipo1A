using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dominio;

namespace negocio
{
    public class categoriaNegocio
    {
        List<categoria> lista = new List<categoria>();
        accesoDatos datos = new accesoDatos();
        public List<categoria> listar()
        {

            string consulta = "select Id, Descripcion from CATEGORIAS";

            try
            {
                datos.setConsulta(consulta);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    categoria aux = new categoria();

                    aux.idCategoria = (int)datos.Lector["Id"];
                    aux.nombre = (string)datos.Lector["Descripcion"];

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
