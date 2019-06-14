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
        public ElegirViajeForm(string puertoOrigen, string puertoDestino, DateTime fechaSalida)
        {
            this.puertoOrigen = puertoOrigen;
            this.puertoDestino = puertoDestino;
            this.fechaSalida = fechaSalida;
            InitializeComponent();
        }

        private void Eleccion_Crucero(object sender, EventArgs e)
        {
            this.cargarCabinas();

        }



        private void cargarCabinas()
        {

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            //Efectuar pago o reserva
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