------------------------------------------------------------------------------------------------------
						-- 1. USAMOS LA BD DEL TP 
------------------------------------------------------------------------------------------------------
USE [GD1C2019] 
GO

------------------------------------------------------------------------------------------------------
						-- 2. ELIMINAMOS LAS TABLAS SI EXISTEN (VALIDACIÓN DE TABLAS)
------------------------------------------------------------------------------------------------------

IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'LOS_BARONES_DE_LA_CERVEZA.Item_factura'))
    DROP TABLE LOS_BARONES_DE_LA_CERVEZA.Item_factura
GO

IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'LOS_BARONES_DE_LA_CERVEZA.Factura'))
    DROP TABLE LOS_BARONES_DE_LA_CERVEZA.Factura
GO

IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'LOS_BARONES_DE_LA_CERVEZA.Estado_Cabinas_Por_Viaje'))
    DROP TABLE LOS_BARONES_DE_LA_CERVEZA.Estado_Cabinas_Por_Viaje
GO

IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'LOS_BARONES_DE_LA_CERVEZA.Reserva'))
    DROP TABLE LOS_BARONES_DE_LA_CERVEZA.Reserva
GO

IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'LOS_BARONES_DE_LA_CERVEZA.ReservaAux'))
    DROP TABLE LOS_BARONES_DE_LA_CERVEZA.ReservaAux
GO

IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'LOS_BARONES_DE_LA_CERVEZA.Compra'))
    DROP TABLE LOS_BARONES_DE_LA_CERVEZA.Compra
GO

IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'LOS_BARONES_DE_LA_CERVEZA.CompraAux'))
    DROP TABLE LOS_BARONES_DE_LA_CERVEZA.CompraAux
GO

IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'LOS_BARONES_DE_LA_CERVEZA.Forma_de_pago'))
    DROP TABLE LOS_BARONES_DE_LA_CERVEZA.Forma_de_pago
GO

IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'LOS_BARONES_DE_LA_CERVEZA.Viaje'))
    DROP TABLE LOS_BARONES_DE_LA_CERVEZA.Viaje
GO

IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'LOS_BARONES_DE_LA_CERVEZA.Tramos_por_Recorrido'))
    DROP TABLE LOS_BARONES_DE_LA_CERVEZA.Tramos_por_Recorrido
GO

IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'LOS_BARONES_DE_LA_CERVEZA.Tramo'))
    DROP TABLE LOS_BARONES_DE_LA_CERVEZA.Tramo
GO

IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'LOS_BARONES_DE_LA_CERVEZA.Recorrido'))
    DROP TABLE LOS_BARONES_DE_LA_CERVEZA.Recorrido
GO

IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'LOS_BARONES_DE_LA_CERVEZA.Puerto'))
    DROP TABLE LOS_BARONES_DE_LA_CERVEZA.Puerto
GO

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

IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'LOS_BARONES_DE_LA_CERVEZA.tipo_servicio'))
    DROP TABLE LOS_BARONES_DE_LA_CERVEZA.tipo_servicio
GO

IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'LOS_BARONES_DE_LA_CERVEZA.Tpr_Auxiliar'))
    DROP TABLE LOS_BARONES_DE_LA_CERVEZA.Tpr_Auxiliar
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

IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'LOS_BARONES_DE_LA_CERVEZA.USP_asociar_Clientes_Compra_Reserva'))
	DROP PROCEDURE LOS_BARONES_DE_LA_CERVEZA.USP_asociar_Clientes_Compra_Reserva
GO

IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'LOS_BARONES_DE_LA_CERVEZA.USP_migrar_recorridos'))
	DROP PROCEDURE LOS_BARONES_DE_LA_CERVEZA.USP_migrar_recorridos
GO

IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'LOS_BARONES_DE_LA_CERVEZA.USP_insertar_recorrido'))
	DROP PROCEDURE LOS_BARONES_DE_LA_CERVEZA.USP_insertar_recorrido
GO

IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'LOS_BARONES_DE_LA_CERVEZA.USP_insertar_tramo_por_recorrido'))
	DROP PROCEDURE LOS_BARONES_DE_LA_CERVEZA.USP_insertar_tramo_por_recorrido
GO

IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'LOS_BARONES_DE_LA_CERVEZA.USP_insertar_viaje'))
	DROP PROCEDURE LOS_BARONES_DE_LA_CERVEZA.USP_insertar_viaje
GO

IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'LOS_BARONES_DE_LA_CERVEZA.[USP_migrar_usuarios_clientes]'))
	DROP PROCEDURE LOS_BARONES_DE_LA_CERVEZA.[USP_migrar_usuarios_clientes]
GO

IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'LOS_BARONES_DE_LA_CERVEZA.USP_actualizar_recorrido'))
	DROP PROCEDURE LOS_BARONES_DE_LA_CERVEZA.USP_actualizar_recorrido

