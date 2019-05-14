using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FrbaCrucero.Utils;

namespace FrbaCrucero.Login
{
    class ErrorLogin : ResultadoLogin
    {
        public void procesarResultado(string nombreUsuario)
        {
            MensajeBox.info("Error en el login. Revise los datos ingresados e intente nuevamente.");
        }
    }
}
