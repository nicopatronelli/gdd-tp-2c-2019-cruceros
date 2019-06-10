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

namespace FrbaCrucero.AbmCrucero
{
    public partial class SeleccionCruceroBajaSTForm : SeleccionCruceroEditarForm
    {
        public SeleccionCruceroBajaSTForm()
        {
            InitializeComponent();
        }

        protected override void SeleccionCruceroForm_Load(object sender, EventArgs e)
        {
            string miConsulta = "SELECT cru.identificador 'Identificador', cru.modelo 'Modelo', mar.marca 'Marca', COUNT(cab.crucero) 'Cantidad de cabinas' "
                                 + "FROM LOS_BARONES_DE_LA_CERVEZA.Cruceros cru "
                                     + "JOIN LOS_BARONES_DE_LA_CERVEZA.Marcas_Cruceros mar "
                                         + "ON cru.marca = mar.id_marca "
                                     + "JOIN LOS_BARONES_DE_LA_CERVEZA.Cabinas cab "
                                         + "ON cru.id_crucero = cab.crucero "
                                 + "WHERE cru.baja_vida_util = 0 " // No tiene sentido mostrar los cruceros ya dados de baja en forma definitiva...
                                    + "AND cru.baja_fuera_servicio = 0 " // ... ni los que ya están fuera de servicio 
                                 + "GROUP BY cru.identificador, cru.modelo, mar.marca";

            ConexionBD conexion = new ConexionBD();
            SqlDataAdapter dataAdapter = new SqlDataAdapter(miConsulta, conexion.obtenerConexion());
            SqlCommandBuilder commandBuilder = new SqlCommandBuilder(dataAdapter);
            DataSet dataSet = new DataSet();
            dataAdapter.Fill(dataSet);
            dgvEditarCrucero.ReadOnly = true;
            dgvEditarCrucero.AllowUserToAddRows = false; // Para evitar que se añadan filas dinámicamente
            dgvEditarCrucero.DataSource = dataSet.Tables[0];
            conexion.cerrar();

            // Añadimos un botón Editar al final de cada fila para poder elegir la publicación a editar 
            DataGridViewButtonColumn botonEditar = new DataGridViewButtonColumn();
            botonEditar.Name = "btnDgvEditar";
            botonEditar.HeaderText = "Acción";
            botonEditar.Text = "Baja Servicio Técnico";
            botonEditar.UseColumnTextForButtonValue = true;
            dgvEditarCrucero.Columns.Add(botonEditar);
            dgvEditarCrucero.CellClick += dgvBajaDefinitivaCrucero_CellContentClick;

            dgvEditarCrucero.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill; // Para autoajustar el tamaño del dgv

        }

        // Abrimos la pantalla de edición de la publicación seleccionada con los datos que ya tenga cargados
        private void dgvBajaDefinitivaCrucero_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
                e.RowIndex >= 0)
            {
                // Obtenemos el identificador del crucero a dar de baja 
                string identificadorCrucero = Convert.ToString(dgvEditarCrucero.Rows[e.RowIndex].Cells[0].Value);

                // Abrimos la forma para ingresar la fecha de baja y reinicio del crucero por servicio técnico
                BajaServicioTecnicoCruceroForm formBajaServicioTecnico = new BajaServicioTecnicoCruceroForm(identificadorCrucero);
                formBajaServicioTecnico.ShowDialog();
                this.Close();
            }
        }
    }
}
