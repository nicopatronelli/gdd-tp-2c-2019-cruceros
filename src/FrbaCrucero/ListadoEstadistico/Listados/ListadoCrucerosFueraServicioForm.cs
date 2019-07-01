using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FrbaCrucero.Utils;

namespace FrbaCrucero.ListadoEstadistico
{
    public partial class ListadoCrucerosFueraServicioForm : Form
    {   
        //private string rangoFechasQuery;
        private string anio;
        private string semestre;

        public ListadoCrucerosFueraServicioForm()
        {
            InitializeComponent();
        }
        
        // Constructor que vamos a utilizar 
        public ListadoCrucerosFueraServicioForm(string anio,string semestre)
        {
            InitializeComponent();
            this.anio = anio;
            this.semestre = semestre;
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ListadoCrucerosFueraServicioForm_Load(object sender, EventArgs e)
        {
            // Mostramos el resultado de la consulta por pantalla
            ListadoUtil.cargar(Consultas.crucerosConMasDiasFueraServicio(anio, semestre), dgvListadoEstadistico);
        }

    }
}
