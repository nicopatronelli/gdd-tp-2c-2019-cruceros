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

namespace FrbaCrucero.AbmRol
{
    public partial class CrearRolForm : Form
    {
        // Atributos
        string modo = "";
        string rolAEditar = "";

        // Constructor para CREAR un nuevo rol
        public CrearRolForm()
        {
            InitializeComponent();
        }

        // Constructor para EDITAR un rol existente
        public CrearRolForm(string rol)
        {
            InitializeComponent();
            modo = "EDICION";
            rolAEditar = rol;
            this.Text = "Editar Rol"; // Cambiamos el nombre del formulario
            btnCrearRol.Text = "Actualizar"; // Cambiamos el nombre del botón para que diga Actualizar en lugar de Crear
            gpbxNombreRol.Text = "Ingrese otro nombre para el rol si lo desea.";
            gpbxCrearNuevoRol.Text = "Complete los campos y pulse Actualizar para modificar el rol.";

            // Llenamos el txtbx de nombre del rol 
            txtbxNombreRol.Text = rolAEditar;

            // Hacemos una consulta para traernos las funcionalidades del rol a editar 
            SqlDataReader funcionalidades = Rol.recuperarFuncionalidades(rolAEditar);

            // Marcamos los checkbox de las funcionalidades que tiene el rol
            while (funcionalidades.Read()) // Mientras haya funcionalidades para leer 
            {
                string funcionalidad = funcionalidades["Funcionalidad"].ToString();

                switch (funcionalidad)
                {   
                    case DEF.FUNC_ABM_CRUCEROS:
                        chbxAbmCruceros.Checked = true;
                        break;
                    case DEF.FUNC_ABM_PUERTOS:
                        chbxAbmPuertos.Checked = true;
                        break;
                    case DEF.FUNC_ABM_RECORRIDOS:
                        chbxAbmRecorridos.Checked = true;
                        break;
                    case DEF.FUNC_ABM_ROLES:
                        chbxAbmPuertos.Checked = true;
                        break;
                    case DEF.FUNC_COMPRAR_RESERVAR_VIAJE:
                        chbxComprarReservarViaje.Checked = true;
                        break;
                    case DEF.FUNC_GENERAR_VIAJE:
                        chbxGenerarViaje.Checked = true;
                        break;
                    case DEF.FUNC_LISTADOS:
                        chbxListadosEstadisticos.Checked = true;
                        break;
                    case DEF.FUNC_PAGAR_RESERVA:
                        chbxPagoReserva.Checked = true;
                        break;
                    default:
                        break;
                } // Fin switch

            } // Fin while 

        }

        private void CrearRolForm_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCrearRol_Click(object sender, EventArgs e)
        {
            // 1. Primero obtenemos el nombre del nuevo rol que el usuario ingreso
            string nombreRol = txtbxNombreRol.Text;

            // 2. Validamos que haya NO se haya ingresado un nombre vacío
            if (NombreRol.campoNombreVacío(nombreRol).Equals(true))
            {
                MensajeBox.error("Debe ingresar un nombre para el rol.");
                return;
            }

            // 3. Bloqueamos la modificación del Rol_Cliente y el Rol_Empresa
            if (modo.Equals("EDICION"))
            {
                if (rolAEditar.Equals(DEF.ROL_CLIENTE))
                {
                    MensajeBox.error("No está permitido modificar el Rol_Cliente.");
                    return; // Abortamos
                }
                if (rolAEditar.Equals(DEF.ROL_ADMIN))
                {
                    MensajeBox.error("No está permitido modificar el Rol_Admin");
                    return; // Abortamos
                }
            } // Fin bloqueo modificación Rol_Cliente y y Rol_Empresa


            // 4. Validamos que el nombre del rol esté disponible 
            if (nombreRol != rolAEditar)
            {
                if (NombreRol.estaDisponible(nombreRol).Equals(false))
                {
                    MensajeBox.error("El nombre elegido para el rol ya se encuentra en uso. Por favor, ingrese uno diferente.");
                    return;
                }
            }
            // Si nombreRol != rolAEditar significa que estamos en modo edición y el usuario 
            // cambió el nombre del rol. 

            // 5. Capturamos los checkbox de funcionalidades seleccionados
            Dictionary<string, bool> funcionalidades = Funcionalidades.seleccionadas(chbxAbmCruceros.Checked, chbxAbmPuertos.Checked, chbxAbmRecorridos.Checked,
                chbxAbmRol.Checked, chbxComprarReservarViaje.Checked, chbxGenerarViaje.Checked, chbxListadosEstadisticos.Checked, chbxPagoReserva.Checked);
  
            // 6. Validamos que el usuario haya seleccionado al menos una funcionalidad
            if (Funcionalidades.alMenosUna(funcionalidades).Equals(false))
            {
                // El usuario NO selecciono ninguna funcionalidad
                MensajeBox.error("Debe seleccionar al menos una funcionalidad.");
                return;
            }

            // 7. En este punto ya podemos insertar o actualizar el nuevo rol en la BD
            if (modo.Equals("EDICION"))
            { /*** INICIO MODO EDICIÓN ***/

                // rolAEditar tiene el valor del nombre de rol anterior y nombreRol el nuevo
                bool rolActualizado = Rol.actualizar(rolAEditar, nombreRol, funcionalidades);
                if (rolActualizado.Equals(true))
                {
                    MensajeBox.info("El rol se actualizó correctamente.");
                    rolAEditar = nombreRol; // El rol anterior ahora es el nuevo rol
                    return;
                }
                else
                {
                    MensajeBox.error("El rol no se pudo actualizar.");
                    return;
                }
            } /*** FIN MODO EDICIÓN ***/

            // Si no estamos en modo edición es que vamos a insertar un rol nuevo
            bool rolInsertado = Rol.insertar(nombreRol, funcionalidades);
            if (rolInsertado.Equals(true))
            {
                // El rol se inserto correctamente
                MensajeBox.info("El nuevo rol se creo correctamente.");
                return;
            }
            else
            {
                // El rol NO se pudo insertar
                MensajeBox.error("El nuevo rol no se pudo crear. Intente nuevamente.");
                return;
            }

        } // FIN btnCrearRol_Click()
    }
}
