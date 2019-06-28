---- BORRADOR ------
USE GD1C2019

-- Listado de cabinas con info de su crucero
SELECT cru.identificador, cab.id_cabina, cab.tipo_cabina, tc.tipo_cabina, cru.modelo, mar.marca, cab.numero, cab.piso
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

DECLARE @fecha_inicio_mi_viaje DATETIME2(3) = (CONVERT(DATETIME2(3), '2018-08-02', 121))
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

SELECT * 
FROM dbo.mi_funcion()

SELECT crucero_identificador
FROM [LOS_BARONES_DE_LA_CERVEZA].[UF_cruceros_disponibles]('2018-08-02')

SELECT DISTINCT crucero_identificador 
from LOS_BARONES_DE_LA_CERVEZA.Crucero

DECLARE @variable DECIMAL(18,0) = 1254715
DECLARE @otra_variable NVARCHAR(255) = @variable
SELECT @otra_variable

/******************
 ABM Recorrido
******************/

SELECT *
FROM LOS_BARONES_DE_LA_CERVEZA.Recorrido

-- Tramos de la migración
SELECT t.id_tramo tramo, puerto_inicio.puerto_nombre puerto_inicio, puerto_fin.puerto_nombre puerto_fin, 
	t.tramo_precio
FROM LOS_BARONES_DE_LA_CERVEZA.Tramo t
	JOIN LOS_BARONES_DE_LA_CERVEZA.Puerto puerto_inicio
		ON t.tramo_puerto_inicio = puerto_inicio.id_puerto
	JOIN LOS_BARONES_DE_LA_CERVEZA.Puerto puerto_fin
		ON t.tramo_puerto_destino = puerto_fin.id_puerto
WHERE puerto_inicio.puerto_nombre = 'Luanda'

SELECT COUNT(*) FROM LOS_BARONES_DE_LA_CERVEZA.Recorrido WHERE recorrido_codigo = 'RecorridoLoco'

DELETE
LOS_BARONES_DE_LA_CERVEZA.Tramos_por_Recorrido
WHERE id_recorrido = 56

DELETE
LOS_BARONES_DE_LA_CERVEZA.Recorrido
WHERE id_recorrido = 56

SELECT * 
FROM LOS_BARONES_DE_LA_CERVEZA.Recorrido
WHERE id_recorrido = 57

SELECT *
FROM LOS_BARONES_DE_LA_CERVEZA.Tramos_por_Recorrido
WHERE id_recorrido = 57

SELECT * 
FROM LOS_BARONES_DE_LA_CERVEZA.Puerto

EXEC [LOS_BARONES_DE_LA_CERVEZA].[USP_insertar_tramo_por_recorrido] 53, 1

INSERT INTO LOS_BARONES_DE_LA_CERVEZA.Tramos_por_Recorrido
(id_recorrido, id_tramo, tramo_siguiente, tramo_anterior)
VALUES (49, 2, 1, NULL)


UPDATE [LOS_BARONES_DE_LA_CERVEZA].Tpr_Auxiliar
SET id_tpr_anterior = NULL

SELECT * 
FROM LOS_BARONES_DE_LA_CERVEZA.Tpr_Auxiliar

DROP TABLE [LOS_BARONES_DE_LA_CERVEZA].Tpr_Auxiliar

SELECT * 
FROM LOS_BARONES_DE_LA_CERVEZA.Recorrido

SELECT 
	r.recorrido_codigo AS identificador, 
	(
		SELECT puerto_nombre 
		FROM LOS_BARONES_DE_LA_CERVEZA.Puerto p
			JOIN LOS_BARONES_DE_LA_CERVEZA.Tramo t
				ON p.id_puerto = t.tramo_puerto_inicio
			JOIN LOS_BARONES_DE_LA_CERVEZA.Tramos_por_Recorrido tpr
				ON t.id_tramo = tpr.id_tramo
		WHERE tpr.tramo_anterior IS NULL -- Son puerto origen
			AND tpr.id_recorrido = '1' --r.id_recorrido
	) AS puerto_inicio
	--t.tramo_puerto_destino AS puerto_fin
