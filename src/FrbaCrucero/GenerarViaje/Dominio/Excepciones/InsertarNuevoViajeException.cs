using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FrbaCrucero.Utils;

namespace FrbaCrucero.GenerarViaje.Dominio.Excepciones
{
    class InsertarNuevoViajeException : Exception
    {
        public InsertarNuevoViajeException() : base() { }

        public void mensajeError()
        {
            MensajeBox.error("Hubo un error al insertar el viaje. Por favor, intente nuevamente o contacte al administrador.");
        }
    }
}
