using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrbaCrucero.ListadoEstadistico
{
    public partial class ListadoCabinasLibresForm : Form
    {   
        private string rangoFechasQuery;

        public ListadoCabinasLibresForm()
        {
            InitializeComponent();
        }
        
        // Constructor que vamos a utilizar 
        public ListadoCabinasLibresForm(string rangoFechasQuery)
        {
            InitializeComponent();
            this.rangoFechasQuery = rangoFechasQuery;
        }

                private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ListadoCabinasLibresForm_Load(object sender, EventArgs e)
        {
            // Mostramos el resultado de la consulta por pantalla
            ListadoUtil.cargar(Consultas.recorridosConMasCabinasLibres(rangoFechasQuery), dgvListadoEstadistico);
        }

        private void btnCerrar_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
