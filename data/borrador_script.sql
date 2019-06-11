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
GROUP BY cru.identificador, cru.modelo, mar.marca, cru.baja_fuera_servicio, 

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

-- Eliminar fuera de servicio 
UPDATE LOS_BARONES_DE_LA_CERVEZA.Cruceros 
SET baja_fuera_servicio = 0
UPDATE LOS_BARONES_DE_LA_CERVEZA.Cruceros_Fuera_Servicio
SET fecha_inicio_fuera_servicio = NULL, fecha_fin_fuera_servicio = NULL

-- Cruceros Fuera de servicio
SELECT cru.identificador, cru.baja_fuera_servicio, fs.fecha_inicio_fuera_servicio, 
	fs.fecha_fin_fuera_servicio
FROM LOS_BARONES_DE_LA_CERVEZA.Cruceros cru
	JOIN LOS_BARONES_DE_LA_CERVEZA.Cruceros_Fuera_Servicio fs
		ON cru.id_crucero = fs.id_crucero

SELECT * 
FROM LOS_BARONES_DE_LA_CERVEZA.Cruceros

SELECT *
FROM LOS_BARONES_DE_LA_CERVEZA.Cruceros_Fuera_Servicio