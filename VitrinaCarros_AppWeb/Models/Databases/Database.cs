using System;
using Npgsql;
using System.Data.SqlClient;

namespace VitrinaCarros_AppWeb.Models.Databases
{
    public class Database
    {

        public Database() { }
   
        #region "Metodos Publicos" 

            //Metodo Conectar. Este metodo Retorna un dato tipo sqlConnection
            //Instaciamos la cadena de conexion pasando unos parametros y Abrimos la conexion
            public SqlConnection Conectar()
            {
                SqlConnection conn = new SqlConnection("Data Source=.;" +
                "Initial Catalog=VITRINA_CARROS;Integrated Security=SSPI;");

            try
                {
                    conn.Open();
                    Console.WriteLine("Conexion Exitosa");
                    return conn;
                }
                catch(SqlException)
                {
                    return null;
                }
            
            }

            //Metodo para cerrar al conexion que recibe como paremetro un objeto de tipo SqlConnection
            public void CerrarConexion(SqlConnection conn)
            {
                try
                {
                    conn.Close();//Con el objeto referenciado. Cerramos la conexion.
                }
                catch (SqlException)
                {
                    throw;
                }
            }

            //Metodo para ejecutar de las instrucciones delete, insert, update
            //las instrucciones SQL que retorna una cantidad de filas afectadas.
            public int operaracion(string conSQL, SqlConnection conector)
            {
                int num = 0;

                try
                {
                    //variable comando tipo SqlCommand le pasamos el Query(puede ser insert, delete o update) 
                    //Junto con el objeto conectar.
                    SqlCommand comando = new SqlCommand(conSQL, conector);
                    num = comando.ExecuteNonQuery();//Ejecutamos el comando
                    return num;//Retorna el numero de filas afectadas.
                }
                catch (SqlException)
                {
                    return num;
                    throw;
                }
                finally
                {
                    // Cerrar la conexión si esta se encuentra abierta
                    if (conector.State == System.Data.ConnectionState.Open)
                        conector.Close();
                }
            }

            public SqlDataReader Consulta(string conSQL, SqlConnection conector)
            {
                try
                {
                    SqlCommand comando = new SqlCommand(conSQL, conector);
                    SqlDataReader datos = comando.ExecuteReader();
                    return datos;
                }
                catch (SqlException)
                {
                    return null;
                    throw;
                }
                finally
                {
                    // Cerrar la conexión si esta se encuentra abierta
                    if (conector.State == System.Data.ConnectionState.Open)
                        conector.Close();
                }
            }

        #endregion
    }
}