using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FrbaCrucero.Utils;

namespace FrbaCrucero.AbmRol
{
    static class Funcionalidades
    {
        public static Dictionary<string, bool> seleccionadas(bool abmCruceros, bool abmPuertos, bool abmRecorridos, bool abmRoles,
            bool comprarReservarViaje, bool generarViaje, bool listadoEstadistico, bool pagarReserva)
        {
            // Añadimos las funcionalidades a una lista 
            Dictionary<string, bool> funcionalidades = new Dictionary<string, bool>();
            funcionalidades.Add(DEF.FUNC_ABM_CRUCEROS, abmCruceros);
            funcionalidades.Add(DEF.FUNC_ABM_PUERTOS, abmPuertos);
            funcionalidades.Add(DEF.FUNC_ABM_RECORRIDOS, abmRecorridos);
            funcionalidades.Add(DEF.FUNC_ABM_ROLES, abmRoles);
            funcionalidades.Add(DEF.FUNC_COMPRAR_RESERVAR_VIAJE, comprarReservarViaje);
            funcionalidades.Add(DEF.FUNC_GENERAR_VIAJE, generarViaje);
            funcionalidades.Add(DEF.FUNC_LISTADOS, listadoEstadistico);
            funcionalidades.Add(DEF.FUNC_PAGAR_RESERVA, pagarReserva);

            return funcionalidades;

        } // FIN seleccionadas()

        public static bool alMenosUna(Dictionary<string, bool> funcionalidades)
        {
            int cantidadFuncionalidadesSeleccionadas = 0;

            foreach (KeyValuePair<string, bool> funcionalidad in funcionalidades)
            {
                if (funcionalidad.Value.Equals(true)) // Contamos las funcionalidades seleccionadas (true)
                    cantidadFuncionalidadesSeleccionadas++;
            }

            if (cantidadFuncionalidadesSeleccionadas.Equals(DEF.NINGUNA_FUNCIONALIDAD_SELECCIONADA))
                return false; // El usuario NO selecciono ninguna funcionalidad 
            else
                return true; // El usuario selecciono por lo menos una funcionalidad

        } // alMenosUna()

        public static bool insertar(string nombreRol, string nombreFuncionalidad)
        {
            string queryInsertarFuncionalidad = "IF NOT EXISTS( "
                + "SELECT rol, funcionalidad "
                + "FROM LOS_BARONES_DE_LA_CERVEZA.Funcionalidades_Por_Roles "
                + "WHERE rol = @nombre_rol AND funcionalidad = @nombre_funcionalidad ) "
                + "INSERT INTO LOS_BARONES_DE_LA_CERVEZA.Funcionalidades_Por_Roles "
                + "VALUES (@nombre_rol, @nombre_funcionalidad)";

            List<Parametro> parametros = new List<Parametro>();
            Parametro paramNombreRol = new Parametro("@nombre_rol", SqlDbType.NVarChar, nombreRol, 100);
            parametros.Add(paramNombreRol);
            Parametro paramNombreFuncionalidad = new Parametro("@nombre_funcionalidad", SqlDbType.NVarChar, nombreFuncionalidad, 255);
            parametros.Add(paramNombreFuncionalidad);

            Query insertarFuncionalidad = new Query(queryInsertarFuncionalidad, parametros);
            int resultado = insertarFuncionalidad.ejecutarNonQuery();
            if (resultado > 0)
                return true;
            else
                return false;
        } // insertar()


        public static bool eliminar(string nombreRol, string nombreFuncionalidad)
        {
            string queryEliminarFuncionalidad = "IF EXISTS( "
                + "SELECT rol, funcionalidad "
                + "FROM LOS_BARONES_DE_LA_CERVEZA.Funcionalidades_Por_Roles "
                + "WHERE rol = @nombre_rol AND funcionalidad = @nombre_funcionalidad ) "
                + "DELETE LOS_BARONES_DE_LA_CERVEZA.Funcionalidades_Por_Roles "
                + "WHERE rol = @nombre_rol AND funcionalidad = @nombre_funcionalidad";

            List<Parametro> parametros = new List<Parametro>();
            Parametro paramNombreRol = new Parametro("@nombre_rol", SqlDbType.NVarChar, nombreRol, 100);
            parametros.Add(paramNombreRol);
            Parametro paramNombreFuncionalidad = new Parametro("@nombre_funcionalidad", SqlDbType.NVarChar, nombreFuncionalidad, 255);
            parametros.Add(paramNombreFuncionalidad);

            Query eliminarFuncionalidad = new Query(queryEliminarFuncionalidad, parametros);
            eliminarFuncionalidad.ejecutarNonQuery();
            return true;
        } // eliminar()

    }
}
