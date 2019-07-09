using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrbaCrucero.AbmCrucero.CancelarViajes
{
    public partial class CancelarViajesForm : Form
    {
        private string identificadorCrucero;

        public CancelarViajesForm(string identificadorCrucero)
        {
            InitializeComponent();
            this.identificadorCrucero = identificadorCrucero;
        }

        private void btnCancelarPasajes_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
