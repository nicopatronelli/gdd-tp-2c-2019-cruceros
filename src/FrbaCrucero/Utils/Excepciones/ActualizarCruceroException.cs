using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrbaCrucero.Utils.Excepciones
{
    class ActualizarCruceroException : Exception 
    {
        public ActualizarCruceroException() : base(){}

        public ActualizarCruceroException(String mensaje)
            : base(mensaje){}

        public void mensajeError()
        {
            MensajeBox.error("Error al actualizar el crucero. Intente nuevamente o contacte al administrador.");
        }
    }
}
