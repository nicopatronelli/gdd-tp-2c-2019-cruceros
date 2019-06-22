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

namespace FrbaCrucero.GeneracionViaje
{
    public partial class GenerarViajeForm : Form
    {
        string identificadorRecorrido; // Identificador del recorrido seleccionado para el viaje

        public GenerarViajeForm()
        {
            InitializeComponent();
        }

        private void GenerarViajeForm_Load(object sender, EventArgs e)
        {
            dgvRecorridos.CellClick += dgvRecorridosSoloUnRecorrido_CellContentClick;
            dgvRecorridos.CellClick += capturarIdentificadorRecorridoSeleccionado_CellContentClick;
        }

        private void dtpFechaInicio_ValueChanged(object sender, EventArgs e)
        {
            cargarCbmxCruceroDisponibles();
        }

        private void btnEnviar_Click(object sender, EventArgs e)
        {   
            DateTime fechaInicioViaje = dtpFechaInicio.Value;
            DateTime fechaFinViaje = dtpFechaFin.Value;
            string identificadorCrucero = cmbxCrucero.SelectedValue.ToString();

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

        } // FIN btnEnviar_Click()

        private void cargarCbmxCruceroDisponibles()
        {
            try
            {
                DateTime fechaInicioNuevoViaje = dtpFechaInicio.Value;
                Parametro paramfechaInicioNuevoViaje = new Parametro("@fecha_inicio_nuevo_viaje", SqlDbType.NVarChar,
                    fechaInicioNuevoViaje.ToString("yyyy-MM-dd h:mm tt"), 255);
                ConexionBD conexion = new ConexionBD();
                conexion.abrir();
                SqlDataAdapter dataAdapter = new SqlDataAdapter("SELECT identificador FROM LOS_BARONES_DE_LA_CERVEZA.UF_cruceros_disponibles(@fecha_inicio_nuevo_viaje)", conexion.obtenerConexion());
                dataAdapter.SelectCommand.Parameters.Add(paramfechaInicioNuevoViaje.obtenerSqlParameter());
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
            // Limpiamos el el datagridview dgvPublicaciones
            limpiarDgv(dgvRecorridos);

            // Recuperamos los puertos ingresados 
            string puertoInicio = txtbxPuertoInicio.Text;
            string puertoFin = txtbxPuertoFin.Text;

            string queryRecorridos = crearQueryRecorridos();

            popularDgvRecorridos(puertoInicio, puertoFin, queryRecorridos);
            agregarCheckBoxDgv(dgvRecorridos, "btnDgvSeleccionarRecorrido", "Seleccionar Recorrido");
        } // FIN btnBuscarRecorridos_Click

        // Agregamos un checkbox al final de cada registro recorrido para poder seleccionarlos
        private void agregarCheckBoxDgv(DataGridView dgv, string nombreBoton, string headerBoton)
        {
            DataGridViewCheckBoxColumn chbxSeleccionarRecorrido = new DataGridViewCheckBoxColumn();
            chbxSeleccionarRecorrido.Name = nombreBoton;
            chbxSeleccionarRecorrido.HeaderText = headerBoton;
            dgv.Columns.Add(chbxSeleccionarRecorrido);
        }

        private void limpiarDgv(DataGridView dgv)
        {
            dgv.Columns.Clear();
            dgv.Refresh();
        }

        private void popularDgvRecorridos(string puertoInicio, string puertoFin, string queryRecorridos)
        {
            ConexionBD conexion = new ConexionBD();
            SqlDataAdapter dataAdapter = new SqlDataAdapter(queryRecorridos, conexion.obtenerConexion());

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
            dgvRecorridos.ReadOnly = false;
            dgvRecorridos.AllowUserToAddRows = false; // Para evitar que se añadan filas dinámicamente
            dgvRecorridos.DataSource = dataSet.Tables[0];
            conexion.cerrar();
        } // FIN popularDgvRecorridos()

        // Armamos la query en forma dinámica según el puerto de inicio y fin ingresados 
        private string crearQueryRecorridos()
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
        } // FIN crearQueryRecorridos()

        // Método para permitir el marcado de un sólo checkbox por recorrido a la vez
        private void dgvRecorridosSoloUnRecorrido_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Desmarcamos todos los checkboxs de recorridos
            foreach (DataGridViewRow row in dgvRecorridos.Rows)
            {
                row.Cells["btnDgvSeleccionarRecorrido"].Value = false;
            }

            // Marcamos el checkbox del recorrido seleccionado
            dgvRecorridos.CurrentRow.Cells["btnDgvSeleccionarRecorrido"].Value = true;
        }

        // Guardamos el identificador del recorrido seleccionado al pulsar Enviar
        private void capturarIdentificadorRecorridoSeleccionado_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            identificadorRecorrido = Convert.ToString(dgvRecorridos.Rows[e.RowIndex].Cells["Identificador"].Value);
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
