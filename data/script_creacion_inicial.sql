------------------------------------------------------------------------------------------------------
						-- 1. USAMOS LA BD DEL TP 
------------------------------------------------------------------------------------------------------
USE [GD1C2019] 
GO

------------------------------------------------------------------------------------------------------
						-- 2. ELIMINAMOS LAS TABLAS SI EXISTEN (VALIDACIÓN DE TABLAS)
------------------------------------------------------------------------------------------------------
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'LOS_BARONES_DE_LA_CERVEZA.Funcionalidades_Por_Roles'))
    DROP TABLE LOS_BARONES_DE_LA_CERVEZA.Funcionalidades_Por_Roles
GO

IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'LOS_BARONES_DE_LA_CERVEZA.Funcionalidades'))
    DROP TABLE LOS_BARONES_DE_LA_CERVEZA.Funcionalidades
GO

IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'LOS_BARONES_DE_LA_CERVEZA.Clientes'))
    DROP TABLE LOS_BARONES_DE_LA_CERVEZA.Clientes
GO

IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'LOS_BARONES_DE_LA_CERVEZA.Roles_Por_Usuario'))
    DROP TABLE LOS_BARONES_DE_LA_CERVEZA.Roles_Por_Usuario
GO

IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'LOS_BARONES_DE_LA_CERVEZA.Usuarios'))
    DROP TABLE LOS_BARONES_DE_LA_CERVEZA.Usuarios
GO

IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'LOS_BARONES_DE_LA_CERVEZA.Roles'))
    DROP TABLE LOS_BARONES_DE_LA_CERVEZA.Roles
GO

IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'LOS_BARONES_DE_LA_CERVEZA.Cruceros_Fuera_Servicio'))
    DROP TABLE LOS_BARONES_DE_LA_CERVEZA.Cruceros_Fuera_Servicio
GO

IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'LOS_BARONES_DE_LA_CERVEZA.Cabinas'))
    DROP TABLE LOS_BARONES_DE_LA_CERVEZA.Cabinas
GO

IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'LOS_BARONES_DE_LA_CERVEZA.Tipos_Cabinas'))
    DROP TABLE LOS_BARONES_DE_LA_CERVEZA.Tipos_Cabinas
GO

IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'LOS_BARONES_DE_LA_CERVEZA.Cruceros'))
    DROP TABLE LOS_BARONES_DE_LA_CERVEZA.Cruceros
GO

IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'LOS_BARONES_DE_LA_CERVEZA.Marcas_Cruceros'))
    DROP TABLE LOS_BARONES_DE_LA_CERVEZA.Marcas_Cruceros
GO


---------------------------------------------------------------
-- X. ELIMINAMOS LOS STORED PROCEDURES, FUNCIONES Y TRIGGERS
---------------------------------------------------------------
/****** STORED PROCEDURES ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'LOS_BARONES_DE_LA_CERVEZA.USP_Login'))
	DROP PROCEDURE LOS_BARONES_DE_LA_CERVEZA.USP_Login
GO

IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'LOS_BARONES_DE_LA_CERVEZA.USP_insertar_crucero'))
	DROP PROCEDURE LOS_BARONES_DE_LA_CERVEZA.USP_insertar_crucero
GO

IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'LOS_BARONES_DE_LA_CERVEZA.USP_actualizar_crucero'))
	DROP PROCEDURE LOS_BARONES_DE_LA_CERVEZA.USP_actualizar_crucero
GO

IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'LOS_BARONES_DE_LA_CERVEZA.USP_insertar_cabina'))
	DROP PROCEDURE LOS_BARONES_DE_LA_CERVEZA.USP_insertar_cabina
GO

/****** FUNCIONES ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'LOS_BARONES_DE_LA_CERVEZA.UF_id_marca_crucero'))
	DROP FUNCTION LOS_BARONES_DE_LA_CERVEZA.UF_id_marca_crucero
GO

IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'LOS_BARONES_DE_LA_CERVEZA.UF_id_tipo_cabina'))
	DROP FUNCTION LOS_BARONES_DE_LA_CERVEZA.UF_id_tipo_cabina
GO

/***** TRIGGERS: Se eliminan automáticamente al eliminar las tablas a las que están asociados *****/

------------------------------------------------------------------------------------------------------
						-- 3. ELIMINAMOS EL ESQUEMA Y VOLVEMOS A CREARLO
