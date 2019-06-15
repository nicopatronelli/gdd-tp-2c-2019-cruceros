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

namespace FrbaCrucero.GeneracionViaje
{
    public partial class GenerarViajeForm : Form
    {
        public GenerarViajeForm()
        {
            InitializeComponent();
        }

        private void dtpFechaInicio_ValueChanged(object sender, EventArgs e)
        {
            cargarCbmxCruceroDisponibles();
        }

        private void cargarCbmxCruceroDisponibles()
        {
            try
            {
                DateTime fechaInicioNuevoViaje = dtpFechaInicio.Value;
                Parametro paramfechaInicioNuevoViaje = new Parametro("@fecha_inicio_nuevo_viaje", SqlDbType.NVarChar,
                    fechaInicioNuevoViaje.ToString("yyyy-MM-dd h:mm tt"), 255);
                ConexionBD conexion = new ConexionBD();
                conexion.abrir();
                SqlDataAdapter dataAdapter = new SqlDataAdapter("SELECT crucero_identificador FROM LOS_BARONES_DE_LA_CERVEZA.UF_cruceros_disponibles(@fecha_inicio_nuevo_viaje)", conexion.obtenerConexion());
                dataAdapter.SelectCommand.Parameters.Add(paramfechaInicioNuevoViaje.obtenerSqlParameter());
                DataTable dt = new DataTable();
                dataAdapter.Fill(dt);
                cmbxCrucero.ValueMember = "crucero_identificador";
                cmbxCrucero.DisplayMember = "crucero_identificador";
                cmbxCrucero.DataSource = dt;
            }
            catch
            {
                this.Close();
            }
        }

        private void btnEnviar_Click(object sender, EventArgs e)
        {
            DateTime fechaActual = ArchivoConfig.obtenerFechaConfig();
            DateTime fechaInicioViaje = dtpFechaInicio.Value;
            DateTime fechaFinViaje = dtpFechaFin.Value;

            // Validamos que la fecha de inicio sea posterior a la fecha actual (fecha del archivo de configuración)
            if (DateTime.Compare(fechaActual, fechaInicioViaje) > 0)
            {
                MensajeBox.error("La fecha de inicio del viaje debe ser posterior a la actual.");
                return;
            }

            // Validamos que la fecha de fin del viaje sea posterior a la de inicio
            if (DateTime.Compare(fechaInicioViaje, fechaFinViaje) > 0)
            {
                MensajeBox.error("La fecha de fin del viaje debe ser posterior a la de inicio.");
                return;
            }

            MensajeBox.aviso("El crucero seleccionado es: " + cmbxCrucero.SelectedItem.ToString());
        }
    }
}
