using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrbaCrucero.AbmRecorrido.AbmTramos.FixCmbxPuertosInicio
{
    class OrdenPostInsert : OrdenCmbxPuertosInicio
    {
        public void ordenar(DataTable dt, ComboBox cmbxPuertoInicio)
        {
            cmbxPuertoInicio.DataSource = dt;
            cmbxPuertoInicio.DisplayMember = "puerto_nombre";
            cmbxPuertoInicio.ValueMember = "puerto_nombre";
        }
    }
}
