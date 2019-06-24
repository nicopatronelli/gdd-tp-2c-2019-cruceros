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

/******************************************************************
[LOS_BARONES_DE_LA_CERVEZA].[USP_insertar_recorrido] 
@Desc: Inserta un nuevo recorrido en la tabla Recorridos
******************************************************************/
GO
CREATE PROCEDURE [LOS_BARONES_DE_LA_CERVEZA].[USP_insertar_recorrido]
(
	@identificador NVARCHAR(255),
	@id_recorrido_asignado INT OUT -- Retornamos el id_crucero asignado por SQL Server (IDENTITY)
)
AS
BEGIN
	BEGIN TRY
		BEGIN TRANSACTION 
			-- id_recorrido se autogenera 
			INSERT INTO LOS_BARONES_DE_LA_CERVEZA.Recorrido
			(recorrido_codigo)
			VALUES (@identificador)
			SET @id_recorrido_asignado = @@IDENTITY;
		COMMIT TRANSACTION 
	END TRY
	BEGIN CATCH
		ROLLBACK TRANSACTION
	END CATCH
END
GO

/******************************************************************
[LOS_BARONES_DE_LA_CERVEZA].[USP_insertar_tramo_por_recorrido] 
@Desc: Inserta un registro en la tabla Tramos_Por_Recorrido
******************************************************************/
GO
CREATE PROCEDURE [LOS_BARONES_DE_LA_CERVEZA].[USP_insertar_tramo_por_recorrido]
(
	@id_recorrido INT, -- PK de la tabla Recorrido
	@id_tramo INT -- PK Tramo actual (PK de la tabla Tramo)
)
AS
BEGIN
	BEGIN TRY
		BEGIN TRANSACTION 
			-- id_tramo_por_recorrido se autogenera 
			DECLARE @id_tpr_anterior INT = (SELECT id_tpr_anterior FROM [LOS_BARONES_DE_LA_CERVEZA].Tpr_Auxiliar);
			INSERT INTO LOS_BARONES_DE_LA_CERVEZA.Tramos_por_Recorrido
			(id_recorrido, id_tramo, tramo_anterior)
			VALUES (@id_recorrido, @id_tramo, @id_tpr_anterior)
			-- Actualizo el id_trp_siguiente del tramo anterior (estaba en NULL) al actual
			UPDATE LOS_BARONES_DE_LA_CERVEZA.Tramos_por_Recorrido
			SET tramo_siguiente = @@IDENTITY
			WHERE id_tramo_por_recorrido = @id_tpr_anterior;
			-- Actualizo el id_tpr_anterior de la tabla Auxiliar (pasa a ser tpr actual)
			UPDATE LOS_BARONES_DE_LA_CERVEZA.Tpr_Auxiliar
			SET id_tpr_anterior = @@IDENTITY;
		COMMIT TRANSACTION 
	END TRY
	BEGIN CATCH
		ROLLBACK TRANSACTION
	END CATCH
END
GO

/******************************************************************
Tabla Tpr_Auxiliar
@Desc: Tabla Auxiliar para insertar Tramos por Recorrido.
******************************************************************/
CREATE TABLE [LOS_BARONES_DE_LA_CERVEZA].Tpr_Auxiliar
(	
	id INT IDENTITY PRIMARY KEY NOT NULL,
	id_tpr_anterior INT NULL
)
GO

INSERT INTO [LOS_BARONES_DE_LA_CERVEZA].Tpr_Auxiliar
VALUES (NULL)
GO
/******* FIN Tabla Auxiliar ********/


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

SELECT id_recorrido
FROM LOS_BARONES_DE_LA_CERVEZA.Recorrido
WHERE recorrido_codigo = @identificador_recorrido_a_editar

DELETE 
FROM LOS_BARONES_DE_LA_CERVEZA.Tramos_por_Recorrido
WHERE id_recorrido = 57