FROM LOS_BARONES_DE_LA_CERVEZA.Recorrido r 
WHERE recorrido_estado = 0 -- Solo considero los recorridos habilitados

SELECT * 
FROM LOS_BARONES_DE_LA_CERVEZA.Recorrido r
	JOIN LOS_BARONES_DE_LA_CERVEZA.Tramos_por_Recorrido tpr
		ON r.id_recorrido = tpr.id_recorrido
WHERE r.id_recorrido = 1

SELECT DISTINCT 
	r.recorrido_codigo identificador,
	pto_inicio.puerto_nombre puerto_inicio,
	pto_fin.puerto_nombre puerto_fin
FROM LOS_BARONES_DE_LA_CERVEZA.Recorrido r
	JOIN LOS_BARONES_DE_LA_CERVEZA.Tramos_por_Recorrido tpr1
		ON r.id_recorrido = tpr1.id_recorrido
	JOIN LOS_BARONES_DE_LA_CERVEZA.Tramos_por_Recorrido tpr2
		ON r.id_recorrido = tpr2.id_recorrido
	JOIN LOS_BARONES_DE_LA_CERVEZA.Tramo t1
		ON tpr1.id_tramo = t1.id_tramo
	JOIN LOS_BARONES_DE_LA_CERVEZA.Tramo t2
		ON tpr2.id_tramo = t2.id_tramo
	JOIN LOS_BARONES_DE_LA_CERVEZA.Puerto pto_inicio
		ON t1.tramo_puerto_inicio = pto_inicio.id_puerto
	JOIN LOS_BARONES_DE_LA_CERVEZA.Puerto pto_fin
		ON t2.tramo_puerto_destino = pto_fin.id_puerto
WHERE r.recorrido_codigo = 'RecorridoLoco'

-- Query tramos por Recorrido
SELECT 	
	CONCAT(pto_inicio.puerto_nombre, '|', 
	pto_fin.puerto_nombre) tramos
FROM LOS_BARONES_DE_LA_CERVEZA.Recorrido r
	JOIN LOS_BARONES_DE_LA_CERVEZA.Tramos_por_Recorrido tpr
		ON r.id_recorrido = tpr.id_recorrido
	JOIN LOS_BARONES_DE_LA_CERVEZA.Tramo t
		ON tpr.id_tramo = t.id_tramo
	JOIN LOS_BARONES_DE_LA_CERVEZA.Puerto pto_inicio
		ON t.tramo_puerto_inicio = pto_inicio.id_puerto
	JOIN LOS_BARONES_DE_LA_CERVEZA.Puerto pto_fin
		ON t.tramo_puerto_destino = pto_fin.id_puerto
WHERE r.recorrido_codigo = 'RecorridoLoco'
ORDER BY tpr.id_tramo_por_recorrido


SELECT * 
FROM LOS_BARONES_DE_LA_CERVEZA.Tramos_por_Recorrido
WHERE id_recorrido = 57

SELECT * 
FROM LOS_BARONES_DE_LA_CERVEZA.Recorrido
WHERE recorrido_codigo = 'RecorridoLoco'

SELECT 
	r.recorrido_codigo 'Identificador Recorrido', 
	tpr.tramo_anterior 'Tpr anterior',
	tpr.tramo_siguiente 'Tpr siguiente',
	p1.puerto_nombre 'Puerto Inicio', 
	p2.puerto_nombre 'Puerto Fin'
FROM LOS_BARONES_DE_LA_CERVEZA.Recorrido r
	JOIN LOS_BARONES_DE_LA_CERVEZA.Tramos_por_Recorrido tpr
		ON r.id_recorrido = tpr.id_recorrido
	JOIN LOS_BARONES_DE_LA_CERVEZA.Tramo t
		ON tpr.id_tramo = t.id_tramo
	JOIN LOS_BARONES_DE_LA_CERVEZA.Puerto p1
		ON t.tramo_puerto_inicio = p1.id_puerto
	JOIN LOS_BARONES_DE_LA_CERVEZA.Puerto p2
		ON t.tramo_puerto_destino = p2.id_puerto
ORDER BY 1

