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

        virtual protected void SeleccionCruceroEditarForm_Load(object sender, EventArgs e)
        {
            string miConsulta = querySeleccionCruceros();
            cargarDgvCruceros(miConsulta);
            agregarBotonEditar("Editar Crucero", "Editar");
            dgvEditarCrucero.CellClick += dgvSeleccionarCrucero_CellContentClick;
            autoajustarDgv();
        }

        virtual protected string querySeleccionCruceros()
        {
            return "SELECT cru.identificador 'Identificador', cru.modelo 'Modelo', mar.marca 'Marca', COUNT(cab.crucero) 'Cantidad de cabinas' "
                                + "FROM LOS_BARONES_DE_LA_CERVEZA.Cruceros cru "
                                    + "JOIN LOS_BARONES_DE_LA_CERVEZA.Marcas_Cruceros mar "
                                        + "ON cru.marca = mar.id_marca "
                                    + "JOIN LOS_BARONES_DE_LA_CERVEZA.Cabinas cab "
                                        + "ON cru.id_crucero = cab.crucero "
                                + "WHERE cru.fecha_baja_vida_util IS NULL " // No permitimos editar los cruceros dados de baja en forma definitiva
                                + "GROUP BY cru.identificador, cru.modelo, mar.marca";
        }

        protected void cargarDgvCruceros(string miConsulta)
        {
            ConexionBD conexion = new ConexionBD();
            SqlDataAdapter dataAdapter = new SqlDataAdapter(miConsulta, conexion.obtenerConexion());
            SqlCommandBuilder commandBuilder = new SqlCommandBuilder(dataAdapter);
            DataSet dataSet = new DataSet();
            dataAdapter.Fill(dataSet);
            dgvEditarCrucero.ReadOnly = true;
            dgvEditarCrucero.AllowUserToAddRows = false; // Para evitar que se añadan filas dinámicamente
            dgvEditarCrucero.DataSource = dataSet.Tables[0];
            conexion.cerrar();
        }

        protected void agregarBotonEditar(string nombreHeader, string nombreBoton)
        {
            // Añadimos un botón Editar al final de cada fila para poder elegir la publicación a editar 
            DataGridViewButtonColumn botonEditar = new DataGridViewButtonColumn();
            botonEditar.Name = "btnDgvEditar";
            botonEditar.HeaderText = nombreHeader;
            botonEditar.Text = nombreBoton;
            botonEditar.UseColumnTextForButtonValue = true;
            dgvEditarCrucero.Columns.Add(botonEditar);
        }

        // Abrimos la pantalla de edición de la publicación seleccionada con los datos que ya tenga cargados
        protected void dgvSeleccionarCrucero_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
                e.RowIndex >= 0)
            {
                string identificadorCrucero = Convert.ToString(dgvEditarCrucero.Rows[e.RowIndex].Cells["identificador"].Value);
                cargarFormulario(identificadorCrucero);

                // Recargamos el dgv de cruceros para no mostrar el dado de baja por servicio técnico
                this.recargarDgvCruceros();
            }
        }

        protected virtual void cargarFormulario(string identificadorCrucero)
        {
            // Abrimos el formulario de edición de cruceros
            CruceroForm formEditarCrucero = new CruceroForm(identificadorCrucero);
            formEditarCrucero.ShowDialog();
        }

        protected void autoajustarDgv()
        {
            dgvEditarCrucero.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill; // Para autoajustar el tamaño del dgv
        }

        // Método para recargar el dgv de cruceros con los registros actualizados luego de una baja (definitiva o temporal)
        protected void recargarDgvCruceros()
        {
            string miConsulta = this.querySeleccionCruceros();
            cargarDgvCruceros(miConsulta);
        }
    }
}
