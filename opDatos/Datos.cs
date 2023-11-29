using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace opDatos
{
    public class Datos
    {
        string cadenaConexion;
        
        public void OpenConexion(ParametrosConexion parametros)
        {
            cadenaConexion = (parametros.obtenerCadena()).ToString();

            try
            {
                SqlConnection connection = new SqlConnection(cadenaConexion);
                connection.Open();
                
                connection.Close();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public List<string> ObtieneDatos(ParametrosConexion parametros, string query)
        {
            var resultado = new List<string>();
            cadenaConexion = (parametros.obtenerCadena()).ToString();
            using (SqlConnection connection = new SqlConnection(cadenaConexion))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        string valor = reader.GetString(0);
                        resultado.Add(valor);
                    }
                }
                    
                connection.Close();
            } 
            return resultado;
        }

        public void createBD(ParametrosConexion parametros, string nameBD)
        {
            string query = $"CREATE DATABASE {nameBD};";
            cadenaConexion = (parametros.obtenerCadena()).ToString();
            try
            {
                using (SqlConnection connection = new SqlConnection(cadenaConexion))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.ExecuteNonQuery();
                    }

                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void deleteBD(ParametrosConexion parametros, string nameBD)
        {
            string query = $"DROP DATABASE {nameBD};";
            cadenaConexion = (parametros.obtenerCadena()).ToString();
            try
            {
                using (SqlConnection connection = new SqlConnection(cadenaConexion))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.ExecuteNonQuery();
                    }

                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