/******************************************************************
[LOS_BARONES_DE_LA_CERVEZA].[USP_insertar_viaje] 
@Desc: Inserta un nuevo viaje en la tabla Viaje y en la tabla 
Estado_Cabinas_Por_Viaje.
******************************************************************/
GO
CREATE PROCEDURE [LOS_BARONES_DE_LA_CERVEZA].[USP_insertar_viaje]
(
	@fecha_inicio NVARCHAR(255), 
	@fecha_fin NVARCHAR(255),
	@identificador_crucero NVARCHAR(50),
	@identificador_recorrido NVARCHAR(255)
)
AS
BEGIN
	BEGIN TRY
		BEGIN TRANSACTION 
			-- Insertamos el registro de nuevo viaje
			INSERT INTO LOS_BARONES_DE_LA_CERVEZA.Viaje
			(viaje_fecha_inicio, viaje_fecha_fin, viaje_id_crucero, viaje_id_recorrido)
			VALUES
			(
				CONVERT(DATETIME2(3), @fecha_inicio, 121),
				CONVERT(DATETIME2(3), @fecha_fin, 121),
				(SELECT id_crucero FROM LOS_BARONES_DE_LA_CERVEZA.Cruceros WHERE identificador = @identificador_crucero),
				(SELECT id_recorrido FROM LOS_BARONES_DE_LA_CERVEZA.Recorrido WHERE recorrido_codigo = @identificador_recorrido)
			);

			DECLARE @id_viaje INT = @@IDENTITY -- Me guardo el id_viaje del viaje recién insertado
			-- Insertamos en la tabla Estado_Cabinas_Por_Viaje
			INSERT INTO LOS_BARONES_DE_LA_CERVEZA.Estado_Cabinas_Por_Viaje
			(id_viaje, id_cabina)
			SELECT @id_viaje, id_cabina
			FROM LOS_BARONES_DE_LA_CERVEZA.Cabinas cab
			WHERE cab.crucero = (
				SELECT id_crucero 
				FROM LOS_BARONES_DE_LA_CERVEZA.Cruceros 
				WHERE identificador = @identificador_crucero);
		COMMIT TRANSACTION 
	END TRY
	BEGIN CATCH
		ROLLBACK TRANSACTION
	END CATCH
END
GO

SELECT * 
FROM LOS_BARONES_DE_LA_CERVEZA.Viaje
WHERE viaje_id_crucero = (
				SELECT id_crucero 
				FROM LOS_BARONES_DE_LA_CERVEZA.Cruceros 
				WHERE identificador = 'XVREPF-74164')
AND viaje_id_recorrido = (
				SELECT id_recorrido 
				FROM LOS_BARONES_DE_LA_CERVEZA.Recorrido 
				WHERE recorrido_codigo = '43820896')
				
SELECT 
	r.recorrido_codigo 'Recorrido', 
	pto_inicio.puerto_nombre 'Puerto Inicio', 
	pto_fin.puerto_nombre 'Puerto Fin' 
FROM LOS_BARONES_DE_LA_CERVEZA.Recorrido r 
	JOIN LOS_BARONES_DE_LA_CERVEZA.Tramos_por_Recorrido tpr1 
		ON r.id_recorrido = tpr1.id_recorrido 
	JOIN LOS_BARONES_DE_LA_CERVEZA.Tramos_por_Recorrido tpr2 
		ON r.id_recorrido = tpr2.id_recorrido 
	JOIN LOS_BARONES_DE_LA_CERVEZA.Tramo t1 
		ON tpr1.id_tramo = t1.id_tramo 
	JOIN LOS_BARONES_DE_LA_CERVEZA.Tramo t2 
		ON tpr2.id_tramo = t2.id_tramo 
	JOIN LOS_BARONES_DE_LA_CERVEZA.Puerto pto_inicio 
		ON t1.tramo_puerto_inicio = pto_inicio.id_puerto 
	JOIN LOS_BARONES_DE_LA_CERVEZA.Puerto pto_fin 
		ON t2.tramo_puerto_destino = pto_fin.id_puerto 
	WHERE tpr1.tramo_anterior IS NULL 
		AND tpr2.tramo_siguiente IS NULL 
		AND pto_inicio.puerto_nombre LIKE '%%' 
		AND pto_fin.puerto_nombre LIKE '%%';

