using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrbaCrucero.CompraReservaPasaje
{
    class Cliente
    {
        public int dni;
        public string nombre;
        public string apellido;
        public string direccion;
        public string telefono;
        public string mail;
        public DateTime fechaDeNacimiento;

        public Cliente(int dni, string nombre, string apellido, string direccion, string telefono, string mail, DateTime nacimiento)
        {
            this.dni = dni;
            this.nombre = nombre;
            this.apellido = apellido;
            this.direccion = direccion;
            this.telefono = telefono;
            this.mail = mail;
            this.fechaDeNacimiento = nacimiento;
        }
    }


}
