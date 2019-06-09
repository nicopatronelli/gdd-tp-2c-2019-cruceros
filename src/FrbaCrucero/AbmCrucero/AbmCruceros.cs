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
            CrucerosForm formAbmCrucero = new CrucerosForm();
            formAbmCrucero.ShowDialog();
        }

        private void btnModificacionCrucero_Click(object sender, EventArgs e)
        {
            SeleccionCruceroForm formSeleccionCrucero = new SeleccionCruceroForm();
            formSeleccionCrucero.ShowDialog();
        }
    }
}
