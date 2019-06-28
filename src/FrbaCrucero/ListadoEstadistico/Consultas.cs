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
                     + "SUM(c.compra_cantidad) cantidad_pasajes_comprados, "
                     + "pto_inicio.puerto_nombre puerto_inicial, "
                     + "pto_fin.puerto_nombre puerto_final "
                 + "FROM LOS_BARONES_DE_LA_CERVEZA.Recorrido r "
                    + "JOIN LOS_BARONES_DE_LA_CERVEZA.Viaje v "
                        + "ON r.id_recorrido = v.viaje_id_recorrido "
                    + "JOIN LOS_BARONES_DE_LA_CERVEZA.Compra c "
                        + "ON v.id_viaje = c.compra_id_viaje "
                    + "JOIN LOS_BARONES_DE_LA_CERVEZA.Tramos_por_Recorrido tpr1 "
                        + "ON r.id_recorrido = tpr1.id_recorrido "
                    + "JOIN LOS_BARONES_DE_LA_CERVEZA.Tramos_por_Recorrido tpr2 "
                        + "ON r.id_recorrido = tpr2.id_recorrido "
                    + "JOIN LOS_BARONES_DE_LA_CERVEZA.Tramo t1 "
                        + "ON tpr1.id_tramo = t1.id_tramo "
                    + "JOIN LOS_BARONES_DE_LA_CERVEZA.Tramo t2 "
                        + "ON tpr2.id_tramo = t2.id_tramo "
                    + "JOIN LOS_BARONES_DE_LA_CERVEZA.Puerto pto_inicio "
                        + "ON t1.tramo_puerto_inicio = pto_inicio.id_puerto "
                    + "JOIN LOS_BARONES_DE_LA_CERVEZA.Puerto pto_fin "
                        + "ON t2.tramo_puerto_destino = pto_fin.id_puerto "
                + "WHERE tpr1.tramo_anterior IS NULL "
                    + "AND tpr2.tramo_siguiente IS NULL "
                    + "AND c.compra_fecha BETWEEN " + rangoFechas + " "
                + "GROUP BY r.recorrido_codigo, pto_inicio.puerto_nombre, pto_fin.puerto_nombre "
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
