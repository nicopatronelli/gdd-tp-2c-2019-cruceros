using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using FrbaCrucero.Utils;
using FrbaCrucero.Utils.Excepciones;
using System.Windows.Forms;

namespace FrbaCrucero.AbmCrucero
{
    public class Cabina
    {
        private int id;
        private int numero;
        private int piso;
        private string tipo;

        public Cabina()
        {
        }

        public Cabina setNumero(int numero)
        {
            this.numero = numero;
            return this;
        }

        public Cabina setPiso(int piso)
        {
            this.piso = piso;
            return this;
        }

        public Cabina setTipo(string tipo)
        {
            this.tipo = tipo;
            return this;
        }

        public Cabina setId(int id)
        {
            this.id = id;
            return this;
        }

        public int getNumero()
        {
            return this.numero;
        }

        public int getPiso()
        {
            return this.piso;
        }

        public int getId()
        {
            return this.id;
        }

        public string getTipo()
        {
            return this.tipo;
        }

        public static string tipoCabinaPorDefecto(string tipoCabinaIngresado){
            if (tipoCabinaIngresado.Equals(DEF.CABINA_NULA))
                return DEF.CABINA_ESTANDAR;
            else
                return tipoCabinaIngresado;
        }

        public static void validarCantidadCabinas(int cantidadCabinas)
        {
            if (cantidadCabinas == 0)
                throw new CruceroSinCabinasException();
        }

        public void insertar(int idCrucero)
        {
            List<Parametro> parametrosCabinas;
            Parametro paramNumero, paramPiso, paramTipoCabina, paramCrucero;

            parametrosCabinas = new List<Parametro>();

            paramNumero = new Parametro("@numero", SqlDbType.Int, this.getNumero());
            parametrosCabinas.Add(paramNumero);

            paramPiso = new Parametro("@piso", SqlDbType.Int, this.getPiso());
            parametrosCabinas.Add(paramPiso);

            paramTipoCabina = new Parametro("@tipo_cabina", SqlDbType.NVarChar, this.getTipo(), 255);
            parametrosCabinas.Add(paramTipoCabina);

            paramCrucero = new Parametro("@crucero", SqlDbType.Int, idCrucero);
            parametrosCabinas.Add(paramCrucero);

            // Creamos la llamada al SP "USP_insertar_cabina" de la BD y lo ejecutamos 
            StoreProcedure spInsertarCabina = new StoreProcedure("LOS_BARONES_DE_LA_CERVEZA.USP_insertar_cabina", parametrosCabinas);
            int cantidadFilasInsertadas = spInsertarCabina.ejecutarNonQuery();
            
            // Comprobamos que la cabina se haya insertado correctamente
            if (!cantidadFilasInsertadas.Equals(DEF.FILAS_INSERT_CABINAS))
                throw new InsertarCruceroException();
        }

        public void comprarse(int id_viaje, int id_compra)
        {
            string consulta = "  insert into [GD1C2019].[LOS_BARONES_DE_LA_CERVEZA].[Estado_Cabinas_Por_Viaje] (id_viaje, id_cabina, compra) Values(" + id_viaje.ToString() +" , "+this.id+", "+id_compra.ToString() +" ) ";
            Query miConsulta = new Query(consulta, new List<Parametro>());
            int filasAfectadas = miConsulta.ejecutarNonQuery();
            if(filasAfectadas != 1)
                MessageBox.Show("Una cabina se a pagado mal");
        }


    }
}
