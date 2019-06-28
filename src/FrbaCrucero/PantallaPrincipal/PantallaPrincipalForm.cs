using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FrbaCrucero.AbmRol;
using FrbaCrucero.AbmCrucero;
using FrbaCrucero.Utils;
using FrbaCrucero.AbmRecorrido;
using FrbaCrucero.GenerarViaje;
using FrbaCrucero.CompraReservaPasaje;
using FrbaCrucero.PagoReserva;
using FrbaCrucero.ListadoEstadistico;

namespace FrbaCrucero.PantallaPrincipal
{   
    /*  ES LA MISMA PANTALLA PRINCIPAL PARA TODOS LOS TIPOS DE USUARIOS (ROLES): Dependiendo 
     *  el rol de usuario activo se mostrarán/ocultarán los botones correspondientes a las 
     *  funcionalidades pertenecientes al rol en cuestión.
     */

    public partial class PantallaPrincipalForm : Form
    {
        // Atributos 
        string usuario; 

        // Constructor predeterminado
        public PantallaPrincipalForm()
        {
            InitializeComponent();
        }

        // Constructor que vamos a utilizar 
        public PantallaPrincipalForm(List<string> funcionalidades, string nombreUsuario)
        {
            InitializeComponent();

            // Asignamos el nombreUsuario a la variable usuario
            usuario = nombreUsuario;

            // Desbloqueamos las funcionalidades correspondientes al rol 
            if (!funcionalidades.Contains(DEF.FUNC_ABM_CRUCEROS))
                btnAbmCruceros.Visible = false;
            if (!funcionalidades.Contains(DEF.FUNC_ABM_PUERTOS))
                btnAbmPuertos.Visible = false;
            if (!funcionalidades.Contains(DEF.FUNC_ABM_RECORRIDOS))
                btnAbmRecorrido.Visible = false;
            if (!funcionalidades.Contains(DEF.FUNC_ABM_ROLES))
                btnAbmRol.Visible = false;
            if (!funcionalidades.Contains(DEF.FUNC_COMPRAR_RESERVAR_VIAJE))
                btnComprarReservar.Visible = false;
            if (!funcionalidades.Contains(DEF.FUNC_GENERAR_VIAJE))
                btnGenerarViaje.Visible = false;
            if (!funcionalidades.Contains(DEF.FUNC_LISTADOS))
                btnListado.Visible = false;
            if (!funcionalidades.Contains(DEF.FUNC_PAGAR_RESERVA))
                btnPagarReserva.Visible = false;
        }

        private void PantallaPrincipalForm_Load(object sender, EventArgs e)
        {

        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAbmRol_Click(object sender, EventArgs e)
        {
            AbmRolForm formAbmRol = new AbmRolForm();
            formAbmRol.ShowDialog();
        }

        private void btnAbmCruceros_Click(object sender, EventArgs e)
        {
            AbmCrucerosForm formAbmCruceros = new AbmCrucerosForm();
            formAbmCruceros.ShowDialog();
        }

        private void btnAbmPuertos_Click(object sender, EventArgs e)
        {
            MensajeBox.info("Esta funcionalidad está disponible aún.");
        }

        private void btnAbmRecorrido_Click(object sender, EventArgs e)
        {
            AbmRecorridosForm formAbmRecorridos = new AbmRecorridosForm();
            formAbmRecorridos.ShowDialog();
        }

        private void btnGenerarViaje_Click(object sender, EventArgs e)
        {
            GenerarViajeForm formGenerarViaje = new GenerarViajeForm();
            formGenerarViaje.ShowDialog();
        }

        private void btnComprarReservar_Click(object sender, EventArgs e)
        {
            CompraReservaForm formCompraReserva = new CompraReservaForm();
            formCompraReserva.ShowDialog();
        }

        private void btnPagarReserva_Click(object sender, EventArgs e)
        {
            PagoReservaForm formPagoReserva = new PagoReservaForm();
            formPagoReserva.ShowDialog();
        }

        private void btnListado_Click(object sender, EventArgs e)
        {
            SeleccionListadoEstadisticoForm formSeleccionListadoEstadistico = new SeleccionListadoEstadisticoForm();
            formSeleccionListadoEstadistico.ShowDialog();
        }

    }
}
