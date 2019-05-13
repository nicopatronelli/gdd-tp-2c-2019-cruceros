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


namespace FrbaCrucero.AbmRol
{
    public partial class SeleccionRolForm : Form
    {
        int contador = 0;
        ConexionBD conexion;
        string rolAEditar;
        string modo; // Seleccionar Rol para editar o deshabilitar

        /*** CONSTRUCTOR PARA EDITAR ROLES ***/
        public SeleccionRolForm()
        {
            InitializeComponent();
            conexion = new ConexionBD();
            Rol.cargarRolesEdicion(conexion, dgvRoles);
            dgvRoles.CellClick += dgvEditarRoles_CellClick; // Evento para el botón Editar
        }

        /*** CONSTRUCTOR PARA ELIMINAR (DESHABILITAR) ROLES ***/
        public SeleccionRolForm(string eliminar)
        {
            InitializeComponent();

            modo = "ELIMINAR";
            this.Text = "Deshabilitar Rol";

            // Cargamos los roles al dgv
            conexion = new ConexionBD();
            Rol.cargarRolesEliminacion(conexion, dgvRoles);
            dgvRoles.CellClick += dgvEditarRoles_CellClick; // Evento para el botón Habilitar
            conexion.cerrar();
        }


        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void SeleccionRolForm_Load(object sender, EventArgs e)
        {

        } // FIN SeleccionRolForm_Load()

        // Abrimos la pantalla de edición para editar el rol seleccionado, con los datos que ya tenga cargados
        private void dgvEditarRoles_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            //if (contador == 0)
            //{
            // Se presiono el botón Editar 
            if ((senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
            e.RowIndex >= 0))
            {
                //string rolAEditar = Convert.ToString(dgvElegirCliente.Rows[e.RowIndex].Cells[0].Value);
                //rolAEditar = Convert.ToString(dgvRoles.Rows[e.RowIndex].Cells[0].Value);
                // Obtengo el nombre del rol a editar
                rolAEditar = Convert.ToString(dgvRoles.Rows[e.RowIndex].Cells["Nombre rol"].Value);

                CrearRolForm formEditarRol = new CrearRolForm(rolAEditar);
                formEditarRol.ShowDialog();

                // Limpiamos el el datagridview para que no queden datos obsoletos
                DGVUtils.limpiar(dgvRoles);
                conexion = new ConexionBD();
                Rol.cargarRolesEdicion(conexion, dgvRoles);
                //dgvRoles.CellClick += dgvEditarRoles_CellClick; // Evento para el botón Editar
                contador++;
                return;
            }
            //} // FIN contador

            // Se presiono el checkbox Habilitar/Deshabilitar rol
            if (e.ColumnIndex == DEF.INDICE_COLUMNA_HABILITAR_ROL && e.RowIndex >= 0)
            {
                dgvRoles.CommitEdit(DataGridViewDataErrorContexts.Commit);

                // Chequeamos el valor del checkbox Habilitar
                if (dgvRoles.CurrentCell.Value.GetType() == typeof(bool))
                {
                    if ((bool)dgvRoles.CurrentCell.Value == false)
                    {
                        // Habilitar cliente
                        rolAEditar = Convert.ToString(dgvRoles.Rows[e.RowIndex].Cells["nombre_rol"].Value);
                        bool resultado = Rol.habilitar(rolAEditar);
                        if (resultado.Equals(true))
                            MensajeBox.info("El rol se habilito correctamente.");
                        else
                            MensajeBox.error("No se pudo habilitar el rol seleccionado.");
                    }
                    else
                    {
                        //Deshabilitar Administrador
                        rolAEditar = Convert.ToString(dgvRoles.Rows[e.RowIndex].Cells["nombre_rol"].Value);
                        if (rolAEditar.Equals("Rol_Admin"))
                        {
                            MensajeBox.info("El Rol Administrador NO puede deshabilitarse.");
                            return;
                        }

                        bool resultado = Rol.deshabilitar(rolAEditar);
                        if (resultado.Equals(true))
                            MensajeBox.info("Rol deshabilitado correctamente.");
                        else
                            MensajeBox.error("No se pudo deshabilitar el rol seleccionado.");
                    }
                } // FIN chequeamos el valor del checkbox

                conexion = new ConexionBD();
                //AbmClienteUtil.configEliminar(nombreBuscado, apellidoBuscado, dniBuscado, emailBuscado, conexion, dgvElegirCliente);
                conexion.cerrar();
                return;

            } // FIN se presiono el checkbox Habilitar/Deshabilitar rol


        } // FIN dgvEditarRoles_CellClick()

    }
}
