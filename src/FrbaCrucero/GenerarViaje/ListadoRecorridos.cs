using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FrbaCrucero.Utils;
using FrbaCrucero.GenerarViaje.Dominio;
using FrbaCrucero.GenerarViaje.Dominio.Excepciones;

namespace FrbaCrucero.GenerarViaje
{
    class ListadoRecorridos
    {
        DataGridView dgvRecorridos;

        public ListadoRecorridos(DataGridView dgvRecorridos)
        {
            this.dgvRecorridos = dgvRecorridos;
        }

        public DataGridView getDgvRecorridos()
        {
            return this.dgvRecorridos;
        }

        public void popularRecorridos(string puertoInicio, string puertoFin)
        {
            // Armamos la query en forma dinámica según el puerto de inicio y fin ingresados 
            ConexionBD conexion = new ConexionBD();
            SqlDataAdapter dataAdapter = new SqlDataAdapter(this.queryRecorridos(), conexion.obtenerConexion());

            // Añadimos el parámetro puerto_inicio
            Parametro paramPuertoInicio = new Parametro("@puerto_inicio", SqlDbType.NVarChar, puertoInicio, 255);
            if (puertoInicio.Equals("")) // Si no se introdujo el puerto de inicio
                paramPuertoInicio.esCadenaVaciaYNoNull();
            dataAdapter.SelectCommand.Parameters.Add(paramPuertoInicio.obtenerSqlParameter());

            // Añadimos el parámetro puerto_fin
            Parametro paramPuertoFin = new Parametro("@puerto_fin", SqlDbType.NVarChar, puertoFin, 255);
            if (puertoFin.Equals("")) // Si no se introdujo el puerto de fin
                paramPuertoFin.esCadenaVaciaYNoNull();
            dataAdapter.SelectCommand.Parameters.Add(paramPuertoFin.obtenerSqlParameter());

            SqlCommandBuilder commandBuilder = new SqlCommandBuilder(dataAdapter);
            DataSet dataSet = new DataSet();
            dataAdapter.Fill(dataSet);
            this.dgvRecorridos.ReadOnly = false; // Para que permita tildar la columna de checkbox para eleccionar recorrido
            this.dgvRecorridos.AllowUserToAddRows = false; // Para evitar que se añadan filas dinámicamente
            this.dgvRecorridos.DataSource = dataSet.Tables[0];
            // Marcamos el resto de las columnas como ReadOnly true para que no se pueda editar su contenido
            this.dgvRecorridos.Columns["Identificador"].ReadOnly = true;
            this.dgvRecorridos.Columns["Puerto Inicio"].ReadOnly = true;
            this.dgvRecorridos.Columns["Puerto Fin"].ReadOnly = true;
            conexion.cerrar();
        } // FIN popularRecorridos()

        // Query para traernos los recorridos disponibles
        private string queryRecorridos()
        {
            return "SELECT DISTINCT "
                    + "r.recorrido_codigo 'Identificador', "
                    + "pto_inicio.puerto_nombre 'Puerto Inicio', "
                    + "pto_fin.puerto_nombre 'Puerto Fin' "
                 + "FROM LOS_BARONES_DE_LA_CERVEZA.Recorrido r "
                    + "JOIN LOS_BARONES_DE_LA_CERVEZA.Tramos_por_Recorrido tpr1 "
                        + "ON r.id_recorrido = tpr1.id_recorrido "
                    + "JOIN LOS_BARONES_DE_LA_CERVEZA.Tramos_por_Recorrido tpr2 "
                        + "ON r.id_recorrido = tpr2.id_recorrido "
                    + "JOIN LOS_BARONES_DE_LA_CERVEZA.Tramo t1 "
                        + "ON tpr1.id_tramo = t1.id_tramo "
                    + "JOIN LOS_BARONES_DE_LA_CERVEZA.Tramo t2 "
                        + "ON tpr2.id_tramo = t2.id_tramo "
                    + "JOIN LOS_BARONES_DE_LA_CERVEZA.Puerto pto_inicio "
                        + "ON t1.tramo_puerto_inicio = pto_inicio.id_puerto "
                    + "JOIN LOS_BARONES_DE_LA_CERVEZA.Puerto pto_fin "
                        + "ON t2.tramo_puerto_destino = pto_fin.id_puerto "
                 + "WHERE tpr1.tramo_anterior IS NULL "
                    + "AND tpr2.tramo_siguiente IS NULL "
                    + "AND pto_inicio.puerto_nombre LIKE '%'+@puerto_inicio+'%' "
                    + "AND pto_fin.puerto_nombre LIKE '%'+@puerto_fin+'%'";
        } // FIN queryRecorridos()

        // Agregamos un checkbox al final de cada registro recorrido para poder seleccionarlos
        public void agregarCheckBoxDgv(string nombreBoton, string headerBoton)
        {
            DataGridViewCheckBoxColumn chbxSeleccionarRecorrido = new DataGridViewCheckBoxColumn();
            chbxSeleccionarRecorrido.Name = nombreBoton;
            chbxSeleccionarRecorrido.HeaderText = headerBoton;
            this.dgvRecorridos.Columns.Add(chbxSeleccionarRecorrido);
            this.dgvRecorridos.Columns[nombreBoton].Width = 55;
        }

        public void limpiarDgv()
        {
            this.dgvRecorridos.Columns.Clear();
            this.dgvRecorridos.Refresh();
        }
    }
}
