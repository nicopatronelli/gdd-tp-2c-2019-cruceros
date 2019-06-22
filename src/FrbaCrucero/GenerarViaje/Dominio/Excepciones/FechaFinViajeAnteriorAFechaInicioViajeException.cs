using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FrbaCrucero.Utils;

namespace FrbaCrucero.GenerarViaje.Dominio.Excepciones
{
    class FechaFinViajeAnteriorAFechaInicioViajeException : Exception
    {
        public FechaFinViajeAnteriorAFechaInicioViajeException() : base() { }

        public void mensajeError()
        {
            MensajeBox.error("La fecha de fin del viaje debe ser posterior a la fecha de inicio del mismo.");
        }
    }
}
