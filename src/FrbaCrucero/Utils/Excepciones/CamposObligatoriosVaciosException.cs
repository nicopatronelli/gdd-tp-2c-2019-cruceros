using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrbaCrucero.Login
{
    class CamposObligatoriosVaciosException : Exception
    {
        public CamposObligatoriosVaciosException() : base(){}

        public CamposObligatoriosVaciosException(String mensaje)
            : base(mensaje){}
    }
}
