using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrbaCrucero.CompraReservaPasaje
{
    public partial class PagoForm : Form
    {
        public List<DisplayCabina> displayCabinas;
        public Viaje viaje;
        public Cliente cliente;

        public PagoForm(List<DisplayCabina> cabinas, Viaje unViaje,Cliente unCliente )
        {
            this.displayCabinas = cabinas;
            this.viaje = unViaje;
            this.cliente = unCliente;
            InitializeComponent();
        }
    }
}
