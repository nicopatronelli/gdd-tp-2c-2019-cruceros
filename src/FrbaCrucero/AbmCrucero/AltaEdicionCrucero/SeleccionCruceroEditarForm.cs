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
    public partial class SeleccionCruceroEditarForm : Form
    {
        public SeleccionCruceroEditarForm()
        {
            InitializeComponent();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        protected virtual void SeleccionCruceroForm_Load(object sender, EventArgs e)
        {
            string miConsulta = "SELECT cru.identificador 'Identificador', cru.modelo 'Modelo', mar.marca 'Marca', COUNT(cab.crucero) 'Cantidad de cabinas' "
                + "FROM LOS_BARONES_DE_LA_CERVEZA.Cruceros cru "
                    + "JOIN LOS_BARONES_DE_LA_CERVEZA.Marcas_Cruceros mar "
                        + "ON cru.marca = mar.id_marca "
                    + "JOIN LOS_BARONES_DE_LA_CERVEZA.Cabinas cab "
                        + "ON cru.id_crucero = cab.crucero "
                + "WHERE cru.fecha_baja_vida_util IS NULL " // No permitimos editar los cruceros dados de baja en forma definitiva
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
            botonEditar.HeaderText = "Editar Crucero";
            botonEditar.Text = "Editar";
            botonEditar.UseColumnTextForButtonValue = true;
            dgvEditarCrucero.Columns.Add(botonEditar);
            dgvEditarCrucero.CellClick += dgvEditarCrucero_CellContentClick;

            dgvEditarCrucero.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill; // Para autoajustar el tamaño del dgv

        }

        // Abrimos la pantalla de edición de la publicación seleccionada con los datos que ya tenga cargados
        private void dgvEditarCrucero_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
                e.RowIndex >= 0)
            {
                string identificadorCrucero = Convert.ToString(dgvEditarCrucero.Rows[e.RowIndex].Cells[0].Value);
                CruceroForm formEditarCrucero = new CruceroForm(identificadorCrucero);
                formEditarCrucero.ShowDialog();
            }
        }
    }
}
