------------------------------------------------------------------------------------------------------
						-- 1. USAMOS LA BD DEL TP 
------------------------------------------------------------------------------------------------------
USE [GD1C2019] 
GO

------------------------------------------------------------------------------------------------------
						-- 2. CREAMOS EL ESQUEMA SINO EXISTE
------------------------------------------------------------------------------------------------------
IF NOT EXISTS (SELECT * FROM sys.schemas WHERE name = 'LOS_BARONES_DE_LA_CERVEZA')
BEGIN
    EXEC ('CREATE SCHEMA LOS_BARONES_DE_LA_CERVEZA AUTHORIZATION gdCruceros2019')
END
GO

------------------------------------------------------------------------------------------------------
						-- 3. ELIMINAMOS LAS TABLAS SI EXISTEN (VALIDACI�N DE TABLAS)
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

-------------------------------------------------------------------------------------------------
						-- 4. CREACION DE TABLAS 
-------------------------------------------------------------------------------------------------

/******************************************************************
Tabla Usuarios
@Desc: Contiene los elementos necesarios para la identificaci�n
de un usuario en el sistema.
******************************************************************/
GO
CREATE TABLE LOS_BARONES_DE_LA_CERVEZA.Usuarios(
	usuario NVARCHAR(100) NOT NULL PRIMARY KEY,
	--pass NVARCHAR(100) NOT NULL,
	pass BINARY(32) NOT NULL,
	habilitado BIT NOT NULL DEFAULT 1,
	cantidad_intentos_fallidos INTEGER NOT NULL DEFAULT 0
)
GO

/******************************************************************
Tabla Roles_Por_Usuario
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
Tabla Roles
@Desc: Tabla de roles. Un rol es un conjunto de funcionalidades
que se puede emplear en la aplicaci�n.
******************************************************************/
GO
CREATE TABLE LOS_BARONES_DE_LA_CERVEZA.Roles (
	nombre_rol NVARCHAR(100) NOT NULL PRIMARY KEY,
	habilitado BIT NOT NULL DEFAULT 1
)
GO

/******************************************************************
Tabla Funcionalidades_Por_Roles
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
Tabla Funcionalidades
@Desc: Tabla con los datos de cada funcionalidad existente. 
******************************************************************/
GO
CREATE TABLE LOS_BARONES_DE_LA_CERVEZA.Funcionalidades(
	nombre_funcionalidad NVARCHAR(255) NOT NULL PRIMARY KEY,
	descripcion NVARCHAR(255)
)
GO

/******************************************************************
Tabla Clientes
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
	--tarjeta_credito NVARCHAR(100) -- No est� en la tabla maestra (valor por defecto NULL) 
)
GO

------------------------------------------------------------------------------------------------------
						-- 6. CARGAMOS DATOS PREVIOS 
------------------------------------------------------------------------------------------------------

/*** INICIO - Cargamos las funcionalidades  ***/
/* Las mismas ser�n las siguientes y no podr�n agregarse nuevas ni eliminarse las existentes, 
es decir, son FIJAS => La tabla Funcionalidades es ESTATICA. En total hay 12 funcionalidades 
relevadas. */

/******************************************************************
Cargamos las funcionalidades. 
@DESC:  Las mismas ser�n las siguientes y no podr�n agregarse nuevas 
ni eliminarse las existentes, es decir, son FIJAS => La tabla 
Funcionalidades es ESTATICA. En total hay 8 funcionalidades 
relevadas.
******************************************************************/
GO
INSERT INTO LOS_BARONES_DE_LA_CERVEZA.Funcionalidades(nombre_funcionalidad, descripcion)
VALUES ('Comprar/Reservar Viaje', 'Permite acceder al m�dulo de compras y reservas de viajes.'),  
		('Generar Viaje', 'Permite la creaci�n de nuevos viajes.'),
		('Pagar Reserva', 'Permite acceder al m�dulo de pago de reservas.'),
		('ABM Roles', 'Funcionalidad que permite crear, eliminar y modificar roles.'),
		('ABM Puertos', 'Funcionalidad que permite crear, eliminar y modificar puertos para los cruceros.'),
		('ABM Recorridos', 'Funcionalidad que permite crear, eliminar y modificar recorridos para los viajes.'),
		('ABM Cruceros', 'Funcionalidad que permite crear, eliminar y modificar los cruceros disponibles para los viajes.'),
		('Listados estadisticos', 'Permite visualizar diferentes listados estad�sticos sobre el sistema.')
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
Creaci�n del usuario Administrador por defecto 
@Desc: Creamos el usuario Administrador por defecto exigido por 
la c�tedra para las pruebas del TP:
	- Usuario: admin
	- Password: w23e
	- Rol: Rol_Admin
	- Funcionalidades: Todas las disponibles
******************************************************************/
DECLARE @hash_pass VARCHAR(100)
SET @hash_pass = 'w23e';
INSERT INTO LOS_BARONES_DE_LA_CERVEZA.Usuarios (usuario, pass)
VALUES ('admin', HASHBYTES('SHA2_256',@hash_pass))

INSERT INTO LOS_BARONES_DE_LA_CERVEZA.Roles_por_Usuario (usuario, rol)
VALUES ('admin', 'Rol_Admin')

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



------------------------------------------------------------------------------
			-- 8. PROCEDIMIENTOS ALMACENADOS (DE APLICACION/NEGOCIO)
------------------------------------------------------------------------------
-- Eliminamos los procedimientos almacenados si existen

IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'LOS_BARONES_DE_LA_CERVEZA.USP_Login'))
	DROP PROCEDURE LOS_BARONES_DE_LA_CERVEZA.USP_Login
GO

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
			SET @resultado = 2 -- El usuario existe pero la contrase�a es incorrecta
			UPDATE LOS_BARONES_DE_LA_CERVEZA.Usuarios
			SET cantidad_intentos_fallidos = cantidad_intentos_fallidos + 1
			WHERE usuario = @usuario_ingresado
		END
	ELSE -- El usuario existe y la contrase�a es correcta 
		IF(	
			-- Chequeo que el usuario est� habilitado 
			(SELECT habilitado 
			FROM LOS_BARONES_DE_LA_CERVEZA.Usuarios	
			WHERE usuario = @usuario_ingresado) = 0
		)
			BEGIN
				-- El usuario est� inhabilitado
				SET @resultado = 3 	
			END
		ELSE
			BEGIN
				-- El usuario est� habilitado
				SET @resultado = 4 	
				UPDATE LOS_BARONES_DE_LA_CERVEZA.Usuarios
				SET cantidad_intentos_fallidos = 0 -- Reseteo la cantidad de intentos fallidos a 0
				WHERE usuario = @usuario_ingresado
			END 
END; -- FIN USP_Login 
GO

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