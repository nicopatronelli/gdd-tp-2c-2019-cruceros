using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrbaCrucero.Utils
{
    static class MensajeBox
    {
        static DialogResult msgbox;
        static string empresa = "FrbaCrucero";

        public static void error(string mensaje)
        {
            msgbox = MessageBox.Show(mensaje, empresa,
            MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public static void aviso(string mensaje)
        {
            msgbox = MessageBox.Show(mensaje, empresa,
            MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        public static void info(string mensaje)
        {
            msgbox = MessageBox.Show(mensaje, empresa,
            MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

    }
}
