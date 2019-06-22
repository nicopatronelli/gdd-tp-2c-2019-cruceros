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

namespace FrbaCrucero.AbmRecorrido.BajaRecorrido
{
    public partial class SeleccionRecorridoBajaForm : SeleccionRecorridoEditarForm
    {
        public SeleccionRecorridoBajaForm()
        {
            InitializeComponent();
        }

        override protected void SeleccionRecorridoForm_Load(object sender, EventArgs e)
        {
            string miConsulta = base.querySeleccionRecorridos();
            base.cargarDgvRecorridos(miConsulta);
            base.agregarBotonEditar("Deshabilitar Recorrido", "Deshabilitar");
            base.dgvSeleccionRecorrido.CellClick += dgvSeleccionarRecorrido_CellContentClick;
            base.autoajustarDgv();
        }
    }
}