/****** FUNCIONES ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'LOS_BARONES_DE_LA_CERVEZA.UF_id_marca_crucero'))
	DROP FUNCTION LOS_BARONES_DE_LA_CERVEZA.UF_id_marca_crucero
GO

IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'LOS_BARONES_DE_LA_CERVEZA.UF_id_tipo_cabina'))
	DROP FUNCTION LOS_BARONES_DE_LA_CERVEZA.UF_id_tipo_cabina
GO

IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'LOS_BARONES_DE_LA_CERVEZA.UF_cruceros_disponibles'))
	DROP FUNCTION LOS_BARONES_DE_LA_CERVEZA.UF_cruceros_disponibles
GO

IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'LOS_BARONES_DE_LA_CERVEZA.UF_crear_username_Cliente'))
	DROP FUNCTION LOS_BARONES_DE_LA_CERVEZA.UF_crear_username_Cliente
GO

IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'LOS_BARONES_DE_LA_CERVEZA.UF_nombre_puertos'))
	DROP FUNCTION LOS_BARONES_DE_LA_CERVEZA.UF_nombre_puertos
GO

 IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'LOS_BARONES_DE_LA_CERVEZA.UF_recorridos_segun_origen'))
	DROP FUNCTION LOS_BARONES_DE_LA_CERVEZA.UF_recorridos_segun_origen
GO

 IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'LOS_BARONES_DE_LA_CERVEZA.UF_destinos_segun_recorrido'))
	DROP FUNCTION LOS_BARONES_DE_LA_CERVEZA.UF_destinos_segun_recorrido
GO

 IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'LOS_BARONES_DE_LA_CERVEZA.UF_destinos_segun_origen'))
	DROP FUNCTION LOS_BARONES_DE_LA_CERVEZA.UF_destinos_segun_origen
GO

 IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'LOS_BARONES_DE_LA_CERVEZA.UF_destinos_segun_origen_y_destino'))
	DROP FUNCTION LOS_BARONES_DE_LA_CERVEZA.UF_destinos_segun_origen_y_destino
GO

IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'LOS_BARONES_DE_LA_CERVEZA.UF_id_puerto'))
	DROP FUNCTION LOS_BARONES_DE_LA_CERVEZA.UF_id_puerto
GO

IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'LOS_BARONES_DE_LA_CERVEZA.UF_recorridos_segun_origen_y_destino'))
	DROP FUNCTION LOS_BARONES_DE_LA_CERVEZA.UF_recorridos_segun_origen_y_destino
GO

IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'LOS_BARONES_DE_LA_CERVEZA.UF_listado_fuera_de_servicio'))
	DROP FUNCTION LOS_BARONES_DE_LA_CERVEZA.UF_listado_fuera_de_servicio
GO

IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'LOS_BARONES_DE_LA_CERVEZA.UF_listado_cabinas_libres_por_viajes'))
	DROP FUNCTION LOS_BARONES_DE_LA_CERVEZA.UF_listado_cabinas_libres_por_viajes
GO



IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'LOS_BARONES_DE_LA_CERVEZA.USP_generar_compra'))
	DROP PROCEDURE LOS_BARONES_DE_LA_CERVEZA.USP_generar_compra
GO


IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'LOS_BARONES_DE_LA_CERVEZA.USP_generar_reserva'))
	DROP PROCEDURE LOS_BARONES_DE_LA_CERVEZA.USP_generar_reserva
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
Tabla Usuarios
@Desc: Contiene los elementos necesarios para la identificación
de un usuario en el sistema.
******************************************************************/
GO
CREATE TABLE LOS_BARONES_DE_LA_CERVEZA.Usuarios(
	-- Elijo directamnente al campo usuario como PK para asegurar que no haya usuarios repetidos (UNIQUE)
	usuario NVARCHAR(100) NOT NULL PRIMARY KEY, 
	pass BINARY(32) NULL,
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
CREATE TABLE LOS_BARONES_DE_LA_CERVEZA.Roles_por_Usuario(
	usuario NVARCHAR(100),
	rol NVARCHAR(100),
	PRIMARY KEY(usuario, rol)
)
GO

/******************************************************************
Tabla Roles 
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
	usuario NVARCHAR(100), -- Es FK al campo usuario en tabla Usuarios, esta en nulo para los de la maestra
	nombre NVARCHAR(255) NOT NULL, -- CLI_NOMBRE en la tabla maestra 
	apellido NVARCHAR(255) NOT NULL, -- CLI_APELLIDO en la tabla maestra 
	dni DECIMAL(18,0) NOT NULL, -- CLI_DNI en la tabla maestra 
	direccion NVARCHAR(255), -- CLI_DIRECCION en la tabla maestra  
	telefono INT, -- CLI_TELEFONO en la tabla maestra 
	mail NVARCHAR(255), -- CLI_MAIL en la tabla maestra 
	fecha_nacimiento DATETIME2(3), -- CLI_FECHA_NAC en la tabla maestra 
	nro_tarjeta NVARCHAR(100) -- No está en la tabla maestra (valor por defecto NULL) 
)
GO

/******************************************************************
Tabla Tipos_Cabinas (Tipos de servicio de cada cabina)
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
Tabla Marcas_Cruceros 
@Desc: 
******************************************************************/
GO
CREATE TABLE LOS_BARONES_DE_LA_CERVEZA.Marcas_Cruceros( 
	id_marca INT IDENTITY PRIMARY KEY NOT NULL,
	marca NVARCHAR(255) -- CRU_FABRICANTE en la tabla maestra
)
GO

/******************************************************************
Tabla Tipo_servicio
@DESC: Dato exigido en el enunciado que no esta en la maestra, 
generamos 5 tipos segun la cantidad de estrellas y asumimos que todos
los cruceros de la maestra so nde 4 estrellas
******************************************************************/
GO
CREATE TABLE LOS_BARONES_DE_LA_CERVEZA.tipo_servicio( 
	id_tipo_servicio INT IDENTITY PRIMARY KEY NOT NULL,
	servicio NVARCHAR(20)
)
GO

-- tipo de servicio de Cruceros lo vinculo con id_tipo_servicio de tipo_servicio
/******************************************************************
Tabla Cruceros_Fuera_Servicio 
@Desc: 
******************************************************************/

GO
CREATE TABLE LOS_BARONES_DE_LA_CERVEZA.Cruceros_Fuera_Servicio( 
	id_fs INT IDENTITY PRIMARY KEY NOT NULL,
	id_crucero INT, -- FK al id del crucero que está fuera de servicio
	fecha_inicio_fuera_servicio DATETIME2(3) NOT NULL,
	fecha_fin_fuera_servicio DATETIME2(3)
)
GO

/******************************************************************
Tabla Cruceros 
@Desc: Tabla de los cruceros disponibles para realizar viajes. 
******************************************************************/
GO
CREATE TABLE LOS_BARONES_DE_LA_CERVEZA.Cruceros( 
	id_crucero INT IDENTITY PRIMARY KEY NOT NULL,
	fecha_alta DATETIME2(3) DEFAULT GETDATE(), 
	modelo NVARCHAR(50) NOT NULL, -- CRUCERO_MODELO en la tabla maestra
	identificador NVARCHAR(50) UNIQUE NOT NULL, -- CRUCERO_IDENTIFICADOR en la tabla maestra
	marca INT NOT NULL, -- FK al id_marca de la marca del crucero en la tabla Marcas_Cruceros
	tipo_servicio INT NOT NULL, --FK a tipo de cabina
	baja_fuera_servicio BIT DEFAULT 0, -- Por defecto, todos los cruceros están funcionando (0) 
	baja_vida_util BIT DEFAULT 0, -- Por defecto, todos los cruceros están activos (0)
	fecha_baja_vida_util DATETIME2(3) 
)
GO

/******************************************************************
Tabla Cabinas 
@Desc: Tabla con las cabinas de todos los cruceros.
******************************************************************/
GO
CREATE TABLE LOS_BARONES_DE_LA_CERVEZA.Cabinas(
	id_cabina INT IDENTITY PRIMARY KEY NOT NULL,
	tipo_cabina INT, -- FK al id_tipo_cabina de Tipos_Cabinas 
	crucero INT, -- FK al id_crucero al cuál pertenece la cabina 
	numero DECIMAL(18,0), -- CABINA_NRO en la tabla Maestra
	piso DECIMAL(18,0) -- CABINA_PISO en la tabla Maestra
)
GO

/******************************************************************
Tabla Puertos (Ciudades) -- OK 
@Desc: Tabla con las cabinas de todos los cruceros.
******************************************************************/
CREATE TABLE [LOS_BARONES_DE_LA_CERVEZA].Puerto(
	id_puerto INT IDENTITY PRIMARY KEY NOT NULL,
	puerto_nombre NVARCHAR(255)
)
GO

/******************************************************************
Tabla Recorrido -- OK 
@Desc: Tabla con los recorridos disponibles para crear viajes.
******************************************************************/
CREATE TABLE [LOS_BARONES_DE_LA_CERVEZA].Recorrido(	
	id_recorrido INT IDENTITY PRIMARY KEY NOT NULL,
	recorrido_codigo NVARCHAR(255), -- Validamos que sea UNIQUE desde la app (NO marcar como UNIQUE)
	recorrido_estado BIT DEFAULT 0
)
GO

/******************************************************************
Tabla Tramo
@Desc: Tabla con los recorridos disponibles para crear viajes.
Recordar que para el dominio del TP, PUERTO es sinónimo de CIUDAD
******************************************************************/
CREATE TABLE [LOS_BARONES_DE_LA_CERVEZA].Tramo(
	id_tramo INT IDENTITY PRIMARY KEY NOT NULL,
	tramo_puerto_inicio INT,   
	tramo_puerto_destino INT,  
	tramo_precio DECIMAL(18,2)
)
GO

/******************************************************************
Tabla Tramos_por_Recorrido
@Desc: Tabla con los recorridos disponibles para crear viajes.
******************************************************************/
CREATE TABLE [LOS_BARONES_DE_LA_CERVEZA].Tramos_por_Recorrido(	
	id_tramo_por_recorrido INT IDENTITY PRIMARY KEY NOT NULL,
	id_recorrido INT,
	id_tramo INT,
	tramo_siguiente INT,
	tramo_anterior INT
)	
GO

/******************************************************************
Tabla Viaje
@Desc: Tabla con los recorridos disponibles para crear viajes.
******************************************************************/
CREATE TABLE [LOS_BARONES_DE_LA_CERVEZA].Viaje(	
	id_viaje INT IDENTITY PRIMARY KEY NOT NULL,
	viaje_fecha_inicio DATETIME2(3),
	viaje_fecha_fin DATETIME2(3),
	viaje_fecha_fin_estimada DATETIME2(3),
	viaje_id_crucero INT,
	viaje_id_recorrido INT
)
GO

/******************************************************************
Tabla Estado_Cabinas_Por_Viaje
@Desc: Permite marcar el estado de cada cabina para un viaje 
determinado, como disponible (0) y no disponible (1).
******************************************************************/
CREATE TABLE [LOS_BARONES_DE_LA_CERVEZA].Estado_Cabinas_Por_Viaje(
	id_viaje INT,   -- FK a id_viaje de Viajes
	id_cabina INT,  -- FK a id_cabina de Cabinas
	reserva int,	-- FK a id_reserva de Reserva
	compra int		-- FK a id_compra de Compra
	PRIMARY KEY(id_viaje, id_cabina)
)
GO

/******************************************************************
Tabla Forma_de_Pago
@Desc: Tabla con los recorridos disponibles para crear viajes.
******************************************************************/
CREATE TABLE [LOS_BARONES_DE_LA_CERVEZA].Forma_de_pago(	
	id_forma_de_pago INT IDENTITY PRIMARY KEY NOT NULL,
	forma_de_pago_nombre NVARCHAR(20)
)
GO

/******************************************************************
Tabla Compras
@Desc: Tabla donde figuran las compras realizadas por los administradores
y clientes.
******************************************************************/
CREATE TABLE [LOS_BARONES_DE_LA_CERVEZA].Compra(	
	id_compra INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
	compra_fecha datetime2(3),
	compra_cantidad int,
	compra_numero_tarjeta nvarchar(50),
	compra_precio_con_recargo decimal(18,2),
	compra_id_forma_de_pago int,
	compra_id_cliente int,
	compra_id_viaje int
)
GO

CREATE TABLE [LOS_BARONES_DE_LA_CERVEZA].CompraAux(	
	id_compra INT PRIMARY KEY NOT NULL,
	compra_fecha datetime2(3),
	compra_cantidad int,
	compra_numero_tarjeta nvarchar(50),
	compra_precio_con_recargo decimal(18,2),
	compra_id_forma_de_pago int,
	compra_id_cliente int IDENTITY(1,1),
	compra_id_viaje int
)
GO
/******************************************************************
Tabla Reserva
@Desc: Tablas con las reservas de viajes realizadas por los 
administradores y clientes. 
******************************************************************/
CREATE TABLE [LOS_BARONES_DE_LA_CERVEZA].Reserva(	
	id_reserva INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
	reserva_fecha datetime2(3),
	reserva_cantidad_pasajes int,
	reserva_cliente int,
	reserva_viaje int
)
GO

CREATE TABLE [LOS_BARONES_DE_LA_CERVEZA].ReservaAux(	
	id_reserva INT PRIMARY KEY NOT NULL,
	reserva_fecha datetime2(3),
	reserva_cantidad_pasajes int,
	reserva_cliente int IDENTITY(1,1),
	reserva_viaje int
)
GO
/******************************************************************
Tabla Factura
@Desc: 
******************************************************************/
CREATE TABLE [LOS_BARONES_DE_LA_CERVEZA].Factura(	
	id_factura INT IDENTITY PRIMARY KEY NOT NULL,
	factura_fecha datetime2(3),
	factura_tipo char(1),
	factura_total numeric(18,0),
	factura_id_viaje int
)
GO

/******************************************************************
Tabla Item_Factura
@Desc: 
******************************************************************/
CREATE TABLE [LOS_BARONES_DE_LA_CERVEZA].Item_factura(	
	id_item_factura int identity (1,1) NOT NULL,
	item_factura_cantidad int,
	item_factura_monto decimal(18,0),
	item_fecha_compra datetime2(3),
	item_tipo_servicio_descripcion nvarchar(255),
	item_factura_id_factura int,
	CONSTRAINT pk_id_item_factura PRIMARY KEY CLUSTERED (id_item_factura) 
)
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
/**** FIN Tabla Auxiliar ****/

------------------------------------------------------------------------------------------------------
						-- 5. CREAMOS LAS FK'S
------------------------------------------------------------------------------------------------------

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
GO

-- marca de Cruceros lo vinculo con id_marca de Marcas_Cruceros
GO
ALTER TABLE LOS_BARONES_DE_LA_CERVEZA.Cruceros
ADD CONSTRAINT FK_id_marca_crucero -- Nombre de la FK
FOREIGN KEY (marca)
REFERENCES LOS_BARONES_DE_LA_CERVEZA.Marcas_Cruceros(id_marca)
GO

-- tipo de servicio de Cruceros lo vinculo con id_tipo_servicio de tipo_servicio
GO
ALTER TABLE LOS_BARONES_DE_LA_CERVEZA.Cruceros
ADD CONSTRAINT FK_id_tipo_servicio -- Nombre de la FK
FOREIGN KEY (tipo_servicio)
REFERENCES LOS_BARONES_DE_LA_CERVEZA.tipo_servicio(id_tipo_servicio)
GO

-- tipo_cabina de Cabinas lo vinculo con id_tipo_cabina de Tipos_Cabinas
GO
ALTER TABLE LOS_BARONES_DE_LA_CERVEZA.Cabinas
ADD CONSTRAINT FK_id_tipo_cabina -- Nombre de la FK
FOREIGN KEY (tipo_cabina)
REFERENCES LOS_BARONES_DE_LA_CERVEZA.Tipos_Cabinas(id_tipo_cabina)
GO

-- tipo_cabina de Cabinas lo vinculo con id_tipo_cabina de Tipos_Cabinas
GO
ALTER TABLE LOS_BARONES_DE_LA_CERVEZA.Cabinas
ADD CONSTRAINT FK_cabina_crucero -- Nombre de la FK
FOREIGN KEY (crucero)
REFERENCES LOS_BARONES_DE_LA_CERVEZA.Cruceros(id_crucero)
GO

/***** FK LEO *****/
-- Vinculo tramo_puerto_inicio de Tramo con id_puerto de Puerto
GO
ALTER TABLE [LOS_BARONES_DE_LA_CERVEZA].Tramo 
ADD CONSTRAINT FK_tramo_puerto_inicio
FOREIGN KEY (tramo_puerto_inicio)
REFERENCES LOS_BARONES_DE_LA_CERVEZA.Puerto(id_puerto)
GO

-- Vinculo tramo_puerto_destino de Tramo con id_puerto de Puerto
GO
ALTER TABLE [LOS_BARONES_DE_LA_CERVEZA].Tramo 
ADD CONSTRAINT FK_tramo_puerto_destino
FOREIGN KEY (tramo_puerto_destino)
REFERENCES LOS_BARONES_DE_LA_CERVEZA.Puerto(id_puerto)
GO

-- Vinculo id_crucero de Crucero con viaje_id_crucero de Viaje
GO
ALTER TABLE [LOS_BARONES_DE_LA_CERVEZA].Viaje
ADD CONSTRAINT FK_viaje_crucero 
FOREIGN KEY (viaje_id_crucero)
REFERENCES LOS_BARONES_DE_LA_CERVEZA.Cruceros(id_crucero)
GO

-- Vinculo id_recorrido de Recorrido con viaje_id_recorrido de Viaje
GO
ALTER TABLE [LOS_BARONES_DE_LA_CERVEZA].Viaje
ADD CONSTRAINT FK_viaje_recorrido
FOREIGN KEY (viaje_id_recorrido)
REFERENCES LOS_BARONES_DE_LA_CERVEZA.Recorrido(id_recorrido)
GO

-- Vinculo id_forma_pago de Forma_de_Pago con compra_id_forma_de_pago de Compra
GO
ALTER TABLE [LOS_BARONES_DE_LA_CERVEZA].Compra
ADD CONSTRAINT FK_forma_de_pago_compra
FOREIGN KEY (compra_id_forma_de_pago)
REFERENCES LOS_BARONES_DE_LA_CERVEZA.Forma_de_Pago(id_forma_de_pago)
GO

-- Vinculo id_viaje de Viaje con compra_id_viaje de Compra
GO
ALTER TABLE [LOS_BARONES_DE_LA_CERVEZA].Compra
ADD CONSTRAINT FK_compra_viaje
FOREIGN KEY (compra_id_viaje)
REFERENCES LOS_BARONES_DE_LA_CERVEZA.Viaje(id_viaje)
GO

-- Vinculo id_viaje de Viaje con reserva_viaje de Reserva
GO
ALTER TABLE [LOS_BARONES_DE_LA_CERVEZA].Reserva
ADD CONSTRAINT FK_viaje_reserva
FOREIGN KEY (reserva_viaje)
REFERENCES LOS_BARONES_DE_LA_CERVEZA.Viaje(id_viaje)
GO

-- Vinculo id_viaje de Viaje con factura_id_viaje de Factura
GO
ALTER TABLE [LOS_BARONES_DE_LA_CERVEZA].Factura
ADD CONSTRAINT FK_factura_viaje
FOREIGN KEY (factura_id_viaje)
REFERENCES LOS_BARONES_DE_LA_CERVEZA.Viaje(id_viaje)
GO

-- Vinculo id_factura de Factura con item_factura_id_factura de Item_Factura
GO
ALTER TABLE [LOS_BARONES_DE_LA_CERVEZA].Item_Factura
ADD CONSTRAINT FK_item_factura_a_factura
FOREIGN KEY (item_factura_id_factura)
REFERENCES LOS_BARONES_DE_LA_CERVEZA.Factura(id_factura)
GO

-- id_recorrido de Tramos_por_Recorrido lo vinculo con id_recorrido de Recorrido
GO
ALTER TABLE [LOS_BARONES_DE_LA_CERVEZA].Tramos_por_Recorrido
ADD CONSTRAINT FK_id_TramoxRecorridoRecorridoRecorrido
FOREIGN KEY (id_recorrido)
REFERENCES [LOS_BARONES_DE_LA_CERVEZA].Recorrido(id_recorrido)
GO

-- id_tramo de Tramos_por_Recorrido lo vinculo con id_tramo de Tramo
GO
ALTER TABLE [LOS_BARONES_DE_LA_CERVEZA].Tramos_por_Recorrido
ADD CONSTRAINT FK_id_TramoxRecorridoTramo
FOREIGN KEY (id_tramo)
REFERENCES [LOS_BARONES_DE_LA_CERVEZA].Tramo(id_tramo)
GO

-- tramo_siguiente de Tramos_por_Recorrido lo vinculo con id_rtramo_por_recorrido de Tramos_por_Recorrido
GO
ALTER TABLE [LOS_BARONES_DE_LA_CERVEZA].Tramos_por_Recorrido
ADD CONSTRAINT FK_id_TramoxRecorridoSiguiente
FOREIGN KEY (tramo_siguiente)
REFERENCES [LOS_BARONES_DE_LA_CERVEZA].Tramos_por_Recorrido(id_tramo_por_recorrido)
GO

-- tramo_anterior de Tramos_por_Recorrido lo vinculo con id_rtramo_por_recorrido de Tramos_por_Recorrido
GO
ALTER TABLE [LOS_BARONES_DE_LA_CERVEZA].Tramos_por_Recorrido
ADD CONSTRAINT FK_id_TramoxRecorridoAnterior
FOREIGN KEY (tramo_anterior)
REFERENCES [LOS_BARONES_DE_LA_CERVEZA].Tramos_por_Recorrido(id_tramo_por_recorrido)
GO

-- id_viaje de Estado_Cabinas_Por_Viaje referencia a id_viaje de Viaje
GO
ALTER TABLE LOS_BARONES_DE_LA_CERVEZA.Estado_Cabinas_Por_Viaje 
ADD CONSTRAINT FK_estado_cabina_por_viaje_con_viaje -- Nombre de la FK
FOREIGN KEY (id_viaje)
REFERENCES LOS_BARONES_DE_LA_CERVEZA.Viaje(id_viaje)
GO

-- id_cabina de Estado_Cabinas_Por_Viaje referencia a id_cabina de Cabinas
GO
ALTER TABLE LOS_BARONES_DE_LA_CERVEZA.Estado_Cabinas_Por_Viaje 
ADD CONSTRAINT FK_estado_cabina_por_viaje_con_cabina -- Nombre de la FK
FOREIGN KEY (id_cabina)
REFERENCES LOS_BARONES_DE_LA_CERVEZA.Cabinas(id_cabina)
GO

-- reserva de Estado_Cabinas_Por_Viaje referencia a id_reserva de Reserva
GO
ALTER TABLE LOS_BARONES_DE_LA_CERVEZA.Estado_Cabinas_Por_Viaje 
ADD CONSTRAINT FK_estado_cabina_por_viaje_con_reserva -- Nombre de la FK
FOREIGN KEY (reserva)
REFERENCES LOS_BARONES_DE_LA_CERVEZA.Reserva(id_reserva)
GO

-- compra de Estado_Cabinas_Por_Viaje referencia a id_compra de Compra
GO
ALTER TABLE LOS_BARONES_DE_LA_CERVEZA.Estado_Cabinas_Por_Viaje 
ADD CONSTRAINT FK_estado_cabina_por_viaje_con_compra -- Nombre de la FK
FOREIGN KEY (compra)
REFERENCES LOS_BARONES_DE_LA_CERVEZA.Compra(id_compra)
GO

/*******************************************************************************
							FIN - CREAMOS LAS FK'S
********************************************************************************/

------------------------------------------------------------------------------
			-- 6. PROCEDIMIENTOS ALMACENADOS/FUNCIONES (DE APLICACION/NEGOCIO)
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
	@tipo_servicio INT,
	@id_crucero_asignada INT OUT -- Retornamos el id_crucero asignado por SQL Server (IDENTITY)
)
AS
BEGIN
	BEGIN TRY
		BEGIN TRANSACTION 
			-- id_crucero se autogenera 
			INSERT INTO LOS_BARONES_DE_LA_CERVEZA.Cruceros 
			(fecha_alta, modelo, identificador, marca, tipo_servicio)
			VALUES (CONVERT(DATETIME2(3), @fecha_alta, 121), @modelo, @identificador, 
				[LOS_BARONES_DE_LA_CERVEZA].[UF_id_marca_crucero](@marca), @tipo_servicio) 

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
	@tipo_servicio INT,
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
					SET modelo = @modelo, marca = [LOS_BARONES_DE_LA_CERVEZA].[UF_id_marca_crucero](@marca), 
						tipo_servicio = @tipo_servicio
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
								SET modelo = @modelo, identificador = @identificador, 
									marca = [LOS_BARONES_DE_LA_CERVEZA].[UF_id_marca_crucero](@marca), tipo_servicio = @tipo_servicio
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
GO

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

