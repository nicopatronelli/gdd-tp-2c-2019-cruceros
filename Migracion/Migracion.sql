--------------------------------------------ELIMINO TODO ANTES DE MIGRAR--------------------------------------------------

--------------------------------------------------------------------------------------------------------------------------
--------------------------------------------------ELIMINAR TABLAS---------------------------------------------------------
--------------------------------------------------------------------------------------------------------------------------

--LAS BORRAMOS EN CASCADA SEGUN SU DEPENDENCIA

IF OBJECT_ID ('[LOS_BARONES_DE_LA_CERVEZA].Item_factura' , 'U' ) IS NOT NULL DROP TABLE [LOS_BARONES_DE_LA_CERVEZA].Item_factura; 				 --Eliminamos tabla existente de Item Factura
GO
IF OBJECT_ID ('[LOS_BARONES_DE_LA_CERVEZA].Factura' , 'U' ) IS NOT NULL DROP TABLE [LOS_BARONES_DE_LA_CERVEZA].Factura; 					     --Eliminamos tabla existente de Factura
GO
IF OBJECT_ID ('[LOS_BARONES_DE_LA_CERVEZA].Reserva' , 'U' ) IS NOT NULL DROP TABLE [LOS_BARONES_DE_LA_CERVEZA].Reserva; 					     --Eliminamos tabla existente de Reserva
GO
IF OBJECT_ID ('[LOS_BARONES_DE_LA_CERVEZA].Compra' , 'U' ) IS NOT NULL DROP TABLE [LOS_BARONES_DE_LA_CERVEZA].Compra; 							 --Eliminamos tabla existente de Compra
GO
IF OBJECT_ID ('[LOS_BARONES_DE_LA_CERVEZA].Forma_de_pago' , 'U' ) IS NOT NULL DROP TABLE [LOS_BARONES_DE_LA_CERVEZA].Forma_de_pago; 			 --Eliminamos tabla existente de Forma_de_pago
GO
IF OBJECT_ID ('[LOS_BARONES_DE_LA_CERVEZA].Viaje' , 'U' ) IS NOT NULL DROP TABLE [LOS_BARONES_DE_LA_CERVEZA].Viaje; 							 --Eliminamos tabla existente de Viaje
GO
IF OBJECT_ID ('[LOS_BARONES_DE_LA_CERVEZA].Recorrido' , 'U' ) IS NOT NULL DROP TABLE [LOS_BARONES_DE_LA_CERVEZA].Recorrido; 					 --Eliminamos tabla existente de Recorrido
GO
IF OBJECT_ID ('[LOS_BARONES_DE_LA_CERVEZA].Puerto' , 'U' ) IS NOT NULL DROP TABLE [LOS_BARONES_DE_LA_CERVEZA].Puerto; 						     --Eliminamos tabla existente de Puerto
GO
IF OBJECT_ID ('[LOS_BARONES_DE_LA_CERVEZA].Cabina' , 'U' ) IS NOT NULL DROP TABLE [LOS_BARONES_DE_LA_CERVEZA].Cabina; 						     --Eliminamos tabla existente de Cabina
GO
IF OBJECT_ID ('[LOS_BARONES_DE_LA_CERVEZA].Tipo_servicio' , 'U' ) IS NOT NULL DROP TABLE [LOS_BARONES_DE_LA_CERVEZA].Tipo_servicio; 			 --Eliminamos tabla existente de Tipo_servicio
GO
IF OBJECT_ID ('[LOS_BARONES_DE_LA_CERVEZA].Fuera_de_servicio' , 'U' ) IS NOT NULL DROP TABLE [LOS_BARONES_DE_LA_CERVEZA].Fuera_de_servicio; 	 --Eliminamos tabla existente de Fuera_de_servicio
GO
IF OBJECT_ID ('[LOS_BARONES_DE_LA_CERVEZA].Crucero' , 'U' ) IS NOT NULL DROP TABLE [LOS_BARONES_DE_LA_CERVEZA].Crucero; 					     --Eliminamos tabla existente de Crucero
GO
IF OBJECT_ID ('[LOS_BARONES_DE_LA_CERVEZA].Marca' , 'U' ) IS NOT NULL DROP TABLE [LOS_BARONES_DE_LA_CERVEZA].Marca; 							 --Eliminamos tabla existente de Marca
GO
IF OBJECT_ID ('[LOS_BARONES_DE_LA_CERVEZA].Cliente' , 'U' ) IS NOT NULL DROP TABLE [LOS_BARONES_DE_LA_CERVEZA].Cliente; 					     --Eliminamos tabla existente de Cliente
GO
IF OBJECT_ID ('[LOS_BARONES_DE_LA_CERVEZA].Rol_x_usuario' , 'U' ) IS NOT NULL DROP TABLE [LOS_BARONES_DE_LA_CERVEZA].Rol_x_usuario; 			 --Eliminamos tabla existente de Rol_x_usuario
GO
IF OBJECT_ID ('[LOS_BARONES_DE_LA_CERVEZA].Usuario' , 'U' ) IS NOT NULL DROP TABLE [LOS_BARONES_DE_LA_CERVEZA].Usuario; 					     --Eliminamos tabla existente de Usuario
GO
IF OBJECT_ID ('[LOS_BARONES_DE_LA_CERVEZA].Funcionalidad_x_rol', 'U') IS NOT NULL DROP TABLE [LOS_BARONES_DE_LA_CERVEZA].Funcionalidad_x_rol;    --Eliminamos tabla existente de Funcionalidad por Rol
GO
IF OBJECT_ID('[LOS_BARONES_DE_LA_CERVEZA].Funcionalidad', 'U') IS NOT NULL DROP TABLE [LOS_BARONES_DE_LA_CERVEZA].Funcionalidad; 			     --Eliminamos tabla existente de Funcionalidad
GO
IF OBJECT_ID ('[LOS_BARONES_DE_LA_CERVEZA].Rol_x_usuario', 'U') IS NOT NULL	DROP TABLE [LOS_BARONES_DE_LA_CERVEZA].Rol_x_usuario; 				 --Eliminamos tabla existente de Rol por Usuario
GO
IF OBJECT_ID ('[LOS_BARONES_DE_LA_CERVEZA].Rol' , 'U' ) IS NOT NULL DROP TABLE [LOS_BARONES_DE_LA_CERVEZA].Rol; 							     --Eliminamos tabla existente de Rol
GO
--------------------------------------------------------------------------------------------------------------------------
--------------------------------------------------ELIMINAR ESQUEMA--------------------------------------------------------
--------------------------------------------------------------------------------------------------------------------------
IF SCHEMA_ID('LOS_BARONES_DE_LA_CERVEZA') IS NOT NULL DROP SCHEMA [LOS_BARONES_DE_LA_CERVEZA]
GO



