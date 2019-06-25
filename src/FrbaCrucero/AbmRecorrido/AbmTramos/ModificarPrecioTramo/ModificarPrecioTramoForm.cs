using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FrbaCrucero.AbmRecorrido.Dominio;
using FrbaCrucero.Utils;

namespace FrbaCrucero.AbmRecorrido.AbmTramos
{
    public partial class ModificarPrecioTramoForm : Form
    {
        Tramo tramo;

        public ModificarPrecioTramoForm()
        {
            InitializeComponent();
        }

        // Constructor que vamos a utilizar (recibe por parámetro la pk del tramo al cuál le vamos a modificar el precio)
        public ModificarPrecioTramoForm(Tramo tramo)
        {
            InitializeComponent();
            this.tramo = tramo;
        }

        private void btnEnviar_Click(object sender, EventArgs e)
        {
            // 1. Validamos que el precio sea correcto
            if (String.IsNullOrEmpty(txtbxNuevoPrecioA.Text))
            {
                MensajeBox.error("Debe ingresar un precio válido.");
                return;
            }

            // 2. Obtenemos el nuevo precio ingresado
            if (txtbxNuevoPrecioB.Text.Equals(""))
                txtbxNuevoPrecioB.Text = "00";
            double nuevoPrecio = Convert.ToDouble(txtbxNuevoPrecioA.Text + "," + txtbxNuevoPrecioB.Text);
            
            // 3. Seteamos el nuevo precio al tramo seleccionado y lo actualizamos
            this.tramo.setPrecio(nuevoPrecio);
            try
            {
                this.tramo.actualizarPrecio();
            }
            catch
            {
                MensajeBox.error("No se pudo actualizar el precio del tramo seleccionado. Intente nuevamente o contacte al administrador.");
                return;
            }
            
            // 4. Informamos del éxito en la actualización del precio y cerramos
            MensajeBox.info("El precio se actualizó correctamente.");
            this.Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ModificarPrecioTramoForm_Load(object sender, EventArgs e)
        {   
            // Cargamos los datos del tramo seleccionado
            lblId.Text = this.tramo.getId().ToString();
            lblPuertoOrigen.Text = this.tramo.getPuertoInicio();
            lblPuertoDestino.Text = this.tramo.getPuertoFin();
            lblPrecioActual.Text = this.tramo.getPrecio().ToString();
        }

    }
}
