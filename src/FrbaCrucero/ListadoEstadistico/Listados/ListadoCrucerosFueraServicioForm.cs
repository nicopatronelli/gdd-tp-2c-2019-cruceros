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
    public partial class ListadoCrucerosFueraServicioForm : Form
    {   
        private string rangoFechasQuery;

        public ListadoCrucerosFueraServicioForm()
        {
            InitializeComponent();
        }
        
        // Constructor que vamos a utilizar 
        public ListadoCrucerosFueraServicioForm(string rangoFechasQuery)
        {
            InitializeComponent();
            this.rangoFechasQuery = rangoFechasQuery;
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ListadoCrucerosFueraServicioForm_Load(object sender, EventArgs e)
        {
            // Mostramos el resultado de la consulta por pantalla
            ListadoUtil.cargar(Consultas.crucerosConMasDiasFueraServicio(rangoFechasQuery), dgvListadoEstadistico);
        }

    }
}
