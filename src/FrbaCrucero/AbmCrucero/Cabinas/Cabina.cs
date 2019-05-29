using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrbaCrucero.AbmCrucero.Cabinas
{   
    class Cabina
    {
        private int numero;
        private int piso;
        private string marca;
        private Tipo tipo;

        // Constructor 
        Cabina(int numero, int piso, string marca, Tipo tipo)
        {
            this.numero = numero;
            this.piso = piso;
            this.marca = marca;
            this.tipo = tipo;
        }
    }

    public enum Tipo
    {
        CABINA_ESTANDAR = "Cabina estandar",
        CABINA_EXTERIOR = "Cabina Exterior",
        CABINA_BALCON = "Cabina Balcón",
        CABINA_SUITE = "Suite",
        CABINA_EJECUTIVO = "Ejecutivo",
    }
}
