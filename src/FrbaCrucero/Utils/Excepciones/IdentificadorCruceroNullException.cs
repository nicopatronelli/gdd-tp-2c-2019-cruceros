using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrbaCrucero.Utils.Excepciones
{
    class IdentificadorCruceroNullException : CamposObligatoriosVaciosException
    {
        public IdentificadorCruceroNullException() : base(){}

        public IdentificadorCruceroNullException(String mensaje)
            : base(mensaje){}

        public override void mensajeError()
        {
            MensajeBox.error("Debe ingresar un campo identificador para el recorrido.");
        }
    }
}
