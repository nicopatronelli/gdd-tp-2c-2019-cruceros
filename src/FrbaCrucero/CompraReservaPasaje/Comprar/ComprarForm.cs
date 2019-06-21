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
    public partial class ComprarForm : Form
    {
        public string tipoCabina;
        public int cantidadCabinas;
        public int viaje_id;

        public ComprarForm(string tipoCabina,int cantidadCabinas,int viaje_id)
        {
            this.tipoCabina = tipoCabina;
            this.cantidadCabinas = cantidadCabinas;
            this.viaje_id = viaje_id;
            InitializeComponent();
            this.informacionCompraLabel.Text= "Usted va a comprar "+cantidadCabinas.ToString()+" de categoria "+tipoCabina+"que pasará por los puertos:";
        }

        private void dniTextBox_TextChanged(object sender, EventArgs e)
        {
            if (dniTextBox.Text.Length > 6)
            {
                var consulta = "  select nombre, apellido, direccion, cast(telefono as nvarchar(255)) as telefono, mail, cast(fecha_nacimiento as nvarchar(255)) as fecha_nacimiento from [GD1C2019].[LOS_BARONES_DE_LA_CERVEZA].[Clientes] "
                               +"     where dni = 9329200";
                Query miConsulta = new Query(consulta, new List<Parametro>());
                SqlDataReader datosPersonales = miConsulta.ejecutarReaderFila();

                this.nombreYApellidoTextBox.Text = Convert.ToString(datosPersonales["nombre"]);

            }
        }
    }
}

/*    Query miConsulta = new Query(consulta, parametros);
            SqlDataReader camposCrucero = miConsulta.ejecutarReaderFila();
            string[] identificadorPartes = identificadorCrucero.Split('-');
            txtbxIdentificadorA.Text = identificadorPartes[0];
            txtbxIdentificadorB.Text = identificadorPartes[1];
            txtbxModelo.Text = Convert.ToString(camposCrucero["modelo"]);
            cmbxMarca.SelectedItem = Convert.ToString(camposCrucero["marca"]);
            miConsulta.cerrarConexionReader();
 * */