------------------------------------------------------------------------------------------------------
IF SCHEMA_ID('LOS_BARONES_DE_LA_CERVEZA') IS NOT NULL DROP SCHEMA [LOS_BARONES_DE_LA_CERVEZA]
GO

IF NOT EXISTS (SELECT * FROM sys.schemas WHERE name = 'LOS_BARONES_DE_LA_CERVEZA')
BEGIN
    EXEC ('CREATE SCHEMA LOS_BARONES_DE_LA_CERVEZA AUTHORIZATION gdCruceros2019')
END
GO


-------------------------------------------------------------------------------------------------
						-- 4. CREACION DE TABLAS 
-------------------------------------------------------------------------------------------------

/******************************************************************
Tabla Usuarios /** OK Leo **/
@Desc: Contiene los elementos necesarios para la identificación
de un usuario en el sistema.
******************************************************************/
GO
CREATE TABLE LOS_BARONES_DE_LA_CERVEZA.Usuarios(
	-- Elijo directamnente al campo usuario como PK para asegurar que no haya usuarios repetidos (UNIQUE)
	usuario NVARCHAR(100) NOT NULL PRIMARY KEY, 
	--pass NVARCHAR(100) NOT NULL,
	pass BINARY(32) NOT NULL,
	habilitado BIT NOT NULL DEFAULT 1,
	cantidad_intentos_fallidos INTEGER NOT NULL DEFAULT 0
)
GO

/******************************************************************
Tabla Roles_Por_Usuario /** OK Leo **/
@Desc: Tabla intermedia donde se especifica que roles tiene asignado
cada usuario. 
******************************************************************/
GO
CREATE TABLE LOS_BARONES_DE_LA_CERVEZA.Roles_por_Usuario (
	usuario NVARCHAR(100),
	rol NVARCHAR(100),
	PRIMARY KEY(usuario, rol)
)
GO

/******************************************************************
Tabla Roles /** OK Leo **/
@Desc: Tabla de roles. Un rol es un conjunto de funcionalidades
que se puede emplear en la aplicación.
******************************************************************/
GO
CREATE TABLE LOS_BARONES_DE_LA_CERVEZA.Roles (
	nombre_rol NVARCHAR(100) NOT NULL PRIMARY KEY,
	habilitado BIT NOT NULL DEFAULT 1
)
GO

/******************************************************************
Tabla Funcionalidades_Por_Roles /** OK Leo **/
@Desc: Tabla intermedia que vincula las funcionalidades que posee
cada rol. 
******************************************************************/
GO
CREATE TABLE LOS_BARONES_DE_LA_CERVEZA.Funcionalidades_Por_Roles(
	rol NVARCHAR(100),
	funcionalidad NVARCHAR(255),
	PRIMARY KEY(rol, funcionalidad)
)
GO

/******************************************************************
Tabla Funcionalidades /** OK Leo **/
@Desc: Tabla con los datos de cada funcionalidad existente. 
******************************************************************/
GO
CREATE TABLE LOS_BARONES_DE_LA_CERVEZA.Funcionalidades(
	nombre_funcionalidad NVARCHAR(255) NOT NULL PRIMARY KEY,
	descripcion NVARCHAR(255)
)
GO

/******************************************************************
Tabla Clientes /** OK Leo **/ 
@Desc: Contiene los campos referidos a los clientes del sistema.
******************************************************************/
GO
CREATE TABLE LOS_BARONES_DE_LA_CERVEZA.Clientes(
	id_cliente INT IDENTITY PRIMARY KEY NOT NULL,
	usuario NVARCHAR(100) UNIQUE NOT NULL, -- Es FK al campo usuario en tabla Usuarios
	nombre NVARCHAR(255) NOT NULL, -- CLI_NOMBRE en la tabla maestra 
	apellido NVARCHAR(255) NOT NULL, -- CLI_APELLIDO en la tabla maestra 
	dni DECIMAL(18,0) NOT NULL, -- CLI_DNI en la tabla maestra 
	direccion NVARCHAR(255), -- CLI_DIRECCION en la tabla maestra  
	telefono INT, -- CLI_TELEFONO en la tabla maestra 
	mail NVARCHAR(255), -- CLI_MAIL en la tabla maestra 
	fecha_nacimiento DATETIME2(3), -- CLI_FECHA_NAC en la tabla maestra 
	tarjeta_credito NVARCHAR(100) -- No está en la tabla maestra (valor por defecto NULL) 
)
GO


