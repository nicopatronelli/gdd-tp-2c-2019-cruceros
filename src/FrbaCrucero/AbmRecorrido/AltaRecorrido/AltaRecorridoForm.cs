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
using FrbaCrucero.AbmRecorrido.Dominio;
using FrbaCrucero.Utils.Excepciones;

namespace FrbaCrucero.AbmRecorrido
{
    public partial class AltaRecorridoForm : Form
    {
       // private List<Tramo> tramos = new List<Tramo>();
        private Recorrido recorrido; 

        public AltaRecorridoForm()
        {
            InitializeComponent();
            popularTramosIniciales();
            dgvElegirTramos.CellClick += dgvElegirTramos_CellContentClick;
            recorrido = new Recorrido(); // Inicializamos el objeto recorrido
        }

        private void btnEliminarTodo_Click(object sender, EventArgs e)
        {
            recorrido.reiniciarTramos();
            lblPrecioRecorrido.Text = Convert.ToString(0);
            this.dgvTramosRecorrido.Rows.Clear();
            this.popularTramosIniciales();
        }

        private void btnEnviar_Click(object sender, EventArgs e)
        {   
            // Seteamos el identificador al recorrido y validamos que no sea nulo 
            try
            {
                recorrido.setIdentificador(txtbxCodRecorrido.Text);
            }
            catch (IdentificadorCruceroNullException ex)
            {
                ex.mensajeError();
                return;
            }

            // Validamos que el código de recorrido éste disponible 
            if (Recorrido.identificadorDisponible(recorrido.getIdentificador()).Equals(false))
            {
                MensajeBox.error("El identificador ingresado para el recorrido ya se encuentra registrado.");
                return; 
            }

            // Validamos que se haya seleccionado al menos un tramo para el recorrido nuevo
            if (recorrido.getTramos().Count == 0)
            {
                MensajeBox.error("Debe seleccionar al menos un tramo.");
                return; 
            }

            // En este punto ya tenemos un recorrido correctamente construido y listo para ser INSERTADO 
            try
            {
                recorrido.insertar();
                MensajeBox.info("El recorrido se dió de alta correctamente.");
            }
            catch (InsertarRecorridoException ex)
            {
                ex.mensajeError();
                return;
            }
        } // FIN btnEnviar_Click

