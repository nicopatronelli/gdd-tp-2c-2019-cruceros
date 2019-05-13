using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrbaCrucero.Utils
{
    static class DGVUtils
    {
        public static void limpiar(DataGridView dgv)
        {
            dgv.Columns.Clear();
        } // FIN limpiar()

        public static void autoAjustarColumnas(DataGridView dgv)
        {
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill; // Para autoajustar el tamaño del dgv
        }

        public static DataGridViewButtonColumn agregarBotonEditar(DataGridView gdv)
        {
            DataGridViewButtonColumn botonEditar = new DataGridViewButtonColumn();
            botonEditar.Name = "btnDgvEditar";
            botonEditar.HeaderText = "Editar";
            botonEditar.Text = "Editar";
            botonEditar.UseColumnTextForButtonValue = true;

            return botonEditar;
        } // FIN agregarBotonEditar()
    }
}