SELECT * 
FROM LOS_BARONES_DE_LA_CERVEZA.Recorrido
ORDER BY 2

SELECT 
	r.recorrido_codigo 'Recorrido', 
	pto_inicio.puerto_nombre 'Puerto Inicio', 
	pto_fin.puerto_nombre 'Puerto Fin' 
FROM LOS_BARONES_DE_LA_CERVEZA.Recorrido r 
	JOIN LOS_BARONES_DE_LA_CERVEZA.Tramos_por_Recorrido tpr1 
		ON r.id_recorrido = tpr1.id_recorrido 
	JOIN LOS_BARONES_DE_LA_CERVEZA.Tramos_por_Recorrido tpr2 
		ON r.id_recorrido = tpr2.id_recorrido 
	JOIN LOS_BARONES_DE_LA_CERVEZA.Tramo t1 
		ON tpr1.id_tramo = t1.id_tramo 
	JOIN LOS_BARONES_DE_LA_CERVEZA.Tramo t2 
		ON tpr2.id_tramo = t2.id_tramo 
	JOIN LOS_BARONES_DE_LA_CERVEZA.Puerto pto_inicio 
		ON t1.tramo_puerto_inicio = pto_inicio.id_puerto 
	JOIN LOS_BARONES_DE_LA_CERVEZA.Puerto pto_fin 
		ON t2.tramo_puerto_destino = pto_fin.id_puerto 
	WHERE tpr1.tramo_anterior IS NULL 
		AND tpr2.tramo_siguiente IS NULL 
		--AND pto_inicio.puerto_nombre LIKE '%%' 
		--AND pto_fin.puerto_nombre LIKE '%%'
		AND r.recorrido_codigo = 'RecorridoLoco'
ORDER BY 1

-- Mostrar Leo
SELECT * 
FROM LOS_BARONES_DE_LA_CERVEZA.Recorrido r
	JOIN LOS_BARONES_DE_LA_CERVEZA.Tramos_por_Recorrido tpr
		ON r.id_recorrido = tpr.id_recorrido 
WHERE r.recorrido_codigo= '43820887'
ORDER BY 2

SELECT * 
FROM LOS_BARONES_DE_LA_CERVEZA.Viaje

SELECT *
FROM LOS_BARONES_DE_LA_CERVEZA.Recorrido
WHERE id_recorrido = 25

SELECT identificador FROM LOS_BARONES_DE_LA_CERVEZA.UF_cruceros_disponibles('2019-06-03','2019-08-06')

UPDATE LOS_BARONES_DE_LA_CERVEZA.Recorrido
SET recorrido_estado = 1
WHERE recorrido_codigo = 

SELECT *
FROM LOS_BARONES_DE_LA_CERVEZA.Recorrido r
	JOIN LOS_BARONES_DE_LA_CERVEZA.Viaje v
		ON r.id_recorrido = v.viaje_id_recorrido
	JOIN LOS_BARONES_DE_LA_CERVEZA.Compra c
		ON v.id_viaje = c.compra_id_viaje 

SELECT * 
FROM LOS_BARONES_DE_LA_CERVEZA.Recorrido r
	JOIN LOS_BARONES_DE_LA_CERVEZA.Tramos_por_Recorrido tpr
		ON r.id_recorrido = tpr.id_recorrido
WHERE r.recorrido_codigo = 'RecorridoAcademico'

SELECT 
	t.id_tramo 'Id tramo', 
	puerto_inicio.puerto_nombre 'Puerto Inicio', 
	puerto_fin.puerto_nombre 'Puerto Fin',
	t.tramo_precio 'Precio'
FROM LOS_BARONES_DE_LA_CERVEZA.Recorrido r 
	JOIN LOS_BARONES_DE_LA_CERVEZA.Tramos_por_Recorrido tpr
		ON r.id_recorrido = tpr.id_recorrido 
	JOIN LOS_BARONES_DE_LA_CERVEZA.Tramo t
		ON tpr.id_tramo = t.id_tramo 
	JOIN LOS_BARONES_DE_LA_CERVEZA.Puerto puerto_inicio
		ON t.tramo_puerto_inicio = puerto_inicio.id_puerto
	JOIN LOS_BARONES_DE_LA_CERVEZA.Puerto puerto_fin
		ON t.tramo_puerto_destino = puerto_fin.id_puerto
