using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FrbaCrucero.Utils;


namespace FrbaCrucero.AbmRol
{
    static class NombreRol
    {
        public static bool campoNombreVacío(string nombreRol)
        {
            if (nombreRol.Equals(""))
                return true;
            else
                return false;
        } // FIN campoNombreVacío()

        public static bool estaDisponible(string nombreRol)
        {
            string consulta = "SELECT COUNT(nombre_rol) FROM LOS_BARONES_DE_LA_CERVEZA.Roles WHERE nombre_rol = @nombre_rol_elegido";

            List<Parametro> parametros = new List<Parametro>();
            Parametro paramNombreRolElegido = new Parametro("@nombre_rol_elegido", SqlDbType.NVarChar, nombreRol, 100);
            parametros.Add(paramNombreRolElegido);

            Query miConsulta = new Query(consulta, parametros);
            int resultado = (int)miConsulta.ejecutarEscalar();

            if (resultado.Equals(DEF.NOMBRE_ROL_DISPONIBLE))
                return true; // El nombre escogido para el rol está disponible 
            else
                return false; // El nombre escogido para el rol ya se encuentra en uso

        } // FIN estaDisponible()
    }
}
