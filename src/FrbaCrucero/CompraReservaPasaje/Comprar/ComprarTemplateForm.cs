using FrbaCrucero.Utils;
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

namespace FrbaCrucero.CompraReservaPasaje.Comprar
{
    public partial class ComprarTemplateForm : Form
    {
        public string tipoCabina;
        public int cantidadCabinas;
        public int viaje_id;
        public Viaje viaje;

        public ComprarTemplateForm(string tipoCabina,int cantidadCabinas,int viaje_id)
        {
            this.tipoCabina = tipoCabina;
            this.cantidadCabinas = cantidadCabinas;
            this.viaje_id = viaje_id;
            InitializeComponent();
            this.informacionCompraLabel.Text= "Usted va a comprar "+cantidadCabinas.ToString()+" cabinas \nde categoria "+tipoCabina+" del viaje \nque pasará por los puertos:";
            this.viaje = new Viaje(viaje_id);
            this.cargarDestinos();
        }
        private void vaciarDatosPersonales()
        {
            this.nombreTextBox.Text = "";
            this.apellidoTextBox.Text = "";
            this.direccionTextBox.Text = "";
            this.telefonoTextBox.Text = "";
            this.mailTextBox.Text = "";
            this.dayTextBox.Text = "";
            this.mesTextBox.Text = "";
            this.anioTextBox.Text = "";
        }

        private void dniTextBox_TextChanged(object sender, EventArgs e)
        {
            this.vaciarDatosPersonales();
            if (dniTextBox.Text.Length > 6)
            {

                var consulta = "  select nombre, apellido, direccion, cast(telefono as nvarchar(255)) as telefono, mail, cast(fecha_nacimiento as nvarchar(255)) as fecha_nacimiento from [GD1C2019].[LOS_BARONES_DE_LA_CERVEZA].[Clientes] "
                               + "     where dni =" + dniTextBox.Text;
                Query miConsulta = new Query(consulta, new List<Parametro>());
                SqlDataReader datosPersonales = miConsulta.ejecutarReaderFila();
                try
                {
                    this.nombreTextBox.Text = Convert.ToString(datosPersonales["nombre"]);
                    this.apellidoTextBox.Text = Convert.ToString(datosPersonales["apellido"]);
                    this.direccionTextBox.Text = Convert.ToString(datosPersonales["direccion"]);
                    this.telefonoTextBox.Text = Convert.ToString(datosPersonales["telefono"]);
                    this.mailTextBox.Text = Convert.ToString(datosPersonales["mail"]);
                    DateTime fechaNacimiento = DateTime.Parse(Convert.ToString(datosPersonales["fecha_nacimiento"]));
                    this.dayTextBox.Text = fechaNacimiento.Day.ToString();
                    this.mesTextBox.Text = fechaNacimiento.Month.ToString();
                    this.anioTextBox.Text = fechaNacimiento.Year.ToString();
                }
                catch(Exception errorMesssage){}
            }
        }

        private void cargarDestinos()
        {
            string consulta = "SELECT puerto_nombre from[GD1C2019].[LOS_BARONES_DE_LA_CERVEZA].[UF_destinos_segun_recorrido](" + this.viaje.id_recorrido +  ")";

            Query miConsulta = new Query(consulta, new List<Parametro>());
            var destinos = miConsulta.ejecutarReaderUnicaColumna();
            foreach (var o in destinos)
            {
                this.puertosLabel.Text += (o+"\n");
            }
        }


    }
}
