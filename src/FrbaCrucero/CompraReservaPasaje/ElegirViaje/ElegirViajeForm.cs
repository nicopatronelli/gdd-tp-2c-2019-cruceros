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
    public partial class ElegirViajeForm : Form
    {
        string puertoOrigen;
        string puertoDestino;
        DateTime fechaSalida;
        //List<int> recorridos;
        public ElegirViajeForm(string puertoOrigen, string puertoDestino, DateTime fechaSalida)
        {
            this.puertoOrigen = puertoOrigen;
            this.puertoDestino = puertoDestino;
            this.fechaSalida = fechaSalida;
            InitializeComponent();
        }

        private void ElegirViajeFormLoad(object sender, EventArgs e)
        {
            string consulta = "SELECT cast(id_recorrido as nvarchar(255)) as id_recorrido from[GD1C2019].[LOS_BARONES_DE_LA_CERVEZA].[UF_recorridos_segun_origen_y_destino]('" + puertoOrigen + "', '" + puertoDestino + "')";

            this.cargarTipoCabinas();

            Query miConsulta = new Query(consulta, new List<Parametro>());
            var recorridos =  miConsulta.ejecutarReaderUnicaColumna();
            foreach (var o in recorridos)
            {
                this.recorridosList.Items.Add(o);
            }
        }


        private void Button1_Click(object sender, EventArgs e)
        {
            //Efectuar pago o reserva
        }

        private void recorridosList_SelectedValueChanged(object sender, EventArgs e)
        {
            this.crucerosList.Items.Clear();
            this.puertosList.Items.Clear();
            this.actualizarPuertos();
            this.actualizarCruceros();
        }

        private void actualizarPuertos()
        {

            string consulta = "SELECT puerto_nombre from[GD1C2019].[LOS_BARONES_DE_LA_CERVEZA].[UF_destinos_segun_recorrido]('" + recorridosList.SelectedItem + "')";

            Query miConsulta = new Query(consulta, new List<Parametro>());
            var destinos =  miConsulta.ejecutarReaderUnicaColumna();
            foreach (var o in destinos)
            {
                this.puertosList.Items.Add(o);
            }
        }

        private void actualizarCruceros()
        {
            
            string consulta = " select cast(id_viaje as nvarchar(255)) from GD1C2019.LOS_BARONES_DE_LA_CERVEZA.Viaje v  "
                                + " where	CONVERT(VARCHAR(10), v.viaje_fecha_inicio, 103) = '" + this.fechaSalida.ToShortDateString() +"'  ";		//el 103 es para pasarlo al format dd/mm/yyyy


            Query miConsulta = new Query(consulta, new List<Parametro>());
            var destinos = miConsulta.ejecutarReaderUnicaColumna();     
            foreach (var o in destinos)
            {
                this.crucerosList.Items.Add(o);
            }

        }

        private void cargarTipoCabinas()
        {
            string consulta = "select tipo_cabina from GD1C2019.LOS_BARONES_DE_LA_CERVEZA.Tipos_Cabinas";
            Query miConsulta = new Query(consulta, new List<Parametro>());
            var destinos = miConsulta.ejecutarReaderUnicaColumna();
            foreach (var o in destinos)
            {
                this.selectorCabinas.Items.Add(o);
            }


        }

        private void selectorCabinas_SelectedValueChanged(object sender, EventArgs e)
        {
            //TODO calcular cuando este disponible cabinas totales - cabinas vendidas
        }


    }
}



/*

    
  --recorrido anterior es nulo-> el puerto origen es el posta
  -- puede haber mas de un reccorido con mismo origen y destino


  select v.* from [LOS_BARONES_DE_LA_CERVEZA].[Recorrido] r 
  inner join [GD1C2019].[LOS_BARONES_DE_LA_CERVEZA].[Viaje] v on v.viaje_id_recorrido = r.id_recorrido
  where recorrido_anterior is null 
  and r.recorrido_codigo in (select recorrido_codigo from [GD1C2019].[LOS_BARONES_DE_LA_CERVEZA].[Recorrido] 
  where 
  recorrido_puerto_inicio =19--'pasar origen'
  or  recorrido_puerto_destino =40)  --'pasar destino'

  ---19 y 40 


    select r.* from [LOS_BARONES_DE_LA_CERVEZA].[Recorrido] r 
  left join [GD1C2019].[LOS_BARONES_DE_LA_CERVEZA].[Viaje] v on v.viaje_id_recorrido = r.id_recorrido
  where recorrido_anterior is null and recorrido_codigo ='43820866'
  and recorrido_codigo in (select recorrido_codigo from [GD1C2019].[LOS_BARONES_DE_LA_CERVEZA].[Recorrido] 
  where 
  recorrido_puerto_inicio =19
  or  recorrido_puerto_destino =40)  
*/