using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using FrbaCrucero.Utils;
using FrbaCrucero.Utils.Excepciones;

namespace FrbaCrucero.AbmCrucero.Utils
{
    class Crucero
    {
        private string modelo;
        private string identificador;
        private string marca;
        private DateTime fechaAlta;
        private List<Cabina> cabinas = new List<Cabina>();

        public Crucero() 
        {
        }

        public Crucero setModelo(string modelo)
        {
            Validaciones.hayCamposObligatoriosNulos(modelo);
            this.modelo = modelo;
            return this;
        }

        public Crucero setIdentificador(string identificadorA, string identificadorB)
        {
            Validaciones.hayCamposObligatoriosNulos(identificadorA);
            Validaciones.hayCamposObligatoriosNulos(identificadorB);
            this.identificador = identificadorA + "-" + identificadorB;
            return this;
        }

        public Crucero setMarca(string marca)
        {
            Validaciones.hayCamposObligatoriosNulos(marca);
            this.marca = marca;
            return this;
        }

        public Crucero setFechaAlta(DateTime fechaAlta)
        {
            this.fechaAlta = fechaAlta;
            return this; 
        }

        public void agregarCabina(Cabina cabina)
        {
            this.cabinas.Add(cabina);
        }

        public List<Cabina> getCabinas()
        {
            return this.cabinas;
        }

        public bool hayCabinasRepetidas()
        {
            return this.getCabinas().GroupBy(cab => cab.getPiso(), cab => cab.getNumero()).Any(cab => cab.Count() > 1);
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

            // Añadimos el parámetro de salida donde obtenemos el id_publicación que SQL Server le asigno al crucero
            Parametro paramIdCruceroAsignado = new Parametro("@id_crucero_asignada", SqlDbType.Int);
            paramIdCruceroAsignado.esParametroOut();
            parametros.Add(paramIdCruceroAsignado);

            // Creamos la llamada al SP "USP_insertar_crucero" de la BD y lo ejecutamos 
            StoreProcedure spInsertarCrucero = new StoreProcedure("LOS_BARONES_DE_LA_CERVEZA.USP_insertar_crucero", parametros);
            int cantidadFilasInsertadas = spInsertarCrucero.ejecutarNonQuery();

            // Comprobamos que el crucero se inserte 
            if (!cantidadFilasInsertadas.Equals(DEF.FILAS_INSERT_CRUCERO))
                throw new InsertarCruceroException();
            else
                return Convert.ToInt32(paramIdCruceroAsignado.obtenerValor());
        }

        private void insertarCabinas(int idCrucero)
        {
            cabinas.ForEach(cabina => cabina.insertar(idCrucero));
        }

        public void insertar()
        {
            int idCrucero = this.insertarCrucero(); // Insertamos el crucero
            this.insertarCabinas(idCrucero); // Insertamos sus cabinas
        }

        private int actualizarCrucero(string identificadorCruceroAnterior)
        {
            // Creamos los parámetros del procedimiento almacenado USP_insertar_crucero
            List<Parametro> parametros = new List<Parametro>();
            Parametro paramIdentificadorAnterior = new Parametro("@identificador_anterior", SqlDbType.NVarChar, identificadorCruceroAnterior, 50);
            parametros.Add(paramIdentificadorAnterior);
            Parametro paramModelo = new Parametro("@modelo", SqlDbType.NVarChar, this.modelo, 50);
            parametros.Add(paramModelo);
            Parametro paramIdentificador = new Parametro("@identificador", SqlDbType.NVarChar, this.identificador, 50);
            parametros.Add(paramIdentificador);
            Parametro paramMarca = new Parametro("@marca", SqlDbType.NVarChar, this.marca, 255);
            parametros.Add(paramMarca);

            // Añadimos el parámetro de salida donde obtenemos el id_publicación que SQL Server le asigno al crucero
            Parametro paramIdCrucero = new Parametro("@id_crucero", SqlDbType.Int);
            paramIdCrucero.esParametroOut();
            parametros.Add(paramIdCrucero);

            // Creamos la llamada al SP "USP_insertar_crucero" de la BD y lo ejecutamos 
            StoreProcedure spActualizarCrucero = new StoreProcedure("LOS_BARONES_DE_LA_CERVEZA.USP_actualizar_crucero", parametros);
            int cantidadFilasActualizadas = spActualizarCrucero.ejecutarNonQuery();

            // Comprobamos que el crucero se inserte 
            if (!cantidadFilasActualizadas.Equals(DEF.FILAS_ACTUALIZAR_CRUCERO))
                throw new ActualizarCruceroException();
            else
                return Convert.ToInt32(paramIdCrucero.obtenerValor());
        }

        public void actualizar(string identificadorCruceroAnterior)
        {
            int idCrucero = this.actualizarCrucero(identificadorCruceroAnterior); // Actualizamos el crucero
            this.actualizarCabinas(idCrucero); // Actualizamos sus cabinas
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
