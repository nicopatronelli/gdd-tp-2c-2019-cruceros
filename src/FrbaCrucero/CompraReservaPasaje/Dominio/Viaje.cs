using FrbaCrucero.Utils;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrbaCrucero.CompraReservaPasaje
{
    public class Viaje
    {
        public int id_viaje;
        public string fecha_inicio;
        public int id_crucero;
        public int id_recorrido;
        public string origen;
        public string puertos;

        public Viaje(int id)
        {
            this.id_viaje = id;
            var consulta = " select cast(v.viaje_fecha_inicio as nvarchar(255)) as fecha_inicio, cast(viaje_id_crucero as nvarchar(255)) as id_crucero, cast(viaje_id_recorrido as nvarchar(255)) as id_recorrido  from [GD1C2019].[LOS_BARONES_DE_LA_CERVEZA].[Viaje] v     where id_viaje =" + this.id_viaje.ToString();

            Query miConsulta = new Query(consulta, new List<Parametro>());
            SqlDataReader datosPersonales = miConsulta.ejecutarReaderFila();
            datosPersonales.Read();
            this.fecha_inicio = DateTime.Parse(Convert.ToString(datosPersonales["fecha_inicio"])).ToShortDateString();
            this.id_crucero = Convert.ToInt32(datosPersonales["id_crucero"]);
            this.id_recorrido = Convert.ToInt32(datosPersonales["id_recorrido"]);
        }

        public string mostrarPuertos()
        {
            return "\n" + puertos;
        }

        public string nombreCrucero()
        {
            //devuelve el nombre del crucero del viaje
            string consulta = " select c.identificador from [GD1C2019].[LOS_BARONES_DE_LA_CERVEZA].[Cruceros] c join [GD1C2019].[LOS_BARONES_DE_LA_CERVEZA].[Viaje] v on c.id_crucero = v.viaje_id_crucero "
               + " where v.id_viaje = " + this.id_viaje.ToString();
            Query miConsulta = new Query(consulta, new List<Parametro>());
            return miConsulta.ejecutarEscalar().ToString();



        }
    }
}
