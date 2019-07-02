using FrbaCrucero.AbmCrucero;
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
    public partial class VoucherForm : Form
    {
        public List<Cabina> cabinas;
        public Viaje viaje;
        public Cliente cliente;
        public int idCompraReserva;
        public bool esCompra;
        public double precio;
        public string tipo;


        public VoucherForm(List<Cabina> unasCabinas, Cliente unCliente ,Viaje  unViaje, int unId, bool esUnaCompra, double unPrecio )
        {
            this.cabinas = unasCabinas;
            this.cliente = unCliente;
            this.viaje = unViaje;
            this.idCompraReserva = unId;
            this.esCompra = esUnaCompra;
            this.precio = unPrecio;
            if(esCompra)
                tipo="Compra";
            else
                tipo="Reserva";

            InitializeComponent();
            this.cargarLabels();
        }

        public void cargarLabels()
        {
            esCompraOReservaLabel.Text += this.tipo;
            precioTotalLabel.Text += precio.ToString();
            codigoVoucherLabel.Text += idCompraReserva.ToString();
            viajeLabel.Text ="El Crucero "+viaje.nombreCrucero()+" partira en \nla fecha "+viaje.fecha_inicio+" del puerto "+viaje.origen +"\n"+viaje.puertos;
            cabinasLabel.Text="Usted a comprado la/s cabina/s:\n";
            foreach (var cabina in cabinas)
            {
                cabinasLabel.Text += cabina.mostrarse();
            }
            clienteLabel.Text += "\n" + cliente.mostrarse();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Impresion finalizada");
            this.Close();
        }

        private void VoucherForm_Load(object sender, EventArgs e)
        {

        }





    }
}
