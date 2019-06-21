using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrbaCrucero.Utils.Excepciones
{
    class InsertarRecorridoException : Exception
    {
        public InsertarRecorridoException() : base(){}

        public InsertarRecorridoException(String mensaje)
            : base(mensaje){}

        public void mensajeError()
        {
            MensajeBox.error("Error al insertar el recorrido. Intente nuevamente o contacte al administrador.");
        }
    }
}
