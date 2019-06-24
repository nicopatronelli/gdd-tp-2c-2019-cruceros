using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

using System.Threading.Tasks;
using System.Windows.Forms;
using FrbaCrucero.AbmRecorrido.Dominio;

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

        public void limpiarBis()
        {
            this.dgvTramosSeleccionados.DataSource = null;
        }
    }
}