-------------------------------------------------COMIENZA MIGRACION-------------------------------------------------------
--------------------------------------------------------------------------------------------------------------------------
--------------------------------------------------CREACION ESQUEMA--------------------------------------------------------
--------------------------------------------------------------------------------------------------------------------------
use GD1C2019; 
GO

create schema [LOS_BARONES_DE_LA_CERVEZA] authorization gdCruceros2019
GO
--------------------------------------------------------------------------------------------------------------------------
--------------------------------------------------CREACION TABLAS---------------------------------------------------------
--------------------------------------------------------------------------------------------------------------------------

--Creamos la tabla de Funcionalidad
CREATE TABLE [LOS_BARONES_DE_LA_CERVEZA].Funcionalidad
(	id_funcionalidad int identity (1,1) NOT NULL,
	funcionalidad_descripcion nvarchar(255),
	CONSTRAINT pk_id_funcionalidad PRIMARY KEY CLUSTERED (id_funcionalidad) )
GO

--Creamos la tabla de Rol
CREATE TABLE [LOS_BARONES_DE_LA_CERVEZA].Rol
(	id_rol int identity (1,1) NOT NULL,
	rol_nombre nvarchar(50),
	rol_estado bit, --si devuelve 0 es inhabilitado, si de vuelve 1 es habilitado
	CONSTRAINT pk_id_rol PRIMARY KEY CLUSTERED  (id_rol) )
GO

--Creamos la tabla de Funcionalidad por Rol
CREATE TABLE [LOS_BARONES_DE_LA_CERVEZA].Funcionalidad_x_rol
(	id_funcionalidad_x_rol int identity (1,1) NOT NULL,
	id_rol int,
	id_funcionalidad int,
	CONSTRAINT pk_id_rol_por_funcionalidad PRIMARY KEY CLUSTERED (id_funcionalidad_x_rol) )
GO

