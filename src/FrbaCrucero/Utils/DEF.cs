using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrbaCrucero.Utils
{
    public static class DEF
    {
        // Constantes para identificar expresar ERROR y EXITO
        public const int ERROR = -1;
        public const int EXITO = 1;

        // Proceso de logueo de un usuario (USP.login en la BD)
        public const int USUARIO_NO_EXISTE = 1;
        public const int PASSWORD_INCORRECTO = 2;
        public const int USUARIO_INHABILITADO = 3;
        public const int INGRESO_CORRECTO = 4;
        
        // Proceso de ingreso (no logueo) de un usuario de tipo Cliente
        public const string CLIENTE_DEFAULT = "cliente_default";

        // Selección de Rol de un usuario 
        public const int NINGUN_ROL = 0;
        public const int UNICO_ROL = 1;
        public const int MAS_DE_UN_ROL = 2;

        // Listado de funcionalidades (Tabla Funcionalidades) - FUNC = FUNCIONALIDAD
        public const string FUNC_ABM_CRUCEROS = "ABM Cruceros";
        public const string FUNC_ABM_PUERTOS = "ABM Puertos";
        public const string FUNC_ABM_RECORRIDOS = "ABM Recorridos";
        public const string FUNC_ABM_ROLES = "ABM Roles";
        public const string FUNC_COMPRAR_RESERVAR_VIAJE = "Comprar/Reservar Viaje";
        public const string FUNC_GENERAR_VIAJE = "Generar Viaje";
        public const string FUNC_LISTADOS = "Listados Estadisticos";
        public const string FUNC_PAGAR_RESERVA = "Pagar Reserva";

        // Abm Rol
        public const int NOMBRE_ROL_DISPONIBLE = 0;
        public const int NINGUNA_FUNCIONALIDAD_SELECCIONADA = 0;
        public const int FILAS_AFECTADAS_INSERTAR_ROL = 1;
        public const int INDICE_COLUMNA_HABILITAR_ROL = 1;
        public const int FILAS_AFECTADAS_HABILITAR_ROL = 1;
        public const int FILAS_AFECTADAS_DESHABILITAR_ROL = 1;
        public const int ROL_HABILITADO = 1;
        public const string ROL_CLIENTE = "Rol_Cliente";
        public const string ROL_ADMIN = "Rol_Admin";

        // Tipos de cabinas (Tabla Tipos_Cabinas en la BD)
        public const string CABINA_NULA = "";
        public const string CABINA_ESTANDAR = "Cabina estandar";
        public const string CABINA_EXTERIOR = "Cabina Exterior";
        public const string CABINA_BALCON = "Cabina Balcón";
        public const string CABINA_SUITE = "Suite";
        public const string CABINA_EJECUTIVO = "Ejecutivo";

        // Validación cabinas
        public const int NINGUNA_CABINA = 0;

        // ABM Cruceros 
        public const int FILAS_INSERT_CRUCERO = 1;
        public const int FILAS_ACTUALIZAR_CRUCERO = 1;
        public const int FILAS_INSERT_CABINAS = 1;

        // ABM Recorridos
        public const int FILAS_INSERT_RECORRIDO = 1;
        public const int FILAS_INSERT_TRAMO_POR_RECORRIDO = 1;
        public const int NINGUN_RECORRIDO_SELECCIONADO = 0;

        // Generar Viaje
        public const int TRAMO_PUERTO_INICIO = 0;
        public const int TRAMO_PUERTO_FIN = 1;

        //public const int FILAS_INSERT_CLIENTE = 3;
        //public const int FILAS_INSERT_EMPRESA = 3;
        //public const int FILAS_INSERT_PUBLICACION = 1;
        //public const int FILAS_INSERT_UBICACION = 1;
        //// Afecta 3 filas: Inserta en compras, actualiza Ubicaciones y suma puntos en Clientes
        //public const int FILAS_INSERT_COMPRAR_UBICACION = 3;
        //// Se añade una fila modificada más por el trigger de finalizar publicación (stock cero)
        //public const int FILAS_INSERT_COMPRAR_UBICACION_TRIGGER = 4;

        //public const int NINGUNA_UBICACION = 0;
        //public const int RUBRO_DEPORTIVO = 1;
        //public const int RUBRO_CULTURAL = 2;
        //public const int RUBRO_MUSICAL = 3;
        //public const int RUBRO_CINE = 4;
        //public const int RUBRO_OTRO = 5;
        //public const int FILAS_DELETE_PUBLICACION = 1;
        //public const int FILAS_UPDATE_TARJETA_CREDITO = 1;
        //public const int FILAS_AFECTADAS_DESCONTAR_PUNTOS = 1;
        //public const int FILAS_AFECTADAS_HABILITAR_USUARIO = 1;
        //public const int FILAS_AFECTADAS_DESHABILITAR_USUARIO = 1;
        //public const int INDICE_COLUMNA_HABILITAR_CLIENTE = 7;
        //public const int INDICE_COLUMNA_HABILITAR_EMPRESA = 4;

    }
}
