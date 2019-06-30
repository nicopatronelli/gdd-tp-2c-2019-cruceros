using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using FrbaCrucero.Utils;
using FrbaCrucero.Utils.Excepciones;
using FrbaCrucero.AbmCrucero.Dominio;

namespace FrbaCrucero.AbmCrucero
{
    public class Crucero
    {
        private string modelo;
        private string identificador;
        private string marca;
        private DateTime fechaAlta;
        private List<Cabina> cabinas = new List<Cabina>();
        private int tipoServicio;

        public Crucero(CruceroBuilder cruceroBuilder)
        {
            this.modelo = cruceroBuilder.getModelo();
            this.marca = cruceroBuilder.getMarca();
            this.identificador = cruceroBuilder.getIdentificador();
            this.fechaAlta = cruceroBuilder.getFechaAlta();
            this.tipoServicio = cruceroBuilder.getTipoServicio();
        }

        public void agregarCabina(Cabina cabina)
        {
            this.cabinas.Add(cabina);
        }

        public string getIdentificador()
        {
            return this.identificador;
        }

        public List<Cabina> getCabinas()
        {
            return this.cabinas;
        }

        public bool hayCabinasRepetidas()
        {
            return this.getCabinas().GroupBy(cab => new {cab.piso, cab.numero}).Any(cab => cab.Count() > 1);
            //var b = from cab in cabinas group cab by new {cab.getPiso(), cab.getNumero(),} into gcs 
        }

        public static bool identificadorDisponible(string identificadorCrucero)
        {
            List<Parametro> parametros = new List<Parametro>();
            Parametro paramIdentificadorCrucero = new Parametro("@identificador_crucero", SqlDbType.NVarChar, identificadorCrucero, 50);
            parametros.Add(paramIdentificadorCrucero);
            string consulta = "SELECT COUNT(*) FROM LOS_BARONES_DE_LA_CERVEZA.Cruceros WHERE identificador = @identificador_crucero";
            Query miConsulta = new Query(consulta, parametros);
            int resultado = Convert.ToInt32(miConsulta.ejecutarEscalar());
            if (resultado.Equals(0))
                return true;
            else
                return false;
        }

        public void insertar()
        {
            int idCrucero = this.insertarCrucero(); // Insertamos el crucero
            this.insertarCabinas(idCrucero); // Insertamos sus cabinas
        }

        public void actualizar(string identificadorCruceroAnterior)
        {
            int idCrucero = this.actualizarCrucero(identificadorCruceroAnterior); // Actualizamos el crucero
            this.actualizarCabinas(idCrucero); // Actualizamos sus cabinas
        }

        private int insertarCrucero()
        {
            // Creamos los parámetros del procedimiento almacenado USP_insertar_crucero
            List<Parametro> parametros = new List<Parametro>();
            Parametro paramModelo = new Parametro("@modelo", SqlDbType.NVarChar, this.modelo, 50);
            parametros.Add(paramModelo);
            Parametro paramIdentificador = new Parametro("@identificador", SqlDbType.NVarChar, this.identificador, 50);
            parametros.Add(paramIdentificador);
            Parametro paramMarca = new Parametro("@marca", SqlDbType.NVarChar, this.marca, 255);
            parametros.Add(paramMarca);
            Parametro paramFechaAlta = new Parametro("@fecha_alta", SqlDbType.NVarChar,
                this.fechaAlta.ToString("yyyy-MM-dd h:mm tt"), 255);
            parametros.Add(paramFechaAlta);
            Parametro paramTipoServicio = new Parametro("@tipo_servicio", SqlDbType.Int, this.tipoServicio);
            parametros.Add(paramTipoServicio);

            // Añadimos el parámetro de salida donde obtenemos el id_publicación que SQL Server le asigno al crucero
            Parametro paramIdCruceroAsignado = new Parametro("@id_crucero_asignada", SqlDbType.Int);
            paramIdCruceroAsignado.esParametroOut();
            parametros.Add(paramIdCruceroAsignado);

            // Creamos la llamada al SP "USP_insertar_crucero" de la BD y lo ejecutamos 
            StoreProcedure spInsertarCrucero = new StoreProcedure("LOS_BARONES_DE_LA_CERVEZA.USP_insertar_crucero", parametros);
            int cantidadFilasInsertadas = spInsertarCrucero.ejecutarNonQuery();

            // Comprobamos que el crucero se inserte correctamente
            if (!cantidadFilasInsertadas.Equals(DEF.FILAS_INSERT_CRUCERO))
                throw new InsertarCruceroException();
            else
                return Convert.ToInt32(paramIdCruceroAsignado.obtenerValor());
        }

        private void insertarCabinas(int idCrucero)
        {
            cabinas.ForEach(cabina => cabina.insertar(idCrucero));
        }

        public int actualizarCrucero(string identificadorCruceroAnterior)
        {
            // Creamos los parámetros del procedimiento almacenado USP_actualizar_crucero
            List<Parametro> parametros = new List<Parametro>();
            Parametro paramIdentificadorAnterior = new Parametro("@identificador_anterior", SqlDbType.NVarChar, identificadorCruceroAnterior, 50);
            parametros.Add(paramIdentificadorAnterior);
            Parametro paramModelo = new Parametro("@modelo", SqlDbType.NVarChar, this.modelo, 50);
            parametros.Add(paramModelo);
            Parametro paramIdentificador = new Parametro("@identificador", SqlDbType.NVarChar, this.identificador, 50);
            parametros.Add(paramIdentificador);
            Parametro paramMarca = new Parametro("@marca", SqlDbType.NVarChar, this.marca, 255);
            parametros.Add(paramMarca);
            Parametro paramTipoServicio = new Parametro("@tipo_servicio", SqlDbType.Int, this.tipoServicio);
            parametros.Add(paramTipoServicio);

            // Añadimos el parámetro de salida donde obtenemos el id_publicación que SQL Server le asigno al crucero
            Parametro paramIdCrucero = new Parametro("@id_crucero", SqlDbType.Int);
            paramIdCrucero.esParametroOut();
            parametros.Add(paramIdCrucero);

            // Creamos la llamada al SP "USP_actualizar_crucero" de la BD y lo ejecutamos 
            StoreProcedure spActualizarCrucero = new StoreProcedure("LOS_BARONES_DE_LA_CERVEZA.USP_actualizar_crucero", parametros);
            int cantidadFilasActualizadas = spActualizarCrucero.ejecutarNonQuery();

            // Comprobamos que el crucero se actualice correctamente
            if (!cantidadFilasActualizadas.Equals(DEF.FILAS_ACTUALIZAR_CRUCERO))
                throw new ActualizarCruceroException();
            else
                return Convert.ToInt32(paramIdCrucero.obtenerValor());
        }

        private void actualizarCabinas(int idCrucero)
        {   
            this.eliminarCabinas(idCrucero);
            cabinas.ForEach(cabina => cabina.insertar(idCrucero));
        }

        private void eliminarCabinas(int idCrucero)
        {   
            // Eliminamos todas las cabinas cuyo estado es 0 (disponibles) pertenecientes al crucero
            List<Parametro> parametros = new List<Parametro>();
            Parametro paramIdCrucero = new Parametro("@id_crucero", SqlDbType.Int, idCrucero);
            parametros.Add(paramIdCrucero);
            string consulta = "DELETE FROM LOS_BARONES_DE_LA_CERVEZA.Cabinas WHERE crucero = @id_crucero AND estado = 0";
            Query miConsulta = new Query(consulta, parametros);
            miConsulta.ejecutarNonQuery();
        }

    }
}
