﻿using FrbaCrucero.CompraReservaPasaje;
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
        //List<int> recorridos;
        public int viajeSeleccionadoId;
        public List<TipoCabina> tipoCabinas = new List<TipoCabina>();
        public List<DisplayCabina> diplaysCabinas = new List<DisplayCabina>();

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

            //agrupo los controllers (label, numeric UpDown y label) que muestran tipoCabinas
            this.diplaysCabinas.Add(new DisplayCabina(cabinas1DisponiblesLabel, cabinas1Numeric, cabinas1Label, recargoLabel1));
            this.diplaysCabinas.Add(new DisplayCabina(cabinas2DisponiblesLabel, cabinas2Numeric, cabinas2Label, recargoLabel2));
            this.diplaysCabinas.Add(new DisplayCabina(cabinas3DisponiblesLabel, cabinas3Numeric, cabinas3Label, recargoLabel3));
            this.diplaysCabinas.Add(new DisplayCabina(cabinas4DisponiblesLabel, cabinas4Numeric, cabinas4Label, recargoLabel4));
            this.diplaysCabinas.Add(new DisplayCabina(cabinas5DisponiblesLabel, cabinas5Numeric, cabinas5Label, recargoLabel5));


            consulta = "SELECT TOP 1000 [id_tipo_cabina] ,[tipo_cabina] ,[porcentaje_recargo] FROM [GD1C2019].[LOS_BARONES_DE_LA_CERVEZA].[Tipos_Cabinas]";
            miConsulta = new Query(consulta, new List<Parametro>());
            SqlDataReader datosCabina = miConsulta.ejecutarReaderFila();
            TipoCabina nuevaCabina;
            for (int count = 0; count < 5; count++)
            {
                nuevaCabina = new TipoCabina((int)datosCabina["id_tipo_cabina"], datosCabina["tipo_cabina"].ToString(), double.Parse(datosCabina["porcentaje_recargo"].ToString()));
                this.tipoCabinas.Add(nuevaCabina);
                this.diplaysCabinas[count].setTipoCabina(nuevaCabina);
                datosCabina.Read();
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

            string consulta = ""
                          + "  select cast(id_viaje as nvarchar(255)) as id from GD1C2019.LOS_BARONES_DE_LA_CERVEZA.Viaje v   where v.viaje_id_recorrido = 13 AND CONVERT(VARCHAR(10), v.viaje_fecha_inicio, 103) = '24/05/2018'";
		//el 103 es para pasarlo al format dd/mm/yyyy


            Query miConsulta = new Query(consulta, new List<Parametro>());
            var destinos = miConsulta.ejecutarReaderUnicaColumna();     
            foreach (var o in destinos)
            {
                this.crucerosList.Items.Add(o);
            }

        }

        private void cargarTipoCabinas()
        {
            //string consulta = "select tipo_cabina from GD1C2019.LOS_BARONES_DE_LA_CERVEZA.Tipos_Cabinas";
            //Query miConsulta = new Query(consulta, new List<Parametro>());
            //var destinos = miConsulta.ejecutarReaderUnicaColumna();
            //foreach (var o in destinos)
            //{
            //    this.selectorCabinas.Items.Add(o);
            //}


        }

        private void selectorCabinas_SelectedValueChanged(object sender, EventArgs e)
        {
            //TODO calcular cuando este disponible cabinas totales - cabinas vendidas
        }

        private void buttonComprar_Click(object sender, EventArgs e)
        {
            //ComprarTemplateForm comprarForm = new ComprarTemplateForm(selectorCabinas.SelectedItem.ToString(), (int)cabinas1Numeric.Value, int.Parse(crucerosList.SelectedItem.ToString()));
            //comprarForm.ShowDialog();
        }

        private void crucerosList_SelectedValueChanged(object sender, EventArgs e)
        {
            this.viajeSeleccionadoId = int.Parse(crucerosList.SelectedItem.ToString());
            this.mostrarCabinasDisponibles();
        }

        private void mostrarCabinasDisponibles()
        {

        }


    }


    public class DisplayCabina
    {
        public System.Windows.Forms.Label cantidadDisponibleLabel;
        public System.Windows.Forms.NumericUpDown cantidadSeleccionadaNumeric;
        public System.Windows.Forms.Label tipoCabinaLabel;
        public System.Windows.Forms.Label recargoLabel;
        public TipoCabina tipoCabina;

        public DisplayCabina(Label disponible, NumericUpDown cantidadSeleccionada, Label tipo, Label recargo)
        {
            this.cantidadDisponibleLabel = disponible;
            this.cantidadSeleccionadaNumeric = cantidadSeleccionada;
            this.tipoCabinaLabel = tipo;
            this.recargoLabel = recargo;
        }

        public void setTipoCabina(TipoCabina unTipoCabina)
        {
            this.tipoCabina = unTipoCabina;
            this.tipoCabinaLabel.Text = tipoCabina.ToString();
            this.recargoLabel.Text = unTipoCabina.precio.ToString();
        }

        public void viajeElegido(int viajeId)
        {
            this.cantidadSeleccionadaNumeric.Value = 0;
            string consulta = "count";
            Query miConsulta = new Query(consulta, new List<Parametro>());

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