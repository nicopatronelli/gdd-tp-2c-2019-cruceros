using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Windows.Forms;
using FrbaCrucero.AbmRecorrido.Dominio;
using FrbaCrucero.Utils;

namespace FrbaCrucero.AbmRecorrido.AltaRecorrido
{
    public class TramosSeleccionados
    {
        DataGridView dgvTramosSeleccionados;

        public TramosSeleccionados(DataGridView dgvTramosSeleccionados)
        {
            this.dgvTramosSeleccionados = dgvTramosSeleccionados;
        }

        public DataGridView getDgvTramosSeleccionados()
        {
            return this.dgvTramosSeleccionados;
        }

        // Agregemos el tramo seleccionado al final del dgvTramosSeleccionados donde vamos armando el recorrido con los diferentes tramos seleccionados
        public void agregarTramo(Tramo tramoSeleccionado)
        {
            this.dgvTramosSeleccionados.Rows.Add(
                tramoSeleccionado.getId(), tramoSeleccionado.getPuertoInicio(), 
                tramoSeleccionado.getPuertoFin(), tramoSeleccionado.getPrecio());
        }

        public int cantidad()
        {
            return this.dgvTramosSeleccionados.Rows.Count;
        }

        public void eliminarUltimoTramo()
        {
            this.dgvTramosSeleccionados.Rows.RemoveAt(this.cantidad() - 1);
        }

        public Tramo getUltimoTramo()
        {
            int idPuertoUltimoTramo = Convert.ToInt32(this.dgvTramosSeleccionados.Rows[this.cantidad() - 1].Cells[0].Value);
            string puertoInicioUltimoTramo = this.dgvTramosSeleccionados.Rows[this.cantidad() - 1].Cells[1].Value.ToString();
            string puertoFinUltimoTramo = this.dgvTramosSeleccionados.Rows[this.cantidad() - 1].Cells[2].Value.ToString();
            double precioUltimoTramo = Convert.ToDouble(this.dgvTramosSeleccionados.Rows[this.cantidad() - 1].Cells[3].Value);

            return new Tramo(idPuertoUltimoTramo, puertoInicioUltimoTramo, puertoFinUltimoTramo, precioUltimoTramo);
        }

        public List<Tramo> getTramos()
        {
            int idTramo;
            string puertoInicioTramo, puertoFinTramo;
            double precioTramo;
            Tramo tramo; 
            List<Tramo> tramosSeleccionados = new List<Tramo>();

            foreach (DataGridViewRow row in this.dgvTramosSeleccionados.Rows)
            {
                idTramo = Convert.ToInt32(row.Cells["id_tramo"].Value);
                puertoInicioTramo = row.Cells["puerto_inicio_tramo"].Value.ToString();
                puertoFinTramo = row.Cells["puerto_fin_tramo"].Value.ToString();
                precioTramo = Convert.ToDouble(row.Cells["precio_tramo"].Value);
                tramo = new Tramo(idTramo, puertoInicioTramo, puertoFinTramo, precioTramo);
                tramosSeleccionados.Add(tramo);
            }
            return tramosSeleccionados;
        }

        public void limpiar()
        {
            this.dgvTramosSeleccionados.Rows.Clear();
        }

        // Populamos el dgvTramosSeleccionados con los tramos que forman parte del recorrido a editar
        public void popularTramosSeleccionadosEditar(string identificadorRecorridoAEditar, Recorrido recorrido)
        {
            string miConsulta = "SELECT "
                + "t.id_tramo id_tramo, "
                + "puerto_inicio.puerto_nombre puerto_inicio_tramo, "
                + "puerto_fin.puerto_nombre puerto_fin_tramo, "
                + "t.tramo_precio precio_tramo "
             + "FROM LOS_BARONES_DE_LA_CERVEZA.Recorrido r "
                + "JOIN LOS_BARONES_DE_LA_CERVEZA.Tramos_por_Recorrido tpr "
                        + "ON r.id_recorrido = tpr.id_recorrido "
                + "JOIN LOS_BARONES_DE_LA_CERVEZA.Tramo t "
                        + "ON tpr.id_tramo = t.id_tramo "
                + "JOIN LOS_BARONES_DE_LA_CERVEZA.Puerto puerto_inicio "
                        + "ON t.tramo_puerto_inicio = puerto_inicio.id_puerto "
                + "JOIN LOS_BARONES_DE_LA_CERVEZA.Puerto puerto_fin "
                        + "ON t.tramo_puerto_destino = puerto_fin.id_puerto "
                + "WHERE r.recorrido_codigo = @identificador_recorrido";

            List<Parametro> parametros = new List<Parametro>();
            Parametro paramPuertoInicio = new Parametro("@identificador_recorrido", SqlDbType.NVarChar, identificadorRecorridoAEditar, 255);
            parametros.Add(paramPuertoInicio);
            Query query = new Query(miConsulta, parametros);
            SqlDataReader sqlDataReader = query.ejecutarReader();
            int idTramo;
            string tramoPuertoInicio, tramoPuertoFin;
            double precioTramo;
            Tramo tramoSeleccionado;
            while (sqlDataReader.Read())
            {
                idTramo = Convert.ToInt32(sqlDataReader["id_tramo"]);
                tramoPuertoInicio = sqlDataReader["puerto_inicio_tramo"].ToString();
                tramoPuertoFin = sqlDataReader["puerto_fin_tramo"].ToString();
                precioTramo = Convert.ToDouble(sqlDataReader["precio_tramo"]);
                tramoSeleccionado = new Tramo(idTramo, tramoPuertoInicio, tramoPuertoFin, precioTramo);
                recorrido.addTramo(tramoSeleccionado);
                this.agregarTramo(tramoSeleccionado);
                recorrido.getPrecio().aumentarLblPrecioRecorrido(tramoSeleccionado.getPrecio());
            }
        }
    }
}