/******************************************************************
Tabla Tipos_Cabinas (Tipos de servicio de cada cabina) /** OK Leo (Tipo_Servicio) **/
@Desc: Existen cinco tipos de cabinas (o servicios de cabina). Los
mismos son fijos y no se pueden modificar (ni alterar el porcetaje
de recargo que se cobra). No hay ABM para esta tabla. 
******************************************************************/
GO
CREATE TABLE LOS_BARONES_DE_LA_CERVEZA.Tipos_Cabinas( 
	id_tipo_cabina INT IDENTITY PRIMARY KEY NOT NULL,
	tipo_cabina NVARCHAR(255), -- CABINA_TIPO en la tabla maestra
	porcentaje_recargo DECIMAL(18,2) -- CABINA_TIPO_PORC_RECARGO en la tabla maestra
)
GO

/******************************************************************
Tabla Marcas_Cruceros /** OK Leo **/
@Desc: 
******************************************************************/
GO
CREATE TABLE LOS_BARONES_DE_LA_CERVEZA.Marcas_Cruceros( 
	id_marca INT IDENTITY PRIMARY KEY NOT NULL,
	marca NVARCHAR(255) -- CRU_FABRICANTE en la tabla maestra
)
GO

/******************************************************************
Tabla Cruceros_Fuera_Servicio /** OK Leo **/
@Desc: 
******************************************************************/
GO
CREATE TABLE LOS_BARONES_DE_LA_CERVEZA.Cruceros_Fuera_Servicio( 
	id_fs INT IDENTITY PRIMARY KEY NOT NULL,
	id_crucero INT, -- FK al id del crucero que está fuera de servicio
	fecha_inicio_fuera_servicio DATETIME2(3) NOT NULL,
	fecha_fin_fuera_servicio DATETIME2(3) NOT NULL
)
GO

/******************************************************************
Tabla Cruceros /** OK Leo **/
@Desc: Tabla de los cruceros disponibles para realizar viajes. 
******************************************************************/
GO
CREATE TABLE LOS_BARONES_DE_LA_CERVEZA.Cruceros( 
	id_crucero INT IDENTITY PRIMARY KEY NOT NULL,
	fecha_alta DATETIME2(3) DEFAULT GETDATE(), 
	modelo NVARCHAR(50) NOT NULL, -- CRUCERO_MODELO en la tabla maestra
	identificador NVARCHAR(50) UNIQUE NOT NULL, -- CRUCERO_IDENTIFICADOR en la tabla maestra
	marca INT NOT NULL, -- FK al id_marca de la marca del crucero en la tabla Marcas_Cruceros 
	baja_fuera_servicio BIT DEFAULT 0, -- Por defecto, todos los cruceros están funcionando (0) 
	baja_vida_util BIT DEFAULT 0, -- Por defecto, todos los cruceros están activos (0)
	fecha_baja_vida_util DATETIME2(3) 
)
GO

/******************************************************************
Tabla Cabinas /** OK Leo **/
@Desc: Tabla con las cabinas de todos los cruceros.
******************************************************************/
GO
CREATE TABLE LOS_BARONES_DE_LA_CERVEZA.Cabinas(
	id_cabina INT IDENTITY PRIMARY KEY NOT NULL,
	tipo_cabina INT, -- FK al id_tipo_cabina de Tipos_Cabinas 
	crucero INT, -- FK al id_crucero al cuál pertenece la cabina 
	numero DECIMAL(18,0), -- CABINA_NRO en la tabla Maestra
	piso DECIMAL(18,0), -- CABINA_PISO en la tabla Maestra
	estado BIT DEFAULT 0 -- 0: Disponible (No comprada/No Reservada) / 1: No Disponible (Comprada/Reservada) 
)
GO

------------------------------------------------------------------------------------------------------
						-- 5. MIGRACION DE DATOS DE LA TABLA MAESTRA 
------------------------------------------------------------------------------------------------------

/******************************************************************
Migramos los cinco tipos de cabinas disponibles.
@DESC: Estos valores no se pueden modificar ni agregar nuevos tipos.
******************************************************************/

INSERT INTO LOS_BARONES_DE_LA_CERVEZA.Tipos_Cabinas(tipo_cabina, porcentaje_recargo)
SELECT DISTINCT CABINA_TIPO, CABINA_TIPO_PORC_RECARGO
FROM gd_esquema.Maestra

/******************************************************************
Migramos las marcas de cruceros existentes. 
@DESC: Estos valores no se pueden modificar ni agregar nuevos marcas.
******************************************************************/

