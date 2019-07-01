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
    public partial class SeleccionListadoEstadisticoForm : Form
    {
        public SeleccionListadoEstadisticoForm()
        {
            InitializeComponent();

            // Modificamos el dtpAnio para que sólo permite elegir un año (por defecto inicia en 2018)
            dtpAnio.Format = DateTimePickerFormat.Custom;
            dtpAnio.CustomFormat = "yyyy";
            dtpAnio.ShowUpDown = true;

            // Establecemos por defecto el primer semestre
            rbtnPrimerSemestre.Checked = true;
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnComprados_Click(object sender, EventArgs e)
        {
            // 1. Obtenemos el año ingresado
            string anio = ListadoUtil.getAnio(dtpAnio);

            // 2. Armamos la parte de fechas de la consulta a partir del año y el semestre ingresados
            string rangoFechasQuery = ListadoUtil.getRangoFechas(rbtnPrimerSemestre, rbtnSegundoSemestre, anio);
            
            // 3. Hacemos la consulta y cargamos el dgv con los resultados
            ListadoRecorridosPasajesForm formListadoPasajesRecorridos = new ListadoRecorridosPasajesForm(rangoFechasQuery);
            formListadoPasajesRecorridos.ShowDialog();
        }

        private void btnCabinasLibres_Click(object sender, EventArgs e)
        {
            // 1. Obtenemos el año ingresado
            string anio = ListadoUtil.getAnio(dtpAnio);

            // 2. Armamos la parte de fechas de la consulta a partir del año y el semestre ingresados
            string rangoFechasQuery = ListadoUtil.getRangoFechas(rbtnPrimerSemestre, rbtnSegundoSemestre, anio);

            // 3. Hacemos la consulta y cargamos el dgv con los resultados
            ListadoCabinasLibresForm formListadoCabinasLibres = new ListadoCabinasLibresForm(rangoFechasQuery);
            formListadoCabinasLibres.ShowDialog();
        }

        private void btnFueraServicio_Click(object sender, EventArgs e)
        {
            // 1. Obtenemos el año ingresado
            string anio = ListadoUtil.getAnio(dtpAnio);

            // 2. Obtenemos el semestre ingresado
            string semestre;

            if (rbtnPrimerSemestre.Checked)
            {
               semestre = "1" ;
            }
            else
            {
               semestre = "2";
            }

            // 3. Hacemos la consulta y cargamos el dgv con los resultados
            ListadoCrucerosFueraServicioForm formListadoCrucerosFueraServicio = new ListadoCrucerosFueraServicioForm(anio, semestre);
            formListadoCrucerosFueraServicio.ShowDialog();
        }


    }
}
