using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FrbaCrucero.Utils;

namespace FrbaCrucero.AbmRol
{
    static class Rol
    {
        // Vamos a insertar un nuevo rol (no existe el nombreRol en la BD)
        public static bool insertar(string nombreRol, Dictionary<string, bool> funcionalidades)
        {
            // 1. Primero insertamos el nombre del rol (si no existe)
            string queryInsertarRol = "IF NOT EXISTS("
                + " SELECT nombre_rol "
                + "FROM LOS_BARONES_DE_LA_CERVEZA.Roles "
                + "WHERE nombre_rol = @nombre_rol ) "
                + "INSERT INTO LOS_BARONES_DE_LA_CERVEZA.Roles "
                + "VALUES(@nombre_rol, 1)";

            List<Parametro> parametros = new List<Parametro>();
            Parametro paramNombreRol = new Parametro("@nombre_rol", SqlDbType.NVarChar, nombreRol, 100);
            parametros.Add(paramNombreRol);

            Query insertarRol = new Query(queryInsertarRol, parametros);
            int cantidadFilasInsertadas = insertarRol.ejecutarNonQuery(); // filas insertadas puede ser 0 o 1

            // 2. Ahora insertamos/actualizamos las funcionalidades del rol
            foreach (KeyValuePair<string, bool> funcionalidad in funcionalidades)
            {
                if (funcionalidad.Value.Equals(true))
                {
                    // Si se seleccionó la funcionalidad actual la insertamos 
                    Funcionalidades.insertar(nombreRol, funcionalidad.Key);
                }
                else
                {
                    // Si la funcionalidad actual NO está marcada, entonces debemos eliminarla (si antes de editar lo estaba)
                    Funcionalidades.eliminar(nombreRol, funcionalidad.Key);
                }
            } // Fin foreach

            // Si llegamos a este punto significa que el nuevo rol y sus funcionalidades se insertaron/modificaorn correctamente
            return true;

        } // FIN insertar()

        // Vamos a actualizar un rol existente (nombreRol existe en la BD)
        public static bool actualizar(string nombreRolAnterior, string nombreRol, Dictionary<string, bool> funcionalidades)
        {
            // 1. Primero insertamos el nombre del rol (si no existe)
            string queryActualizarRol =
                "UPDATE LOS_BARONES_DE_LA_CERVEZA.Roles "
                + "SET nombre_rol = @nombre_rol "
                + "WHERE nombre_rol = @nombre_rol_anterior";

            List<Parametro> parametros = new List<Parametro>();
            Parametro paramNombreRol = new Parametro("@nombre_rol", SqlDbType.NVarChar, nombreRol, 100);
            parametros.Add(paramNombreRol);
            Parametro paramNombreRolAnterior = new Parametro("@nombre_rol_anterior", SqlDbType.NVarChar, nombreRolAnterior, 100);
            parametros.Add(paramNombreRolAnterior);

            Query actualizarRol = new Query(queryActualizarRol, parametros);
            int cantidadFilasInsertadas = actualizarRol.ejecutarNonQuery(); // filas insertadas puede ser 0 o 1

            // 2. Ahora insertamos/actualizamos las funcionalidades del rol
            foreach (KeyValuePair<string, bool> funcionalidad in funcionalidades)
            {
                if (funcionalidad.Value.Equals(true))
                {
                    // Si se seleccionó la funcionalidad actual la insertamos 
                    Funcionalidades.insertar(nombreRol, funcionalidad.Key);
                }
                else
                {
                    // Si la funcionalidad actual NO está marcada, entonces debemos eliminarla (si antes de editar lo estaba)
                    Funcionalidades.eliminar(nombreRol, funcionalidad.Key);
                }
            } // Fin foreach

            // Si llegamos a este punto significa que el nuevo rol y sus funcionalidades se insertaron/modificaron correctamente
            return true;

        } // FIN actualizar()


        public static SqlDataReader recuperarFuncionalidades(string nombreRol)
        {
            string consulta = "SELECT fpr.funcionalidad Funcionalidad "
                + "FROM LOS_BARONES_DE_LA_CERVEZA.Roles r "
                    + "JOIN LOS_BARONES_DE_LA_CERVEZA.Funcionalidades_Por_Roles fpr "
                        + "ON r.nombre_rol = fpr.rol "
                + "WHERE nombre_rol = @nombre_rol";

            List<Parametro> parametros = new List<Parametro>();
            Parametro paramNombreRol = new Parametro("@nombre_rol", SqlDbType.NVarChar, nombreRol, 100);
            parametros.Add(paramNombreRol);

            Query miConsulta = new Query(consulta, parametros);
            SqlDataReader funcionalidades = miConsulta.ejecutarReader();

            // Retornamos las funcionalidades del rol en un SqlDataReader que tendrá tantas filas (rows) como 
            // funcionalidades tenga el rol 
            return funcionalidades;

        } // FIN cargarRol()