INSERT INTO LOS_BARONES_DE_LA_CERVEZA.Marcas_Cruceros(marca)
SELECT DISTINCT CRU_FABRICANTE
FROM gd_esquema.Maestra

-- Insertamos la marca 'Otra' para permitir el alta de cruceros de marcas 
-- diferentes a las ya existentes
INSERT INTO LOS_BARONES_DE_LA_CERVEZA.Marcas_Cruceros(marca)
VALUES('Otra')

------------------------------------------------------------------------------------------------------
						-- 6. CARGAMOS DATOS PREVIOS 
------------------------------------------------------------------------------------------------------

/******************************************************************
Cargamos las funcionalidades. 
@DESC:  Las mismas serán las siguientes y no podrán agregarse nuevas 
ni eliminarse las existentes, es decir, son FIJAS => La tabla 
Funcionalidades es ESTATICA. En total hay 8 funcionalidades 
relevadas.
******************************************************************/
GO
INSERT INTO LOS_BARONES_DE_LA_CERVEZA.Funcionalidades(nombre_funcionalidad, descripcion)
VALUES ('Comprar/Reservar Viaje', 'Permite acceder al módulo de compras y reservas de viajes.'),  
		('Generar Viaje', 'Permite la creación de nuevos viajes.'),
		('Pagar Reserva', 'Permite acceder al módulo de pago de reservas.'),
		('ABM Roles', 'Funcionalidad que permite crear, eliminar y modificar roles.'),
		('ABM Puertos', 'Funcionalidad que permite crear, eliminar y modificar puertos para los cruceros.'),
		('ABM Recorridos', 'Funcionalidad que permite crear, eliminar y modificar recorridos para los viajes.'),
		('ABM Cruceros', 'Funcionalidad que permite crear, eliminar y modificar los cruceros disponibles para los viajes.'),
		('Listados estadisticos', 'Permite visualizar diferentes listados estadísticos sobre el sistema.')
GO


/******************************************************************
Cargamos el Rol_Cliente y le asignamos sus funcionalidades. 
@DESC: Este rol viene por defecto. 
******************************************************************/
GO
BEGIN TRANSACTION
	-- Primero insertamos el rol 'Rol_Cliente' en la tabla Roles (el campo habilitado
	-- se inicializa por defecto en 1)
	INSERT INTO LOS_BARONES_DE_LA_CERVEZA.Roles(nombre_rol)
	VALUES ('Rol_Cliente')

	-- @Listado de funcionalidades del Rol_Cliente: Comprar/Reservar, Pagar Reserva
	-- Ahora hacemos las vinculaciones por medio de la tabla intermedia 
	INSERT INTO LOS_BARONES_DE_LA_CERVEZA.Funcionalidades_Por_Roles(rol, funcionalidad)
	VALUES ('Rol_Cliente', 'Comprar/Reservar Viaje'), ('Rol_Cliente', 'Pagar Reserva')

COMMIT TRANSACTION
GO

/******************************************************************
Cargamos el Rol_Admin y le asignamos sus funcionalidades (TODAS).
@DESC: Este rol viene por defecto. 
******************************************************************/
GO
BEGIN TRANSACTION
	-- Primero insertamos el rol 'Rol_Empresa' en la tabla Roles (el campo habilitado
	-- se inicializa por defecto en 1)
	INSERT INTO LOS_BARONES_DE_LA_CERVEZA.Roles(nombre_rol)
	VALUES ('Rol_Admin')

	-- @Listado de funcionalidades del Rol_Empresa: Todas
	-- Ahora hacemos las vinculaciones por medio de la tabla intermedia 
	INSERT INTO LOS_BARONES_DE_LA_CERVEZA.Funcionalidades_Por_Roles(rol, funcionalidad)
	VALUES ('Rol_Admin', 'Comprar/Reservar Viaje'), ('Rol_Admin', 'Generar Viaje'), ('Rol_Admin', 'Pagar Reserva'),
	('Rol_Admin', 'ABM Roles'), ('Rol_Admin', 'ABM Puertos'), ('Rol_Admin', 'ABM Recorridos'), 
	('Rol_Admin', 'ABM Cruceros'), ('Rol_Admin', 'Listados estadisticos')

COMMIT TRANSACTION
GO