/******************************************************************
[LOS_BARONES_DE_LA_CERVEZA].[UF_id_puerto] 
@Desc: Retorna el id de un puerto segun su nombre
******************************************************************/
CREATE FUNCTION [LOS_BARONES_DE_LA_CERVEZA].[UF_id_puerto]
(
	@nombre_puerto  NVARCHAR(255)
)
RETURNS INT 
AS 
BEGIN
	 DECLARE @id_puerto INT = (
		 SELECT id_puerto
		 FROM LOS_BARONES_DE_LA_CERVEZA.Puerto
		 WHERE puerto_nombre = UPPER(@nombre_puerto)
	)

	RETURN @id_puerto
END 
go


/******************************************************************
[LOS_BARONES_DE_LA_CERVEZA].[UF_destinos_segun_origen] 
@Desc: Retorna los posibles puerto destino segun un puerto origen
******************************************************************/

create FUNCTION [LOS_BARONES_DE_LA_CERVEZA].[UF_destinos_segun_origen]
(
	@nombre_puerto_origen  NVARCHAR(255)
)
RETURNS @destinos_posibles table (unDestino nvarchar(255))
AS 
BEGIN
	--declare table destinos_posibles
	declare @recorrido int
	declare destinos cursor local for ( select * from LOS_BARONES_DE_LA_CERVEZA.UF_recorridos_segun_origen(@nombre_puerto_origen)   )
	open destinos
	fetch next from destinos into @recorrido
	while @@FETCH_STATUS = 0
		begin 
			insert into @destinos_posibles select * from LOS_BARONES_DE_LA_CERVEZA.UF_destinos_segun_recorrido(@recorrido)
			where puerto_nombre not in (select * from @destinos_posibles)
			--select * into #destinos_posibles.unDestino from LOS_BARONES_DE_LA_CERVEZA.UF_destinos_segun_recorrido(@recorrido)
			fetch next from destinos into @recorrido
		end
	close destinos
	deallocate destinos
	return
