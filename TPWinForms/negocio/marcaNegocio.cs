using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dominio;

namespace negocio
{
    public class marcaNegocio
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
        public void agregar(marca nuevo)
        {
            string insert = "INSERT INTO MARCAS (Descripcion) VALUES (@nombre)";
            try
            {
                datos.setConsulta(insert);
                datos.setParametro("@nombre", nuevo.nombre);

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
            string consutla = "DELETE FROM MARCAS WHERE Id = @ID";
            try
            {
                datos.setConsulta(consutla);
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
