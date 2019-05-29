using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FrbaCrucero.Utils.Excepciones;

namespace FrbaCrucero.Utils
{
    static class Validaciones
    {
        public static bool hayCamposObligatoriosNulos(params string[] campos)
        {
            //Func<string, bool> lambda = campo => String.IsNullOrEmpty(campo);
            if (campos.Any(campo => String.IsNullOrEmpty(campo)))
                throw new CamposObligatoriosNulosException();
            else
                return false;
        } // FIN hayCamposObligatoriosNulos()
    }
}
