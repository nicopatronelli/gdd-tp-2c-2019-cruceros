using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FrbaCrucero.AbmRecorrido.EditarRecorrido;
using FrbaCrucero.GenerarViaje;
using FrbaCrucero.Utils;


namespace FrbaCrucero.AbmRecorrido.HabilitacionDeshabilitacionRecorrido
{
    public partial class SeleccionRecorridoDeshabilitarForm : Form
    {
        private ListadoRecorridos listadoRecorridos;
        private string puertoInicio;
        private string puertoFin;

        public SeleccionRecorridoDeshabilitarForm()
        {
            InitializeComponent();
        }

        private void SeleccionRecorridoForm_Load_1(object sender, EventArgs e)
        {
            this.listadoRecorridos = new ListadoRecorridos(dgvRecorridos);
            this.listadoRecorridos.getDgvRecorridos().CellClick += dgvSeleccionarRecorrido_CellContentClick;
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnBuscarRecorridos_Click(object sender, EventArgs e)
        {
            // Recuperamos los puertos ingresados 
            puertoInicio = txtbxPuertoInicio.Text;
            puertoFin = txtbxPuertoFin.Text;

            recargarDgvRecorridos(puertoInicio, puertoFin);
        }

        private void recargarDgvRecorridos(string puertoInicio, string puertoFin)
        {
            // Limpiamos el listado (datagridview) de recorridos
            this.listadoRecorridos.limpiarDgv();
            this.listadoRecorridos.popularRecorridos(puertoInicio, puertoFin, this.listadoRecorridos.queryRecorridosEstado(DEF.RECORRIDOS_HABILITADOS));
            this.listadoRecorridos.agregarBotonEditar("Deshabilitar Recorrido", "Deshabilitar");
        }

        // Abrimos el formulario para que el usuario confirme la deshabilitación del recorrido
        protected void dgvSeleccionarRecorrido_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
                e.RowIndex >= 0)
            {
                string identificadorRecorrido = Convert.ToString(this.listadoRecorridos.getDgvRecorridos().Rows[e.RowIndex].Cells["Identificador"].Value);
                ConfirmarDeshabilitacionRecorridoForm formConfirmarDeshabilitacionRecorrido = new ConfirmarDeshabilitacionRecorridoForm(identificadorRecorrido);
                formConfirmarDeshabilitacionRecorrido.ShowDialog();

                // Recargamos el dgv con los recorridos habilitados, excluyendo el que acabamos de deshabilitar
                this.recargarDgvRecorridos(puertoInicio, puertoFin);
            }
        }

    }
}
