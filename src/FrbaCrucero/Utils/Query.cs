using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrbaCrucero.Utils
{
    class Query
    {
        SqlCommand comando;
        ConexionBD conexion;

        // Query sin parámetros 
        public Query(string consulta)
        {
            // Creamos un comando con la consulta (query) pasada por parámetro en el constructor
            comando = new SqlCommand(consulta);
        } // Fin constructor
        
        // Query con parámetros 
        public Query(string consulta, List<Parametro> parametros)
        {
            // Creamos un comando con la consulta (query) pasada por parámetro en el constructor
            comando = new SqlCommand(consulta);

            // Añadimos los parametros a la consulta
            foreach (Parametro param in parametros)
            {
                comando.Parameters.Add(param.obtenerSqlParameter());
            }
        } // Fin constructor

        public void cerrarConexionReader()
        {
            /* En el caso de las consultas que retornan un SqlDataReader, no podemos cerrar la conexión 
             * inmediatamente luego de hacer la consulta (dentro del mismo método), pues de hacerlo no
             * podemos leer los datos del data reader devuelto. Por lo tanto, proveemos un método que nos
             * permite cerrar la conexión abierta contra la BD de manera manual. 
             */
            conexion.cerrar();

        } // FIN cerrarConexionReader

        public object ejecutarEscalar()
        {
            try
            {
                // Creamos y abrimos una conexión a la base de datos 
                conexion = new ConexionBD();
                conexion.abrir();

                // Asignamos la conexión al SP
                comando.Connection = conexion.obtenerConexion();

                // Ejecutamos el SP
                object resultado = comando.ExecuteScalar();

                // Liberamos los recursos asociados al SP
                comando.Dispose();

                // Cerramos la conexión
                conexion.cerrar();

                // El procedimiento almacenado se ejecuto correctamente 
                return resultado;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al ejecutar una consulta desde la aplicación. Info: " + ex.ToString());
                return DEF.ERROR;
            }
        } // FIN ejecutarEscalar()

        public List<string> ejecutarReaderUnicaColumna()
        {
            const int UNICA_COLUMNA = 0;
            try
            {
                // Creamos y abrimos una conexión a la base de datos 
                conexion = new ConexionBD();
                conexion.abrir();

                // Asignamos la conexión a la consulta
                comando.Connection = conexion.obtenerConexion();

                // Ejecutamos la consulta
                SqlDataReader registrosLeidos = comando.ExecuteReader();

                // Declaramos una lista de objects donde vamos a guardar el contenido de cada fila que retorno 
                // la consulta. Cada fila es un elemento de la lista. 
                List<string> registros = new List<string>();

                while (registrosLeidos.Read())
                {
                    registros.Add((registrosLeidos.GetString(UNICA_COLUMNA)));
                }

                // Liberamos los recursos asociados a la consulta
                comando.Dispose();

                // Cerramos la conexión
                conexion.cerrar();

                // La consulta se ejecuto correctamente 
                return registros;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al ejecutar una consulta desde la aplicación. Info: " + ex.ToString());
                return null;
            }
        } // FIN ejecutarReaderUnicaColumna()

        public SqlDataReader ejecutarReaderFila()
        {
            try
            {
                // Creamos y abrimos una conexión a la base de datos 
                conexion = new ConexionBD();
                conexion.abrir();

                // Asignamos la conexión a la consulta
                comando.Connection = conexion.obtenerConexion();

                // Ejecutamos la consulta
                SqlDataReader registroLeido = comando.ExecuteReader();
                registroLeido.Read();
                //int cantidadColumnas = registroLeido.FieldCount;

                //// Declaramos una lista de string donde vamos a guardar el contenido de cada campo de la 
                //// fila que retorno la consulta.
                //List<string> fila = new List<string>();

                //while (registroLeido.Read())
                //{
                //    fila.Add((registroLeido.GetString(UNICA_COLUMNA)));
                //}

                //// Liberamos los recursos asociados a la consulta
                //comando.Dispose();

                //// Cerramos la conexión
                //conexion.cerrar();

                // La consulta se ejecuto correctamente 
                return registroLeido;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al ejecutar una consulta desde la aplicación. Info: " + ex.ToString());
                return null;
            }
        } // FIN ejecutarReaderFila()


        public SqlDataReader ejecutarReader()
        {
            try
            {
                // Creamos y abrimos una conexión a la base de datos 
                conexion = new ConexionBD();
                conexion.abrir();

                // Asignamos la conexión a la consulta
                comando.Connection = conexion.obtenerConexion();

                // Ejecutamos la consulta
                SqlDataReader registroLeido = comando.ExecuteReader();
                //int cantidadColumnas = registroLeido.FieldCount;

                // Declaramos una lista de string donde vamos a guardar el contenido de cada campo de la 
                // fila que retorno la consulta.
                //List<string> fila = new List<string>();

                //while (registroLeido.Read())
                //{
                //    fila.Add((registroLeido.GetString(UNICA_COLUMNA)));
                //}

                // Liberamos los recursos asociados a la consulta
                //comando.Dispose();

                // Cerramos la conexión
                //conexion.cerrar();

                // La consulta se ejecuto correctamente 
                return registroLeido;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al ejecutar una consulta desde la aplicación. Info: " + ex.ToString());
                return null;
            }
        } // FIN ejecutarReader()



        // Retorna la cantidad de filas afectadas (insertadas, actualizadas o eliminadas) por la consulta 
        public int ejecutarNonQuery()
        {
            try
            {
                // Creamos y abrimos una conexión a la base de datos 
                conexion = new ConexionBD();
                conexion.abrir();

                // Asignamos la conexión al SP
                comando.Connection = conexion.obtenerConexion();

                // Ejecutamos el SP
                int cantidadFilasAfectadas = comando.ExecuteNonQuery();

                // Liberamos los recursos asociados al SP
                comando.Dispose();

                // Cerramos la conexión
                conexion.cerrar();

                // El procedimiento almacenado se ejecuto correctamente 
                return cantidadFilasAfectadas;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al ejecutar un Consulta desde la aplicación. Info: " + ex.ToString());
                return DEF.ERROR;
            }
        } // FIN ejecutarNonQuery()

    } // FIN Clase Query
}