WHERE r.recorrido_codigo = 'RecorridoLoco'
--WHERE r.id_recorrido = 67

SELECT *
FROM LOS_BARONES_DE_LA_CERVEZA.Recorrido r 
	JOIN LOS_BARONES_DE_LA_CERVEZA.Tramos_por_Recorrido tpr
		ON r.id_recorrido = tpr.id_recorrido 
WHERE r.recorrido_codigo = 'RecorridoReLoco'

UPDATE LOS_BARONES_DE_LA_CERVEZA.Recorrido
SET recorrido_codigo = 'RecorridoLoco'
WHERE recorrido_codigo = 'RecorridoLoco'

SELECT COUNT(*)
FROM LOS_BARONES_DE_LA_CERVEZA.Recorrido
WHERE recorrido_codigo = 'RecorridoReLoco'
	AND id_recorrido != 57

SELECT *
FROM LOS_BARONES_DE_LA_CERVEZA.Recorrido
WHERE recorrido_codigo = @identificador_recorrido_a_editar

SELECT *
FROM LOS_BARONES_DE_LA_CERVEZA.Tramos_por_Recorrido
WHERE id_recorrido = 67

/* TOP 5 recorridos con más pasajes comprados (versión sin mostrar puerto inicial y final de cada recorrido) */
SELECT TOP 5 r.recorrido_codigo identificador_recorrido, 
	SUM(c.compra_cantidad) cantidad_pasajes_comprados
FROM LOS_BARONES_DE_LA_CERVEZA.Recorrido r
	JOIN LOS_BARONES_DE_LA_CERVEZA.Viaje v
		ON r.id_recorrido = v.viaje_id_recorrido
	JOIN LOS_BARONES_DE_LA_CERVEZA.Compra c
		ON v.id_viaje = c.compra_id_viaje
WHERE c.compra_fecha BETWEEN '2018-01-01' AND '2018-06-30'  
GROUP BY r.recorrido_codigo
ORDER BY 2 DESC

/* TOP 5 recorridos con más pasajes comprados (versión completa) */
SELECT TOP 5 r.recorrido_codigo identificador_recorrido, 
	SUM(c.compra_cantidad) cantidad_pasajes_comprados,
	pto_inicio.puerto_nombre puerto_inicial,
	pto_fin.puerto_nombre puerto_final
FROM LOS_BARONES_DE_LA_CERVEZA.Recorrido r
	JOIN LOS_BARONES_DE_LA_CERVEZA.Viaje v
		ON r.id_recorrido = v.viaje_id_recorrido
	JOIN LOS_BARONES_DE_LA_CERVEZA.Compra c
		ON v.id_viaje = c.compra_id_viaje
	JOIN LOS_BARONES_DE_LA_CERVEZA.Tramos_por_Recorrido tpr1 
		ON r.id_recorrido = tpr1.id_recorrido 
	JOIN LOS_BARONES_DE_LA_CERVEZA.Tramos_por_Recorrido tpr2 
		ON r.id_recorrido = tpr2.id_recorrido 
	JOIN LOS_BARONES_DE_LA_CERVEZA.Tramo t1 
		ON tpr1.id_tramo = t1.id_tramo 
	JOIN LOS_BARONES_DE_LA_CERVEZA.Tramo t2 
		ON tpr2.id_tramo = t2.id_tramo 
	JOIN LOS_BARONES_DE_LA_CERVEZA.Puerto pto_inicio 
		ON t1.tramo_puerto_inicio = pto_inicio.id_puerto 
	JOIN LOS_BARONES_DE_LA_CERVEZA.Puerto pto_fin 
		ON t2.tramo_puerto_destino = pto_fin.id_puerto 
WHERE tpr1.tramo_anterior IS NULL 
	AND tpr2.tramo_siguiente IS NULL 
	AND c.compra_fecha BETWEEN '2018-01-01' AND '2018-06-30'  
