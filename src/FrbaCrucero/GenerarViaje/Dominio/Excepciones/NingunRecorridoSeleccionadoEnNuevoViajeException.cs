using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FrbaCrucero.Utils;

namespace FrbaCrucero.GenerarViaje.Dominio.Excepciones
{
    class NingunRecorridoSeleccionadoEnNuevoViajeException : Exception
    {
        public NingunRecorridoSeleccionadoEnNuevoViajeException() : base() { }

        public void mensajeError()
        {
            MensajeBox.error("No ha seleccionado ningún recorrido para el nuevo viaje. Por favor, seleccione uno.");
        }
    }
}
