using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FrbaCrucero.AbmRecorrido.HabilitacionDeshabilitacionRecorrido;
using FrbaCrucero.Utils;

namespace FrbaCrucero.AbmRecorrido.EditarRecorrido
{
    public partial class SeleccionRecorridoEditarForm : SeleccionRecorridoDeshabilitarForm
    {
        public SeleccionRecorridoEditarForm()
        {
            InitializeComponent();
        }

        private void SeleccionRecorridoEditarForm_Load(object sender, EventArgs e)
        {
            this.Text = "Editar Recorrido";
            this.lblAvisoEditarRecorridos.Text = "AVISO: Sólo se listarán recorridos habilitados; no se permite editar un recorrido deshabilitado";
        }

        override protected void recargarDgvRecorridos(string puertoInicio, string puertoFin)
        {
            // Limpiamos el listado (datagridview) de recorridos
            this.listadoRecorridos.limpiarDgv();
            this.listadoRecorridos.popularRecorridos(puertoInicio, puertoFin, this.listadoRecorridos.queryRecorridosEstado(DEF.RECORRIDOS_HABILITADOS));
            this.listadoRecorridos.agregarBotonEditar("Editar Recorrido", "Editar");
        }

        override protected void dgvSeleccionarRecorrido_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
                e.RowIndex >= 0)
            {
                string identificadorRecorrido = Convert.ToString(this.listadoRecorridos.getDgvRecorridos().Rows[e.RowIndex].Cells["Identificador"].Value);

                // Abrimos el formulario de edición de recorridos
                EditarRecorridoForm formEditarRecorrido = new EditarRecorridoForm(identificadorRecorrido);
                formEditarRecorrido.ShowDialog();

                // Recargamos el dgv con los recorridos deshabilitados, excluyendo el que acabamos de habilitar
                //this.recargarDgvRecorridos(puertoInicio, puertoFin);
            }
        }
    }
}
