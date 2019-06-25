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
using FrbaCrucero.AbmRecorrido.Dominio;
using FrbaCrucero.AbmRecorrido.Dominio.Excepciones;

namespace FrbaCrucero.AbmRecorrido.EditarRecorrido
{
    public partial class EditarRecorridoForm : AltaRecorridoForm
    {
        string identificadorRecorridoAEditar;
        int pkRecorridoAEditar;

        public EditarRecorridoForm()
        {
            InitializeComponent();
        }

        // Constructor que vamos a utilizar
        public EditarRecorridoForm(string identificadorRecorridoAEditar)
        {
            InitializeComponent();
            this.identificadorRecorridoAEditar = identificadorRecorridoAEditar;
            this.gpbxAltaNuevoRecorrido.Text = "Editar Recorrido";
            this.btnEnviar.Text = "Guardar";
        }

        private void EditarRecorridoForm_Load(object sender, EventArgs e)
        {
            // 1. Cargamos el identificador del recorrido a editar en el txtbox
            this.txtbxCodRecorrido.Text = identificadorRecorridoAEditar;

            // 2. Populamos el dgvTramosSeleccionados con los tramos que forman parte del recorrido a editar
            this.tramosSeleccionados.popularTramosSeleccionadosEditar(identificadorRecorridoAEditar, this.recorrido);

            // 3. Populamos el dgvTramosDisponibles según el puerto fin del último tramo del recorrido a editar
            Tramo ultimoTramo = this.tramosSeleccionados.getUltimoTramo();
            this.tramosDisponibles.popularTramosPosibles(ultimoTramo.getPuertoFin());

            // A partir de ahora, estamos en la misma situación que en un alta de nuevo recorrido

            // 4. Recuperamos la pk del recorrido a editar (podría ir en Load o constructor)
            pkRecorridoAEditar = Recorrido.obtenerPkRecorridoAEditar(identificadorRecorridoAEditar);
        }

        // Cambiamos el comportamiento del botón Enviar nuevo recorrido: Ahora será el botón Guardar los cambios del recorrido editado
        override protected void btnEnviar_Click(object sender, EventArgs e) // Botón GUARDAR
        {
            // 1. Primero actualizamos el identificador del recorrido
            // Seteamos el identificador al recorrido y validamos que no sea nulo o cadena vacía
            try
            {
                recorrido.setIdentificador(txtbxCodRecorrido.Text);
            }
            catch (IdentificadorCruceroNullException ex)
            {
                ex.mensajeError();
                return;
            }

            // Validamos que el código de recorrido éste disponible 
            string identificadorRecorridoEditado = txtbxCodRecorrido.Text; // Puede ser igual al anterior
            if (Recorrido.identificadorDisponibleEditarRecorrido(identificadorRecorridoAEditar, identificadorRecorridoEditado, pkRecorridoAEditar).Equals(false))
            {
                MensajeBox.error("El identificador ingresado para el recorrido ya se encuentra en uso en otro recorrido diferente a éste. Por favor, pruebe con uno diferente.");
                return;
            }

            // 2. Borramos todos los tramos en la BD del recorrido a editar 
            Recorrido.eliminarTramos(pkRecorridoAEditar);

            // 3. Insertamos los nuevos tramos seleccionados para el recorrido a editar
            recorrido.actualizar(identificadorRecorridoAEditar);

            MensajeBox.info("El recorrido se actualizo correctamente");
            this.Close(); // Cerramos el formulario de editar recorrido
        }

    }
}
