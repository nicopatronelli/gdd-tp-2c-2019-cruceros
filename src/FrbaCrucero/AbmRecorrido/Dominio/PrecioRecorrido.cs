using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrbaCrucero.AbmRecorrido.Dominio
{
    public class PrecioRecorrido
    {
        Label precioRecorrido;

        public PrecioRecorrido(Label precioRecorrido)
        {
            this.precioRecorrido = precioRecorrido;
            this.precioRecorrido.Text = "0"; // Inicializamos el valor a 0
        }

        public void aumentarLblPrecioRecorrido(double precioTramo)
        {
            this.precioRecorrido.Text = Convert.ToString(Convert.ToDouble(this.precioRecorrido.Text) + precioTramo);
        }

        public void disminuirLblPrecioRecorrido(double precioTramo)
        {
            this.precioRecorrido.Text = Convert.ToString(Convert.ToDouble(this.precioRecorrido.Text) - precioTramo);
        }

        public void resetearLblPrecioRecorridoACero()
        {
            this.precioRecorrido.Text = "0";
        }
    }
}
