using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrbaCrucero.AbmCrucero
{
    public partial class AbmCruceros : Form
    {
        public AbmCruceros()
        {
            InitializeComponent();
        }

        private void btnAltaCrucero_Click(object sender, EventArgs e)
        {
            CruceroForm formAbmCrucero = new CruceroForm();
            formAbmCrucero.ShowDialog();
        }

        private void btnModificacionCrucero_Click(object sender, EventArgs e)
        {
            SeleccionCruceroEditarForm formSeleccionCrucero = new SeleccionCruceroEditarForm();
            formSeleccionCrucero.ShowDialog();
        }

        private void btnBajaServicioTecnico_Click(object sender, EventArgs e)
        {
            SeleccionCruceroBajaSTForm formSeleccionCrucero = new SeleccionCruceroBajaSTForm();
            formSeleccionCrucero.ShowDialog();
        }

        private void btnBajaDefinitiva_Click(object sender, EventArgs e)
        {
            SeleccionCruceroBajaDefinitiva formSeleccionCrucero = new SeleccionCruceroBajaDefinitiva();
            formSeleccionCrucero.ShowDialog();
        }

    }
}