/******************************************************************
Creación del usuario Administrador por defecto 
@Desc: Creamos el usuario Administrador por defecto exigido por 
la cátedra para las pruebas del TP:
	- Usuario: admin
	- Password: w23e
	- Rol: Rol_Admin
	- Funcionalidades: Todas las disponibles
******************************************************************/
--DECLARE @hash_pass VARCHAR(100)
--SET @hash_pass = 'w23e';
INSERT INTO LOS_BARONES_DE_LA_CERVEZA.Usuarios (usuario, pass)
VALUES ('admin', HASHBYTES('SHA2_256', 'w23e'));

INSERT INTO LOS_BARONES_DE_LA_CERVEZA.Roles_por_Usuario (usuario, rol)
VALUES ('admin', 'Rol_Admin');

/******************************************************************
Cargamos un set adicional de usuarios administradores 
@DESC: Requerido por el enunciado del TP.  
******************************************************************/
INSERT INTO LOS_BARONES_DE_LA_CERVEZA.Usuarios (usuario, pass)
VALUES ('nico', HASHBYTES('SHA2_256', 'w23e'));

INSERT INTO LOS_BARONES_DE_LA_CERVEZA.Roles_por_Usuario (usuario, rol)
VALUES ('nico', 'Rol_Admin');

INSERT INTO LOS_BARONES_DE_LA_CERVEZA.Usuarios (usuario, pass)
VALUES ('ema', HASHBYTES('SHA2_256', 'w23e'));

INSERT INTO LOS_BARONES_DE_LA_CERVEZA.Roles_por_Usuario (usuario, rol)
VALUES ('ema', 'Rol_Admin');

INSERT INTO LOS_BARONES_DE_LA_CERVEZA.Usuarios (usuario, pass)
VALUES ('leo', HASHBYTES('SHA2_256', 'w23e'));

INSERT INTO LOS_BARONES_DE_LA_CERVEZA.Roles_por_Usuario (usuario, rol)
VALUES ('leo', 'Rol_Admin');

INSERT INTO LOS_BARONES_DE_LA_CERVEZA.Usuarios (usuario, pass)
VALUES ('martin', HASHBYTES('SHA2_256', 'w23e'));

INSERT INTO LOS_BARONES_DE_LA_CERVEZA.Roles_por_Usuario (usuario, rol)
VALUES ('martin', 'Rol_Admin');

/******************************************************************
Usuario de tipo Cliente por defecto  
@DESC: Insertamos un usuario de tipo Cliente por defecto que será 
EMPLEADO en el proceso de ingreso de usuarios Clientes en la 
aplicación C#. Es un registro de control interno, no de información.   
******************************************************************/
INSERT INTO LOS_BARONES_DE_LA_CERVEZA.Usuarios (usuario, pass)
VALUES ('cliente_default', HASHBYTES('SHA2_256', 'cliente_default'));

INSERT INTO LOS_BARONES_DE_LA_CERVEZA.Roles_por_Usuario (usuario, rol)
VALUES ('cliente_default', 'Rol_Cliente');


/*******************************************************************************
							FIN - CARGA DE DATOS PREVIOS 
********************************************************************************/

------------------------------------------------------------------------------------------------------
						-- 7. CREAMOS LAS FK'S
------------------------------------------------------------------------------------------------------

-- usuario de Clientes lo vinculo con usuario de Usuarios 
GO
ALTER TABLE LOS_BARONES_DE_LA_CERVEZA.Clientes 
ADD CONSTRAINT FK_cliente_usuario -- Nombre de la FK
FOREIGN KEY (usuario)
REFERENCES LOS_BARONES_DE_LA_CERVEZA.Usuarios(usuario)
ON UPDATE CASCADE 
GO

/* INICIO - FK's Tabla intermedia Roles_Por_Usuario */
-- usuario de Roles_Por_Usuario lo vinculo con usuario de Usuarios
GO
ALTER TABLE LOS_BARONES_DE_LA_CERVEZA.Roles_Por_Usuario 
ADD CONSTRAINT FK_usuario -- Nombre de la FK
FOREIGN KEY (usuario)
REFERENCES LOS_BARONES_DE_LA_CERVEZA.Usuarios(usuario)
ON UPDATE CASCADE
GO

-- rol de Roles_Por_Usuario lo vinculo con nombre_rol de Roles
GO
ALTER TABLE LOS_BARONES_DE_LA_CERVEZA.Roles_Por_Usuario 
ADD CONSTRAINT FK_rol -- Nombre de la FK
FOREIGN KEY (rol)
REFERENCES LOS_BARONES_DE_LA_CERVEZA.Roles(nombre_rol)
ON UPDATE CASCADE
GO
/* FIN - FK's Tabla intermedia Roles_Por_Usuario */

