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
            string consulta = "select TOP 5 Sumas.recorri as Recorrido, "
                        + " AVG(Sumas.cabinas) as Promedios_cabinas_libres "
                    + "from (select REC.recorrido_codigo as recorri, VI.id_viaje as viaj, COUNT(CAB.id_cabina) cabinas "
                          + "from LOS_BARONES_DE_LA_CERVEZA.Recorrido REC join LOS_BARONES_DE_LA_CERVEZA.Viaje VI on REC.id_recorrido = VI.viaje_id_recorrido "
                        + "join LOS_BARONES_DE_LA_CERVEZA.Cabinas CAB on CAB.crucero = VI.viaje_id_crucero "
                    + " where CAB.id_cabina NOT IN (select ECV.id_cabina from LOS_BARONES_DE_LA_CERVEZA.Estado_Cabinas_Por_Viaje ECV where ECV.id_viaje = VI.id_viaje and ECV.compra IS NOT NULL) "
                        + "AND (VI.viaje_fecha_fin_estimada BETWEEN " + rangoFechas + " "
                        + "OR viaje_fecha_inicio BETWEEN " + rangoFechas + " ) "
                    + "group by REC.recorrido_codigo, VI.id_viaje) as Sumas "
                    + "group by Sumas.recorri order by Promedios_cabinas_libres desc";
            return consulta;
        }

        public static string crucerosConMasDiasFueraServicio(string anio, string semestre)
        {
            return "select * from LOS_BARONES_DE_LA_CERVEZA.UF_listado_fuera_de_servicio("+ anio + "," + semestre + ")";
            /*
            return "select top 5 FS.id_crucero,CRU.identificador, CRU.modelo, "
                    + "(SUM(datediff(DAY, case when FS.fecha_inicio_fuera_servicio < " + inicioSem + " then " + inicioSem + " else FS.fecha_inicio_fuera_servicio end, case when FS.fecha_fin_fuera_servicio > " + finSem + " then " + finSem + " else FS.fecha_fin_fuera_servicio end ))) as diferencia "
                    + "from LOS_BARONES_DE_LA_CERVEZA.Cruceros_Fuera_Servicio FS join LOS_BARONES_DE_LA_CERVEZA.Cruceros CRU on (CRU.id_crucero = FS.id_crucero) "
                    + "where (FS.fecha_fin_fuera_servicio BETWEEN " + rangoFechas + " "
                            + "OR FS.fecha_inicio_fuera_servicio BETWEEN " + rangoFechas + " ) "
                    + "group by FS.id_crucero,CRU.identificador,CRU.modelo order by diferencia desc "; */
        }

    }
}

