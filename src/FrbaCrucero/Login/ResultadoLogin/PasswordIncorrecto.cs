using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FrbaCrucero.Utils;

namespace FrbaCrucero.Login
{
    class PasswordIncorrecto : ResultadoLogin
    {
        public void procesarResultado(string nombreUsuario)
        {
            MensajeBox.error("Contraseña incorrecta.");
        }
    }
}
