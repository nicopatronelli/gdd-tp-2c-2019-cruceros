using FrbaCrucero.AbmCrucero;
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

namespace FrbaCrucero.CompraReservaPasaje
{
    public partial class PagoForm : Form
    {
        public List<DisplayCabina> displayCabinas;
        public Viaje viaje;
        public Cliente cliente;
        public double precioBase;
        public double precioTotal;
        public int idCompra;

        public PagoForm(List<DisplayCabina> cabinas, Viaje unViaje,Cliente unCliente )
        {
            this.displayCabinas = cabinas;
            this.viaje = unViaje;
            this.cliente = unCliente;
            InitializeComponent();

            //calculo precio base del recorrido
            string consulta = " select sum(t.tramo_precio) from [GD1C2019].[LOS_BARONES_DE_LA_CERVEZA].[Tramos_por_Recorrido] txr join [GD1C2019].[LOS_BARONES_DE_LA_CERVEZA].[Tramo] t on t.id_tramo = txr.id_tramo "+
	                " where id_recorrido = "+viaje.id_recorrido.ToString();
            Query miConsulta = new Query(consulta, new List<Parametro>());
            precioBase = double.Parse(miConsulta.ejecutarEscalar().ToString());
            mostrarInfoCompra();
            conseguirMetodosDePago();
        }

        public void mostrarInfoCompra()
        {
            precioTotal=0;
            infoCompraLabel.Text = "El precio base del recorrido es: " + precioBase.ToString() + ":\n";
            displayCabinas.ForEach(x =>
            {
                infoCompraLabel.Text += x.mostrarDescripcionCosto(precioBase);
                precioTotal += x.costoFinal(precioBase);
            }
            );
            infoCompraLabel.Text += "\n\n        El Precio Total Final es: "+precioTotal.ToString();
        }
        public void conseguirMetodosDePago()
        {
            formaPagoUpDown.Items.Clear();
            string consulta = "  select forma_de_pago_nombre FROM [GD1C2019].[LOS_BARONES_DE_LA_CERVEZA].[Forma_de_pago]";
            Query miConsulta = new Query(consulta, new List<Parametro>());
            SqlDataReader nombresFormaPago = miConsulta.ejecutarReaderFila();
            formaPagoUpDown.Items.Add(nombresFormaPago["forma_de_pago_nombre"]);
            nombresFormaPago.Read();
            formaPagoUpDown.Items.Add(nombresFormaPago["forma_de_pago_nombre"]);
        }

       


        public int generarCompra()
        {
            List<Parametro> parametros = new List<Parametro>();

            //agregamos parametro cantidad de cabinas
            Parametro paramCantidadCabinas = new Parametro("@cantidad_cabinas", SqlDbType.Int, 5);
            parametros.Add(paramCantidadCabinas);

            // Añadimos el parámetro identificador del viaje asociado a la compra
            Parametro paramIdViaje = new Parametro("@id_viaje", SqlDbType.Int, viaje.id_viaje);
            parametros.Add(paramIdViaje);

            Parametro paramIdCliente= new Parametro("@id_cliente", SqlDbType.Int, cliente.id);
            parametros.Add(paramIdCliente);

            //agregamos el costo total de la compra

            Parametro paramPrecioConRecargo = new Parametro("@precio_con_recargo", SqlDbType.Float, (float)this.precioTotal);
            parametros.Add(paramPrecioConRecargo);


            // Añadimos el parámetro de salida donde obtenemos el id_compra generado

            Parametro paramIdCompra = new Parametro("@id_compra", SqlDbType.Int);
            paramIdCompra.esParametroOut();
            parametros.Add(paramIdCompra);

            StoreProcedure spGenerarCompra = new StoreProcedure("LOS_BARONES_DE_LA_CERVEZA.USP_generar_compra", parametros);
            int cantidadFilasActualizadas = spGenerarCompra.ejecutarNonQuery();

            // Comprobamos que la compra se inserte correctamente
            if (!cantidadFilasActualizadas.Equals(1))
                MessageBox.Show("No se genero bien la comnpra----filas afectadas= "+cantidadFilasActualizadas.ToString());
            else
            {
                // label9.Text = cantidadFilasActualizadas.ToString();
                MessageBox.Show("Compra generada bien, el id es = " + paramIdCompra.obtenerValor().ToString());
            }

            return Int32.Parse(paramIdCompra.obtenerValor().ToString());



        }

        private void formaPagoUpDown_SelectedItemChanged(object sender, EventArgs e)
        {
            button1.Enabled = true;
            tarjetaTextBox.Visible= false;
            tarjetaTextBox.Text="";
            if (formaPagoUpDown.SelectedItem.ToString() == "Tarjeta")
            {
                this.mostrarOpcionesTarjeta();
            }
            else
                if (formaPagoUpDown.SelectedItem.ToString() == "Efectivo")
                {
                    this.mostrarOpcionesEfectivo();
                }
                else
                {
                    labelFormaPago.Text = "Procedimiento de pago aun no implementado";
                }   
        }

        public void mostrarOpcionesTarjeta()
        {
            labelFormaPago.Text = "Tarjeta--Ingrese los 16 digitos de su tarjeta de credito";
            tarjetaTextBox.Visible= true;
        }
        public void mostrarOpcionesEfectivo()
        {
            button1.Text = "Aceptar";
            labelFormaPago.Text = "Efectivo-- Pague el monto correspondiente con efectivo en \nun Rapi-pago o  unPagoFacil en la siguiente cuenta: 155555566903859.\n Seleccione Aceptar cuando el pago esté hecho";
        }

        private void tarjetaTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (formaPagoUpDown.SelectedItem.ToString() == "Tarjeta" && tarjetaTextBox.Text.Length < 16)
            {
                MessageBox.Show("Ingrese un numero de tarjeta de 16 digitos");
                return;
            }
            MessageBox.Show("Pago recibido");
            this.efectuarCompra();
            this.Close();
        }

        private void efectuarCompra()
        {
            this.idCompra = this.generarCompra();
            List<Cabina> cabinasPagadas = new List<Cabina>();
            displayCabinas.ForEach( display => cabinasPagadas.AddRange(display.cabinasPagadas(viaje.id_viaje, idCompra)));
            Form form = new VoucherForm(cabinasPagadas, cliente, viaje, idCompra, true, precioTotal);  //el true es para marcar que es una compra y no una reserva
        }

    }
}
