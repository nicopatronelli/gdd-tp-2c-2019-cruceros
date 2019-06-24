using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using FrbaCrucero.Utils;
using FrbaCrucero.Utils.Excepciones;

namespace FrbaCrucero.AbmRecorrido.Dominio
{
    public class Tramo
    {
        private int id; 
        private string puertoInicio;
        private string puertoFin;
        private double precio;

        public Tramo(int id, string puertoInicio, string puertoFin, double precio)
        {
            this.id = id;
            this.puertoInicio = puertoInicio;
            this.puertoFin = puertoFin;
            this.precio = precio;
        }

        public int getId()
        {
            return this.id;
        }

        public string getPuertoInicio()
        {
            return this.puertoInicio;
        }

        public string getPuertoFin()
        {
            return this.puertoFin;
        }

        public double getPrecio()
        {
            return this.precio;
        }

        // Insertamos en la tabla Tramos_Por_Recorrido
        public void insertarTramoPorRecorrido(int idRecorrido, Recorrido recorrido)
        {   
            List<Parametro> parametrosTramoPorRecorrido = new List<Parametro>();
            Parametro paramIdRecorrido, paramIdTramo;

            paramIdRecorrido = new Parametro("@id_recorrido", SqlDbType.Int, idRecorrido);
            parametrosTramoPorRecorrido.Add(paramIdRecorrido);

            paramIdTramo = new Parametro("@id_tramo", SqlDbType.Int, this.id);
            parametrosTramoPorRecorrido.Add(paramIdTramo);

            // Creamos la llamada al SP "USP_insertar_tramo_por_recorrido" de la BD y lo ejecutamos 
            StoreProcedure spInsertarTramoPorRecorrido = new StoreProcedure("LOS_BARONES_DE_LA_CERVEZA.USP_insertar_tramo_por_recorrido", parametrosTramoPorRecorrido);
            int cantidadFilasInsertadas = spInsertarTramoPorRecorrido.ejecutarNonQuery();

            // Comprobamos que la cabina se haya insertado correctamente
            //if (!cantidadFilasInsertadas.Equals(DEF.FILAS_INSERT_TRAMO_POR_RECORRIDO)) 
            //    throw new InsertarRecorridoException();
        }
    }
}