GROUP BY r.recorrido_codigo, pto_inicio.puerto_nombre, pto_fin.puerto_nombre
ORDER BY 2 DESC

select FECHA_SALIDA, FECHA_LLEGADA, FECHA_LLEGADA_ESTIMADA, PUERTO_DESDE, PUERTO_HASTA
from  gd_esquema.Maestra
where CRUCERO_IDENTIFICADOR = 'SRHBMX-41378'
and   RECORRIDO_CODIGO = 43820907
and   FECHA_SALIDA = '2018-07-20 07:00:00.000'
and   FECHA_LLEGADA_ESTIMADA = '2018-07-20 19:00:00.000'
and   PASAJE_CODIGO is not null

SELECT puerto_nombre
FROM LOS_BARONES_DE_LA_CERVEZA.Puerto p
ORDER BY puerto_nombre

SELECT 
	t.id_tramo 'Id tramo', 
	puerto_inicio.puerto_nombre 'Puerto Inicio', 
	puerto_fin.puerto_nombre 'Puerto Fin',
	t.tramo_precio 'Precio'
FROM LOS_BARONES_DE_LA_CERVEZA.Recorrido r 
	JOIN LOS_BARONES_DE_LA_CERVEZA.Tramos_por_Recorrido tpr
		ON r.id_recorrido = tpr.id_recorrido 
	JOIN LOS_BARONES_DE_LA_CERVEZA.Tramo t
		ON tpr.id_tramo = t.id_tramo 
	JOIN LOS_BARONES_DE_LA_CERVEZA.Puerto puerto_inicio
		ON t.tramo_puerto_inicio = puerto_inicio.id_puerto
	JOIN LOS_BARONES_DE_LA_CERVEZA.Puerto puerto_fin
		ON t.tramo_puerto_destino = puerto_fin.id_puerto
WHERE puerto_inicio.puerto_nombre = 'LUANDA'
ORDER BY 1

SELECT *
FROM LOS_BARONES_DE_LA_CERVEZA.Tramo
WHERE tramo_puerto_inicio = 43 -- Luanda

-- Hay 45 puertos 
SELECT id_puerto
FROM LOS_BARONES_DE_LA_CERVEZA.Puerto
WHERE puerto_nombre = 'LUANDA'

-- Query para el segundo combobox de Alta Tramo
SELECT puerto_nombre
FROM LOS_BARONES_DE_LA_CERVEZA.Puerto puerto
EXCEPT
SELECT DISTINCT puerto_fin.puerto_nombre
FROM LOS_BARONES_DE_LA_CERVEZA.Tramo t
	JOIN LOS_BARONES_DE_LA_CERVEZA.Puerto puerto_inicio
		ON t.tramo_puerto_inicio = puerto_inicio.id_puerto
	JOIN LOS_BARONES_DE_LA_CERVEZA.Puerto puerto_fin
		ON t.tramo_puerto_destino = puerto_fin.id_puerto
WHERE puerto_inicio.puerto_nombre = 'SANTO TOMÉ'
EXCEPT 
SELECT 'SANTO TOMÉ'
ORDER BY puerto.puerto_nombre

-- Query para insertar nuevos tramos
INSERT INTO LOS_BARONES_DE_LA_CERVEZA.Tramo (tramo_puerto_inicio, tramo_puerto_destino, tramo_precio)
VALUES 
(
	(SELECT id_puerto FROM LOS_BARONES_DE_LA_CERVEZA.Puerto WHERE puerto_nombre = 'SANTO TOMÉ'), 
	(SELECT id_puerto FROM LOS_BARONES_DE_LA_CERVEZA.Puerto WHERE puerto_nombre = 'VICTORIA'), 
	700.0
)

SELECT puerto_inicio.puerto_nombre, puerto_fin.puerto_nombre, t.tramo_precio
FROM LOS_BARONES_DE_LA_CERVEZA.Tramo t
	JOIN LOS_BARONES_DE_LA_CERVEZA.Puerto puerto_inicio
		ON t.tramo_puerto_inicio = puerto_inicio.id_puerto
	JOIN LOS_BARONES_DE_LA_CERVEZA.Puerto puerto_fin
		ON t.tramo_puerto_destino = puerto_fin.id_puerto