--Asociamos las FKs de Funcionalidad y Rol para la relacion Muchos a Muchos
Alter table [LOS_BARONES_DE_LA_CERVEZA].Funcionalidad_x_rol add
constraint fk_id_rolFuncionalidad foreign key (id_rol) references [LOS_BARONES_DE_LA_CERVEZA].rol(id_rol),
constraint fk_id_funcionalidadRol foreign key (id_funcionalidad) references [LOS_BARONES_DE_LA_CERVEZA].Funcionalidad(id_funcionalidad)
GO

--Creamos la tabla de Usuario
CREATE TABLE [LOS_BARONES_DE_LA_CERVEZA].Usuario
(	id_usuario int identity (1,1) NOT NULL,
	usuario_username nvarchar (100),
	usuario_password nvarchar (255),
	usuario_intentos_fallidos tinyint default 0,  --Los intentos arrancan en 0 por default 
	usuario_estado bit,
	CONSTRAINT pk_id_usuario PRIMARY KEY CLUSTERED (id_usuario) )
GO

--Creamos la tabla de Rol por Usuario
CREATE TABLE [LOS_BARONES_DE_LA_CERVEZA].Rol_x_usuario
(	id_rol_x_usuario int identity (1,1) NOT NULL,
	id_usuario int,
	id_rol int,
	CONSTRAINT pk_id_rol_por_usuario PRIMARY KEY CLUSTERED (id_rol_x_usuario) )
GO

--Asociamos las FKs de Rol y Usuario para la relacion Muchos a Muchos
Alter table [LOS_BARONES_DE_LA_CERVEZA].Rol_x_usuario add
constraint fk_id_rolUsuario foreign key (id_rol) references [LOS_BARONES_DE_LA_CERVEZA].rol(id_rol),
constraint fk_id_usuarioRol foreign key (id_usuario) references [LOS_BARONES_DE_LA_CERVEZA].usuario(id_usuario)
GO

--Creamos la tabla de Cliente
CREATE TABLE [LOS_BARONES_DE_LA_CERVEZA].Cliente
(	id_cliente int identity (1,1) NOT NULL,
	cliente_nombre nvarchar(100),
	cliente_apellido nvarchar(100),
	cliente_DNI decimal(18,0) NOT NULL,
	cliente_direccion nvarchar(100),
	cliente_telefono int,
	cliente_numero_de_tarjeta nvarchar(50),
	cliente_fecha_nacimiento datetime2(3),
	cliente_mail nvarchar(100),
	cliente_id_usuario int,
	CONSTRAINT pk_id_cliente PRIMARY KEY CLUSTERED (id_cliente) )
GO

--Asociamos la FK de Usuario a Cliente
alter table [LOS_BARONES_DE_LA_CERVEZA].Cliente add
constraint fk_id_usuarioCliente foreign key (cliente_id_usuario) references [LOS_BARONES_DE_LA_CERVEZA].usuario(id_usuario)
GO

--Creamos la tabla de Marca
CREATE TABLE [LOS_BARONES_DE_LA_CERVEZA].Marca
(	id_marca int identity (1,1) NOT NULL,
	marca_nombre nvarchar(100),
	CONSTRAINT pk_id_marca PRIMARY KEY CLUSTERED (id_marca) )
GO

--Creamos la tabla de Crucero
CREATE TABLE [LOS_BARONES_DE_LA_CERVEZA].Crucero 
(	id_crucero int identity (1,1) NOT NULL,
	crucero_fecha_de_alta datetime2(3),
	crucero_modelo nvarchar(50),
	crucero_identificador nvarchar(50),
	crucero_baja_por_fuera_de_servicio bit,
	crucero_baja_por_vida_util bit,
	crucero_fecha_de_baja_definitiva datetime2(3),
	crucero_id_marca int
	CONSTRAINT pk_id_crucero PRIMARY KEY CLUSTERED (id_crucero) )
GO

--Asociamos la FK de Marca a Crucero
alter table [LOS_BARONES_DE_LA_CERVEZA].Crucero add
constraint fk_id_marcaCrucero foreign key (crucero_id_marca) references [LOS_BARONES_DE_LA_CERVEZA].Marca(id_marca)
GO

--Creamos la tabla de Fuera de servicio
CREATE TABLE [LOS_BARONES_DE_LA_CERVEZA].Fuera_de_servicio
(	id_fuera_de_servicio int identity (1,1) NOT NULL,
	fuera_de_servicio_fecha datetime2(3),
	fuera_de_servicio_fecha_reinicio datetime2(3),
	fuera_de_servicio_id_crucero int
	CONSTRAINT pk_id_tipo_publicacion PRIMARY KEY CLUSTERED (id_fuera_de_servicio) )
