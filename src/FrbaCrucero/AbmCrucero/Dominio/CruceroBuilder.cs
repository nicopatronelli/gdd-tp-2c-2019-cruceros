using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FrbaCrucero.Utils;
using FrbaCrucero.AbmCrucero.Dominio;

namespace FrbaCrucero.AbmCrucero.Dominio
{
    public class CruceroBuilder
    {
        private string modelo;
        private string identificador;
        private string marca;
        private DateTime fechaAlta;
        //private List<Cabina> cabinas = new List<Cabina>();

        public CruceroBuilder(){}

        public CruceroBuilder setModelo(string modelo)
        {
            this.modelo = modelo;
            return this;
        }

        public CruceroBuilder setIdentificador(string identificadorA, string identificadorB)
        {
            Validaciones.hayCamposObligatoriosNulos(identificadorA);
            Validaciones.hayCamposObligatoriosNulos(identificadorB);
            this.identificador = identificadorA + "-" + identificadorB;
            return this;
        }

        public CruceroBuilder setMarca(string marca)
        {
            this.marca = marca;
            return this;
        }

        public CruceroBuilder setFechaAlta(DateTime fechaAlta)
        {
            Validaciones.hayCamposObligatoriosNulos(fechaAlta.ToString());
            this.fechaAlta = fechaAlta;
            return this;
        }

        public Crucero buildCrucero()
        {
            Validaciones.hayCamposObligatoriosNulos(this.modelo, this.identificador, this.marca);
            return new Crucero(this);   
        }

        // GETTERS

        public string getModelo()
        {
            return this.modelo;
        }

        public string getMarca()
        {
            return this.marca;
        }

        public string getIdentificador()
        {
            return this.identificador;
        }

        public DateTime getFechaAlta()
        {
            return this.fechaAlta;
        }
    }
}
