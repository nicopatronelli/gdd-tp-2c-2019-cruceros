using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FrbaCrucero.Utils;

namespace FrbaCrucero.GenerarViaje.Dominio.Excepciones
{
    class IdentificadorCruceroEnViajeEsNuloOVacioException : Exception
    {   
        public IdentificadorCruceroEnViajeEsNuloOVacioException() : base() { }

        public void mensajeError()
        {
            MensajeBox.error("No ha seleccionado un crucero para el viaje. Por favor, seleccione uno.");
        }
    }
}