GO

--Asociamos la FK de Crucero a Fuera de servicio
alter table [LOS_BARONES_DE_LA_CERVEZA].Fuera_de_servicio add
constraint fk_id_cruceroFueraDeServicio foreign key (fuera_de_servicio_id_crucero) references [LOS_BARONES_DE_LA_CERVEZA].Crucero(id_crucero)
GO

--Creamos la tabla de Tipo servicio
CREATE TABLE [LOS_BARONES_DE_LA_CERVEZA].Tipo_servicio
(	id_tipo_servicio int identity (1,1) NOT NULL,
	tipo_servicio_descripcion nvarchar(255),
	tipo_servicio_porcentage_recargo decimal(18,2),
	CONSTRAINT pk_id_tipo_servicio PRIMARY KEY CLUSTERED (id_tipo_servicio) )
GO

--Creamos la tabla de Cabina
CREATE TABLE [LOS_BARONES_DE_LA_CERVEZA].Cabina
(	id_cabina int identity (1,1) NOT NULL,
	cabina_estado bit default 0,          --0 no comprada/reservada, 1 comprada/reservada
	cabina_piso decimal(18,0),
	cabina_nro decimal(18,0),
	cabina_tipo_servicio int,
	cabina_crucero int,
	CONSTRAINT pk_id_cabina PRIMARY KEY CLUSTERED (id_cabina) )
GO

--Asociamos la FK de Crucero y de Tipo de servicio a Cabina
alter table [LOS_BARONES_DE_LA_CERVEZA].Cabina add
constraint fk_id_cruceroCabina foreign key (cabina_crucero) references [LOS_BARONES_DE_LA_CERVEZA].Crucero(id_crucero),
constraint fk_id_tipoServicioCabina foreign key (cabina_tipo_servicio) references [LOS_BARONES_DE_LA_CERVEZA].Tipo_servicio(id_tipo_servicio)
GO

--Creamos la tabla de Puerto
CREATE TABLE [LOS_BARONES_DE_LA_CERVEZA].Puerto
(	id_puerto int identity (1,1) NOT NULL,
	puerto_nombre nvarchar(255),
	CONSTRAINT pk_id_forma_de_pago PRIMARY KEY CLUSTERED (id_puerto) )
GO


--Cada fila reprecenta un tramo de un recorrido
--Creamos la tabla de Recorrido
CREATE TABLE [LOS_BARONES_DE_LA_CERVEZA].Recorrido 
(	id_recorrido int identity (1,1) NOT NULL,
	recorrido_codigo int,
	recorrido_puerto_inicio int,   --Ciudad = Puerto
	recorrido_puerto_destino int,  --Ciudad = Puerto
	recorrido_precio_tramo decimal(18,2),
	recorrido_estado bit,
	recorrido_siguiente int,
	recorrido_anterior int,
	CONSTRAINT pk_id_publicacion PRIMARY KEY CLUSTERED (id_recorrido) )
GO

--Asociamos la FK de Puerto a Recorrido y tambien Recorrido a si mismo en siguiente y anterior
alter table [LOS_BARONES_DE_LA_CERVEZA].Recorrido add
constraint fk_id_puertoInicioRecorrido foreign key (recorrido_puerto_inicio) references [LOS_BARONES_DE_LA_CERVEZA].Puerto(id_puerto),
constraint fk_id_puertoDestinoRecorrido foreign key (recorrido_puerto_destino) references [LOS_BARONES_DE_LA_CERVEZA].Puerto(id_puerto),
constraint fk_id_recorridoAnterior foreign key (recorrido_siguiente) references [LOS_BARONES_DE_LA_CERVEZA].Recorrido(id_recorrido),
constraint fk_id_recorridoSiguiente foreign key (recorrido_anterior) references [LOS_BARONES_DE_LA_CERVEZA].Recorrido(id_recorrido)
GO

--Creamos la tabla de Viaje
CREATE TABLE [LOS_BARONES_DE_LA_CERVEZA].Viaje
(	id_viaje int identity (1,1) NOT NULL,
	viaje_fecha_inicio datetime2(3),
	viaje_fecha_fin datetime2(3),
	viaje_fecha_fin_estimada datetime2(3),
	viaje_id_crucero int,
	viaje_id_recorrido int,
	CONSTRAINT pk_id_fecha_publicacion PRIMARY KEY CLUSTERED (id_viaje) )
GO

