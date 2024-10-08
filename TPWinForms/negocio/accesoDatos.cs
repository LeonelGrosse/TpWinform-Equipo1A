﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Net;


namespace negocio
{
    public class accesoDatos
    {
        private SqlConnection conexion;         //establece al coneccion
        private SqlCommand comando;             //para realizar las acciones
        private SqlDataReader lector;           // trae los datos
        public SqlDataReader Lector             // Con esta property se puyede leer el lecto del exterior
        {
            get { return lector; }
        }

        public accesoDatos()
        {
            conexion = new SqlConnection("server=.\\SQLEXPRESS; database = CATALOGO_P3_DB; integrated security = true");
            comando = new SqlCommand();
        }
        public void setConsulta(string consulta)
        {
            comando.CommandType = System.Data.CommandType.Text; //es la foma de hacer la consutal, texto 
            comando.CommandText = consulta;                     //se pasa la consutal en texto al metodo 
        }
        public void ejecutarLectura()
        {
            comando.Connection = conexion;
            try
            {
                conexion.Open();
                lector = comando.ExecuteReader();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public void ejecutarAccion()
        {
            comando.Connection = conexion;
            try
            {
                conexion.Open();
                comando.ExecuteNonQuery();  //ejecuta una accion q no es una QUERY
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public int ejecutarEscalar()
        {
            try
            {
                conexion.Open();
                return (int)comando.ExecuteScalar();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conexion.Close();
            }
        }


        public void setParametro(string nombre, object valor)
        {
            comando.Parameters.AddWithValue(nombre, valor);      //Para setear un valor a una columna cuando se haga la consulta
        }
        public void cerrarConexion()
        {
            if (lector != null)
            {
                lector.Close();
            }
            conexion.Close();
        }
    }
}
