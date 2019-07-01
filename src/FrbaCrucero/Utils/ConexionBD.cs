using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace FrbaCrucero.Utils
{
    class ConexionBD
    {
        //private string cadenaConexion = "Data source=localhost\\SQLSERVER2012;Initial Catalog=GD2C2018; User Id=gdEspectaculos2018;Password=gdEspectaculos2018"; 
        private string cadenaConexion = ArchivoConfig.obtenerCadenaConexion();
        private SqlConnection conexion = new SqlConnection();

        // Constructor (inicializa el atributo ConnectionString del objeto SqlConnection)  
        public ConexionBD()
        {
            conexion.ConnectionString = cadenaConexion;
        }

        public SqlConnection obtenerConexion()
        {
            return conexion;
        }

        // Metodo para abrir la conexión 
        public void abrir()
        {
            try
            {
                conexion.Open();
                //Console.WriteLine("Conexion establecida con base de datos");
            }
            catch (Exception ex)
            {
                //Console.WriteLine("No se pudo conectar a la BD: " + ex.ToString());
            }
        }

        // Metodo para cerrar la conexión 
        public void cerrar()
        {
            this.conexion.Close();
        }

    }
}