--Asociamos la FK de Crucero y Recorrido a Viaje
alter table [LOS_BARONES_DE_LA_CERVEZA].Viaje add
constraint fk_id_cruceroViaje foreign key (viaje_id_crucero) references [LOS_BARONES_DE_LA_CERVEZA].Crucero(id_crucero),
constraint fk_id_recorridoViaje foreign key (viaje_id_recorrido) references [LOS_BARONES_DE_LA_CERVEZA].Recorrido(id_recorrido)
GO

--Creamos la tabla de Forma de Pago
CREATE TABLE [LOS_BARONES_DE_LA_CERVEZA].Forma_de_pago
(	id_forma_de_pago int identity (1,1) NOT NULL,
	forma_de_pago_nombre nvarchar(20),
	CONSTRAINT pk_id_forma_pago PRIMARY KEY CLUSTERED (id_forma_de_pago) )
GO

--Creamos la tabla de Compra
CREATE TABLE [LOS_BARONES_DE_LA_CERVEZA].Compra
(	id_compra int identity (1,1) NOT NULL,
	compra_fecha datetime2(3),
	compra_cantidad int,
	compra_numero_tarjeta nvarchar(50),
	compra_precio_con_recargo decimal(18,2),
	compra_id_forma_de_pago int,
	compra_id_cliente int,
	compra_id_viaje int,
	CONSTRAINT pk_id_compra PRIMARY KEY CLUSTERED (id_compra) ) 
GO

--Asociamos la FK de Forma de pago, Cliente y Viaje a Compra
alter table [LOS_BARONES_DE_LA_CERVEZA].Compra add
constraint fk_id_formaDePagoCompra foreign key (compra_id_forma_de_pago) references [LOS_BARONES_DE_LA_CERVEZA].Forma_de_Pago(id_forma_de_pago),
constraint fk_id_clienteCompra foreign key (compra_id_cliente) references [LOS_BARONES_DE_LA_CERVEZA].Cliente(id_cliente),
constraint fk_id_viajeCompra foreign key (compra_id_viaje) references [LOS_BARONES_DE_LA_CERVEZA].Viaje(id_viaje)
GO

--Creamos la tabla de Reserva
CREATE TABLE [LOS_BARONES_DE_LA_CERVEZA].Reserva
(	id_reserva int identity (1,1) NOT NULL,
	reserva_fecha datetime2(3),
	reserva_cantidad_pasajes int,
	reserva_cliente int,
	reserva_viaje int,
	CONSTRAINT pk_id_Reserva PRIMARY KEY CLUSTERED (id_reserva) ) 
GO

--Asociamos la FK de Forma de pago, Cliente y Viaje a Reserva
alter table [LOS_BARONES_DE_LA_CERVEZA].Reserva add
constraint fk_id_clienteReserva foreign key (reserva_cliente) references [LOS_BARONES_DE_LA_CERVEZA].Cliente(id_cliente),
constraint fk_id_viajeReserva foreign key (reserva_viaje) references [LOS_BARONES_DE_LA_CERVEZA].Viaje(id_viaje)
GO

--Creamos la tabla de Factura
CREATE TABLE [LOS_BARONES_DE_LA_CERVEZA].Factura
(	id_factura int identity (1,1) NOT NULL,
	factura_fecha datetime2(3),
	factura_tipo char(1),
	factura_total numeric(18,0),
	factura_id_viaje int,    
	CONSTRAINT pk_id_factura PRIMARY KEY CLUSTERED (id_factura) )
GO

--Asociamos la FK de Viaje a Factura
alter table [LOS_BARONES_DE_LA_CERVEZA].Factura add
constraint fk_id_viajeFactura foreign key (factura_id_viaje) references [LOS_BARONES_DE_LA_CERVEZA].Viaje(id_viaje)
GO

--Creamos la tabla de Item Factura
CREATE TABLE [LOS_BARONES_DE_LA_CERVEZA].Item_factura
(	id_item_factura int identity (1,1) NOT NULL,
	item_factura_cantidad int,
	item_factura_monto decimal(18,0),
	item_fecha_compra datetime2(3),
	item_tipo_servicio_descripcion nvarchar(255),
	item_factura_id_factura int,
	CONSTRAINT pk_id_item_factura PRIMARY KEY CLUSTERED (id_item_factura) )
GO

--Asociamos la FK de Factura a Item_factura
alter table [LOS_BARONES_DE_LA_CERVEZA].Item_factura add
constraint fk_id_facturaItemFactura foreign key (item_factura_id_factura) references [LOS_BARONES_DE_LA_CERVEZA].Factura(id_factura)
GO
--------------------------------------------------------------------------------------------------------------------------
--------------------------------------------------MIGRACION DE DATOS------------------------------------------------------
--------------------------------------------------------------------------------------------------------------------------

