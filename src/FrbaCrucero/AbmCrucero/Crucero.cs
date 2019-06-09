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

        public void insertarCabinas(int idCrucero)
        {
            cabinas.ForEach(cabina => cabina.insertar(idCrucero));
        }

        public void insertar()
        {
            int idCrucero = this.insertarCrucero(); // Insertamos el crucero
            this.insertarCabinas(idCrucero); // Insertamos sus cabinas
        }
    }
}
