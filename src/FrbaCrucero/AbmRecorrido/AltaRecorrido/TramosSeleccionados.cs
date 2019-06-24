using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

        // Actualizamos el dgvTramosSeleccionados donde vamos armando el recorrido con los diferentes tramos seleccionados
        public void popular(int idTramo, string puertoInicioTramo, string puertoFinTramo, double precioTramo)
        {
            this.dgvTramosSeleccionados.Rows.Add(idTramo, puertoInicioTramo, puertoFinTramo, precioTramo);
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

        public void limpiar()
        {
            this.dgvTramosSeleccionados.Rows.Clear();
        }
    }
}
