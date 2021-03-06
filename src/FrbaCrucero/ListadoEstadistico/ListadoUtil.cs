﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FrbaCrucero.Utils;

namespace FrbaCrucero.ListadoEstadistico
{
    public class ListadoUtil
    {
        public static string getAnio(DateTimePicker dtpAnio)
        {
            return dtpAnio.Value.ToString("yyyy");
        }

        public static string getRangoFechas(RadioButton rbPrimerSemestre, RadioButton rbSegundoSemestre, string anio)
        {
            if (rbPrimerSemestre.Checked)
            {   
                // Primer semestre: Anio-01-01 al Anio -06-30 (1 de enero al 30 de junio)
                return "CONVERT(datetime, '" + anio + "-01-01', 121) AND CONVERT(datetime, '" + anio + "-06-30', 121) ";
            }
            else
            {
                // Segundo semestre: Anio-07-01 al Anio -12-31 (1 de julio al 31 de diciembre)
                return "CONVERT(datetime, '" + anio + "-07-01', 121) AND CONVERT(datetime, '" + anio + "-12-31', 121) ";
            }
        }

        public static string getInicioSemestre(RadioButton rbPrimerSemestre, RadioButton rbSegundoSemestre, string anio)
        {
                // Primer semestre: Anio-01-01 al Anio -06-30 (1 de enero al 30 de junio)
                return "convert(datetime2(3), (select CONCAT((select CAST( " + anio + " AS varchar)), '-0', (case when 1 = 1 then '1-01' else '7-00' end),' 00:00:00.000'  )),121)";
        }

        public static string getFinSemestre(RadioButton rbPrimerSemestre, RadioButton rbSegundoSemestre, string anio)
        {
                // Segundo semestre: Anio-07-01 al Anio -12-31 (1 de julio al 31 de diciembre)
                return "convert(datetime2(3), (select CONCAT((select CAST( " + anio + " AS varchar)), '-', (case when 2 = 1 then '07-01' else '12-31' end),' 00:00:00.000')),121)";
        }

        public static void cargar(string consulta, DataGridView dgv)
        {
            ConexionBD conexion = new ConexionBD();
            SqlDataAdapter dataAdapter = new SqlDataAdapter(consulta, conexion.obtenerConexion());

            // Ejecutamos la consulta y traemos los datos 
            SqlCommandBuilder commandBuilder = new SqlCommandBuilder(dataAdapter);
            DataSet dataSet = new DataSet();
            dataAdapter.Fill(dataSet);
            dgv.DataSource = dataSet.Tables[0];

            // Para autoajustar el tamaño del dgv
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            conexion.cerrar();
        } // FIN cargar()

    }
}