END
go

/******************************************************************
[LOS_BARONES_DE_LA_CERVEZA].[UF_recorridos_segun_origen] 
@Desc: Retorna los recorridos que inician desde un mismo puerto
******************************************************************/

CREATE FUNCTION [LOS_BARONES_DE_LA_CERVEZA].[UF_recorridos_segun_origen] 
(
	@puerto_origen NVARCHAR(255)
)
RETURNS TABLE 
AS
return
	SELECT txr.id_recorrido
	FROM LOS_BARONES_DE_LA_CERVEZA.Tramos_por_Recorrido txr
		JOIN LOS_BARONES_DE_LA_CERVEZA.Tramo t
			ON txr.id_tramo = t.id_tramo
	WHERE txr.tramo_anterior is null AND t.tramo_puerto_inicio = (select id_puerto from LOS_BARONES_DE_LA_CERVEZA.Puerto where puerto_nombre = @puerto_origen)

go

--lo que dice el nombre

create FUNCTION [LOS_BARONES_DE_LA_CERVEZA].[UF_recorridos_segun_origen_y_destino] 
(
	@puerto_origen NVARCHAR(255),
	@puerto_destino NVARCHAR(255)
)
RETURNS TABLE 
AS
return
	SELECT txr.id_recorrido
		FROM LOS_BARONES_DE_LA_CERVEZA.Tramos_por_Recorrido txr
		JOIN LOS_BARONES_DE_LA_CERVEZA.Tramo t
				ON txr.id_tramo = t.id_tramo
		JOIN (select deOrigen.id_recorrido from [LOS_BARONES_DE_LA_CERVEZA].[UF_recorridos_segun_origen](@puerto_origen) as deOrigen) as deOrigenn 
				ON deOrigenn.id_recorrido = txr.id_recorrido
		JOIN LOS_BARONES_DE_LA_CERVEZA.Recorrido r
				on r.id_recorrido = txr.id_recorrido
		WHERE t.tramo_puerto_destino = (select id_puerto from LOS_BARONES_DE_LA_CERVEZA.Puerto where puerto_nombre = @puerto_destino)
			AND r.recorrido_estado = 0
go

/******************************************************************
[LOS_BARONES_DE_LA_CERVEZA].[UF_destinos_segun_recorrido] 
@Desc: Retorna los posibles destinos de un recorrido
******************************************************************/

CREATE FUNCTION [LOS_BARONES_DE_LA_CERVEZA].[UF_destinos_segun_recorrido] 
(
	@recorrido_id INT
)
RETURNS TABLE 
AS
return
	SELECT distinct p.puerto_nombre
	FROM LOS_BARONES_DE_LA_CERVEZA.Tramos_por_Recorrido txr
		JOIN LOS_BARONES_DE_LA_CERVEZA.Tramo t
			ON txr.id_tramo = t.id_tramo
		JOIN LOS_BARONES_DE_LA_CERVEZA.Puerto p
			ON p.id_puerto = t.tramo_puerto_destino
	WHERE txr.id_recorrido = @recorrido_id

 go


 /*
****** Object:  StoredProcedure [LOS_BARONES_DE_LA_CERVEZA].[USP_generar_compra]    Script Date: 27/06/2019 3:54:17 ******/

--generar una compra y devolver el id

CREATE  PROCEDURE [LOS_BARONES_DE_LA_CERVEZA].[USP_generar_compra] 
(
	@cantidad_cabinas INT,
	@id_viaje INT,
	@id_cliente INT,
	@precio_con_recargo FLOAT,
	@fecha_compra nvarchar(255), 
	@id_compra INT OUTPUT
)

AS
BEGIN
	INSERT into [GD1C2019].[LOS_BARONES_DE_LA_CERVEZA].[Compra] (compra_fecha,compra_cantidad,compra_numero_tarjeta,compra_precio_con_recargo, compra_id_forma_de_pago,compra_id_cliente, compra_id_viaje)
	values (convert(nvarchar(255),@fecha_compra,103), @cantidad_cabinas,null,@precio_con_recargo,2,@id_cliente,@id_viaje)
	SET @id_compra = SCOPE_IDENTITY()
