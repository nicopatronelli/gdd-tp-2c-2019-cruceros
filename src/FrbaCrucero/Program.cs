using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using FrbaCrucero.AbmRol;
using FrbaCrucero.Login;
using FrbaCrucero.AbmCrucero;
using FrbaCrucero.CompraReservaPasaje;
using FrbaCrucero.CompraReservaPasaje.Comprar;

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
            Application.Run(new ComprarTemplateForm("unaCabina",8,33));
        }
    }
}