/* INICIO - FK's Tabla intermedia Funcionalidades_Por_Roles */
-- rol de Funcionalidades_Por_Roles lo vinculo con nombre_rol de Roles
GO
ALTER TABLE LOS_BARONES_DE_LA_CERVEZA.Funcionalidades_Por_Roles 
ADD CONSTRAINT FK_rol_funcionalidades -- Nombre de la FK
FOREIGN KEY (rol)
REFERENCES LOS_BARONES_DE_LA_CERVEZA.Roles(nombre_rol)
ON UPDATE CASCADE
GO

-- funcionalidad de Funcionalidades_Por_Roles lo vinculo con nombre_funcionalidad de Funcionalidades
GO
ALTER TABLE LOS_BARONES_DE_LA_CERVEZA.Funcionalidades_Por_Roles  
ADD CONSTRAINT FK_funcionalidad -- Nombre de la FK
FOREIGN KEY (funcionalidad)
REFERENCES LOS_BARONES_DE_LA_CERVEZA.Funcionalidades(nombre_funcionalidad)
ON UPDATE CASCADE
GO
/* FIN - FK's Tabla intermedia Funcionalidades_Por_Roles */

-- id_crucero de Cruceros_Fuera_Servicio lo vinculo con id_crucero de Cruceros
GO
ALTER TABLE LOS_BARONES_DE_LA_CERVEZA.Cruceros_Fuera_Servicio  
ADD CONSTRAINT FK_id_crucero_fuera_servicio -- Nombre de la FK
FOREIGN KEY (id_crucero)
REFERENCES LOS_BARONES_DE_LA_CERVEZA.Cruceros(id_crucero)
ON UPDATE CASCADE
GO

-- marca de Cruceros lo vinculo con id_marca de Marcas_Cruceros
GO
ALTER TABLE LOS_BARONES_DE_LA_CERVEZA.Cruceros
ADD CONSTRAINT FK_id_marca_crucero -- Nombre de la FK
FOREIGN KEY (marca)
REFERENCES LOS_BARONES_DE_LA_CERVEZA.Marcas_Cruceros(id_marca)
ON UPDATE CASCADE
GO

-- tipo_cabina de Cabinas lo vinculo con id_tipo_cabina de Tipos_Cabinas
GO
ALTER TABLE LOS_BARONES_DE_LA_CERVEZA.Cabinas
ADD CONSTRAINT FK_id_tipo_cabina -- Nombre de la FK
FOREIGN KEY (tipo_cabina)
REFERENCES LOS_BARONES_DE_LA_CERVEZA.Tipos_Cabinas(id_tipo_cabina)
ON UPDATE CASCADE
GO

-- tipo_cabina de Cabinas lo vinculo con id_tipo_cabina de Tipos_Cabinas
GO
ALTER TABLE LOS_BARONES_DE_LA_CERVEZA.Cabinas
ADD CONSTRAINT FK_cabina_crucero -- Nombre de la FK
FOREIGN KEY (crucero)
REFERENCES LOS_BARONES_DE_LA_CERVEZA.Cruceros(id_crucero)
ON UPDATE CASCADE
GO

/*******************************************************************************
							FIN - CREAMOS LAS FK'S
********************************************************************************/

------------------------------------------------------------------------------
			-- 8. PROCEDIMIENTOS ALMACENADOS/FUNCIONES (DE APLICACION/NEGOCIO)
------------------------------------------------------------------------------

