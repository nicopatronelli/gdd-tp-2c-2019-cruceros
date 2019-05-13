using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace FrbaCrucero.Utils
{
    static class ArchivoConfig
    {

        public static string obtenerCadenaConexion()
        {
            string dataSource = "Data Source=";
            string initialCatalog = ";Initial Catalog=";
            string userId = ";User Id=";
            string password = ";Password=";

            string[] lineas = File.ReadAllLines("../../../archivoConfig.txt");

            if (lineas != null && lineas.Count() > 0) // Hay datos en el archivo 
            {
                foreach (string linea in lineas)
                {
                    char[] separator = "=".ToCharArray();
                    String[] palabras = linea.Split(separator, 2, System.StringSplitOptions.None);
                    string clave = palabras.ElementAt(0);

                    if (clave.Equals("Data Source"))
                    {
                        dataSource = dataSource + palabras.ElementAt(1);
                    }
                    else if (clave.Equals("Initial Catalog"))
                    {
                        initialCatalog = initialCatalog + palabras.ElementAt(1);
                    }
                    else if (clave.Equals("User Id"))
                    {
                        userId = userId + palabras.ElementAt(1);
                    }
                    else if (clave.Equals("Password"))
                    {
                        password = password + palabras.ElementAt(1);
                    }
                } // FIN foreach
            } // FIN if 

            return dataSource + initialCatalog + userId + password;

        } // FIN obtenerCadenaConexion()

        public static DateTime obtenerFechaConfig()
        {
            string fechaConfigCadena = "";
            string[] lineas = File.ReadAllLines("../../../archivoConfig.txt");
            if (lineas != null && lineas.Count() > 0) // Hay datos en el archivo 
            {
                foreach (string linea in lineas)
                {
                    char[] separator = "=".ToCharArray();
                    String[] palabras = linea.Split(separator, 2, System.StringSplitOptions.None);
                    string clave = palabras.ElementAt(0);

                    if (clave.Equals("fecha config"))
                    {
                        fechaConfigCadena = palabras.ElementAt(1);
                    }
                } // FIN foreach
            } // FIN if 

            // Convertimos la fecha de string a DateTime 
            DateTime fechaConfig = Convert.ToDateTime(fechaConfigCadena);

            return fechaConfig;

        } // FIN obtenerFechaConfig()

    } // FIN Clase ArchivoConfig
}
