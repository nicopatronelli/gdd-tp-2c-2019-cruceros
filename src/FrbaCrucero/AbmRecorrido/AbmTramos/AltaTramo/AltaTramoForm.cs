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
using FrbaCrucero.Utils.Excepciones;
using FrbaCrucero.AbmRecorrido.Dominio;
using FrbaCrucero.AbmRecorrido.AbmTramos.AltaTramo.FixCmbxPuertosInicio;
using System.Globalization;

namespace FrbaCrucero.AbmRecorrido.AbmTramos.AltaTramo
{
    public partial class AltaTramoForm : Form
    {   
        public AltaTramoForm()
        {
            InitializeComponent();
            OrdenCmbxPuertosInicio ordenPreInsert = new OrdenPreInsert();
            this.cargarCbmxPuertosInicio(ordenPreInsert);
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // Cargamos TODOS los puertos de la tabla Puerto al cmbox puerto inicio, pues todos pueden ser puerto inicio de un nuevo tramo
        private void cargarCbmxPuertosInicio(OrdenCmbxPuertosInicio metodoOrden)
        {
            try
            {   
                ConexionBD conexion = new ConexionBD();
                conexion.abrir();
                SqlDataAdapter dataAdapter = new SqlDataAdapter("SELECT puerto_nombre FROM LOS_BARONES_DE_LA_CERVEZA.Puerto ORDER BY puerto_nombre", conexion.obtenerConexion());
                DataTable dt = new DataTable();
                dataAdapter.Fill(dt);
                metodoOrden.ordenar(dt, cmbxPuertoInicio);
                conexion.cerrar();
            }
            catch (Exception)
            {
                this.Close();
            }
        }

        // Evento que se dispara para cargar los puertos finales posibles de acuerdo al puerto de inicio seleccionado al segundo cmbx
        private void cmbxPuertosInicio_SelectedIndexChanged(object sender, EventArgs e)
        {
            string puertoInicioElegido = cmbxPuertoInicio.SelectedValue.ToString();

            // A partir del puerto de inicio seleccionado, buscamos los posibles puertos finales, que son aquellos para los 
            // cuales todavía no existe el tramo con el puerto de origen seleccionado
            ConexionBD conexion = new ConexionBD();
            conexion.abrir();
            string query = "SELECT puerto_nombre " // puerto_fin
                         + "FROM LOS_BARONES_DE_LA_CERVEZA.Puerto puerto "
                         + "EXCEPT "
                         + "SELECT DISTINCT puerto_fin.puerto_nombre "
                         + "FROM LOS_BARONES_DE_LA_CERVEZA.Tramo t "
                            + "JOIN LOS_BARONES_DE_LA_CERVEZA.Puerto puerto_inicio "
                                + "ON t.tramo_puerto_inicio = puerto_inicio.id_puerto "
                            + "JOIN LOS_BARONES_DE_LA_CERVEZA.Puerto puerto_fin "
                                + "ON t.tramo_puerto_destino = puerto_fin.id_puerto "
                         + "WHERE puerto_inicio.puerto_nombre = @puerto_inicio_elegido "
                         + "EXCEPT "
                         + "SELECT @puerto_inicio_elegido " // Para evitar tramos A-A
                         + "ORDER BY puerto.puerto_nombre";
            Parametro paramNombrePuertoInicioElegido = new Parametro("@puerto_inicio_elegido", SqlDbType.NVarChar, puertoInicioElegido, 255);
            SqlDataAdapter dataAdapter = new SqlDataAdapter(query, conexion.obtenerConexion());
            dataAdapter.SelectCommand.Parameters.Add(paramNombrePuertoInicioElegido.obtenerSqlParameter());
            DataTable dt = new DataTable();
            dataAdapter.Fill(dt);
            cmbxPuertoFin.DisplayMember = "puerto_nombre";
            cmbxPuertoFin.ValueMember = "puerto_nombre";
            cmbxPuertoFin.DataSource = dt;
        }

        private void btnEnviar_Click(object sender, EventArgs e)
        {
            // 1. Validamos que se haya seleccionado un puerto de inicio y fin
            if (cmbxPuertoInicio.SelectedValue == null || cmbxPuertoFin.SelectedValue == null)
            {
                MensajeBox.error("Debe seleccionar un puerto de origen y destino.");
                return;
            }

            // 2. Validamos que el precio sea correcto
            if (String.IsNullOrEmpty(txtbxPrecioA.Text))
            {
                MensajeBox.error("Debe ingresar un precio válido.");
                return;
            }

            // 3. Obtenemos el puerto de inicio, puerto de fin y precio ingresdos
            string puertoInicio = cmbxPuertoInicio.SelectedValue.ToString();
            string puertoFin = cmbxPuertoFin.SelectedValue.ToString();

            if (txtbxPrecioB.Text.Equals(""))
                txtbxPrecioB.Text = "00";
            double precio = Convert.ToDouble(txtbxPrecioA.Text + "," + txtbxPrecioB.Text);

            // 4. Construimos el objeto tramo y lo insertamos
            Tramo tramo = new Tramo(puertoInicio, puertoFin, Convert.ToDouble(precio));
            try
            {
                tramo.insertar();
            }
            catch
            {
                MensajeBox.error("Hubo un error al insertar el nuevo tramo. Por favor, intente nuevamente o contacte al administrador");
                return;
            }

            // 5. Mostramos el mensaje de confirmación
            MensajeBox.info("El nuevo tramo se inserto correctamente.");

            // 6. Después de insertar debo recargar el cmbx de puerto de inicio y de fin para descartar el tramo recién insertado
            OrdenCmbxPuertosInicio ordenPostInsert = new OrdenPostInsert();
            this.cargarCbmxPuertosInicio(ordenPostInsert);
        }

        private void txtbxPrecio_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

    }
}
