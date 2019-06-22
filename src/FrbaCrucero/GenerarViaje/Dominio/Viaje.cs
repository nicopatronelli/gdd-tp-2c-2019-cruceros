using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using FrbaCrucero.Utils;
using FrbaCrucero.GenerarViaje.Dominio.Excepciones;

namespace FrbaCrucero.GenerarViaje.Dominio
{
    class Viaje
    {
        DateTime fechaInicio;
        DateTime fechaFin;
        string identificadorCrucero;
        string identificadorRecorrido;

        public Viaje() { }

        public Viaje setFechaInicio(DateTime fechaInicio)
        {
            // Validamos que la fecha de inicio sea posterior a la fecha actual (fecha del archivo de configuración)
            if (DateTime.Compare(ArchivoConfig.obtenerFechaConfig(), fechaInicio) > 0)
                throw new FechaInicioAnteriorFechaConfigException();
            this.fechaInicio = fechaInicio;
            return this;
        }

        public Viaje setFechaFin(DateTime fechaFin)
        {
            // Validamos que la fecha de fin del viaje sea posterior a la de inicio
            if (DateTime.Compare(this.fechaInicio, fechaFin) > 0)
                throw new FechaFinViajeAnteriorAFechaInicioViajeException();
            this.fechaFin = fechaFin;
            return this;
        }

        public Viaje setIdentificadorCrucero(string identificadorCrucero)
        {
            if (String.IsNullOrEmpty(identificadorCrucero))
                throw new IdentificadorCruceroEnViajeEsNuloOVacioException();
            this.identificadorCrucero = identificadorCrucero;
            return this;
        }

        public Viaje setIdentificadorRecorrido(string identificadorRecorrido)
        {
            if (String.IsNullOrEmpty(identificadorRecorrido))
                throw new NingunRecorridoSeleccionadoEnNuevoViajeException();
            this.identificadorRecorrido = identificadorRecorrido;
            return this;
        }

        public void insertar()
        {
            try
            {
                // Creamos los parámetros del procedimiento almacenado USP_insertar_viaje
                List<Parametro> parametros = new List<Parametro>();

                Parametro paramFechaInicio = new Parametro("@fecha_inicio", SqlDbType.NVarChar, this.fechaInicio.ToString("yyyy-MM-dd h:mm tt"), 255);
                parametros.Add(paramFechaInicio);

                Parametro paramFechaFin = new Parametro("@fecha_fin", SqlDbType.NVarChar, this.fechaFin.ToString("yyyy-MM-dd h:mm tt"), 255);
                parametros.Add(paramFechaFin);

                Parametro paramIdentificadorCrucero = new Parametro("@identificador_crucero", SqlDbType.NVarChar, this.identificadorCrucero, 50);
                parametros.Add(paramIdentificadorCrucero);

                Parametro paramIdentificadorRecorrido = new Parametro("@identificador_recorrido", SqlDbType.NVarChar, this.identificadorRecorrido, 255);
                parametros.Add(paramIdentificadorRecorrido);

                // Creamos la llamada al SP "USP_insertar_viaje" de la BD y lo ejecutamos 
                StoreProcedure spInsertarViaje = new StoreProcedure("LOS_BARONES_DE_LA_CERVEZA.USP_insertar_viaje", parametros);
                int cantidadFilasInsertadas = spInsertarViaje.ejecutarNonQuery();
            }
            catch (Exception)
            { throw new InsertarNuevoViajeException(); }
            // Comprobamos que el crucero se inserte correctamente
            //if (!cantidadFilasInsertadas.Equals(DEF.FILAS_INSERT_CRUCERO))
            //    throw new InsertarCruceroException();
            //else
            //    return Convert.ToInt32(paramIdCruceroAsignado.obtenerValor());
        }
    }
}
