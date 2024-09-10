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
        public void agregar(categoria nuevo)
        {
            string insert = "INSERT INTO CATEGORIAS (Descripcion) VALUES (@nombre)";
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
            string consutla = "DELETE FROM CATEGORIAS WHERE Id = @ID";
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
