using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrbaCrucero.Utils.Excepciones
{
    class CruceroSinCabinasException : Exception
    {
        public CruceroSinCabinasException() : base(){}

        public CruceroSinCabinasException(String mensaje)
            : base(mensaje){}

        public void mensajeError()
        {
            MensajeBox.error("Debe ingresar al menos una cabina.");
        }
    }
}
