﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrbaCrucero.Utils.Excepciones
{
    class CamposObligatoriosNulosException : Exception
    {
        public CamposObligatoriosNulosException() : base(){}

        public CamposObligatoriosNulosException(String mensaje)
            : base(mensaje){}
    }
}
