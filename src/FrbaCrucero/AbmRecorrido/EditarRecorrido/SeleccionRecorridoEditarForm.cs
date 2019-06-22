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

namespace FrbaCrucero.AbmRecorrido.EditarRecorrido
{
    public partial class SeleccionRecorridoEditarForm : Form
    {
        public SeleccionRecorridoEditarForm()
        {
            InitializeComponent();
        }

        protected void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        virtual protected void SeleccionRecorridoForm_Load(object sender, EventArgs e)
        {
            string miConsulta = querySeleccionRecorridos();
            cargarDgvRecorridos(miConsulta);
            agregarBotonEditar("Editar Recorrido", "Editar");
            dgvSeleccionRecorrido.CellClick += dgvSeleccionarRecorrido_CellContentClick;
            autoajustarDgv();
        }

        virtual protected string querySeleccionRecorridos()
        {
            return "SELECT recorrido_codigo identificador "
                 + "FROM LOS_BARONES_DE_LA_CERVEZA.Recorrido r "
                 + "WHERE r.recorrido_estado = 0 -- Solo considero los recorridos habilitados";
        }

        protected void cargarDgvRecorridos(string miConsulta)
        {
            ConexionBD conexion = new ConexionBD();
            SqlDataAdapter dataAdapter = new SqlDataAdapter(miConsulta, conexion.obtenerConexion());
            SqlCommandBuilder commandBuilder = new SqlCommandBuilder(dataAdapter);
            DataSet dataSet = new DataSet();
            dataAdapter.Fill(dataSet);
            dgvSeleccionRecorrido.ReadOnly = true;
            dgvSeleccionRecorrido.AllowUserToAddRows = false; // Para evitar que se añadan filas dinámicamente
            dgvSeleccionRecorrido.DataSource = dataSet.Tables[0];
            conexion.cerrar();
        }

        protected void agregarBotonEditar(string nombreHeader, string nombreBoton)
        {
            // Añadimos un botón Editar al final de cada fila para poder elegir el recorrido a editar
            DataGridViewButtonColumn botonEditar = new DataGridViewButtonColumn();
            botonEditar.Name = "btnDgvEditar";
            botonEditar.HeaderText = nombreHeader;
            botonEditar.Text = nombreBoton;
            botonEditar.UseColumnTextForButtonValue = true;
            dgvSeleccionRecorrido.Columns.Add(botonEditar);
        }

        // Abrimos la pantalla de edición del recorrido seleccionado con los datos que ya tenga cargados
        protected void dgvSeleccionarRecorrido_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
                e.RowIndex >= 0)
            {
                string identificadorRecorrido = Convert.ToString(dgvSeleccionRecorrido.Rows[e.RowIndex].Cells["identificador"].Value);
                cargarFormulario(identificadorRecorrido);

                // Recargamos el dgv de recorridos para no mostrar el dado de baja por servicio técnico
                this.recargarDgvRecorridos();
            }
        }

        protected virtual void cargarFormulario(string identificadorRecorrido)
        {
            // Abrimos el formulario de edición de recorridos
            EditarRecorridoForm formEditarRecorrido = new EditarRecorridoForm(identificadorRecorrido);
            formEditarRecorrido.ShowDialog();
        }

        protected void autoajustarDgv()
        {
            dgvSeleccionRecorrido.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill; // Para autoajustar el tamaño del dgv
        }

        // Método para recargar el dgv de recorridos con los registros actualizados luego de deshabilitar un recorrido
        protected void recargarDgvRecorridos()
        {
            string miConsulta = this.querySeleccionRecorridos();
            cargarDgvRecorridos(miConsulta);
        }
    }
}
