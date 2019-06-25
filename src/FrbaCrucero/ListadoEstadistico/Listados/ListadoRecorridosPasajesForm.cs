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
    public partial class ListadoRecorridosPasajesForm : Form
    {
        private string rangoFechasQuery;

        public ListadoRecorridosPasajesForm()
        {
            InitializeComponent();
        }

        // Constructor que vamos a utilizar 
        public ListadoRecorridosPasajesForm(string rangoFechasQuery)
        {
            InitializeComponent();
            this.rangoFechasQuery = rangoFechasQuery;
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        virtual protected void ListadoRecorridosPasajesForm_Load(object sender, EventArgs e)
        {
            // Mostramos el resultado de la consulta por pantalla
            ListadoUtil.cargar(Consultas.recorridosConMasPasajesComprados(rangoFechasQuery), dgvListadoEstadistico);
        }
    }
}
