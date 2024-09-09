using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dominio;

namespace negocio
{
    internal class marcaNegocio
    {
        List<marca> lista = new List<marca>();
        accesoDatos datos = new accesoDatos();

        public List<marca> listar()
        {

            string consulta = "select Id, Descripcion from marcas";

            try
            {
                datos.setConsulta(consulta);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    marca aux = new marca();

                    aux.idMarca = (int)datos.Lector["Id"];
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