/******************************************************************
[LOS_BARONES_DE_LA_CERVEZA].[USP_Login] 
@Desc: Valida el proceso de logueo de un usuario existente 
******************************************************************/
GO
CREATE PROCEDURE [LOS_BARONES_DE_LA_CERVEZA].[USP_Login]
(
	@usuario_ingresado NVARCHAR(100),
	@pass_ingresada VARCHAR(100),
	@resultado INT OUT
)
AS
BEGIN 
	DECLARE @hash_pass_almacenada BINARY(32)
	SET @hash_pass_almacenada =
	(SELECT pass
	FROM LOS_BARONES_DE_LA_CERVEZA.Usuarios
	WHERE usuario = @usuario_ingresado)

	DECLARE @hash_pass_ingresada BINARY(32)
	SET @hash_pass_ingresada = HASHBYTES('SHA2_256',@pass_ingresada)

	IF @hash_pass_almacenada IS NULL
		BEGIN
			SET @resultado = 1 -- El usuario no existe 
		END
	ELSE IF @hash_pass_almacenada != @hash_pass_ingresada
		BEGIN	
			SET @resultado = 2 -- El usuario existe pero la contraseña es incorrecta
			UPDATE LOS_BARONES_DE_LA_CERVEZA.Usuarios
			SET cantidad_intentos_fallidos = cantidad_intentos_fallidos + 1
			WHERE usuario = @usuario_ingresado
		END
	ELSE -- El usuario existe y la contraseña es correcta 
		IF(	
			-- Chequeo que el usuario esté habilitado 
			(SELECT habilitado 
			FROM LOS_BARONES_DE_LA_CERVEZA.Usuarios	
			WHERE usuario = @usuario_ingresado) = 0
		)
			BEGIN
				-- El usuario está inhabilitado
				SET @resultado = 3 	
			END
		ELSE
			BEGIN
				-- El usuario está habilitado
				SET @resultado = 4 	
				UPDATE LOS_BARONES_DE_LA_CERVEZA.Usuarios
				SET cantidad_intentos_fallidos = 0 -- Reseteo la cantidad de intentos fallidos a 0
				WHERE usuario = @usuario_ingresado
			END 
END; -- FIN USP_Login 
GO

/******************************************************************
[LOS_BARONES_DE_LA_CERVEZA].[UF_id_marca_crucero]
@Desc: Función auxiliar que retorna el id_crucero (PK) asignado a 
un crucero según el nombre de la marca que le pasemos por parámetro 
******************************************************************/
CREATE FUNCTION [LOS_BARONES_DE_LA_CERVEZA].[UF_id_marca_crucero]
(
	@nombre_marca NVARCHAR(255)
)
RETURNS INT 
AS 
BEGIN
	 DECLARE @id_marca INT = (
		 SELECT id_marca
		 FROM LOS_BARONES_DE_LA_CERVEZA.Marcas_Cruceros
		 WHERE marca = @nombre_marca
	)

	RETURN @id_marca
END 

/******************************************************************
[LOS_BARONES_DE_LA_CERVEZA].[USP_insertar_crucero] 
@Desc: Inserta un nuevo crucero en la tabla Cruceros
******************************************************************/
GO
CREATE PROCEDURE [LOS_BARONES_DE_LA_CERVEZA].[USP_insertar_crucero]
(
	@modelo NVARCHAR(50),
	@identificador NVARCHAR(50),
	@marca NVARCHAR(255),
	@fecha_alta NVARCHAR(255),
	@id_crucero_asignada INT OUT -- Retornamos el id_crucero asignado por SQL Server (IDENTITY)
)
AS
BEGIN
	BEGIN TRY
		BEGIN TRANSACTION 
			-- id_crucero se autogenera 
			INSERT INTO LOS_BARONES_DE_LA_CERVEZA.Cruceros 
			(fecha_alta, modelo, identificador, marca)
			VALUES (CONVERT(DATETIME2(3), @fecha_alta, 121), @modelo, @identificador, 
				[LOS_BARONES_DE_LA_CERVEZA].[UF_id_marca_crucero](@marca))

			SET @id_crucero_asignada = @@IDENTITY;
		COMMIT TRANSACTION 
	END TRY
	BEGIN CATCH
		ROLLBACK TRANSACTION
	END CATCH
END
GO

/******************************************************************
[LOS_BARONES_DE_LA_CERVEZA].[USP_actualizar_crucero] 
@Desc: Actualiza un crucero existente en la tabla Cruceros
******************************************************************/
GO
CREATE PROCEDURE [LOS_BARONES_DE_LA_CERVEZA].[USP_actualizar_crucero]
(
	@identificador_anterior NVARCHAR(50),
	@modelo NVARCHAR(50),
	@identificador NVARCHAR(50),
	@marca NVARCHAR(255),
	@id_crucero INT OUT -- Retornamos el id_crucero asignado por SQL Server (IDENTITY)
)
AS
BEGIN
	BEGIN TRY
		BEGIN TRANSACTION 
			-- No se está modificando el identificador del crucero
			IF @identificador = @identificador_anterior 
				BEGIN
					UPDATE LOS_BARONES_DE_LA_CERVEZA.Cruceros
					SET modelo = @modelo, marca = [LOS_BARONES_DE_LA_CERVEZA].[UF_id_marca_crucero](@marca)
					WHERE identificador = @identificador_anterior;
					SET @id_crucero = (
						SELECT id_crucero
						FROM LOS_BARONES_DE_LA_CERVEZA.Cruceros
						WHERE identificador = @identificador_anterior)
				END
			ELSE -- Se quiere modificar el identificador del crucero 
				BEGIN
					IF NOT EXISTS (
						SELECT identificador
						FROM LOS_BARONES_DE_LA_CERVEZA.Cruceros
						WHERE identificador = @identificador)
							-- Si el identificador está disponible, insertamos 
							BEGIN
								UPDATE LOS_BARONES_DE_LA_CERVEZA.Cruceros
								SET modelo = @modelo, identificador = @identificador, marca = [LOS_BARONES_DE_LA_CERVEZA].[UF_id_marca_crucero](@marca)
								WHERE identificador = @identificador_anterior;
								SET @id_crucero = (
									SELECT id_crucero
									FROM LOS_BARONES_DE_LA_CERVEZA.Cruceros
									WHERE identificador = @identificador)
							END
					ELSE 
						SET @id_crucero = -1 -- Si el identificador está en uso retornamos -1
				END
		COMMIT TRANSACTION 
	END TRY
	BEGIN CATCH
		ROLLBACK TRANSACTION
	END CATCH
