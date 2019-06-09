using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrbaCrucero.Utils.Excepciones
{
    class InsertarCruceroException : Exception
    {
        public InsertarCruceroException() : base(){}

        public InsertarCruceroException(String mensaje)
            : base(mensaje){}

        public void mensajeError()
        {
            MensajeBox.error("Error al insertar el crucero. Intente nuevamente o contacte al administrador.");
        }
    }
}
