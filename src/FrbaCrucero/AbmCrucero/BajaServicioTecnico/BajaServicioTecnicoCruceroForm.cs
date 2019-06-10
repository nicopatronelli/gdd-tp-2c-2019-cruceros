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
    public partial class BajaServicioTecnicoCruceroForm : Form
    {
        private string identificadorCruceroST;

        public BajaServicioTecnicoCruceroForm()
        {
            InitializeComponent();
        }

        // Constructor que vamos a utilizar
        public BajaServicioTecnicoCruceroForm(string identificadorCrucero)
        {
            InitializeComponent();
            identificadorCruceroST = identificadorCrucero;
        }


    }
}