--Insertamos los datos que queremos que sean desplegables

INSERT INTO [LOS_BARONES_DE_LA_CERVEZA].Forma_de_pago (forma_de_pago_nombre) VALUES
	('Tarjeta'),
	('Efectivo')
GO

insert into [LOS_BARONES_DE_LA_CERVEZA].rol (rol_nombre,rol_estado) VALUES
    ('ADMINISTRADOR', 1),
    ('CLIENTE', 1) 
GO

--ACA PUSE UNAS FUNCIONALIDADES DE EJEPLO PERO NOSE CUALES VAN, ES NECESARIO DISCUTIRLO
INSERT INTO [LOS_BARONES_DE_LA_CERVEZA].Funcionalidad(funcionalidad_descripcion) VALUES
	('COMPRAR'),
	('RESERVAR'),
	('ABM_CLIENTE'),
	('ABM_ROL'),
	('LISTADO_ESTADISTICO'),
	('HABILITAR_USUARIO')
GO

--ACA DE NUEVO PUSE UNOS DE EJEMPLO PERO HAY QUE DECIDIRLOS
insert into [LOS_BARONES_DE_LA_CERVEZA].Funcionalidad_x_rol(id_rol, id_funcionalidad) VALUES
	( (select id_rol from [LOS_BARONES_DE_LA_CERVEZA].Rol where rol_nombre = 'CLIENTE') , (select id_funcionalidad from [LOS_BARONES_DE_LA_CERVEZA].Funcionalidad where funcionalidad_descripcion = 'COMPRAR') ),

	( (select id_rol from [LOS_BARONES_DE_LA_CERVEZA].Rol where rol_nombre = 'CLIENTE') , (select id_funcionalidad from [LOS_BARONES_DE_LA_CERVEZA].Funcionalidad where funcionalidad_descripcion = 'RESERVAR') )
GO

-------------------------------------Empezamos a migrar los datos de la tabla maestra-------------------------------------

/******************Clientes******************/ 
INSERT INTO [LOS_BARONES_DE_LA_CERVEZA].Cliente
(	cliente_nombre,
	cliente_apellido,
	cliente_DNI,
	cliente_direccion,
	cliente_telefono,
	cliente_numero_de_tarjeta,
	cliente_fecha_nacimiento,
	cliente_mail,
	cliente_id_usuario)
SELECT DISTINCT
	 CLI_NOMBRE,
	 CLI_APELLIDO,	
	 CLI_DNI,
	 CLI_DIRECCION,
	 CLI_TELEFONO,
	 NULL,						--Numero de Tarjeta que no esta en la maestra
	 CLI_FECHA_NAC,
	 CLI_MAIL,
	 NULL
FROM gd_esquema.Maestra MA WHERE CLI_DNI IS NOT NULL
GO

/******************Marca******************/
INSERT INTO [LOS_BARONES_DE_LA_CERVEZA].Marca (marca_nombre)
SELECT DISTINCT MR.CRU_FABRICANTE
FROM gd_esquema.Maestra MR WHERE CRU_FABRICANTE IS NOT NULL
GO

/******************Crucero******************/ 
INSERT INTO [LOS_BARONES_DE_LA_CERVEZA].Crucero
(	crucero_fecha_de_alta,
	crucero_modelo,
	crucero_identificador,
	crucero_baja_por_fuera_de_servicio,
	crucero_baja_por_vida_util, 
	crucero_fecha_de_baja_definitiva,
	crucero_id_marca )
SELECT DISTINCT
	 convert(datetime2(3),'2019-05-06 00:00:00.000',121),			--  yyyy-mm-dd hh:mi:ss.mmm datetime2(3)
	 CRUCERO_MODELO,
	 CRUCERO_IDENTIFICADOR,
	 0,							--Asumo que todos los de la maestra estan en servicio
	 0,							--Asumo que todos los de la maestra estan en servicio
	 NULL,
	 (select id_marca from LOS_BARONES_DE_LA_CERVEZA.Marca where marca_nombre = CRU_FABRICANTE)
FROM gd_esquema.Maestra MA WHERE CRUCERO_MODELO IS NOT NULL
GO

/******************Compra******************/

