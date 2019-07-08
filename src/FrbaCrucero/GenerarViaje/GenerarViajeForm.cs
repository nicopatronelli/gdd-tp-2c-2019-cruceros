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
using FrbaCrucero.GenerarViaje;

namespace FrbaCrucero.GenerarViaje
{
    public partial class GenerarViajeForm : Form
    {
        private string identificadorRecorrido; // Identificador del recorrido seleccionado para el viaje
        private ListadoRecorridos listadoRecorridos;

        public GenerarViajeForm()
        {
            InitializeComponent();
            listadoRecorridos = new ListadoRecorridos(dgvRecorridos);
        }

        private void GenerarViajeForm_Load(object sender, EventArgs e)
        {
            dgvRecorridos.CellClick += dgvRecorridosSoloUnRecorrido_CellContentClick;
            dgvRecorridos.CellClick += capturarIdentificadorRecorridoSeleccionado_CellContentClick;
            dgvRecorridos.CellClick += mostrarTramosDelRecorridoSeleccionado_CellContentClick;
        }

        private void btnEnviar_Click(object sender, EventArgs e)
        {   
            DateTime fechaInicioViaje = dtpFechaInicio.Value;
            DateTime fechaFinViaje = dtpFechaFin.Value;
            string identificadorCrucero;
            try{ identificadorCrucero = cmbxCrucero.SelectedValue.ToString(); }
            catch
            {
                MensajeBox.info("No ha seleccionado un crucero para el viaje: debe seleccionar uno. Si no le figura ningún crucero, significa que no hay cruceros disponibles para las fechas ingresadas.");
                return;
            }

            int flagNingunCruceroSeleccionado = 0;
            foreach (DataGridViewRow row in dgvRecorridos.Rows)
            {
                if (row.Cells["btnDgvSeleccionarRecorrido"].Value.Equals(true))
                    flagNingunCruceroSeleccionado++;
            }
            if (flagNingunCruceroSeleccionado.Equals(DEF.NINGUN_RECORRIDO_SELECCIONADO))
            {
                MensajeBox.info("No ha seleccionado un recorrido para el viaje: debe seleccionar uno. Si no le figura ningún recorrido, significa que no hay recorridos disponibles para los puertos ingresados.");
                return;
            }
            
            Viaje viaje = new Viaje();
            try
            {
                viaje
                    .setFechaInicio(fechaInicioViaje)
                    .setFechaFin(fechaFinViaje)
                    .setIdentificadorCrucero(identificadorCrucero)
                    .setIdentificadorRecorrido(identificadorRecorrido);
            }
            catch (FechaInicioAnteriorFechaConfigException ex) { ex.mensajeError(); return; }
            catch (FechaFinViajeAnteriorAFechaInicioViajeException ex) { ex.mensajeError(); return; }
            catch (IdentificadorCruceroEnViajeEsNuloOVacioException ex) { ex.mensajeError(); return; }
            catch (NingunRecorridoSeleccionadoEnNuevoViajeException ex) { ex.mensajeError(); return; }

            // En este punto ya tenemos un objeto viaje correctamente construido y válido para INSERTAR
            try
            {
                viaje.insertar();
            }
            catch (InsertarNuevoViajeException ex){ ex.mensajeError(); return; }

            // Llegamos acá, el viaje se inserto correctamente
            MensajeBox.info("El nuevo viaje se ha creado correctamente.");
            this.Close();

        } // FIN btnEnviar_Click()

        private void dtpFechaInicio_ValueChanged(object sender, EventArgs e)
        {
            cargarCbmxCruceroDisponibles();
            this.dtpFechaFin.Enabled = true;
        }

        private void cargarCbmxCruceroDisponibles()
        {
            try
            {
                DateTime fechaInicioNuevoViaje = dtpFechaInicio.Value;
                DateTime fechaFinNuevoViaje = dtpFechaFin.Value;
                Parametro paramFechaInicioNuevoViaje = new Parametro("@fecha_inicio_nuevo_viaje_s", SqlDbType.NVarChar,
                    fechaInicioNuevoViaje.ToString("yyyy-MM-dd h:mm tt"), 255);
                Parametro paramFechaFinNuevoViaje = new Parametro("@fecha_fin_nuevo_viaje_s", SqlDbType.NVarChar,
                    fechaFinNuevoViaje.ToString("yyyy-MM-dd h:mm tt"), 255);
                ConexionBD conexion = new ConexionBD();
                conexion.abrir();
                SqlDataAdapter dataAdapter = new SqlDataAdapter("SELECT identificador FROM LOS_BARONES_DE_LA_CERVEZA.UF_cruceros_disponibles(@fecha_inicio_nuevo_viaje_s, @fecha_fin_nuevo_viaje_s)", conexion.obtenerConexion());
                dataAdapter.SelectCommand.Parameters.Add(paramFechaInicioNuevoViaje.obtenerSqlParameter());
                dataAdapter.SelectCommand.Parameters.Add(paramFechaFinNuevoViaje.obtenerSqlParameter());
                DataTable dt = new DataTable();
                dataAdapter.Fill(dt);
                cmbxCrucero.DisplayMember = "identificador";
                cmbxCrucero.ValueMember = "identificador";
                cmbxCrucero.DataSource = dt;
            }
            catch (Exception)
            {
                this.Close();
            }
        } // FIN cargarCbmxCruceroDisponibles()

