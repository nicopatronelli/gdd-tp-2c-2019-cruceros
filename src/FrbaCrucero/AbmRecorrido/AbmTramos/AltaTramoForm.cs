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

namespace FrbaCrucero.AbmRecorrido.AbmTramos
{
    public partial class AltaTramoForm : Form
    {
        public AltaTramoForm()
        {
            InitializeComponent();
            this.cargarCbmxPuertosInicio();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cargarCbmxPuertosInicio()
        {
            try
            {
                ConexionBD conexion = new ConexionBD();
                conexion.abrir();
                SqlDataAdapter dataAdapter = new SqlDataAdapter("SELECT puerto_nombre FROM LOS_BARONES_DE_LA_CERVEZA.Puerto ORDER BY puerto_nombre", conexion.obtenerConexion());
                DataTable dt = new DataTable();
                dataAdapter.Fill(dt);
                cmbxPuertoInicio.DisplayMember = "puerto_nombre";
                cmbxPuertoInicio.ValueMember = "puerto_nombre";
                cmbxPuertoInicio.DataSource = dt;
            }
            catch (Exception)
            {
                this.Close();
            }
        }

        private void cmbxPuertosInicio_SelectedIndexChanged(object sender, EventArgs e)
        {
            string puertoInicioElegido = cmbxPuertoInicio.SelectedValue.ToString();

            // A partir del puerto de inicio seleccionado, buscamos los posibles puertos finales, que son aquellos para los 
            // cuales ya no existe el tramo con el puerto de origen seleccionado
            ConexionBD conexion = new ConexionBD();
            conexion.abrir();
            string query = "SELECT DISTINCT puerto_fin.puerto_nombre puerto_fin "
                        + "FROM LOS_BARONES_DE_LA_CERVEZA.Tramo t "
                            + "JOIN LOS_BARONES_DE_LA_CERVEZA.Puerto puerto_inicio "
                                + "ON t.tramo_puerto_inicio = puerto_inicio.id_puerto "
                            + "JOIN LOS_BARONES_DE_LA_CERVEZA.Puerto puerto_fin "
                                + "ON t.tramo_puerto_destino = puerto_fin.id_puerto "
                            + "WHERE puerto_inicio.puerto_nombre != @nombre_puerto_inicio_elegido "
                                + "AND puerto_fin.puerto_nombre != @nombre_puerto_inicio_elegido "
                            + "ORDER BY puerto_fin.puerto_nombre";
            Parametro paramNombrePuertoInicioElegido = new Parametro("@nombre_puerto_inicio_elegido", SqlDbType.NVarChar, puertoInicioElegido, 255);
            SqlDataAdapter dataAdapter = new SqlDataAdapter(query, conexion.obtenerConexion());
            dataAdapter.SelectCommand.Parameters.Add(paramNombrePuertoInicioElegido.obtenerSqlParameter());
            DataTable dt = new DataTable();
            dataAdapter.Fill(dt);
            cmbxPuertoFin.DisplayMember = "puerto_fin";
            cmbxPuertoFin.ValueMember = "puerto_fin";
            cmbxPuertoFin.DataSource = dt;
        } 
        
    }
}
