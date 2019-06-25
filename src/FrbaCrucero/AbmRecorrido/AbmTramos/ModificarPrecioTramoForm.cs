using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrbaCrucero.AbmRecorrido.AbmTramos
{
    public partial class ModificarPrecioTramoForm : Form
    {
        int idTramo;

        public ModificarPrecioTramoForm()
        {
            InitializeComponent();
        }

        // Constructor que vamos a utilizar (recibe por parámetro la pk del tramo al cuál le vamos a modificar el precio)
        public ModificarPrecioTramoForm(int idTramo)
        {
            InitializeComponent();
            this.idTramo = idTramo;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnEnviar_Click(object sender, EventArgs e)
        {

        }
    }
}
