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

        // Constructor para Tramo_por_Recorrido
        public Tramo(int id, string puertoInicio, string puertoFin, double precio)
        {
            this.id = id;
            this.puertoInicio = puertoInicio;
            this.puertoFin = puertoFin;
            this.precio = precio;
        }

        // Constructor para alta de un nuevo tramo (ABM Tramos)
        public Tramo(string puertoInicio, string puertoFin, double precio)
        {
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

        public void setPrecio(double precio)
        {
            this.precio = precio;
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

        // Insertar nuevo tramo
        public void insertar()
        {
            List<Parametro> parametros = new List<Parametro>();
            Parametro paramPuertoInicio = new Parametro("@puerto_inicio", SqlDbType.NVarChar, this.puertoInicio, 255);
            parametros.Add(paramPuertoInicio);
            Parametro paramPuertoFin = new Parametro("@puerto_fin", SqlDbType.NVarChar, this.puertoFin, 255);
            parametros.Add(paramPuertoFin);
            Parametro paramPrecio = new Parametro("@precio", SqlDbType.Decimal, this.precio);
            paramPrecio.obtenerSqlParameter().Precision = 18;
            paramPrecio.obtenerSqlParameter().Scale = 2;
            parametros.Add(paramPrecio);
            string queryInsertarTramo = "INSERT INTO LOS_BARONES_DE_LA_CERVEZA.Tramo (tramo_puerto_inicio, tramo_puerto_destino, tramo_precio) "
                                      + "VALUES"
                                      + "( "
                                            + "(SELECT id_puerto FROM LOS_BARONES_DE_LA_CERVEZA.Puerto WHERE puerto_nombre = @puerto_inicio), "
                                            + "(SELECT id_puerto FROM LOS_BARONES_DE_LA_CERVEZA.Puerto WHERE puerto_nombre = @puerto_fin), "
                                            + "@precio "
                                      + ")";
            Query miConsulta = new Query(queryInsertarTramo, parametros);
            miConsulta.ejecutarNonQuery();
        }

        public void actualizarPrecio()
        {
            List<Parametro> parametros = new List<Parametro>();
            Parametro paramIdTramo = new Parametro("@id_tramo", SqlDbType.Int, this.getId());
            parametros.Add(paramIdTramo);
            Parametro paramNuevoPrecio = new Parametro("@nuevo_precio", SqlDbType.Decimal, this.getPrecio());
            paramNuevoPrecio.obtenerSqlParameter().Precision = 18;
            paramNuevoPrecio.obtenerSqlParameter().Scale = 2;
            parametros.Add(paramNuevoPrecio);

            string consulta = "UPDATE LOS_BARONES_DE_LA_CERVEZA.Tramo "
                            + "SET tramo_precio = @nuevo_precio "
                            + "WHERE id_tramo = @id_tramo";
            Query miConsulta = new Query(consulta, parametros);
            miConsulta.ejecutarNonQuery();
        }
    }
}
