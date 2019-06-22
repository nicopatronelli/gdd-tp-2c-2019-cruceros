using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FrbaCrucero.Utils;

namespace FrbaCrucero.GenerarViaje.Dominio.Excepciones
{
    class FechaInicioAnteriorFechaConfigException : Exception
    {
        public FechaInicioAnteriorFechaConfigException() : base(){}

        public void mensajeError()
        {
            MensajeBox.error("La fecha de inicio del viaje debe ser posterior a la actual (fecha de archivo de configuración).");
        }
    }
}
