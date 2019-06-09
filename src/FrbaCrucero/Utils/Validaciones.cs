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
        public static void hayCamposObligatoriosNulos(params string[] campos)
        {
            //Func<string, bool> lambda = campo => String.IsNullOrEmpty(campo);
            if (campos.Any(campo => String.IsNullOrEmpty(campo)))
                throw new CamposOblitaroiosVaciosException();
        } // FIN hayCamposObligatoriosNulos()
    }
}
