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
        private TramosSeleccionados tramosSeleccionados;

        // Constructor
        public AltaRecorridoForm()
        {
            InitializeComponent();
            recorrido = new Recorrido(); // Inicializamos el objeto recorrido
            recorrido.setPrecio(new PrecioRecorrido(lblPrecioRecorrido));
            tramosDisponibles = new TramosDisponibles(dgvTramosDisponibles);
            tramosSeleccionados = new TramosSeleccionados(dgvTramosSeleccionados);
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
                    Tramo tramoSeleccionado = this.tramosDisponibles.getTramoSeleccionado(e.RowIndex);
                    this.recorrido.addTramo(tramoSeleccionado);
                    this.tramosSeleccionados.popular(tramoSeleccionado.getId(), tramoSeleccionado.getPuertoInicio(), tramoSeleccionado.getPuertoFin(), tramoSeleccionado.getPrecio());
                    this.recorrido.getPrecio().aumentarLblPrecioRecorrido(tramoSeleccionado.getPrecio());
                    this.tramosDisponibles.popularTramosPosibles(tramoSeleccionado.getPuertoFin());
                }
                catch
                {
                    return;
                }
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnEliminarUltimoTramo_Click(object sender, EventArgs e)
        {
            // Eliminamos el último tramo agregado (la última fila del dgvTramosSeleccionados)
            if (this.tramosSeleccionados.cantidad().Equals(0)) { return; }
            this.tramosSeleccionados.eliminarUltimoTramo();
            this.recorrido.eliminarUltimoTramo(); // También debemos eliminar el último tramo agregado de la lista de tramos del recorrido

            if (this.tramosSeleccionados.cantidad() > 0)
            {
                Tramo ultimoTramo = this.tramosSeleccionados.getUltimoTramo();
                this.recorrido.getPrecio().disminuirLblPrecioRecorrido(ultimoTramo.getPrecio());
                this.tramosDisponibles.popularTramosPosibles(ultimoTramo.getPuertoFin());
            }
            else
            {
                this.tramosDisponibles.popularTramos();
                this.recorrido.getPrecio().resetearLblPrecioRecorridoACero();
            }
        }

        private void btnEliminarTodo_Click(object sender, EventArgs e)
        {
            this.recorrido.reiniciarTramos();
            this.recorrido.getPrecio().resetearLblPrecioRecorridoACero();
            this.tramosSeleccionados.limpiar();
            this.tramosDisponibles.popularTramos();
        }
    }
}
