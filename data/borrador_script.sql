---- BORRADOR ------
USE GD1C2019

-- Listado de cabinas con info de su crucero
SELECT cru.identificador, cab.id_cabina, cab.tipo_cabina, tc.tipo_cabina, cru.modelo, mar.marca, cab.numero, cab.piso, cab.estado
FROM LOS_BARONES_DE_LA_CERVEZA.Cabinas cab
	JOIN LOS_BARONES_DE_LA_CERVEZA.Tipos_Cabinas tc
		ON cab.tipo_cabina = tc.id_tipo_cabina
	JOIN LOS_BARONES_DE_LA_CERVEZA.Cruceros cru
		ON cab.crucero = cru.id_crucero
	JOIN LOS_BARONES_DE_LA_CERVEZA.Marcas_Cruceros mar
		ON cru.marca = mar.id_marca

-- Detalle Cruceros (sin cabinas)
SELECT cru.identificador, cru.modelo, mar.marca, COUNT(cab.crucero) 'Cantidad cabinas'
FROM LOS_BARONES_DE_LA_CERVEZA.Cruceros cru
	JOIN LOS_BARONES_DE_LA_CERVEZA.Marcas_Cruceros mar
		ON cru.marca = mar.id_marca
	JOIN LOS_BARONES_DE_LA_CERVEZA.Cabinas cab
		ON cru.id_crucero = cab.crucero
GROUP BY cru.identificador, cru.modelo, mar.marca

-- Baja definitiva 
UPDATE LOS_BARONES_DE_LA_CERVEZA.Cruceros 
SET 
baja_vida_util = 0, 
fecha_baja_vida_util = NULL
WHERE identificador = 'ABCDEF-98765'

/******************************************************************
@TEST: BAJA DEFINITIVA
******************************************************************/

-- Eliminar baja definitiva 
UPDATE LOS_BARONES_DE_LA_CERVEZA.Cruceros 
SET 
	baja_vida_util = 0,
	fecha_baja_vida_util = NULL

-- Cruceros baja definitiva
SELECT cru.identificador, cru.modelo, cru.baja_vida_util, cru.fecha_baja_vida_util
FROM LOS_BARONES_DE_LA_CERVEZA.Cruceros cru


/******************************************************************
@TEST: BAJA FUERA DE SERVICIO
******************************************************************/

-- Eliminar fueras de servicio (vuelven a estar disponibles)
UPDATE LOS_BARONES_DE_LA_CERVEZA.Cruceros 
SET baja_fuera_servicio = 0

-- Cruceros Fuera de servicio
SELECT cru.identificador, cru.modelo, cru.baja_fuera_servicio, fs.fecha_inicio_fuera_servicio, 
	fs.fecha_fin_fuera_servicio
FROM LOS_BARONES_DE_LA_CERVEZA.Cruceros cru
	JOIN LOS_BARONES_DE_LA_CERVEZA.Cruceros_Fuera_Servicio fs
		ON cru.id_crucero = fs.id_crucero

/******************************************************************
@TEST: QUERY PARA OBTENER LOS CRUCEROS DISPONIBLES 
El objetivo es obtener el identificador de aquellos cruceros que
están disponibles para realizar un nuevo viaje. Para ello, tenemos
que considerar el la fecha de fin del último viaje de cada crucero, 
y asegurarnos que dicha fecha sea menor a la fecha de inicio del
nuevo viaje que se está queriendo crear. 

Nota: Hay 37 cruceros distintos en total de la migración. 
******************************************************************/

DECLARE @fecha_inicio_mi_viaje DATETIME2(3) = (CONVERT(DATETIME2(3), '2018-08-03', 121))
SELECT DISTINCT cru.crucero_identificador
FROM LOS_BARONES_DE_LA_CERVEZA.Crucero cru
	JOIN LOS_BARONES_DE_LA_CERVEZA.Viaje via
		ON cru.id_crucero = via.viaje_id_crucero
WHERE @fecha_inicio_mi_viaje > 
		(
			-- Le fecha de inicio de mi viaje debe ser mayor a la fecha de fin del 
			-- último viaje asignado del crucero
			SELECT TOP 1 via2.viaje_fecha_fin 
			FROM LOS_BARONES_DE_LA_CERVEZA.Crucero cru2
				JOIN LOS_BARONES_DE_LA_CERVEZA.Viaje via2
					ON cru2.id_crucero = via2.viaje_id_crucero
			WHERE cru2.crucero_identificador = cru.crucero_identificador
			ORDER BY 1 DESC
		)
ORDER BY 1

SELECT cru.crucero_identificador, via.viaje_fecha_fin
FROM LOS_BARONES_DE_LA_CERVEZA.Crucero cru
	JOIN LOS_BARONES_DE_LA_CERVEZA.Viaje via
		ON cru.id_crucero = via.viaje_id_crucero
ORDER BY via.viaje_fecha_fin DESC


