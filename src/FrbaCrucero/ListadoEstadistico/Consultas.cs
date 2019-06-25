using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrbaCrucero.ListadoEstadistico
{
    public class Consultas
    {
        public static string recorridosConMasPasajesComprados(string rangoFechas)
        {
            return "SELECT TOP 5 r.recorrido_codigo identificador_recorrido, "
                     + "SUM(c.compra_cantidad) cantidad_pasajes_comprados "
                 + "FROM LOS_BARONES_DE_LA_CERVEZA.Recorrido r "
                    + "JOIN LOS_BARONES_DE_LA_CERVEZA.Viaje v "
                        + "ON r.id_recorrido = v.viaje_id_recorrido "
                    + "JOIN LOS_BARONES_DE_LA_CERVEZA.Compra c "
                        + "ON v.id_viaje = c.compra_id_viaje "
                + "WHERE c.compra_fecha BETWEEN " + rangoFechas + " " 
                + "GROUP BY r.recorrido_codigo "
                + "ORDER BY 2 DESC";
        }

        public static string recorridosConMasCabinasLibres(string rangoFechas)
        {
            return "";
        }

        public static string crucerosConMasDiasFueraServicio(string rangoFechas)
        {
            return "";
        }

    }
}
