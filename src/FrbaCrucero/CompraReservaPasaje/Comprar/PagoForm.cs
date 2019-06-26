using FrbaCrucero.Utils;
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







        public void generarCompra()
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

            // Añadimos el parámetro de salida donde obtenemos el id_compra generado

            Parametro paramIdCompra = new Parametro("@id_compra", SqlDbType.Int);
            paramIdCompra.esParametroOut();
            parametros.Add(paramIdCompra);

            // Creamos la llamada al SP "USP_actualizar_recorrido" de la BD y lo ejecutamos 
            StoreProcedure spGenerarCompra = new StoreProcedure("LOS_BARONES_DE_LA_CERVEZA.USP_generar_compra", parametros);
            int cantidadFilasActualizadas = spGenerarCompra.ejecutarNonQuery();

            // Comprobamos que el recorrido se inserte correctamente
            if (!cantidadFilasActualizadas.Equals(1))
                label1.Text = cantidadFilasActualizadas.ToString();
            else
            {
                // label9.Text = cantidadFilasActualizadas.ToString();
                label1.Text = Convert.ToInt32(paramIdCompra.obtenerValor()).ToString();
            }
            // FIN insertarRecorrido()



        }




    }
}
