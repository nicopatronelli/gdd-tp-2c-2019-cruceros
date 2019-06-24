using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FrbaCrucero.Utils;

namespace FrbaCrucero.AbmRecorrido.AltaRecorrido
{
    public class TramosDisponibles
    {
        DataGridView dgvTramosDisponibles;

        public TramosDisponibles(DataGridView dgvTramosDisponibles)
        {
            this.dgvTramosDisponibles = dgvTramosDisponibles;
        }

        public DataGridView getDgvTramosDisponibles()
        {
            return this.dgvTramosDisponibles;
        }

        // Cargamos el dgvTramosDisponibles con TODOS los tramos disponibles en la tabla Tramo
        public void popularTramos()
        {
            ConexionBD conexion = new ConexionBD();
            conexion.abrir();

            string miConsulta = "SELECT t.id_tramo tramo, puerto_inicio.puerto_nombre puerto_inicio, puerto_fin.puerto_nombre puerto_fin, t.tramo_precio precio  "
                              + "FROM LOS_BARONES_DE_LA_CERVEZA.Tramo t "
                                + "JOIN LOS_BARONES_DE_LA_CERVEZA.Puerto puerto_inicio "
                                    + "ON t.tramo_puerto_inicio = puerto_inicio.id_puerto "
                                + "JOIN LOS_BARONES_DE_LA_CERVEZA.Puerto puerto_fin "
                                    + "ON t.tramo_puerto_destino = puerto_fin.id_puerto";

            SqlDataAdapter dataAdapter = new SqlDataAdapter(miConsulta, conexion.obtenerConexion());
            DataTable dt = new DataTable();
            dataAdapter.Fill(dt);
            this.dgvTramosDisponibles.DataSource = dt;
            conexion.cerrar();
        }

        // Cargamos el dgvTramosDisponibles sólo con los posibles tramos que según el puerto final del último tramo agregado
        public void popularTramosPosibles(string puertoInicio)
        {
            ConexionBD conexion = new ConexionBD();
            conexion.abrir();

            string miConsulta = "SELECT t.id_tramo tramo, puerto_inicio.puerto_nombre puerto_inicio, puerto_fin.puerto_nombre puerto_fin, t.tramo_precio precio "
                              + "FROM LOS_BARONES_DE_LA_CERVEZA.Tramo t "
                                + "JOIN LOS_BARONES_DE_LA_CERVEZA.Puerto puerto_inicio "
                                    + "ON t.tramo_puerto_inicio = puerto_inicio.id_puerto "
                                + "JOIN LOS_BARONES_DE_LA_CERVEZA.Puerto puerto_fin "
                                    + "ON t.tramo_puerto_destino = puerto_fin.id_puerto "
                              + "WHERE puerto_inicio.puerto_nombre = @puerto_inicio";

            SqlDataAdapter dataAdapter = new SqlDataAdapter(miConsulta, conexion.obtenerConexion());
            Parametro paramPuertoInicio = new Parametro("@puerto_inicio", SqlDbType.NVarChar, puertoInicio, 255);
            dataAdapter.SelectCommand.Parameters.Add(paramPuertoInicio.obtenerSqlParameter());
            SqlCommandBuilder commandBuilder = new SqlCommandBuilder(dataAdapter);
            DataTable dt = new DataTable();
            dataAdapter.Fill(dt);
            this.dgvTramosDisponibles.DataSource = dt;
            conexion.cerrar();
        }
    }
}
