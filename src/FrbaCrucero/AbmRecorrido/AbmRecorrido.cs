using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrbaCrucero.AbmRecorrido
{
    public partial class AbmRecorrido : Form
    {
        public AbmRecorrido()
        {
            InitializeComponent();
        }

        private void btnNuevoRecorrido_Click(object sender, EventArgs e)
        {
            AltaRecorridoForm formAltaRecorrido = new AltaRecorridoForm();
            formAltaRecorrido.ShowDialog();
        }

        private void btnBajaRecorrido_Click(object sender, EventArgs e)
        {

        }
    }
}
