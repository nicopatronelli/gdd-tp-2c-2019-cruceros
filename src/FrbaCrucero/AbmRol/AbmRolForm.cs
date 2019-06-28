using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrbaCrucero.AbmRol
{
    public partial class AbmRolForm : Form
    {
        // Constructor predeterminado
        public AbmRolForm()
        {
            InitializeComponent();
        }

        private void AbmRolForm_Load(object sender, EventArgs e)
        {

        }

        private void btnCrearRol_Click(object sender, EventArgs e)
        {
            CrearRolForm formCrearRol = new CrearRolForm();
            formCrearRol.ShowDialog();
        }

        private void btnModificarRol_Click(object sender, EventArgs e)
        {
            SeleccionRolForm formSeleccionRol = new SeleccionRolForm();
            formSeleccionRol.ShowDialog();
        }

        private void btnDeshabilitarRol_Click(object sender, EventArgs e)
        {
            SeleccionRolForm deshabilitarRolForm = new SeleccionRolForm("ELIMINAR");
            deshabilitarRolForm.ShowDialog();
        }

    }
}
