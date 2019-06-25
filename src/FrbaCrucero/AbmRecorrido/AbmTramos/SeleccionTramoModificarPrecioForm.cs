using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FrbaCrucero.AbmRecorrido.AltaRecorrido;
using FrbaCrucero.AbmRecorrido.Dominio;

namespace FrbaCrucero.AbmRecorrido.AbmTramos
{
    public partial class SeleccionTramoModificarPrecioForm : Form
    {
        TramosDisponibles tramosDisponibles;

        // Constructor
        public SeleccionTramoModificarPrecioForm()
        {
            InitializeComponent();
            tramosDisponibles = new TramosDisponibles(dgvTramosDisponibles);
            this.tramosDisponibles.getDgvTramosDisponibles().CellClick += dgvTramosDisponibles_CellContentClick;
        }

        protected void dgvTramosDisponibles_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
                e.RowIndex >= 0)
            {
                try
                {
                    Tramo tramoSeleccionado = this.tramosDisponibles.getTramoSeleccionado(e.RowIndex);
                    ModificarPrecioTramoForm formModificarPrecio = new ModificarPrecioTramoForm(tramoSeleccionado.getId());
                    formModificarPrecio.ShowDialog();
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

        private void btnBuscarTramos_Click(object sender, EventArgs e)
        {
            // Recuperamos los puertos ingresados (puede que no se haya ingresado uno o ambos -> se traen todos los tramos disponibles)
            string puertoInicio = txtbxPuertoInicio.Text;
            string puertoFin = txtbxPuertoFin.Text;

            // Cargamos el dgv de tramos con los tramos que cumplan el criterio de búsqueda
            this.tramosDisponibles.popularTramosConBusqueda(puertoInicio, puertoFin);
        }

    }
}
