using FrbaCrucero.AbmCrucero;
using FrbaCrucero.Utils;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrbaCrucero.CompraReservaPasaje
{
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



        public void mostrarDisponibles(int idViaje)
        {
            this.cantidadSeleccionadaNumeric.Value = 0;
            //CALCULO CABINAS TOTALES DE ESTE TIPO QUE TIENE EL CRUCERO
            string consulta = ""
              + " 	SELECT count(cab.id_cabina) as cabinasTotales from [GD1C2019].[LOS_BARONES_DE_LA_CERVEZA].[Viaje] v "
                    + "   join [GD1C2019].[LOS_BARONES_DE_LA_CERVEZA].[Cabinas] cab "
                    + "   on cab.crucero = v.viaje_id_crucero "
                    + "   where v.id_viaje = " + idViaje.ToString() + " and cab.tipo_cabina = " + this.tipoCabina.id.ToString();

            Query miConsulta = new Query(consulta, new List<Parametro>());
            int cabinasTotales = (int)miConsulta.ejecutarEscalar();

            consulta = ""
              + " 	SELECT COUNT(cxv.id_cabina) as cabinasOcupadas from [GD1C2019].[LOS_BARONES_DE_LA_CERVEZA].[Estado_Cabinas_Por_Viaje] cxv"
                    + "   join [GD1C2019].[LOS_BARONES_DE_LA_CERVEZA].[Cabinas] c "
                    + "   on cxv.id_cabina = c.id_cabina "
                    + "   where (c.tipo_cabina = " + this.tipoCabina.id.ToString() + " and cxv.id_viaje = " + idViaje.ToString() + ") and ( cxv.compra IS NOT null  or  cxv.reserva IS NOT null) ";
            miConsulta = new Query(consulta, new List<Parametro>());
            int cabinasOcupadas = (int)miConsulta.ejecutarEscalar();
            int cabinasDisponibles = cabinasTotales - cabinasOcupadas;

            this.cantidadDisponibleLabel.Text = cabinasDisponibles.ToString();
            this.cantidadSeleccionadaNumeric.Maximum = cabinasDisponibles;
        }

        public string mostrarDescripcionCosto(double precioBase)
        {
            return "---" + this.cantidadSeleccionadaNumeric.Value.ToString() + " " + this.tipoCabina.descripcion + " con un multiplicador de " + this.recargoLabel.Text + "  suma: -----------  " + this.costoFinal(precioBase).ToString()+ "\n";
        }

        public double costoFinal(double precioBase)
        {
            return ((double)this.cantidadSeleccionadaNumeric.Value) * this.tipoCabina.precio * precioBase;
        }

        public List<Cabina> cabinasPagadas(int idViaje, int idCompra)//
        {
            List<Cabina> cabinasResult = new List<Cabina>();
            string consulta = "  select top " + this.cantidadSeleccionadaNumeric.Value.ToString() + "  c.id_cabina, c.numero, c.piso  from [GD1C2019].[LOS_BARONES_DE_LA_CERVEZA].[Viaje] v  "
                              + "        join [GD1C2019].[LOS_BARONES_DE_LA_CERVEZA].[Cabinas] c "
                              + "        on c.crucero = v.viaje_id_crucero "
                              + "        where v.id_viaje = " + idViaje.ToString() + " and c.id_cabina not in (   "
                              + "              select cxv.id_cabina FROM [GD1C2019].[LOS_BARONES_DE_LA_CERVEZA].[Estado_Cabinas_Por_Viaje] cxv  "
                              + "              where cxv.id_viaje = " + idViaje.ToString()
                              + "                      ) and c.tipo_cabina = " + this.tipoCabina.id.ToString();
            Query miConsulta = new Query(consulta, new List<Parametro>());
            SqlDataReader infoCabina = miConsulta.ejecutarReaderFila();
            Cabina cabinaNueva;
            do
            {
                cabinaNueva = new Cabina();
                if (infoCabina.HasRows)
                {
                    cabinaNueva.setId(Int32.Parse(infoCabina["id_cabina"].ToString())).setNumero(Int32.Parse(infoCabina["numero"].ToString())).setPiso(Int32.Parse(infoCabina["piso"].ToString()));
                    cabinasResult.Add(cabinaNueva);
                    cabinaNueva.comprarse(idViaje, idCompra);
                }
            }
            while (infoCabina.Read());
            return cabinasResult;
        }
    }
}
