using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrbaCrucero.CompraReservaPasaje
{
    public class TipoCabina
    {
        public int id;
        public string descripcion;
        public double precio;

        public TipoCabina(int id, string descripcion, double precio)
        {
            this.id = id;
            this.descripcion = descripcion;
            this.precio = precio;
        }

        public override string ToString()
        {
            return this.descripcion;
        }
        
        }
}
