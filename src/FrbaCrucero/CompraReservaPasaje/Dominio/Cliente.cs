using FrbaCrucero.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrbaCrucero.CompraReservaPasaje
{
    public class Cliente
    {
        public int id;
        public int dni;
        public string nombre;
        public string apellido;
        public string direccion;
        public string telefono;
        public string mail;
        public DateTime fechaDeNacimiento;

        public Cliente(int id,int dni, string nombre, string apellido, string direccion, string telefono, string mail, DateTime nacimiento)
        {
            
            this.id = id;
            this.dni = dni;
            this.nombre = nombre;
            this.apellido = apellido;
            this.direccion = direccion;
            this.telefono = telefono;
            if(string.IsNullOrEmpty(mail))
                {this.mail = "";}
            else
                {this.mail = mail;}
            this.fechaDeNacimiento = nacimiento;
        }

        public override string ToString()
        {
            return this.nombre.ToLower() + ' ' + this.apellido;
        }
        public void saveOrUpdate()
        {
            int filas;

            if (id == 0)
            {
                var consulta = " INSERT into [GD1C2019].[LOS_BARONES_DE_LA_CERVEZA].[Clientes] (nombre, apellido, dni, direccion, telefono, mail, fecha_nacimiento) "
                       + " Values ('" + this.nombre.ToUpper() + "', '" + this.apellido.ToLower() + "' , " + this.dni.ToString() + ", '" + direccion + "', " + telefono + ", '" + this.mail + "' , cast('" + this.fechaDeNacimiento.Date.ToString() + "' as datetime))";
                Query miConsulta = new Query(consulta, new List<Parametro>());
                filas = miConsulta.ejecutarNonQuery();
                System.Windows.Forms.MessageBox.Show("cliente agregado, se han alterado " + filas.ToString() + " filas");

                //asigno al cliente el nuevo id, porque actualmente figura 0 aca en el front//
                consulta = "  select ident_current('LOS_BARONES_DE_LA_CERVEZA.Clientes') ";
                miConsulta = new Query(consulta, new List<Parametro>());
                this.id = int.Parse(miConsulta.ejecutarEscalar().ToString());
                System.Windows.Forms.MessageBox.Show("nuevo id es" + this.id.ToString());
            }
            else
            {
                var consulta = " update [GD1C2019].[LOS_BARONES_DE_LA_CERVEZA].[Clientes] "
                       + " set nombre = '"+this.nombre+"', apellido= '"+this.apellido+"', dni= "+this.dni.ToString()+", direccion = '"+this.direccion+"', telefono = "+this.telefono
                       + " where id_cliente = "+this.id.ToString();
                Query miConsulta = new Query(consulta, new List<Parametro>());
                filas = miConsulta.ejecutarNonQuery();
                System.Windows.Forms.MessageBox.Show("cliente Editado, se han alterado " + filas.ToString() + " filas");               
	

            }
        }


    }
}