WHERE t.tramo_precio = 1400.25

SELECT * 
FROM LOS_BARONES_DE_LA_CERVEZA.Tramo
WHERE tramo_precio = 700.0

SELECT t.id_tramo tramo, puerto_inicio.puerto_nombre puerto_inicio, puerto_fin.puerto_nombre puerto_fin, t.tramo_precio precio  
FROM LOS_BARONES_DE_LA_CERVEZA.Tramo t 
	JOIN LOS_BARONES_DE_LA_CERVEZA.Puerto puerto_inicio 
		ON t.tramo_puerto_inicio = puerto_inicio.id_puerto 
	JOIN LOS_BARONES_DE_LA_CERVEZA.Puerto puerto_fin 
		ON t.tramo_puerto_destino = puerto_fin.id_puerto
WHERE puerto_inicio.puerto_nombre LIKE '%' + '%'
	AND puerto_fin.puerto_nombre LIKE '%' + '%';

SELECT t.id_tramo tramo, puerto_inicio.puerto_nombre puerto_inicio, puerto_fin.puerto_nombre puerto_fin, t.tramo_precio precio  
FROM LOS_BARONES_DE_LA_CERVEZA.Tramo t 
	JOIN LOS_BARONES_DE_LA_CERVEZA.Puerto puerto_inicio 
		ON t.tramo_puerto_inicio = puerto_inicio.id_puerto 
	JOIN LOS_BARONES_DE_LA_CERVEZA.Puerto puerto_fin 
		ON t.tramo_puerto_destino = puerto_fin.id_puerto 
WHERE puerto_inicio.puerto_nombre LIKE '%'+''+'%' 
	AND puerto_fin.puerto_nombre LIKE '%'+''+'%'

--si todavia sigue fuera de servicio en esta query le pongo diferencia cero
SELECT TOP 5 
	FS.id_crucero,CRU.identificador, 
	CRU.modelo,SUM(datediff(DAY, FS.fecha_inicio_fuera_servicio, 
	ISNULL(FS.fecha_fin_fuera_servicio, FS.fecha_inicio_fuera_servicio))) as diferencia
FROM LOS_BARONES_DE_LA_CERVEZA.Cruceros_Fuera_Servicio FS 
	JOIN LOS_BARONES_DE_LA_CERVEZA.Cruceros CRU 
		ON (CRU.id_crucero = FS.id_crucero)
WHERE @ano = year(FS.fecha_fin_fuera_servicio) 
	AND month(FS.fecha_fin_fuera_servicio) > (@semestre - 1) * 6 
	AND month(FS.fecha_fin_fuera_servicio) <= @semestre * 6
GROUP BY FS.id_crucero,CRU.identificador,CRU.modelo 
ORDER BY diferencia DESC

SELECT * 
FROM LOS_BARONES_DE_LA_CERVEZA.Cruceros_Fuera_Servicio

SELECT TOP 5 
	FS.id_crucero,CRU.identificador, 
	CRU.modelo,SUM(datediff(DAY, FS.fecha_inicio_fuera_servicio, 
	ISNULL(FS.fecha_fin_fuera_servicio, FS.fecha_inicio_fuera_servicio))) as diferencia
FROM LOS_BARONES_DE_LA_CERVEZA.Cruceros_Fuera_Servicio FS 
	JOIN LOS_BARONES_DE_LA_CERVEZA.Cruceros CRU 
		ON (CRU.id_crucero = FS.id_crucero)
WHERE YEAR(FS.fecha_fin_fuera_servicio) = 2018
	AND month(FS.fecha_fin_fuera_servicio) >= 1
	AND month(FS.fecha_fin_fuera_servicio) <= 6
GROUP BY FS.id_crucero,CRU.identificador,CRU.modelo 
ORDER BY diferencia DESC


/******************************************************************
---------------------TESTS de la app--------------------- 
******************************************************************/

