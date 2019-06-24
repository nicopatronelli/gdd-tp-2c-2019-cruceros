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
using FrbaCrucero.AbmRecorrido.AltaRecorrido;

namespace FrbaCrucero.AbmRecorrido
{
    public partial class AltaRecorridoForm : Form
    {
        private Recorrido recorrido;
        private TramosDisponibles tramosDisponibles;

        // Constructor
        public AltaRecorridoForm()
        {
            InitializeComponent();
            recorrido = new Recorrido(); // Inicializamos el objeto recorrido
            recorrido.setPrecio(new PrecioRecorrido(lblPrecioRecorrido));
            tramosDisponibles = new TramosDisponibles(dgvTramosDisponibles);
            this.tramosDisponibles.popularTramos();
            this.tramosDisponibles.getDgvTramosDisponibles().CellClick += dgvTramosDisponibles_CellContentClick;
        }

        private void btnEnviar_Click(object sender, EventArgs e)
        {   
            // Seteamos el identificador al recorrido y validamos que no sea nulo o cadena vacía
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
                MensajeBox.error("El identificador ingresado para el recorrido ya se encuentra registrado. Por favor, pruebe con uno diferente.");
                return; 
            }

            // Validamos que se haya seleccionado al menos un tramo para el nuevo recorrido
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

        protected void dgvTramosDisponibles_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
                e.RowIndex >= 0)
            {
                try
                {
                    int idTramoSeleccionado = Convert.ToInt32(dgvTramosDisponibles.Rows[e.RowIndex].Cells["tramo"].Value);
                    string puertoInicioTramoSeleccionado = Convert.ToString(dgvTramosDisponibles.Rows[e.RowIndex].Cells["puerto_inicio"].Value);
                    string puertoFinTramoSeleccionado = Convert.ToString(dgvTramosDisponibles.Rows[e.RowIndex].Cells["puerto_fin"].Value);
                    double precioTramoSeleccionado = Convert.ToDouble(dgvTramosDisponibles.Rows[e.RowIndex].Cells["precio"].Value);
                    Tramo tramo = new Tramo(idTramoSeleccionado, puertoInicioTramoSeleccionado, puertoFinTramoSeleccionado, precioTramoSeleccionado);
                    this.recorrido.addTramo(tramo);
                    this.popularDgvTramosSeleccionados(idTramoSeleccionado, puertoInicioTramoSeleccionado, puertoFinTramoSeleccionado, precioTramoSeleccionado);
                    this.recorrido.getPrecio().aumentarLblPrecioRecorrido(precioTramoSeleccionado);
                    this.tramosDisponibles.popularTramosPosibles(puertoFinTramoSeleccionado);
                }
                catch
                {
                    return;
                }
            }
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
                string puertoFinUltimoTramo = dgvTramosRecorrido.Rows[dgvTramosRecorrido.Rows.Count - 1].Cells[2].Value.ToString();
                double precioUltimoTramo = Convert.ToDouble(dgvTramosRecorrido.Rows[dgvTramosRecorrido.Rows.Count - 1].Cells[3].Value);
                this.recorrido.getPrecio().disminuirLblPrecioRecorrido(precioUltimoTramo);
                this.tramosDisponibles.popularTramosPosibles(puertoFinUltimoTramo);
            }
            else
            {
                this.tramosDisponibles.popularTramos();
                this.recorrido.getPrecio().resetearLblPrecioRecorridoACero();
            }
        }

        private void btnEliminarTodo_Click(object sender, EventArgs e)
        {
            recorrido.reiniciarTramos();
            lblPrecioRecorrido.Text = Convert.ToString(0);
            this.dgvTramosRecorrido.Rows.Clear();
            this.tramosDisponibles.popularTramos();
        }
    }
}