        protected void dgvElegirTramos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
                e.RowIndex >= 0)
            {
                try
                {
                    int idTramoSeleccionado = Convert.ToInt32(dgvElegirTramos.Rows[e.RowIndex].Cells["tramo"].Value);
                    string puertoInicioTramoSeleccionado = Convert.ToString(dgvElegirTramos.Rows[e.RowIndex].Cells["puerto_inicio"].Value);
                    string puertoFinTramoSeleccionado = Convert.ToString(dgvElegirTramos.Rows[e.RowIndex].Cells["puerto_fin"].Value);
                    double precioTramoSeleccionado = Convert.ToDouble(dgvElegirTramos.Rows[e.RowIndex].Cells["precio"].Value);
                    Tramo tramo = new Tramo(idTramoSeleccionado, puertoInicioTramoSeleccionado, puertoFinTramoSeleccionado, precioTramoSeleccionado);
                    this.recorrido.addTramo(tramo);
                    this.popularDgvTramosSeleccionados(idTramoSeleccionado, puertoInicioTramoSeleccionado, puertoFinTramoSeleccionado, precioTramoSeleccionado);
                    this.aumentarLblPrecioRecorrido(precioTramoSeleccionado);
                    this.popularTramosPosibles(puertoFinTramoSeleccionado);
                }
                catch
                {
                    return;
                }
            }
        }

        // Cargamos el dgvTramos con TODOS los tramos disponibles en la tabla Tramo
        private void popularTramosIniciales()
        {
            ConexionBD conexion = new ConexionBD();
            conexion.abrir();

            string miConsulta = "SELECT t.id_tramo tramo, puerto_inicio.puerto_nombre puerto_inicio, puerto_fin.puerto_nombre puerto_fin, t.tramo_precio precio  "
                              + "FROM LOS_BARONES_DE_LA_CERVEZA.Tramo t "
                                + "JOIN LOS_BARONES_DE_LA_CERVEZA.Puerto puerto_inicio "
                                    + "ON t.tramo_puerto_inicio = puerto_inicio.id_puerto "
                                + "JOIN LOS_BARONES_DE_LA_CERVEZA.Puerto puerto_fin "
                                    + "ON t.tramo_puerto_destino = puerto_fin.id_puerto";

            SqlDataAdapter dataAdapter = new SqlDataAdapter(miConsulta, conexion.obtenerConexion());
            DataTable dt = new DataTable();
            dataAdapter.Fill(dt);
            dgvElegirTramos.DataSource = dt;
            conexion.cerrar();
        }

        // Cargamos el dgvTramos sólo con los posibles tramos que según el tramo seleccionado
        private void popularTramosPosibles(string puertoInicio)
        {
            ConexionBD conexion = new ConexionBD();
            conexion.abrir();

            string miConsulta = "SELECT t.id_tramo tramo, puerto_inicio.puerto_nombre puerto_inicio, puerto_fin.puerto_nombre puerto_fin, t.tramo_precio precio "
                              + "FROM LOS_BARONES_DE_LA_CERVEZA.Tramo t "
                                + "JOIN LOS_BARONES_DE_LA_CERVEZA.Puerto puerto_inicio "
                                    + "ON t.tramo_puerto_inicio = puerto_inicio.id_puerto "
                                + "JOIN LOS_BARONES_DE_LA_CERVEZA.Puerto puerto_fin "
                                    + "ON t.tramo_puerto_destino = puerto_fin.id_puerto "
                              + "WHERE puerto_inicio.puerto_nombre = @puerto_inicio";

            SqlDataAdapter dataAdapter = new SqlDataAdapter(miConsulta, conexion.obtenerConexion());
            Parametro paramPuertoInicio = new Parametro("@puerto_inicio", SqlDbType.NVarChar, puertoInicio, 255);
            dataAdapter.SelectCommand.Parameters.Add(paramPuertoInicio.obtenerSqlParameter());
            SqlCommandBuilder commandBuilder = new SqlCommandBuilder(dataAdapter);
            DataTable dt = new DataTable();
            dataAdapter.Fill(dt);
            dgvElegirTramos.DataSource = dt;
            conexion.cerrar();
        }

        // Actualizamos el label donde se muestra el precio acumulado del recorrido
        private void aumentarLblPrecioRecorrido(double precioTramo)
        {
            lblPrecioRecorrido.Text = Convert.ToString(Convert.ToDouble(lblPrecioRecorrido.Text) + precioTramo);
        }

        private void disminuirLblPrecioRecorrido(double precioTramo)
        {
            lblPrecioRecorrido.Text = Convert.ToString(Convert.ToDouble(lblPrecioRecorrido.Text) - precioTramo);
        }

        // Actualizamos el textbox lateral donde vamos mostrando los tramos seleccionados
        private void popularDgvTramosSeleccionados(int idTramo, string puertoInicioTramo, string puertoFinTramo, double precioTramo)
        {
            dgvTramosRecorrido.Rows.Add(idTramo, puertoInicioTramo, puertoFinTramo, precioTramo);
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnEliminarUltimoTramo_Click(object sender, EventArgs e)
        {
            // Eliminamos el último tramo agregado (la última fila del dgvTramosRrecorrido)
            int cantidadTramosAgregados = dgvTramosRecorrido.Rows.Count;
            if (cantidadTramosAgregados.Equals(0)) { return; }
            dgvTramosRecorrido.Rows.RemoveAt(cantidadTramosAgregados - 1);
            this.recorrido.eliminarUltimoTramo(); // Eliminamos el último tramo agregado de la lista de tramos

            // Guardamos los datos del AHORA último tramo agregado
            if (cantidadTramosAgregados - 1 > 0)
            {
                int idUltimoTramo = Convert.ToInt32(dgvTramosRecorrido.Rows[dgvTramosRecorrido.Rows.Count - 1].Cells[0].Value);
                string puertoInicioUltimoTramo = dgvTramosRecorrido.Rows[dgvTramosRecorrido.Rows.Count - 1].Cells[1].Value.ToString();
                string puertoFinUltimoTramo = dgvTramosRecorrido.Rows[dgvTramosRecorrido.Rows.Count - 1].Cells[2].Value.ToString();
                double precioUltimoTramo = Convert.ToDouble(dgvTramosRecorrido.Rows[dgvTramosRecorrido.Rows.Count - 1].Cells[3].Value);
                this.disminuirLblPrecioRecorrido(precioUltimoTramo);
                this.popularTramosPosibles(puertoFinUltimoTramo);
            }
            else
            {
                this.popularTramosIniciales();
                this.lblPrecioRecorrido.Text = "0";
            }
        }
    }
}