END
Go

--Generar una reserva y devolver el id

GO
/****** Object:  StoredProcedure [LOS_BARONES_DE_LA_CERVEZA].[USP_generar_compra]    Script Date: 27/06/2019 3:54:17 ******/

--generar una compra y devolver el id

CREATE PROCEDURE [LOS_BARONES_DE_LA_CERVEZA].[USP_generar_reserva] 
(
	@cantidad_cabinas INT,
	@id_viaje INT,
	@id_cliente INT,
	@fecha_reserva nvarchar(255),
	@id_reserva INT OUTPUT
)

AS
BEGIN
	INSERT into [GD1C2019].[LOS_BARONES_DE_LA_CERVEZA].[Reserva] (reserva_fecha,reserva_cantidad_pasajes,reserva_cliente, reserva_viaje)
	values (convert(nvarchar(255),@fecha_reserva,103), @cantidad_cabinas,@id_cliente,@id_viaje)
	SET @id_reserva = SCOPE_IDENTITY()
END
go

/******************************************************************
[LOS_BARONES_DE_LA_CERVEZA].[USP_migrar_recorridos] 
@Desc: migra los recorridos y los asocia con los tramos
******************************************************************/

create procedure LOS_BARONES_DE_LA_CERVEZA.USP_migrar_recorridos
AS BEGIN

	--inserto los 2 que no tienen el mismo codigo primero
	
	INSERT INTO LOS_BARONES_DE_LA_CERVEZA.Recorrido(recorrido_codigo, recorrido_estado)
	VALUES ('43820864', 0);
	
	INSERT into LOS_BARONES_DE_LA_CERVEZA.Tramos_por_Recorrido (id_recorrido, id_tramo, tramo_anterior, tramo_siguiente)
	values (SCOPE_IDENTITY(), (select id_tramo from LOS_BARONES_DE_LA_CERVEZA.Tramo 
							   where tramo_puerto_inicio = (select id_puerto from LOS_BARONES_DE_LA_CERVEZA.Puerto where puerto_nombre = 'LUANDA')
							   and  tramo_puerto_destino = (select id_puerto from LOS_BARONES_DE_LA_CERVEZA.Puerto where puerto_nombre = 'ARGEL')), NULL, NULL)

	INSERT INTO LOS_BARONES_DE_LA_CERVEZA.Recorrido(recorrido_codigo, recorrido_estado)
	VALUES ('43820908', 0);

	INSERT into LOS_BARONES_DE_LA_CERVEZA.Tramos_por_Recorrido (id_recorrido, id_tramo, tramo_anterior, tramo_siguiente)
	values (SCOPE_IDENTITY(), (select id_tramo from LOS_BARONES_DE_LA_CERVEZA.Tramo 
							   where tramo_puerto_inicio = (select id_puerto from LOS_BARONES_DE_LA_CERVEZA.Puerto where puerto_nombre = 'MBABANE')
							   and  tramo_puerto_destino = (select id_puerto from LOS_BARONES_DE_LA_CERVEZA.Puerto where puerto_nombre = 'LUANDA')), NULL, NULL)

	declare @codigo decimal(18,0), @puerto1 nvarchar(255), @puerto2 nvarchar(255)

	DECLARE recor CURSOR LOCAL FOR
	select distinct RECORRIDO_CODIGO, PUERTO_DESDE, PUERTO_HASTA
	from gd_esquema.Maestra where recorrido_codigo != '43820864' AND recorrido_codigo != '43820908' order by RECORRIDO_CODIGO

	OPEN recor;
	FETCH NEXT FROM recor into @codigo, @puerto1, @puerto2
	WHILE @@FETCH_STATUS = 0	--mientras que el cursor no se vaya de la tabla
	BEGIN	
		if( exists(select * from LOS_BARONES_DE_LA_CERVEZA.Recorrido cod where cod.recorrido_codigo = CAST(@codigo as nvarchar(20)) ))
			begin
				--Primer Recorrido
				INSERT INTO LOS_BARONES_DE_LA_CERVEZA.Recorrido(recorrido_codigo, recorrido_estado)
				VALUES (@codigo * 10 + ABS(CHECKSUM(NEWID()) % 10), 0);
			end
		else
			begin
				--Primer Recorrido
				INSERT INTO LOS_BARONES_DE_LA_CERVEZA.Recorrido(recorrido_codigo, recorrido_estado)
				VALUES (@codigo, 0);
			end

		--Lo asocio con su tramo
		INSERT into LOS_BARONES_DE_LA_CERVEZA.Tramos_por_Recorrido(id_recorrido, id_tramo, tramo_anterior, tramo_siguiente)
		values (SCOPE_IDENTITY(),(select TR.id_tramo from LOS_BARONES_DE_LA_CERVEZA.Tramo TR where TR.tramo_puerto_inicio=(select id_puerto from LOS_BARONES_DE_LA_CERVEZA.Puerto PUE where PUE.puerto_nombre = @puerto1)
								  and TR.tramo_puerto_destino=(select id_puerto from LOS_BARONES_DE_LA_CERVEZA.Puerto PUE where PUE.puerto_nombre = @puerto2)),NULL,NULL)
		FETCH NEXT FROM recor into @codigo, @puerto1, @puerto2
	END
	CLOSE recor;
	deallocate recor;
END
GO

/******************************************************************
[LOS_BARONES_DE_LA_CERVEZA].[UF_cruceros_disponibles] 
@Desc: Retorna el listado de identificadores de los cruceros que 
se encuentran disponibles para realizar un viaje en la fecha de
inicio dado, es decir, no están ocupados haciendo otro viaje. Además,
sólo nos quedamos con los cruceros que no estén fuera de servicio y 
no hayan sido dados de baja de forma definitiva. 
******************************************************************/
ALTER FUNCTION [LOS_BARONES_DE_LA_CERVEZA].[UF_cruceros_disponibles] 
(
	@fecha_inicio_nuevo_viaje_s NVARCHAR(255),
	@fecha_fin_nuevo_viaje_s NVARCHAR(255)
)
RETURNS TABLE 
AS
RETURN 
	SELECT DISTINCT cru.identificador
	FROM LOS_BARONES_DE_LA_CERVEZA.Cruceros cru
		JOIN LOS_BARONES_DE_LA_CERVEZA.Viaje via
			ON cru.id_crucero = via.viaje_id_crucero
	WHERE CONVERT(DATETIME2(3), @fecha_inicio_nuevo_viaje_s, 121) > 
			(
				-- Le fecha de inicio de mi viaje debe ser mayor a la fecha de fin del 
				-- último viaje asignado del crucero
				SELECT TOP 1 via2.viaje_fecha_fin 
				FROM LOS_BARONES_DE_LA_CERVEZA.Cruceros cru2
					JOIN LOS_BARONES_DE_LA_CERVEZA.Viaje via2
						ON cru2.id_crucero = via2.viaje_id_crucero
				WHERE cru2.identificador = cru.identificador
				ORDER BY 1 DESC
			)
		AND cru.baja_fuera_servicio = 0
		AND cru.baja_vida_util = 0
	UNION
	SELECT cruceros_sin_viajes.identificador
	FROM LOS_BARONES_DE_LA_CERVEZA.Cruceros cruceros_sin_viajes
	WHERE cruceros_sin_viajes.id_crucero NOT IN 
		(
			SELECT cruceros_con_viajes.viaje_id_crucero
			FROM LOS_BARONES_DE_LA_CERVEZA.Viaje cruceros_con_viajes
		)

-- FIN [LOS_BARONES_DE_LA_CERVEZA].[UF_cruceros_disponibles] 
GO

