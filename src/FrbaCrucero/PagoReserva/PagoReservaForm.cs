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
            string consulta;
            Query miConsulta;
            try
            {
             consulta = "   select top 1  r.id_reserva ,r.reserva_fecha ,r.reserva_cantidad_pasajes ,r.reserva_cliente ,r.reserva_viaje FROM [GD1C2019].[LOS_BARONES_DE_LA_CERVEZA].[Reserva] r "
                        + " join [GD1C2019].[LOS_BARONES_DE_LA_CERVEZA].[Estado_Cabinas_Por_Viaje] cxv   ON r.id_reserva = cxv.reserva "
                                + " WHERE id_reserva = " + idReservaText.Text;
             miConsulta = new Query(consulta, new List<Parametro>());
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
            Cliente cliente = new Cliente(reserva_cliente_id);

            //hago un display cabina porque asi lo toma el pago form
            List<DisplayCabina> displaysCabinas = new List<DisplayCabina>();
            displaysCabinas.Add(new DisplayCabina(new Label(), new NumericUpDown() ,new Label(), new Label()));
            displaysCabinas.Add(new DisplayCabina(new Label(), new NumericUpDown(), new Label(), new Label()));
            displaysCabinas.Add(new DisplayCabina(new Label(), new NumericUpDown(), new Label(), new Label()));
            displaysCabinas.Add(new DisplayCabina(new Label(), new NumericUpDown(), new Label(), new Label()));
            displaysCabinas.Add(new DisplayCabina(new Label(), new NumericUpDown(), new Label(), new Label()));


            consulta = "SELECT TOP 1000 [id_tipo_cabina] ,[tipo_cabina] ,[porcentaje_recargo] FROM [GD1C2019].[LOS_BARONES_DE_LA_CERVEZA].[Tipos_Cabinas]";
            miConsulta = new Query(consulta, new List<Parametro>());
            SqlDataReader datosCabina = miConsulta.ejecutarReaderFila();
            TipoCabina nuevaCabina;
            for (int count = 0; count < 5; count++)
            {
                nuevaCabina = new TipoCabina((int)datosCabina["id_tipo_cabina"], datosCabina["tipo_cabina"].ToString(), double.Parse(datosCabina["porcentaje_recargo"].ToString()));
                displaysCabinas[count].setTipoCabina(nuevaCabina);
                displaysCabinas[count].cargarCabinasReservadas(id_reserva);
                datosCabina.Read();
            }


            PagoForm pagoForm = new PagoForm(displaysCabinas, viaje, cliente, false, id_reserva);
            pagoForm.ShowDialog();
            pagoForm.Close();
        }
    }
}

/*   public PagoForm(List<DisplayCabina> cabinas, Viaje unViaje,Cliente unCliente,bool esUnaCompra )    */