Set Identity_Insert [LOS_BARONES_DE_LA_CERVEZA].Compra ON	--Usamos esta funcion para que pueda insertar las Compras y poner sus PK segun  el pasaje_codigo de la maestra y que despues al crear nuevas
														    --compras los numeros continuen desde el que lo deje. Primero lo enciendo para migrar y luego lo apago para que el identity continue desde la ultima
INSERT INTO [LOS_BARONES_DE_LA_CERVEZA].Compra
(	id_compra,
	compra_fecha,
	compra_cantidad,			--Decision: Todas las compras de la maestra son comisionadas
	compra_numero_tarjeta,		--Es NULL porque son todas compras en efectivo y el dato no esta en la maestra
	compra_precio_con_recargo,
	compra_id_forma_de_pago,	--Las compras de la maestra que no tienen metodo de pago las dejamos en NULL para no inventar que metodo podian haber sido
	compra_id_cliente,
	compra_id_viaje )
SELECT 
	MR.PASAJE_CODIGO,
	MR.PASAJE_FECHA_COMPRA,
	1,				--En la maestra todos compran de a una sola cabina
	NULL,			--No hay nro tarjeta en la maestra
	PASAJE_PRECIO,
	2,				--Como no hay numeros de tarjeta en la maestra asumo que todas las formas de pago fueron efectivo
	(SELECT distinct id_cliente FROM [LOS_BARONES_DE_LA_CERVEZA].Cliente WHERE MR.CLI_DNI = cliente_DNI and MR.CLI_NOMBRE = cliente_nombre and MR.CLI_APELLIDO = cliente_apellido),
	(SELECT distinct id_viaje FROM [LOS_BARONES_DE_LA_CERVEZA].Viaje join LOS_BARONES_DE_LA_CERVEZA.Crucero on viaje_id_crucero = id_crucero 
							  WHERE MR.FECHA_SALIDA = Viaje.viaje_fecha_inicio AND MR.FECHA_LLEGADA_ESTIMADA = Viaje.viaje_fecha_fin_estimada
							    AND MR.CRUCERO_IDENTIFICADOR = crucero_identificador AND MR.CRUCERO_MODELO = crucero_modelo)
FROM gd_esquema.Maestra MR WHERE MR.PASAJE_CODIGO IS NOT NULL order by MR.PASAJE_CODIGO

Set Identity_Insert [LOS_BARONES_DE_LA_CERVEZA].Compra OFF		--Luego de apagarlo las PKs van a seguir segun el ultimo numero de pasaje_codigo que ingrese
GO

Set Identity_Insert [LOS_BARONES_DE_LA_CERVEZA].Reserva ON

/******************Reserva******************/ 
INSERT INTO [LOS_BARONES_DE_LA_CERVEZA].Reserva
(	id_reserva,
	reserva_fecha,
	reserva_cantidad_pasajes,
	reserva_cliente,
	reserva_viaje )
SELECT DISTINCT
	 MR.RESERVA_CODIGO,
	 MR.RESERVA_FECHA,
	 1,
	 (SELECT distinct id_cliente FROM [LOS_BARONES_DE_LA_CERVEZA].Cliente WHERE MR.CLI_DNI = cliente_DNI and MR.CLI_NOMBRE = cliente_nombre and MR.CLI_APELLIDO = cliente_apellido),
	 (SELECT distinct id_viaje FROM [LOS_BARONES_DE_LA_CERVEZA].Viaje join LOS_BARONES_DE_LA_CERVEZA.Crucero on viaje_id_crucero = id_crucero 
							  WHERE MR.FECHA_SALIDA = Viaje.viaje_fecha_inicio AND MR.FECHA_LLEGADA_ESTIMADA = Viaje.viaje_fecha_fin_estimada
							    AND MR.CRUCERO_IDENTIFICADOR = crucero_identificador AND MR.CRUCERO_MODELO = crucero_modelo)
FROM gd_esquema.Maestra MR WHERE RESERVA_CODIGO IS NOT NULL
GO

Set Identity_Insert [LOS_BARONES_DE_LA_CERVEZA].Reserva OFF

/******************Marca******************/
INSERT INTO [LOS_BARONES_DE_LA_CERVEZA].Puerto (puerto_nombre)
SELECT DISTINCT MR.PUERTO_DESDE  --Puedo hacerlo solo con puerto_desde porque este campo cubre los mismos puertos que puerto_hasta
FROM gd_esquema.Maestra MR WHERE PUERTO_DESDE IS NOT NULL
GO

