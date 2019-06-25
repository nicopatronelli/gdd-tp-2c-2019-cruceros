using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using FrbaCrucero.AbmRol;
using FrbaCrucero.Login;
using FrbaCrucero.AbmCrucero;
using FrbaCrucero.CompraReservaPasaje;
using FrbaCrucero.GeneracionViaje;
using FrbaCrucero.AbmRecorrido;
using FrbaCrucero.AbmRecorrido.AbmTramos;
using FrbaCrucero.ListadoEstadistico;

namespace FrbaCrucero
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new AbmCruceros());
            //Application.Run(new GenerarViajeForm());
            //Application.Run(new AltaRecorridoForm());
            //Application.Run(new CompraReservaForm());
            //Application.Run(new AbmRecorridosForm());
            //Application.Run(new SeleccionListadoEstadisticoForm());
            Application.Run(new AltaTramoForm());
        }
    }
}
