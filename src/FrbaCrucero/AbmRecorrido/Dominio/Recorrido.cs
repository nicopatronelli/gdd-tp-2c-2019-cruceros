using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;
using FrbaCrucero.Utils;
using FrbaCrucero.Utils.Excepciones;

namespace FrbaCrucero.AbmRecorrido.Dominio
{
    public class Recorrido
    {
        private string identificador;
        private List<Tramo> tramos;
        private PrecioRecorrido precio;

        public Recorrido()
        {
            this.tramos = new List<Tramo>();
        }

        public void setIdentificador(string identificador)
        {
            try
            {
                Validaciones.hayCamposObligatoriosNulos(identificador);
                this.identificador = identificador;
            }
            catch (CamposObligatoriosVaciosException)
            {
                throw new IdentificadorCruceroNullException();
            }
        }

        public string getIdentificador()
        {
            return this.identificador;
        }

        public void addTramo(Tramo tramo)
        {
            this.tramos.Add(tramo);
        }

        public void eliminarUltimoTramo()
        {
            this.tramos.RemoveAt(this.tramos.Count - 1);
        }

        public List<Tramo> getTramos()
        {
            return this.tramos;
        }

        public void reiniciarTramos()
        {
            this.tramos = new List<Tramo>();
        }

        public void setPrecio(PrecioRecorrido precio)
        {
            this.precio = precio;
        }

        public PrecioRecorrido getPrecio()
        {
            return this.precio;
        }

        public static bool identificadorDisponible(string identificadorRecorrido)
        {
            List<Parametro> parametros = new List<Parametro>();
            Parametro paramIdentificadorRecorrido = new Parametro("@identificador_recorrido", SqlDbType.NVarChar, identificadorRecorrido, 255);
            parametros.Add(paramIdentificadorRecorrido);
            string consulta = "SELECT COUNT(*) FROM LOS_BARONES_DE_LA_CERVEZA.Recorrido WHERE recorrido_codigo = @identificador_recorrido";
            Query miConsulta = new Query(consulta, parametros);
            int resultado = Convert.ToInt32(miConsulta.ejecutarEscalar());
            if (resultado.Equals(0))
                return true;
            else
                return false;
        }

        private int insertarRecorrido()
        {
            List<Parametro> parametros = new List<Parametro>();
            Parametro paramIdentificador = new Parametro("@identificador", SqlDbType.NVarChar, this.identificador, 255);
            parametros.Add(paramIdentificador);

            // Añadimos el parámetro de salida donde obtenemos el id_recorrido que SQL Server le asigno al recorrido
            Parametro paramIdRecorridoAsignado = new Parametro("@id_recorrido_asignado", SqlDbType.Int);
            paramIdRecorridoAsignado.esParametroOut();
            parametros.Add(paramIdRecorridoAsignado);

            // Creamos la llamada al SP "USP_insertar_recorrido" de la BD y lo ejecutamos 
            StoreProcedure spInsertarRecorrido = new StoreProcedure("LOS_BARONES_DE_LA_CERVEZA.USP_insertar_recorrido", parametros);
            int cantidadFilasInsertadas = spInsertarRecorrido.ejecutarNonQuery();

            // Comprobamos que el recorrido se inserte correctamente
            if (!cantidadFilasInsertadas.Equals(DEF.FILAS_INSERT_RECORRIDO))
                throw new InsertarRecorridoException();
            else
                return Convert.ToInt32(paramIdRecorridoAsignado.obtenerValor());
        } // FIN insertarRecorrido()

        private void insertarTramosPorRecorrido(int idRecorrido, Recorrido recorrido)
        {
            tramos.ForEach(tramo => tramo.insertarTramoPorRecorrido(idRecorrido, recorrido));
        }

        public void insertar()
        {
            int idRecorrido = this.insertarRecorrido();
            this.inicializarTablaAuxiliarTpr();
            this.insertarTramosPorRecorrido(idRecorrido, this);
        }

        private void inicializarTablaAuxiliarTpr()
        {
            string iniciarTablaAuxTpr = "UPDATE [LOS_BARONES_DE_LA_CERVEZA].Tpr_Auxiliar "
                                      + "SET id_tpr_anterior = NULL ";
            Query miConsulta = new Query(iniciarTablaAuxTpr);
            miConsulta.ejecutarNonQuery();
        }
    }
}
