using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;
using FrbaCrucero.Utils;
using FrbaCrucero.Utils.Excepciones;
using FrbaCrucero.AbmRecorrido.Dominio.Excepciones;

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

        public void setTramos(List<Tramo> tramos)
        {
            this.tramos = tramos;
        }

        public void reiniciarTramos()
        {
            this.tramos = new List<Tramo>();
        }

        public int cantidadTramos()
        {
            return this.tramos.Count;
        }

        public bool ningunTramo()
        {
            return this.cantidadTramos().Equals(0);
        }

        public void setPrecio(PrecioRecorrido precioRecorrido)
        {
            this.precio = precioRecorrido;
        }

        public PrecioRecorrido getPrecio()
        {
            return this.precio;
        }

        public static bool identificadorDisponibleRecorridoNuevo(string identificadorRecorrido)
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

        public static bool identificadorDisponibleEditarRecorrido(string identificadorRecorridoAEditar, string identificadoRecorridoEditado, int pkRecorridoAEditar)
        {
            // Chequeamos si el identificador elegido no está en uso para otro recorrido que no tenga la pk del recorrido editado
            string consultaIdentificadorDisponible = "SELECT COUNT(*) "
                                                   + "FROM LOS_BARONES_DE_LA_CERVEZA.Recorrido "
                                                   + "WHERE recorrido_codigo = @identificador_recorrido_editado "
                                                        + "AND id_recorrido != @pk_recorrido_a_editar";
            List<Parametro> parametros = new List<Parametro>();
            Parametro paramIdentificadoRecorridoEditado = new Parametro("@identificador_recorrido_editado", SqlDbType.NVarChar, identificadoRecorridoEditado, 255);
            Parametro paramPkIdentificadorRecorridoAEditar = new Parametro("@pk_recorrido_a_editar", SqlDbType.Int, pkRecorridoAEditar);
            parametros.Add(paramIdentificadoRecorridoEditado);
            parametros.Add(paramPkIdentificadorRecorridoAEditar);
            Query queryIdentificadorRecorridoDisponible = new Query(consultaIdentificadorDisponible, parametros);
            int resultado = Convert.ToInt32(queryIdentificadorRecorridoDisponible.ejecutarEscalar());
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
            int pkRecorrido = this.insertarRecorrido();
            this.inicializarTablaAuxiliarTpr();
            this.insertarTramosPorRecorrido(pkRecorrido, this);
        }

        private void inicializarTablaAuxiliarTpr()
        {
            string iniciarTablaAuxTpr = "UPDATE [LOS_BARONES_DE_LA_CERVEZA].Tpr_Auxiliar "
                                      + "SET id_tpr_anterior = NULL ";
            Query miConsulta = new Query(iniciarTablaAuxTpr);
            miConsulta.ejecutarNonQuery();
        }

        public void actualizar(string identificadorRecorridoAnterior)
        {
            int pkRecorrido = this.actualizarRecorrido(identificadorRecorridoAnterior);
            this.inicializarTablaAuxiliarTpr();
            this.insertarTramosPorRecorrido(pkRecorrido, this);
        }

        private int actualizarRecorrido(string identificadorRecorridoAnterior)
        {
            List<Parametro> parametros = new List<Parametro>();

            Parametro paramIdentificadorRecorridoAnterior = new Parametro("@identificador_recorrido_anterior", SqlDbType.NVarChar, identificadorRecorridoAnterior, 255);
            parametros.Add(paramIdentificadorRecorridoAnterior);

            // Añadimos el parámetro identificador recorrido editado (el nuevo identificador que ingresó el cliente, que puede ser igual al anterior)
            Parametro paramIdentificadorRecorridoNuevo = new Parametro("@identificador_recorrido_nuevo", SqlDbType.NVarChar, this.identificador, 255);
            parametros.Add(paramIdentificadorRecorridoNuevo);

            // Añadimos el parámetro de salida donde obtenemos el id_recorrido (PK) del recorrido a editar
            Parametro paramPkRecorrido = new Parametro("@id_recorrido_pk", SqlDbType.Int);
            paramPkRecorrido.esParametroOut();
            parametros.Add(paramPkRecorrido);

            // Creamos la llamada al SP "USP_actualizar_recorrido" de la BD y lo ejecutamos 
            StoreProcedure spActualizarRecorrido = new StoreProcedure("LOS_BARONES_DE_LA_CERVEZA.USP_actualizar_recorrido", parametros);
            int cantidadFilasActualizadas = spActualizarRecorrido.ejecutarNonQuery();

            // Comprobamos que el recorrido se inserte correctamente
            if (!cantidadFilasActualizadas.Equals(DEF.FILAS_UPDATE_RECORRIDO))
                throw new InsertarRecorridoException();
            else
                return Convert.ToInt32(paramPkRecorrido.obtenerValor());
        } // FIN insertarRecorrido()

        // Retorna la PK (id_recorrido) de un recorrido a editar (dado su identificador)
        public static int obtenerPkRecorridoAEditar(string identificadorRecorridoAEditar)
        {
            List<Parametro> parametros = new List<Parametro>();
            Parametro paramIdentificadorRecorridoAEditar = new Parametro("@identificador_recorrido_a_editar", SqlDbType.NVarChar, identificadorRecorridoAEditar, 255);
            parametros.Add(paramIdentificadorRecorridoAEditar);
            string consultaRecorridopk = "SELECT id_recorrido FROM LOS_BARONES_DE_LA_CERVEZA.Recorrido WHERE recorrido_codigo = @identificador_recorrido_a_editar";
            Query queryObtenerPk = new Query(consultaRecorridopk, parametros);
            return Convert.ToInt32(queryObtenerPk.ejecutarEscalar());
        }

        // Elimina de la BD los tramos del recorrido cuya pk (id_recorrido) recibe por parámetro (se usa en la edición de un recorrido)
        public static void eliminarTramos(int pkRecorridoAEditar)
        {
            List<Parametro> parametros = new List<Parametro>();
            Parametro paramPkRecorrido = new Parametro("@pk_recorrido", SqlDbType.Int, pkRecorridoAEditar);
            parametros.Add(paramPkRecorrido);
            string consulta = "DELETE FROM LOS_BARONES_DE_LA_CERVEZA.Tramos_por_Recorrido WHERE id_recorrido = @pk_recorrido";
            Query miConsulta = new Query(consulta, parametros);
            miConsulta.ejecutarNonQuery();
        }

    }
}
