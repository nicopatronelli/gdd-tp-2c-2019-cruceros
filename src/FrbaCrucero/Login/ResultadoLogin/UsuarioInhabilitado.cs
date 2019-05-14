using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FrbaCrucero.Utils;

namespace FrbaCrucero.Login
{
    class UsuarioInhabilitado : ResultadoLogin
    {
        public void procesarResultado(string nombreUsuario)
        {
            MensajeBox.info("El usuario se encuentra inhabilitado. Contacte al administrador.");
        }
    }
}
