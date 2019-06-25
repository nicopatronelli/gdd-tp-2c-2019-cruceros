using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrbaCrucero.AbmRecorrido.AbmTramos.FixCmbxPuertosInicio
{
    interface OrdenCmbxPuertosInicio
    {
        void ordenar(DataTable dt, ComboBox cmbxPuertoInicio);
    }
}
