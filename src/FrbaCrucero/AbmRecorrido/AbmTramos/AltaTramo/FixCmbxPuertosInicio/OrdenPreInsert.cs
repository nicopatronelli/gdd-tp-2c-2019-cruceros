using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrbaCrucero.AbmRecorrido.AbmTramos.AltaTramo.FixCmbxPuertosInicio
{
    class OrdenPreInsert : OrdenCmbxPuertosInicio
    {
        public void ordenar(DataTable dt, ComboBox cmbxPuertoInicio)
        {
            cmbxPuertoInicio.DisplayMember = "puerto_nombre";
            cmbxPuertoInicio.ValueMember = "puerto_nombre";
            cmbxPuertoInicio.DataSource = dt;
        }
    }
}
