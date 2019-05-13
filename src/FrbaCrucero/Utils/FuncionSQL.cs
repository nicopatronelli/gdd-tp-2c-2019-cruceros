using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrbaCrucero.Utils
{
    class FuncionSQL
    {

        SqlCommand comando;
        SqlParameter resultado;

        public FuncionSQL(string nombreFuncionSQL, List<Parametro> listaParam, SqlDbType tipoDatoRetorno)
        {
            // Creamos un comando con el nombre de la función SQL 
            comando = new SqlCommand(nombreFuncionSQL);

            // Aunque se trata de una función y no un SP, debemos definirlo como SP para que funcione
            comando.CommandType = CommandType.StoredProcedure;

            // Añadimos los parametros de la función SQL 
            foreach (Parametro param in listaParam)
            {
                comando.Parameters.Add(param.obtenerSqlParameter());
            }

            // Añadimos el parametro que será el valor de retorno de la función SQL
            resultado = new SqlParameter("@salida", tipoDatoRetorno);
            resultado.Direction = ParameterDirection.ReturnValue;
            comando.Parameters.Add(resultado);

        } // Fin constructor 

        public object ejecutar()
        {
            /* Una función SQL siempre devuelve un valor (resultado). Dicho resultado estará almacenado
             * en el atributo Value del parámetro resultado. 
             */
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

                // Retornamos el resultado de la función SQL
                return resultado.Value;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al ejecutar una Función SQL. Info: " + ex.ToString());
                return DEF.ERROR;
            }
        } // Fin ejecutar()

    }
}
