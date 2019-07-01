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

namespace FrbaCrucero.CompraReservaPasaje
{
    public partial class ElegirViajeForm : Form
    {
        string puertoOrigen;
        string puertoDestino;
        DateTime fechaSalida;
        public int? viajeSeleccionadoId;
        public List<DisplayCabina> displaysCabinas = new List<DisplayCabina>();

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

            Query miConsulta = new Query(consulta, new List<Parametro>());
            var recorridos =  miConsulta.ejecutarReaderUnicaColumna();
            foreach (var o in recorridos)
            {
                if(!recorridosList.Items.Contains(o))
                    this.recorridosList.Items.Add(o);
            }

            //agrupo los controllers (label, numeric UpDown y label) que muestran tipoCabinas
            this.displaysCabinas.Add(new DisplayCabina(cabinas1DisponiblesLabel, cabinas1Numeric, cabinas1Label, recargoLabel1));
            this.displaysCabinas.Add(new DisplayCabina(cabinas2DisponiblesLabel, cabinas2Numeric, cabinas2Label, recargoLabel2));
            this.displaysCabinas.Add(new DisplayCabina(cabinas3DisponiblesLabel, cabinas3Numeric, cabinas3Label, recargoLabel3));
            this.displaysCabinas.Add(new DisplayCabina(cabinas4DisponiblesLabel, cabinas4Numeric, cabinas4Label, recargoLabel4));
            this.displaysCabinas.Add(new DisplayCabina(cabinas5DisponiblesLabel, cabinas5Numeric, cabinas5Label, recargoLabel5));


            consulta = "SELECT TOP 1000 [id_tipo_cabina] ,[tipo_cabina] ,[porcentaje_recargo] FROM [GD1C2019].[LOS_BARONES_DE_LA_CERVEZA].[Tipos_Cabinas]";
            miConsulta = new Query(consulta);
            SqlDataReader datosCabina = miConsulta.ejecutarReaderFila();
            TipoCabina nuevaCabina;
            for (int count = 0; count < 5; count++)
            {
                datosCabina.Read();
                nuevaCabina = new TipoCabina((int)datosCabina["id_tipo_cabina"], datosCabina["tipo_cabina"].ToString(), double.Parse(datosCabina["porcentaje_recargo"].ToString()));
                this.displaysCabinas[count].setTipoCabina(nuevaCabina);

            }




        }


        private void recorridosList_SelectedValueChanged(object sender, EventArgs e)
        {
            if (recorridosList.SelectedItem != null)
            {
                this.crucerosList.Items.Clear();
                this.puertosList.Items.Clear();
                this.actualizarPuertos();
                this.actualizarCruceros();
            }
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

            string consulta = ""
                          + "  select cast(id_viaje as nvarchar(255)) as id from GD1C2019.LOS_BARONES_DE_LA_CERVEZA.Viaje v   where v.viaje_id_recorrido = "+ recorridosList.SelectedItem.ToString() + "  AND CONVERT(VARCHAR(10), v.viaje_fecha_inicio, 103) = '"+this.fechaSalida.ToShortDateString()+ "'";
		//el 103 es para pasarlo al format dd/mm/yyyy


            Query miConsulta = new Query(consulta, new List<Parametro>());
            var destinos = miConsulta.ejecutarReaderUnicaColumna();     
            foreach (var o in destinos)
            {
                this.crucerosList.Items.Add(o);
            }

        }




        private void crucerosList_SelectedValueChanged(object sender, EventArgs e)
        {
            if (this.crucerosList.SelectedItem != null)
            {
                this.viajeSeleccionadoId = int.Parse(crucerosList.SelectedItem.ToString());
                this.mostrarCabinasDisponibles();
            }
        }

        private void mostrarCabinasDisponibles()
        {
            this.displaysCabinas.ForEach( x => x.mostrarDisponibles(this.viajeSeleccionadoId.Value));
        }

        private void ingresar_datos_click(object sender, EventArgs e)
        {
            if(!this.viajeSeleccionadoId.HasValue)
            {
                MessageBox.Show("Eliga un viaje y cabinas primero");
                return;
            }
            if (displaysCabinas.All(x => x.cantidadSeleccionadaNumeric.Value == 0))
            {
                MessageBox.Show("Eliga cabinas a comprar");
                return;                
            }
            
            ComprarTemplateForm comprarForm = new ComprarTemplateForm(displaysCabinas,viajeSeleccionadoId.Value, puertoOrigen);
            comprarForm.ShowDialog();
            this.Close();
        }


    }






}

//CALCULO CABINAS DISPONIBLES
/*
 * --CANTIDAD CABINAS DE DETERMINADO TIPO OCUPADAS PARA UN VIAJE
  select COUNT(cxv.id_cabina) as cabinasOcupadas from [GD1C2019].[LOS_BARONES_DE_LA_CERVEZA].[Estado_Cabinas_Por_Viaje] cxv
	join [GD1C2019].[LOS_BARONES_DE_LA_CERVEZA].[Cabinas] c
	on cxv.id_cabina = c.id_cabina
	where (c.tipo_cabina = 5 and cxv.id_viaje = 389) and ( cxv.compra IS NOT null  or  cxv.reserva IS NOT null)    

--CANTIDAD DE CABINAS DE UN TIPO DE DETERMINADO CRUCERO SEGUN UN VIAJE
	SELECT count(cab.id_cabina) as cabinasTotales from [GD1C2019].[LOS_BARONES_DE_LA_CERVEZA].[Viaje] v
		join [GD1C2019].[LOS_BARONES_DE_LA_CERVEZA].[Cabinas] cab
		on cab.crucero = v.viaje_id_crucero
		where v.id_viaje = 389 and cab.tipo_cabina = 5
 * 
 * */








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