        private void btnBuscarRecorridos_Click(object sender, EventArgs e)
        {
            // Limpiamos el listado (datagridview) de recorridos
            this.listadoRecorridos.limpiarDgv();

            // Recuperamos los puertos ingresados (puede que no se haya ingresado uno o ambos -> se traen todos los recorridos disponibles)
            string puertoInicio = txtbxPuertoInicio.Text;
            string puertoFin = txtbxPuertoFin.Text;

            this.listadoRecorridos.popularRecorridos(puertoInicio, puertoFin, this.listadoRecorridos.queryRecorridosGenerarViaje());
            this.listadoRecorridos.agregarCheckBoxDgv("btnDgvSeleccionarRecorrido", "Seleccionar Recorrido");
        } // FIN btnBuscarRecorridos_Click

        // Guardamos el identificador del recorrido seleccionado al pulsar Enviar
        private void capturarIdentificadorRecorridoSeleccionado_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;
            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewCheckBoxColumn &&
                e.RowIndex >= 0)
            {
                identificadorRecorrido = Convert.ToString(dgvRecorridos.Rows[e.RowIndex].Cells["Identificador"].Value);
            }
        }

        // Método para permitir el marcado de un sólo checkbox por recorrido a la vez
        public void dgvRecorridosSoloUnRecorrido_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;
            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewCheckBoxColumn &&
                e.RowIndex >= 0)
            {
                // Desmarcamos todos los checkboxs de recorridos
                foreach (DataGridViewRow row in dgvRecorridos.Rows)
                {
                    row.Cells["btnDgvSeleccionarRecorrido"].Value = false;
                }

                // Marcamos el checkbox del recorrido seleccionado
                this.listadoRecorridos.getDgvRecorridos().CurrentRow.Cells["btnDgvSeleccionarRecorrido"].Value = true;
            }
        }

        // Mostramos los tramos que componen el recorrido seleccionado por el usuario
        private void mostrarTramosDelRecorridoSeleccionado_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;
            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewCheckBoxColumn &&
                e.RowIndex >= 0)
            {
                string consulta = "SELECT "
                    + "CONCAT(pto_inicio.puerto_nombre, '|', "
                    + "pto_fin.puerto_nombre) tramos "
                + "FROM LOS_BARONES_DE_LA_CERVEZA.Recorrido r "
                    + "JOIN LOS_BARONES_DE_LA_CERVEZA.Tramos_por_Recorrido tpr "
                        + "ON r.id_recorrido = tpr.id_recorrido "
                    + "JOIN LOS_BARONES_DE_LA_CERVEZA.Tramo t "
                        + "ON tpr.id_tramo = t.id_tramo "
                    + "JOIN LOS_BARONES_DE_LA_CERVEZA.Puerto pto_inicio "
                        + "ON t.tramo_puerto_inicio = pto_inicio.id_puerto "
                    + "JOIN LOS_BARONES_DE_LA_CERVEZA.Puerto pto_fin "
                        + "ON t.tramo_puerto_destino = pto_fin.id_puerto "
                + "WHERE r.recorrido_codigo = @identificador_recorrido "
                + "ORDER BY tpr.id_tramo_por_recorrido";
                List<Parametro> parametros = new List<Parametro>();
                Parametro paramIdentificadorRecorrido = new Parametro("@identificador_recorrido", SqlDbType.NVarChar, identificadorRecorrido, 255);
                parametros.Add(paramIdentificadorRecorrido);
                Query miConsulta = new Query(consulta, parametros);
                List<string> tramos = miConsulta.ejecutarReaderUnicaColumna();
                string[] tramo;
                limpiarTxtbxTramosRecorrido();
                for (int i = 0; i < tramos.Count; i++)
                {
                    tramo = tramos[i].Split('|');
                    txtbxTramosPorRecorrido.Text = txtbxTramosPorRecorrido.Text + tramo[DEF.TRAMO_PUERTO_INICIO] + " - " + tramo[DEF.TRAMO_PUERTO_FIN] + Environment.NewLine;
                }
            }
        }

        private void limpiarTxtbxTramosRecorrido()
        {
            txtbxTramosPorRecorrido.Text = "";
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void tipCruceros_Popup(object sender, PopupEventArgs e)
        {
            this.Text = "dasdsads";
        }
    }
}