/*
--Creamos la tabla de Recorrido
CREATE TABLE [LOS_BARONES_DE_LA_CERVEZA].Recorrido 
(	id_recorrido int identity (1,1) NOT NULL,
	recorrido_codigo int,
	recorrido_puerto_inicio int,   --Ciudad = Puerto
	recorrido_puerto_destino int,  --Ciudad = Puerto
	recorrido_precio_tramo decimal(18,2),
	recorrido_estado bit,
	recorrido_siguiente int,
	recorrido_anterior int,
	CONSTRAINT pk_id_publicacion PRIMARY KEY CLUSTERED (id_recorrido) )
GO
*/

/******************Recorrido******************/

INSERT INTO [LOS_BARONES_DE_LA_CERVEZA].Recorrido
(	recorrido_codigo,
	recorrido_puerto_inicio,
	recorrido_puerto_destino,
	recorrido_precio_tramo,
	recorrido_estado,
	recorrido_siguiente,
	recorrido_anterior )
SELECT DISTINCT
	 MR.RECORRIDO_CODIGO,
	 (select id_puerto from LOS_BARONES_DE_LA_CERVEZA.Puerto where puerto_nombre = MR.PUERTO_DESDE),
	 (select id_puerto from LOS_BARONES_DE_LA_CERVEZA.Puerto where puerto_nombre = MR.PUERTO_HASTA),
	 MR.RECORRIDO_PRECIO_BASE,
	 0,				--Todos los recorridos los tomo caidos porque son del 2018 su fecha estimada de llegada
	 NULL,			--ACA ESTA MAL PORQUE HAY RECORRIDOS QUE SON DE MAS DE UN VIAJE
	 NULL			--Es el primer tramo
FROM gd_esquema.Maestra MR WHERE RECORRIDO_CODIGO IS NOT NULL
GO

/******************Tipo_servicio******************/ 
INSERT INTO [LOS_BARONES_DE_LA_CERVEZA].Tipo_servicio
(	tipo_servicio_descripcion,
	tipo_servicio_porcentage_recargo )
SELECT DISTINCT
	 MR.CABINA_TIPO,
	 MR.CABINA_TIPO_PORC_RECARGO
FROM gd_esquema.Maestra MR WHERE CRUCERO_MODELO IS NOT NULL
GO

/******************Cabina******************/ 
INSERT INTO [LOS_BARONES_DE_LA_CERVEZA].Cabina
(	cabina_estado,
	cabina_piso,
	cabina_nro,
	cabina_tipo_servicio,
	cabina_crucero )
SELECT DISTINCT
	 1,					--FALTA AGREGAR CUALES SE VENDIERON Y CUALES NO DE UN CRUCERO (ahi tengo que fijarme el nro y piso en ese viaje y ver si se vendio, por ahora les pongo a todas 1)
	 MR.CABINA_PISO,
	 MR.CABINA_NRO,
	 (select id_tipo_servicio from LOS_BARONES_DE_LA_CERVEZA.Tipo_servicio where MR.CABINA_TIPO = tipo_servicio_descripcion),
	 (select id_crucero from LOS_BARONES_DE_LA_CERVEZA.Crucero CR where MR.CRUCERO_IDENTIFICADOR = CR.crucero_identificador and MR.CRUCERO_MODELO = CR.crucero_modelo
	  and MR.CRU_FABRICANTE = ( select distinct marca_nombre from LOS_BARONES_DE_LA_CERVEZA.Marca where id_marca = CR.crucero_id_marca) )
FROM gd_esquema.Maestra MR WHERE CRUCERO_MODELO IS NOT NULL
GO

/******************Viaje******************/ 

INSERT INTO [LOS_BARONES_DE_LA_CERVEZA].Viaje
(	viaje_fecha_inicio,
	viaje_fecha_fin,
	viaje_fecha_fin_estimada,
	viaje_id_crucero,
	viaje_id_recorrido )
SELECT DISTINCT
	MR.FECHA_SALIDA,
	MR.FECHA_LLEGADA,
	MR.FECHA_LLEGADA_ESTIMADA,
	(select id_crucero from LOS_BARONES_DE_LA_CERVEZA.Crucero where crucero_identificador = MR.CRUCERO_IDENTIFICADOR and crucero_modelo = MR.CRUCERO_MODELO),
	(select id_recorrido from LOS_BARONES_DE_LA_CERVEZA.Recorrido where MR.RECORRIDO_CODIGO = recorrido_codigo)
FROM gd_esquema.Maestra MR
GO
