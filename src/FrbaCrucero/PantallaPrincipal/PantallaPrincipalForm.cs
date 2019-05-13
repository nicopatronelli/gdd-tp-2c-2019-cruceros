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
using FrbaCrucero.Utils;

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

    }
}
