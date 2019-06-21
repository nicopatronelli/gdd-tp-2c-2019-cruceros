using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrbaCrucero.Utils.Excepciones
{
    class CamposObligatoriosVaciosException : Exception
    {
        public CamposObligatoriosVaciosException() : base(){}

        public CamposObligatoriosVaciosException(String mensaje)
            : base(mensaje){}

        public virtual void mensajeError()
        {
            MensajeBox.error("Hay campos obligatorios sin completar.");
        }
    }
}
