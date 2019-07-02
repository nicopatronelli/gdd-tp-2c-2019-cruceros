using FrbaCrucero.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrbaCrucero.Login.ChequeosPostLoginExitoso
{
    class ChequeoAltaCrucerosServicioTecnico : ChequeoPostLoginExitoso
    {
        public void chequear()
        {
            // Creamos los parámetros del procedimiento almacenado USP_insertar_crucero
            List<Parametro> parametros = new List<Parametro>();
            Parametro paramFechaActual = new Parametro("@fecha_actual", SqlDbType.NVarChar,
                ArchivoConfig.obtenerFechaConfig().ToString("yyyy-MM-dd h:mm tt"), 255);
            parametros.Add(paramFechaActual);

            // Creamos la llamada al SP "USP_chequear_cruceros_servicio_tecnico" de la BD y lo ejecutamos 
            StoreProcedure spChequearAltaCrucerosServicioTecnico = new StoreProcedure("LOS_BARONES_DE_LA_CERVEZA.USP_chequear_cruceros_servicio_tecnico", parametros);
            spChequearAltaCrucerosServicioTecnico.ejecutarNonQuery();
        }
    }
}
