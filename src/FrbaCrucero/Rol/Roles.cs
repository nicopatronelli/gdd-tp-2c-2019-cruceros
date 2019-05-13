using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using FrbaCrucero.Utils;

namespace FrbaCrucero.Rol
{
    static class Roles
    {
        public static int cantidad(string usuario)
        {
            string consulta = "SELECT COUNT(rol) FROM LOS_BARONES_DE_LA_CERVEZA.Roles_Por_Usuario WHERE usuario = @usuario_elegido";
            List<Parametro> parametros = new List<Parametro>();
            Parametro param = new Parametro("@usuario_elegido", SqlDbType.NVarChar, usuario, 100);
            parametros.Add(param);
            Query miConsulta = new Query(consulta, parametros);

            try
            {
                int cantidadRoles = (int)miConsulta.ejecutarEscalar();

                if (cantidadRoles.Equals(DEF.NINGUN_ROL))
                {
                    MensajeBox.error("Error al cargar los roles. El usuario no tienen ningún rol asignado.");
                    return DEF.ERROR;
                }
                else if (cantidadRoles.Equals(DEF.UNICO_ROL))
                    return DEF.UNICO_ROL;
                else
                    return DEF.MAS_DE_UN_ROL;
            }
            catch (Exception ex)
            {
                MensajeBox.error("Error al cargar los roles. Info: " + ex.ToString());
                return DEF.ERROR;
            }

        } // FIN cantidad()

        public static bool rolHabilitado(string usuario)
        {
            string consulta =
            "SELECT habilitado"
            + " FROM LOS_BARONES_DE_LA_CERVEZA.Roles r"
                + " JOIN LOS_BARONES_DE_LA_CERVEZA.Roles_por_Usuario rpu"
                    + " ON r.nombre_rol = rpu.rol"
            + " WHERE rpu.usuario = @usuario";

            List<Parametro> parametros = new List<Parametro>();
            Parametro param = new Parametro("@usuario", SqlDbType.NVarChar, usuario, 100);
            parametros.Add(param);

            bool habilitado;

            try
            {
                Query miConsulta = new Query(consulta, parametros);
                habilitado = (bool)miConsulta.ejecutarEscalar();
                if (habilitado.Equals(true))
                    return true; // El rol está habilitado
                else
                    return false; // El rol NO está habilitado
            }
            catch(Exception ex)
            {
                MensajeBox.error("Error al cargar el rol. Info: " + ex.ToString());
                return false;
            }

        } // FIN rolHabilitado()

        // @IMPORTANTE: Puede que ande para recuperar las funcionalidades totales de varios roles
        public static List<string> funcionalidadesUnicoRol(string usuario)
        {
            string consulta =
                "SELECT funcionalidad"
                + " FROM LOS_BARONES_DE_LA_CERVEZA.Funcionalidades_Por_Roles fpr"
                + " JOIN LOS_BARONES_DE_LA_CERVEZA.Roles_Por_Usuario rpu"
                + " ON fpr.rol = rpu.rol"
                + " WHERE usuario = @usuario_elegido";

            List<Parametro> parametros = new List<Parametro>();
            Parametro param = new Parametro("@usuario_elegido", SqlDbType.NVarChar, usuario, 100);
            parametros.Add(param);
            Query miConsulta = new Query(consulta, parametros);
            List<string> funcionalidades;

            try
            {
                funcionalidades = miConsulta.ejecutarReaderUnicaColumna();
                return funcionalidades;
            }
            catch(Exception ex)
            {
                MensajeBox.error("Error al cargar las funcionalidades. Info: " + ex.ToString());
                return null;
            }
        } // FIN recuperarUnicoRol()

    }
}
