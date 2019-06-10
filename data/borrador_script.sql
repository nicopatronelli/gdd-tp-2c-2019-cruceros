---- BORRADOR ------
USE GD1C2019

SELECT * 
FROM LOS_BARONES_DE_LA_CERVEZA.Cruceros

SELECT cab.id_cabina, cab.numero, cab.piso, cab.tipo_cabina, tc.tipo_cabina
FROM LOS_BARONES_DE_LA_CERVEZA.Cabinas cab
	JOIN LOS_BARONES_DE_LA_CERVEZA.Tipos_Cabinas tc
		ON cab.tipo_cabina = tc.id_tipo_cabina

-- Detalles Cruceros y sus cabinas
SELECT cab.id_cabina, cab.tipo_cabina, tc.tipo_cabina, cru.modelo, mar.marca, cab.numero, cab.piso, cab.estado
FROM LOS_BARONES_DE_LA_CERVEZA.Cabinas cab
	JOIN LOS_BARONES_DE_LA_CERVEZA.Tipos_Cabinas tc
		ON cab.tipo_cabina = tc.id_tipo_cabina
	JOIN LOS_BARONES_DE_LA_CERVEZA.Cruceros cru
		ON cab.crucero = cru.id_crucero
	JOIN LOS_BARONES_DE_LA_CERVEZA.Marcas_Cruceros mar
		ON cru.marca = mar.id_marca

SELECT *
FROM LOS_BARONES_DE_LA_CERVEZA.Cabinas

SELECT cru.identificador, cru.modelo, mar.marca, COUNT(cab.crucero) 'Cantidad cabinas'
FROM LOS_BARONES_DE_LA_CERVEZA.Cruceros cru
	JOIN LOS_BARONES_DE_LA_CERVEZA.Marcas_Cruceros mar
		ON cru.marca = mar.id_marca
	JOIN LOS_BARONES_DE_LA_CERVEZA.Cabinas cab
		ON cru.id_crucero = cab.crucero
GROUP BY cru.identificador, cru.modelo, mar.marca

DECLARE @id INT
EXEC [LOS_BARONES_DE_LA_CERVEZA].[USP_actualizar_crucero] 'XYZWJ-12345', 'Crucerito', 'XYZWJ-12345', 'Holland America Line', @id OUT
SELECT @id

DELETE 
FROM LOS_BARONES_DE_LA_CERVEZA.Cabinas 
WHERE crucero = 1 AND estado = 0

SELECT cru.identificador 'Identificador', cru.modelo 'Modelo', mar.marca 'Marca', COUNT(cab.crucero) 'Cantidad de cabinas', 
	cru.fecha_alta 'Fecha alta'
FROM LOS_BARONES_DE_LA_CERVEZA.Cruceros cru 
	JOIN LOS_BARONES_DE_LA_CERVEZA.Marcas_Cruceros mar 
		ON cru.marca = mar.id_marca 
	JOIN LOS_BARONES_DE_LA_CERVEZA.Cabinas cab
		ON cru.id_crucero = cab.crucero 
WHERE cru.baja_vida_util = 0
	AND cru.baja_fuera_servicio = 0
GROUP BY cru.identificador, cru.modelo, mar.marca, cru.fecha_alta



SELECT cru.identificador 'Identificador', cru.modelo 'Modelo', mar.marca 'Marca', COUNT(cab.crucero) 'Cantidad de cabinas' 
FROM LOS_BARONES_DE_LA_CERVEZA.Cruceros cru 
	JOIN LOS_BARONES_DE_LA_CERVEZA.Marcas_Cruceros mar 
		ON cru.marca = mar.id_marca 
	JOIN LOS_BARONES_DE_LA_CERVEZA.Cabinas cab 
		ON cru.id_crucero = cab.crucero 
WHERE cru.fecha_baja_vida_util IS NULL
GROUP BY cru.identificador, cru.modelo, mar.marca

SELECT * 
FROM LOS_BARONES_DE_LA_CERVEZA.Cruceros

UPDATE LOS_BARONES_DE_LA_CERVEZA.Cruceros 
SET 
baja_vida_util = 0, 
fecha_baja_vida_util = NULL
WHERE identificador = 'ABCDEF-98765'