END
GO

/******************************************************************
[LOS_BARONES_DE_LA_CERVEZA].[UF_id_tipo_cabina]
@Desc: Función auxiliar que retorna el id_tipo_cabina (PK) asignado a 
un tipo de cabina según la descripción de la cabina (tipo_cabina)
******************************************************************/
CREATE FUNCTION [LOS_BARONES_DE_LA_CERVEZA].[UF_id_tipo_cabina]
(
	@tipo_cabina NVARCHAR(255)
)
RETURNS INT 
AS 
BEGIN
	 DECLARE @id_tipo_cabina INT = (
		 SELECT id_tipo_cabina
		 FROM LOS_BARONES_DE_LA_CERVEZA.Tipos_Cabinas
		 WHERE tipo_cabina = @tipo_cabina
	)

	RETURN @id_tipo_cabina
END 

/******************************************************************
[LOS_BARONES_DE_LA_CERVEZA].[USP_insertar_cabina] 
@Desc: Inserta una cabina asociada a un crucero en la tabla Cabinas
******************************************************************/
GO
CREATE PROCEDURE [LOS_BARONES_DE_LA_CERVEZA].[USP_insertar_cabina]
(	
	@numero INT,
	@piso INT, 
	@tipo_cabina NVARCHAR(255),
	@crucero INT -- id_crucero: es la FK al crucero al cual pertenece la cabina 
)
AS
BEGIN
	BEGIN TRY
		BEGIN TRANSACTION 
		-- id_cabina se autogenera 
		INSERT INTO LOS_BARONES_DE_LA_CERVEZA.Cabinas
		(numero, piso, tipo_cabina, crucero)
		VALUES (@numero, @piso, 
			[LOS_BARONES_DE_LA_CERVEZA].[UF_id_tipo_cabina](@tipo_cabina), 
			@crucero)
		COMMIT TRANSACTION 
	END TRY
	BEGIN CATCH
		ROLLBACK TRANSACTION
	END CATCH
END
GO

/*******************************************************************************
							FIN - PROCEDIMIENTOS ALMACENADOS/FUNCIONES
********************************************************************************/

------------------------------------------------------------------------------
					-- 9. TRIGGERS
------------------------------------------------------------------------------

/******************************************************************
TR_reset_intentos_fallidos
@Desc: Inhabilita al usuario cuando alcanzo los 3 intentos de 
login incorrectos.
******************************************************************/
GO
CREATE TRIGGER [LOS_BARONES_DE_LA_CERVEZA].[UTR_inhabilitar_intentos_fallidos]
ON LOS_BARONES_DE_LA_CERVEZA.Usuarios
FOR UPDATE
AS
BEGIN
	-- Cuando la cantidad de intentos de login incorrectos es 3, inhabilitamos 
	-- al usuario 
	UPDATE LOS_BARONES_DE_LA_CERVEZA.Usuarios
	SET habilitado = 0, cantidad_intentos_fallidos = 0
	WHERE usuario IN (
					SELECT usuario
					FROM inserted -- Apunta a una tabla usuarios virtual 
					WHERE cantidad_intentos_fallidos = 3
					)
	-- Como ya deshabilitamos al usuario, le reseteamos la cantidad de intentos fallidos

END;
GO

/*******************************************************************************
							FIN - TRIGGERS
********************************************************************************/
