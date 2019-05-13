using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrbaCrucero.Utils
{
    class StoreProcedure
    {

        SqlCommand comando;

        public StoreProcedure(string nombreSP, List<Parametro> listaParam)
        {
            // Creamos un comando con el nombre del SP pasado y definimos que será del tipo SP
            comando = new SqlCommand(nombreSP);
            comando.CommandType = CommandType.StoredProcedure;

            // Añadimos los parametros del SP
            foreach (Parametro param in listaParam)
            {
                comando.Parameters.Add(param.obtenerSqlParameter());
            }

        }

        /* @Nota: Un SP nunca devuelve un valor. Si todos sus parámetros son de entrada tendrá un efecto de 
        * lado en la base. Si alguno es de salida guardará un valor nuevo en el mismo, pero la salida será
        * por el parámetro y no por el SP como en una función. Por lo tanto, el método ejecutarSP() no tiene
        * que devolver ningún valor. Podemos hacer que devuelva 0 si todo salió bien y -1 en caso contrario.
        */
        public int ejecutar()
        {
            try
            {
                // Creamos y abrimos una conexión a la base de datos 
                ConexionBD conexion = new ConexionBD();
                conexion.abrir();

                // Asignamos la conexión al SP
                comando.Connection = conexion.obtenerConexion();

                // Ejecutamos el SP
                comando.ExecuteScalar();

                // Liberamos los recursos asociados al SP
                comando.Dispose();

                // Cerramos la conexión
                conexion.cerrar();

                // El procedimiento almacenado se ejecuto correctamente 
                return DEF.EXITO;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al ejecutar un Procedimiento Almacenado. Info: " + ex.ToString());
                return DEF.ERROR;
            }
        } // Fin ejecutar()

        // Retorna la cantidad de filas afectadas (insertadas, actualizadas o eliminadas) por el SP
        public int ejecutarNonQuery()
        {
            try
            {
                // Creamos y abrimos una conexión a la base de datos 
                ConexionBD conexion = new ConexionBD();
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
                Console.WriteLine("Error al ejecutar un Procedimiento Almacenado. Info: " + ex.ToString());
                return DEF.ERROR;
            }
        } // FIN ejecutarNonQuery()

    } // FIN clase StoreProcedure
}