-- ABM Roles 
SELECT r.nombre_rol, f.nombre_funcionalidad, f.descripcion
FROM LOS_BARONES_DE_LA_CERVEZA.Roles r
	JOIN LOS_BARONES_DE_LA_CERVEZA.Funcionalidades_Por_Roles fpr
		ON r.nombre_rol = fpr.rol
	JOIN LOS_BARONES_DE_LA_CERVEZA.Funcionalidades f
		ON fpr.funcionalidad = f.nombre_funcionalidad

SELECT *
FROM LOS_BARONES_DE_LA_CERVEZA.Roles

SELECT * 
FROM LOS_BARONES_DE_LA_CERVEZA.Funcionalidades

UPDATE LOS_BARONES_DE_LA_CERVEZA.Roles 
SET nombre_rol = 'Rol_Pepito2'
WHERE nombre_rol ='Rol_Pepito';

SELECT * 
FROM LOS_BARONES_DE_LA_CERVEZA.Usuarios
WHERE usuario = 'nico'

UPDATE LOS_BARONES_DE_LA_CERVEZA.Usuarios
SET cantidad_intentos_fallidos = 0
WHERE usuario = 'nico'

UPDATE LOS_BARONES_DE_LA_CERVEZA.Usuarios
SET habilitado = 1
WHERE usuario = 'nico'

SELECT * 
FROM LOS_BARONES_DE_LA_CERVEZA.Tipos_Cabinas

INSERT INTO LOS_BARONES_DE_LA_CERVEZA.Cruceros
(fecha_alta, modelo, identificador, marca, tipo_servicio)
VALUES (GETDATE(), 'ModeloLoco', 'CruceroVeloz', 1, 4)


DECLARE @pk INT
EXEC [LOS_BARONES_DE_LA_CERVEZA].[USP_insertar_crucero] 'ModeloLoco', 'CruceroReLosdsdco', 'P&O Cruises', '2018-12-05', 5, @pk OUT

INSERT INTO LOS_BARONES_DE_LA_CERVEZA.Cruceros 
(fecha_alta, modelo, identificador, marca, tipo_servicio)
VALUES ('2018-05-02', @fecha_alta, 121), 'ModeloLoco', 'SuperCrucero', 
[LOS_BARONES_DE_LA_CERVEZA].[UF_id_marca_crucero](''), @tipo_servicio) 

SELECT * 
FROM LOS_BARONES_DE_LA_CERVEZA.Cruceros

SELECT cru.identificador 'Identificador', cru.modelo 'Modelo', mar.marca 'Marca', COUNT(cab.crucero) 'Cantidad de cabinas'
FROM LOS_BARONES_DE_LA_CERVEZA.Cruceros cru 
	JOIN LOS_BARONES_DE_LA_CERVEZA.Marcas_Cruceros mar 
         ON cru.marca = mar.id_marca 
    JOIN LOS_BARONES_DE_LA_CERVEZA.Cabinas cab 
         ON cru.id_crucero = cab.crucero 
WHERE cru.baja_vida_util != 1 
	AND GETDATE() >  
		(
			SELECT TOP 1 v.viaje_fecha_fin
			FROM LOS_BARONES_DE_LA_CERVEZA.Viaje v
				JOIN LOS_BARONES_DE_LA_CERVEZA.Cruceros cru2
					ON v.viaje_id_crucero = cru2.id_crucero
			WHERE cru.id_crucero = v.viaje_id_crucero
			ORDER BY v.viaje_fecha_fin DESC
		)
	OR cru.id_crucero IN 
						(
							SELECT c.id_crucero
							FROM LOS_BARONES_DE_LA_CERVEZA.Cruceros c
							EXCEPT
							SELECT DISTINCT v.viaje_id_crucero 
							FROM LOS_BARONES_DE_LA_CERVEZA.Viaje v
						)

GROUP BY cru.identificador, cru.modelo, mar.marca

SELECT * 
FROM LOS_BARONES_DE_LA_CERVEZA.Viaje
WHERE YEAR(viaje_fecha_fin) = '2019'

DECLARE @var NVARCHAR(4) = CAST(2018 AS nvarchar(4));

select convert
(
	datetime2(3),
	(select CONCAT(@var,'-', 'x',' 00:00:00.000')),
	121
)

'x' = (case when 1 = 1 then '07-00' else '12-31' end)