/******************************************************************
[LOS_BARONES_DE_LA_CERVEZA].[USP_insertar_recorrido] 
@Desc: Inserta un nuevo recorrido en la tabla Recorridos
******************************************************************/
GO
CREATE PROCEDURE [LOS_BARONES_DE_LA_CERVEZA].[USP_insertar_recorrido]
(
	@identificador NVARCHAR(255),
	@id_recorrido_asignado INT OUT -- Retornamos el id_recorrido asignado por SQL Server (IDENTITY)
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

/******************************************************************
[LOS_BARONES_DE_LA_CERVEZA].[USP_actualizar_recorrido] 
@Desc: Actualiza el identificador de un recorrido existente
******************************************************************/
GO
CREATE PROCEDURE [LOS_BARONES_DE_LA_CERVEZA].[USP_actualizar_recorrido]
(
	@identificador_recorrido_anterior NVARCHAR(255),
	@identificador_recorrido_nuevo NVARCHAR(255),
	@id_recorrido_pk INT OUT -- Retornamos el id_recorrido (PK) del recorrido
)
AS
BEGIN
	BEGIN TRY
		BEGIN TRANSACTION 
			UPDATE LOS_BARONES_DE_LA_CERVEZA.Recorrido
			SET recorrido_codigo = @identificador_recorrido_nuevo
			WHERE recorrido_codigo = @identificador_recorrido_anterior;
			SET @id_recorrido_pk = (
									SELECT id_recorrido
									FROM LOS_BARONES_DE_LA_CERVEZA.Recorrido r
									WHERE r.recorrido_codigo = @identificador_recorrido_nuevo)
		COMMIT TRANSACTION 
	END TRY
	BEGIN CATCH
		ROLLBACK TRANSACTION
	END CATCH
END
GO

/******************************************************************
[LOS_BARONES_DE_LA_CERVEZA].[UF_listado_fuera_de_servicio] 
@Desc: 
******************************************************************/

create function LOS_BARONES_DE_LA_CERVEZA.UF_listado_fuera_de_servicio (@ano int, @semestre int)
RETURNS @Tabla_Resultado table (cruID int, cruIdentificador nvarchar(255), cruModelo nvarchar(50), cantidadDias int) 
AS begin

	declare @inicioSemestre datetime2(3), @finSemestre datetime2(3)
	set @inicioSemestre = convert(datetime2(3),(select CONCAT((select CAST(@ano AS varchar)),'-0', (case when @semestre = 1 then '1-01' else '7-00' end),' 00:00:00.000'  )),121)
	set @finSemestre =    convert(datetime2(3),(select CONCAT((select CAST(@ano AS varchar)),'-' , (case when @semestre = 1 then '07-01' else '12-31' end),' 00:00:00.000')),121)

	INSERT INTO @Tabla_Resultado
	--si todavia sigue fuera de servicio en esta query le pongo diferencia cero
	select top 5 FS.id_crucero,CRU.identificador, CRU.modelo,
	(SUM(datediff(DAY, case when FS.fecha_inicio_fuera_servicio < @inicioSemestre then @inicioSemestre else FS.fecha_inicio_fuera_servicio end, case when FS.fecha_fin_fuera_servicio > @finSemestre then @finSemestre else FS.fecha_fin_fuera_servicio end ))) as diferencia
	from LOS_BARONES_DE_LA_CERVEZA.Cruceros_Fuera_Servicio FS join LOS_BARONES_DE_LA_CERVEZA.Cruceros CRU on (CRU.id_crucero = FS.id_crucero)
	--con que una de las fechas este dentro del semestre ya tengo dias para contar
	where (@ano = year(FS.fecha_fin_fuera_servicio) and month(FS.fecha_fin_fuera_servicio) > (@semestre - 1) * 6 and month(FS.fecha_fin_fuera_servicio) < @semestre * (case when @semestre = 1 then 7 else 12 end))				--caso 1 fecha fin adentro
		OR(@ano = year(FS.fecha_inicio_fuera_servicio) and month(FS.fecha_inicio_fuera_servicio) > (@semestre - 1) * 6 and month(FS.fecha_inicio_fuera_servicio) < @semestre * (case when @semestre = 1 then 7 else 12 end))	--caso 2 fecha inicio adentro
		OR(FS.fecha_inicio_fuera_servicio < @inicioSemestre and FS.fecha_fin_fuera_servicio > @finSemestre)					--caso 3 ambas fechas afuera pero engloban el intervalo
	group by FS.id_crucero,CRU.identificador,CRU.modelo order by diferencia desc
	
	return
end
GO

/******************************************************************
[LOS_BARONES_DE_LA_CERVEZA].[UF_listado_cabinas_libres_por_viajes] 
@Desc: Elegimos por promedio y lo ponemos en la estrategia
******************************************************************/

--Top 5 de los recorridos con más cabinas libres en cada uno de los viajes realizados.

create function LOS_BARONES_DE_LA_CERVEZA.UF_listado_cabinas_libres_por_viajes (@ano int, @semestre int)
RETURNS @Tabla_Resultado table (recorridosFinales int, promedio int)
AS begin

	declare @inicioSemestre datetime2(3), @finSemestre datetime2(3)
	set @inicioSemestre = convert(datetime2(3),(select CONCAT((select CAST(@ano AS varchar)),'-0', (case when @semestre = 1 then '1-01' else '7-00' end),' 00:00:00.000'  )),121)
	set @finSemestre =    convert(datetime2(3),(select CONCAT((select CAST(@ano AS varchar)),'-' , (case when @semestre = 1 then '07-01' else '12-31' end),' 00:00:00.000')),121)

	INSERT INTO @Tabla_Resultado

	 select TOP 5 Sumas.recorri, AVG(Sumas.cabinas) as promedios from
	 --select recorri, viaj, cabinas from 
	 (select VI.viaje_id_recorrido as recorri , VI.id_viaje as viaj, COUNT(CAB.id_cabina) cabinas
	  from LOS_BARONES_DE_LA_CERVEZA.Recorrido REC join LOS_BARONES_DE_LA_CERVEZA.Viaje VI on REC.id_recorrido = VI.viaje_id_recorrido
	  join LOS_BARONES_DE_LA_CERVEZA.Cabinas CAB on CAB.crucero = VI.viaje_id_crucero
	  where CAB.id_cabina NOT IN (select ECV.id_cabina from LOS_BARONES_DE_LA_CERVEZA.Estado_Cabinas_Por_Viaje ECV where ECV.id_viaje = VI.id_viaje and ECV.compra IS NOT NULL)
		and (@ano = year(VI.viaje_fecha_fin_estimada) and month(VI.viaje_fecha_fin_estimada) > (@semestre - 1) * 6 and month(VI.viaje_fecha_fin_estimada) < @semestre * (case when @semestre = 1 then 7 else 12 end))	--caso 1 fecha fin adentro
		OR(@ano = year(VI.viaje_fecha_inicio) and month(VI.viaje_fecha_inicio) > (@semestre - 1) * 6 and month(VI.viaje_fecha_inicio) < @semestre * (case when @semestre = 1 then 7 else 12 end))						--caso 2 fecha inicio adentro
		OR(VI.viaje_fecha_inicio < @inicioSemestre and VI.viaje_fecha_fin_estimada > @finSemestre)																														--caso 3 ambas fechas afuera pero engloban el intervalo
	  group by VI.viaje_id_recorrido, VI.id_viaje) as Sumas

	  group by Sumas.recorri order by promedios desc
	return
end
GO

/******************************************************************
[LOS_BARONES_DE_LA_CERVEZA].[UF_crear_username_Cliente] 
@Desc: 
******************************************************************/

create function LOS_BARONES_DE_LA_CERVEZA.UF_crear_username_Cliente ( @nroDoc decimal(18,0), @telefono int )
returns nvarchar(100)
as begin
	return concat(convert(nvarchar(20), @nroDoc),convert(nvarchar(20), @telefono))
end
go

/******************************************************************
[LOS_BARONES_DE_LA_CERVEZA].[[USP_migrar_usuarios_clientes]] 
@Desc: les generamos username unico a partir de su nombre, apellido
y direccion
******************************************************************/

CREATE PROCEDURE [LOS_BARONES_DE_LA_CERVEZA].[USP_migrar_usuarios_clientes]
AS
BEGIN
	declare @nombre nvarchar(255), @apellido nvarchar(255), @dni decimal(18,0),@telefono int, @direccion nvarchar(255), @mail nvarchar(255), @fechaNac datetime2(3)
	declare @username nvarchar(100)
	
	declare clients cursor local for ( select distinct CLI_NOMBRE, CLI_APELLIDO, CLI_DNI, CLI_DIRECCION, CLI_TELEFONO, CLI_MAIL, CLI_FECHA_NAC from gd_esquema.Maestra)
	open clients
	fetch next from clients into @nombre,@apellido,@dni,@direccion,@telefono,@mail,@fechaNac
	while @@FETCH_STATUS = 0
		begin 
			--set @username = LOS_BARONES_DE_LA_CERVEZA.UF_crear_username_Cliente(@dni, @telefono)

			--INSERT INTO [LOS_BARONES_DE_LA_CERVEZA].Usuarios(usuario) values (@username) NO OLVIDARME DE SACAR EL NULL EN USUARIO DEL INSERT QUE SIGUE DESPUES DE ESTA LINEA

			INSERT INTO [LOS_BARONES_DE_LA_CERVEZA].Clientes(usuario, nombre, apellido, dni, direccion, telefono, mail, fecha_nacimiento, nro_tarjeta)
			values (NULL,replace(replace(replace(@nombre,' ','<>'),'><',''),'<>',' '), replace(replace(replace(@apellido,' ','<>'),'><',''),'<>',' '), @dni, @direccion, @telefono, @mail, @fechaNac, NULL)

			fetch next from clients into @nombre,@apellido,@dni,@direccion,@telefono,@mail,@fechaNac
		end
	close clients;
	deallocate clients;
END
GO

/*******************************************************************************
							FIN - PROCEDIMIENTOS ALMACENADOS/FUNCIONES
********************************************************************************/

------------------------------------------------------------------------------------------------------
						-- 7. CARGAMOS DATOS PREVIOS 
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

/******************************************************************
Generamos 2 formas de pago
@DESC: Como no tienen numero de tarjeta, asumimos que todos los pagos
de la maestra fueron realizados mediante efectivo
******************************************************************/

INSERT INTO [LOS_BARONES_DE_LA_CERVEZA].Forma_de_pago (forma_de_pago_nombre) VALUES
	('Tarjeta'),
	('Efectivo')
GO

/******************************************************************
Generamos 5 tipos de servicio segun estrellas
@DESC: Dato exigido en el enunciado que no esta en la maestra
******************************************************************/

INSERT INTO [LOS_BARONES_DE_LA_CERVEZA].tipo_servicio (servicio) VALUES
('1 estrella'),	('2 estrella'),	('3 estrella'),	('4 estrella'),	('5 estrella')
GO

/*******************************************************************************
							FIN - CARGA DE DATOS PREVIOS 
********************************************************************************/

------------------------------------------------------------------------------------------------------
						-- 8. MIGRACION DE DATOS DE LA TABLA MAESTRA 
------------------------------------------------------------------------------------------------------

/******************************************************************
Migramos los clientes de la Tabla Maestra
******************************************************************/

INSERT INTO [LOS_BARONES_DE_LA_CERVEZA].Clientes(usuario, nombre, apellido, dni, direccion, telefono, mail, fecha_nacimiento, nro_tarjeta)
select distinct NULL,replace(replace(replace(MR.CLI_NOMBRE,' ','<>'),'><',''),'<>',' '), replace(replace(replace(MR.CLI_APELLIDO,' ','<>'),'><',''),'<>',' '), CLI_DNI, CLI_DIRECCION, CLI_TELEFONO, CLI_MAIL, CLI_FECHA_NAC, NULL
from gd_esquema.Maestra MR

-- TARDA 5 segundos
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
go

/******************************************************************
Migramos los puertos de la tabla maestra.
@DESC: Estos valores no se pueden modificar ni agregar nuevos tipos.
******************************************************************/

INSERT INTO LOS_BARONES_DE_LA_CERVEZA.Puerto(puerto_nombre)
SELECT DISTINCT PUERTO_DESDE
FROM gd_esquema.Maestra 
go

/******************************************************************
Migramos los tramos de la tabla maestra.
@DESC: Estos valores no se pueden modificar ni agregar nuevos tipos.
******************************************************************/

INSERT INTO LOS_BARONES_DE_LA_CERVEZA.Tramo(tramo_puerto_inicio,tramo_puerto_destino,tramo_precio)
SELECT DISTINCT (select id_puerto from LOS_BARONES_DE_LA_CERVEZA.Puerto where PUERTO_DESDE = puerto_nombre),
				(select id_puerto from LOS_BARONES_DE_LA_CERVEZA.Puerto where PUERTO_HASTA = puerto_nombre), RECORRIDO_PRECIO_BASE
FROM gd_esquema.Maestra
go

/******************************************************************
Migramos los cruceros de la tabla maestra.
@DESC: Asumo que todos los de la maestra estan en servicio.
******************************************************************/

INSERT INTO [LOS_BARONES_DE_LA_CERVEZA].Cruceros
(fecha_alta, marca, modelo, identificador,	baja_fuera_servicio, baja_vida_util, fecha_baja_vida_util, tipo_servicio)
SELECT DISTINCT
	 convert(datetime2(3),'2019-05-06 00:00:00.000',121),	--yyyy-mm-dd hh:mi:ss.mmm datetime2(3)
	 (select id_marca from LOS_BARONES_DE_LA_CERVEZA.Marcas_Cruceros where marca = CRU_FABRICANTE),
	 CRUCERO_MODELO, CRUCERO_IDENTIFICADOR, 0, 0, NULL, 4
FROM gd_esquema.Maestra MA WHERE CRUCERO_MODELO IS NOT NULL
GO

/******************************************************************
Migramos los Recorridos, Tramos_por_Recorrido de la tabla maestra.
@DESC:  Por respuestas de ayudantes en el foro y por inconsistencias
en la maestra asumimos que todos los recorridos de esta son solo de
tramo, y en el sistema que construimos se puede tener recorridos de
mas de un tramo como lo exige el enunciado.
******************************************************************/

EXEC LOS_BARONES_DE_LA_CERVEZA.USP_migrar_recorridos

/******************************************************************
Migramos los viajes de la tabla maestra.
@DESC: Estos valores no se pueden modificar ni agregar nuevos tipos.
******************************************************************/

INSERT INTO [LOS_BARONES_DE_LA_CERVEZA].Viaje
(viaje_fecha_inicio, viaje_fecha_fin, viaje_fecha_fin_estimada, viaje_id_crucero, viaje_id_recorrido)
SELECT DISTINCT MR.FECHA_SALIDA, MR.FECHA_LLEGADA, MR.FECHA_LLEGADA_ESTIMADA,
	(select CRU.id_crucero from LOS_BARONES_DE_LA_CERVEZA.Cruceros CRU where CRU.identificador = MR.CRUCERO_IDENTIFICADOR and CRU.modelo = MR.CRUCERO_MODELO),
	(select REC.id_recorrido from LOS_BARONES_DE_LA_CERVEZA.Recorrido REC join LOS_BARONES_DE_LA_CERVEZA.Tramos_por_Recorrido TRE on REC.id_recorrido = TRE.id_recorrido 
	 join LOS_BARONES_DE_LA_CERVEZA.Tramo TA on TRE.id_tramo = TA.id_tramo where PUERTO_DESDE = (select P1.puerto_nombre from LOS_BARONES_DE_LA_CERVEZA.Puerto P1 where P1.id_puerto = TA.tramo_puerto_inicio) 
																			 and PUERTO_HASTA = (select P2.puerto_nombre from LOS_BARONES_DE_LA_CERVEZA.Puerto P2 where P2.id_puerto = TA.tramo_puerto_destino))
FROM gd_esquema.Maestra MR
GO

/******************************************************************
Migramos los cinco tipos de cabinas disponibles.
@DESC: Estos valores no se pueden modificar ni agregar nuevos tipos.
******************************************************************/

INSERT INTO LOS_BARONES_DE_LA_CERVEZA.Tipos_Cabinas(tipo_cabina, porcentaje_recargo)
SELECT DISTINCT CABINA_TIPO, CABINA_TIPO_PORC_RECARGO
FROM gd_esquema.Maestra

/******************************************************************
Migramos las compras de la tabla maestra.
@DESC: Los codigo de pasaje de la maestra van a ser los id_compra
de nuestra tabla
******************************************************************/

INSERT INTO [LOS_BARONES_DE_LA_CERVEZA].CompraAux
(	id_compra,
	compra_fecha,
	compra_precio_con_recargo,
	compra_id_viaje )
SELECT DISTINCT
	MR.PASAJE_CODIGO,
	MR.PASAJE_FECHA_COMPRA,
	MR.PASAJE_PRECIO,
	(SELECT id_viaje FROM [LOS_BARONES_DE_LA_CERVEZA].Viaje VI where 
			VI.viaje_id_crucero = (select id_crucero from LOS_BARONES_DE_LA_CERVEZA.Cruceros where MR.CRUCERO_IDENTIFICADOR = identificador and MR.CRUCERO_MODELO = modelo)
			and VI.viaje_id_recorrido = (select REC.id_recorrido from LOS_BARONES_DE_LA_CERVEZA.Recorrido REC join LOS_BARONES_DE_LA_CERVEZA.Tramos_por_Recorrido TRE on REC.id_recorrido = TRE.id_recorrido 
										  join LOS_BARONES_DE_LA_CERVEZA.Tramo TA on TRE.id_tramo = TA.id_tramo
										  where MR.PUERTO_DESDE = (select P1.puerto_nombre from LOS_BARONES_DE_LA_CERVEZA.Puerto P1 where P1.id_puerto = TA.tramo_puerto_inicio) 
										    and MR.PUERTO_HASTA = (select P2.puerto_nombre from LOS_BARONES_DE_LA_CERVEZA.Puerto P2 where P2.id_puerto = TA.tramo_puerto_destino))
		    and VI.viaje_fecha_inicio = MR.FECHA_SALIDA and MR.FECHA_LLEGADA_ESTIMADA = viaje_fecha_fin_estimada and MR.FECHA_LLEGADA = viaje_fecha_fin)
FROM (select PASAJE_CODIGO,PASAJE_FECHA_COMPRA,PASAJE_PRECIO,CRUCERO_IDENTIFICADOR,CRUCERO_MODELO,PUERTO_DESDE,PUERTO_HASTA,FECHA_SALIDA,FECHA_LLEGADA_ESTIMADA,FECHA_LLEGADA
	  from gd_esquema.Maestra where PASAJE_CODIGO IS NOT NULL) MR
GO

Set Identity_Insert [LOS_BARONES_DE_LA_CERVEZA].Compra ON  

insert into LOS_BARONES_DE_LA_CERVEZA.Compra 
(id_compra,
 compra_fecha,
 compra_cantidad,
 compra_numero_tarjeta,			--Es NULL porque son todas compras en efectivo y el dato no esta en la maestra
 compra_precio_con_recargo,
 compra_id_forma_de_pago,
 compra_id_viaje
 )
select
 id_compra,
 compra_fecha,
 1,								--En la maestra todos compran de a una sola cabina
 NULL,							--No hay nro tarjeta en la maestra
 compra_precio_con_recargo,
 2,								--Como no hay numeros de tarjeta en la maestra asumo que todas las formas de pago fueron efectivo
 compra_id_viaje
 from LOS_BARONES_DE_LA_CERVEZA.CompraAux

Set Identity_Insert [LOS_BARONES_DE_LA_CERVEZA].Compra OFF

/******************************************************************
Migramos las reservas de la tabla maestra.
@DESC: Los codigo de reserva de la maestra van a ser los id_reserva
de nuestra tabla
******************************************************************/

INSERT INTO [LOS_BARONES_DE_LA_CERVEZA].ReservaAux
(	id_reserva,
	reserva_fecha,
	reserva_cantidad_pasajes,
	reserva_viaje )
SELECT DISTINCT
	 MR.RESERVA_CODIGO,
	 MR.RESERVA_FECHA,
	 1,
	 (SELECT id_viaje FROM [LOS_BARONES_DE_LA_CERVEZA].Viaje VI where VI.viaje_id_crucero = (select id_crucero from LOS_BARONES_DE_LA_CERVEZA.Cruceros where MR.CRUCERO_IDENTIFICADOR = identificador and MR.CRUCERO_MODELO = modelo)
	 and VI.viaje_id_recorrido = (select REC.id_recorrido from LOS_BARONES_DE_LA_CERVEZA.Recorrido REC join LOS_BARONES_DE_LA_CERVEZA.Tramos_por_Recorrido TRE on REC.id_recorrido = TRE.id_recorrido 
								  join LOS_BARONES_DE_LA_CERVEZA.Tramo TA on TRE.id_tramo = TA.id_tramo 
								  where MR.PUERTO_DESDE = (select P1.puerto_nombre from LOS_BARONES_DE_LA_CERVEZA.Puerto P1 where P1.id_puerto = TA.tramo_puerto_inicio) 
								  and MR.PUERTO_HASTA = (select P2.puerto_nombre from LOS_BARONES_DE_LA_CERVEZA.Puerto P2 where P2.id_puerto = TA.tramo_puerto_destino))
	 and VI.viaje_fecha_inicio = MR.FECHA_SALIDA and MR.FECHA_LLEGADA_ESTIMADA = viaje_fecha_fin_estimada and MR.FECHA_LLEGADA = viaje_fecha_fin)
FROM (select CRUCERO_IDENTIFICADOR, CRUCERO_MODELO, PUERTO_DESDE,PUERTO_HASTA, FECHA_SALIDA,FECHA_LLEGADA, FECHA_LLEGADA_ESTIMADA, RESERVA_CODIGO, RESERVA_FECHA
	  from gd_esquema.Maestra where PASAJE_CODIGO IS NULL) MR
GO

Set Identity_Insert [LOS_BARONES_DE_LA_CERVEZA].Reserva ON  

insert into LOS_BARONES_DE_LA_CERVEZA.Reserva 
(id_reserva,
 reserva_cantidad_pasajes,
 reserva_cliente,
 reserva_fecha,
 reserva_viaje
 )
select
 id_reserva,
 reserva_cantidad_pasajes,
 reserva_cliente,
 reserva_fecha,
 reserva_viaje
 from LOS_BARONES_DE_LA_CERVEZA.ReservaAux

Set Identity_Insert [LOS_BARONES_DE_LA_CERVEZA].Reserva OFF

/******************************************************************
Migramos las cabinas de todos los cruceros.
@DESC: En la maestra vemos que solo figuran las compradas.
******************************************************************/

INSERT INTO [LOS_BARONES_DE_LA_CERVEZA].Cabinas
(	tipo_cabina,
	crucero,
	numero,
	piso )
SELECT DISTINCT
	 (select id_tipo_cabina from LOS_BARONES_DE_LA_CERVEZA.Tipos_Cabinas where MR.CABINA_TIPO = tipo_cabina),
	 (select id_crucero from LOS_BARONES_DE_LA_CERVEZA.Cruceros CR where MR.CRUCERO_IDENTIFICADOR = CR.identificador and MR.CRUCERO_MODELO = CR.modelo
	  and MR.CRU_FABRICANTE = ( select distinct MAR.marca from LOS_BARONES_DE_LA_CERVEZA.Marcas_Cruceros MAR where MAR.id_marca = CR.marca)),
	 MR.CABINA_NRO,
	 MR.CABINA_PISO
FROM gd_esquema.Maestra MR
GO

/******************************************************************
Migramos los viajes de la tabla maestra.
@DESC: Estos valores no se pueden modificar ni agregar nuevos tipos.
******************************************************************/
--Instrucción INSERT en conflicto con la restricción FOREIGN KEY "FK_estado_cabina_por_viaje_con_compra". El conflicto ha aparecido en la base de datos "GD1C2019", tabla "LOS_BARONES_DE_LA_CERVEZA.Compra", column 'id_compra'.

INSERT INTO [LOS_BARONES_DE_LA_CERVEZA].Estado_Cabinas_Por_Viaje(id_viaje, id_cabina, reserva, compra)
SELECT DISTINCT 
(SELECT VI.id_viaje FROM [LOS_BARONES_DE_LA_CERVEZA].Viaje VI where VI.viaje_id_crucero = (select CR.id_crucero from LOS_BARONES_DE_LA_CERVEZA.Cruceros CR where MR.CRUCERO_IDENTIFICADOR = CR.identificador and MR.CRUCERO_MODELO = CR.modelo)
				 and VI.viaje_fecha_inicio = MR.FECHA_SALIDA and MR.FECHA_LLEGADA_ESTIMADA = viaje_fecha_fin_estimada
				 and VI.viaje_id_recorrido = (select REC.id_recorrido from LOS_BARONES_DE_LA_CERVEZA.Recorrido REC join LOS_BARONES_DE_LA_CERVEZA.Tramos_por_Recorrido TRE on REC.id_recorrido = TRE.id_recorrido 
											  join LOS_BARONES_DE_LA_CERVEZA.Tramo TA on TRE.id_tramo = TA.id_tramo 
											  where MR.PUERTO_DESDE = (select P1.puerto_nombre from LOS_BARONES_DE_LA_CERVEZA.Puerto P1 where P1.id_puerto = TA.tramo_puerto_inicio) 
											  and MR.PUERTO_HASTA = (select P2.puerto_nombre from LOS_BARONES_DE_LA_CERVEZA.Puerto P2 where P2.id_puerto = TA.tramo_puerto_destino))),
(select CAB.id_cabina from LOS_BARONES_DE_LA_CERVEZA.Cabinas CAB where MR.CABINA_NRO = CAB.numero and MR.CABINA_PISO = CAB.piso 
 and CAB.crucero = (select CR.id_crucero from LOS_BARONES_DE_LA_CERVEZA.Cruceros CR where MR.CRUCERO_IDENTIFICADOR = CR.identificador and MR.CRUCERO_MODELO = CR.modelo)
 and CAB.tipo_cabina = (select TC.id_tipo_cabina from LOS_BARONES_DE_LA_CERVEZA.Tipos_Cabinas TC where MR.CABINA_TIPO = TC.tipo_cabina)),
NULL,
(select id_compra from LOS_BARONES_DE_LA_CERVEZA.Compra where id_compra = MR.PASAJE_CODIGO)
FROM gd_esquema.Maestra MR where PASAJE_CODIGO IS NOT NULL
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

/*******************************************************************************
							FIN - TRIGGERS
********************************************************************************/

ALTER TABLE LOS_BARONES_DE_LA_CERVEZA.Reserva ALTER COLUMN reserva_cliente int;

-- usuario de Clientes lo vinculo con usuario de Usuarios 

GO
ALTER TABLE LOS_BARONES_DE_LA_CERVEZA.Clientes 
ADD CONSTRAINT FK_cliente_usuario -- Nombre de la FK
FOREIGN KEY (usuario)
REFERENCES LOS_BARONES_DE_LA_CERVEZA.Usuarios(usuario) 
GO

-- Vinculo id_cliente de Cliente con compra_id_cliente de Compra

GO
ALTER TABLE [LOS_BARONES_DE_LA_CERVEZA].Compra
ADD CONSTRAINT FK_cliente_compra
FOREIGN KEY (compra_id_cliente)
REFERENCES LOS_BARONES_DE_LA_CERVEZA.Clientes(id_cliente)
GO

-- Vinculo id_cliente de Cliente con reserva_cliente de Reserva

GO
ALTER TABLE [LOS_BARONES_DE_LA_CERVEZA].Reserva
ADD CONSTRAINT FK_cliente_reserva
FOREIGN KEY (reserva_cliente)
REFERENCES LOS_BARONES_DE_LA_CERVEZA.Clientes(id_cliente)
GO