        public static void cargarRolesEdicion(ConexionBD conexion, DataGridView dgvRoles)
        {
            // Armamos la query para traernos todos los roles de la BD
            string consultaRoles = "SELECT nombre_rol 'Nombre Rol' FROM LOS_BARONES_DE_LA_CERVEZA.Roles";

            // Cargamos los roles al dgv
            SqlDataAdapter dataAdapter = new SqlDataAdapter(consultaRoles, conexion.obtenerConexion());
            SqlCommandBuilder commandBuilder = new SqlCommandBuilder(dataAdapter);
            DataSet dataSet = new DataSet();
            dataAdapter.Fill(dataSet);
            dgvRoles.DataSource = dataSet.Tables[0];

            // Añadimos un botón Editar al final de cada fila para poder elegir el rol  a editar 
            DataGridViewButtonColumn botonEditar = DGVUtils.agregarBotonEditar(dgvRoles);
            dgvRoles.Columns.Add(botonEditar);

            DGVUtils.autoAjustarColumnas(dgvRoles); // Para autoajustar el tamaño del dgv

            conexion.cerrar();
        } // FIN cargarRolesDisponibles()


        public static void cargarRolesEliminacion(ConexionBD conexion, DataGridView dgvRoles)
        {
            // Armamos la query para traernos los campos nombre_rol y habilitado de todos los roles
            string consultaRoles = "SELECT nombre_rol, habilitado FROM LOS_BARONES_DE_LA_CERVEZA.Roles";

            // Cargamos los roles al dgv
            SqlDataAdapter dataAdapter = new SqlDataAdapter(consultaRoles, conexion.obtenerConexion());
            SqlCommandBuilder commandBuilder = new SqlCommandBuilder(dataAdapter);
            DataSet dataSet = new DataSet();
            dataAdapter.Fill(dataSet);
            dgvRoles.DataSource = dataSet.Tables[0];
            dgvRoles.ReadOnly = false;
            dgvRoles.Columns["nombre_rol"].ReadOnly = true;
            DGVUtils.autoAjustarColumnas(dgvRoles); // Para autoajustar el tamaño del dgv

            conexion.cerrar();
        } // FIN cargarRolesDisponibles()


        public static bool habilitar(string nombreRol)
        {
            string consulta = "UPDATE LOS_BARONES_DE_LA_CERVEZA.Roles SET habilitado = 1 WHERE nombre_rol = @nombre_rol";
            List<Parametro> parametros = new List<Parametro>();
            Parametro paramNombreRol = new Parametro("@nombre_rol", SqlDbType.NVarChar, nombreRol, 100);
            parametros.Add(paramNombreRol);

            Query miConsulta = new Query(consulta, parametros);
            int cantidadFilasAfectadas = miConsulta.ejecutarNonQuery();

            if (cantidadFilasAfectadas.Equals(DEF.FILAS_AFECTADAS_HABILITAR_ROL))
                return true; // El rol se habilito correctamente
            else
                return false; // No se pudo habilitar el rol 

        } // FIN habilitar()


        public static bool deshabilitar(string nombreRol)
        {
            string consulta = "UPDATE LOS_BARONES_DE_LA_CERVEZA.Roles SET habilitado = 0 WHERE nombre_rol = @nombre_rol";
            List<Parametro> parametros = new List<Parametro>();
            Parametro paramNombreRol = new Parametro("@nombre_rol", SqlDbType.NVarChar, nombreRol, 100);
            parametros.Add(paramNombreRol);

            Query miConsulta = new Query(consulta, parametros);
            int cantidadFilasAfectadas = miConsulta.ejecutarNonQuery();

            if (cantidadFilasAfectadas.Equals(DEF.FILAS_AFECTADAS_DESHABILITAR_ROL))
                return true; // El rol se deshabilito correctamente
            else
                return false; // No se pudo deshabilitar el rol 

        } // FIN deshabilitar()

    } 
}
