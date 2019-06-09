using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrbaCrucero.Utils.Excepciones
{
    class CamposOblitaroiosVaciosException : Exception
    {
        public CamposOblitaroiosVaciosException() : base(){}

        public CamposOblitaroiosVaciosException(String mensaje)
            : base(mensaje){}

        public void mensajeError()
        {
            MensajeBox.error("Hay campos obligatorios sin completar.");
        }
    }
}
