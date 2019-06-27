using FrbaCrucero.CompraReservaPasaje;
using FrbaCrucero.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace FrbaCrucero.PagoReserva
{
    public partial class PagoReservaForm : Form
    {
        int id_reserva;
        int reserva_cliente_id;
        Viaje viaje;

        public PagoReservaForm()
        {
            InitializeComponent();
        }

        private void idCompraText_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (idReservaText.Text.Length == 0)
            {
                MessageBox.Show("Ingrese un codiggo de reserva");
                return;
            }
            SqlDataReader datosReserva;
            try
            {
            string consulta = "   select top 1  [id_reserva] ,[reserva_fecha] ,[reserva_cantidad_pasajes] ,[reserva_cliente] ,[reserva_viaje] FROM [GD1C2019].[LOS_BARONES_DE_LA_CERVEZA].[Reserva] "
                                + " WHERE id_reserva = " + idReservaText.Text;
            Query miConsulta = new Query(consulta, new List<Parametro>());
            datosReserva = miConsulta.ejecutarReaderFila();

                MessageBox.Show(datosReserva["reserva_viaje"].ToString());
            }
            catch (Exception unError)
            {
                MessageBox.Show("Codigo de reserva no encontrado");
                unError.ToString();
                return;
            }
            id_reserva = int.Parse(datosReserva["id_reserva"].ToString());
            reserva_cliente_id = int.Parse(datosReserva["reserva_cliente"].ToString());
            int viaje_id = int.Parse(datosReserva["reserva_viaje"].ToString());

            this.viaje = new Viaje(viaje_id);
        }
    }
}

/*   public PagoForm(List<DisplayCabina> cabinas, Viaje unViaje,Cliente unCliente,bool esUnaCompra )    */