using FrbaCrucero.AbmCrucero;
using FrbaCrucero.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrbaCrucero.CompraReservaPasaje
{
    public partial class ComprarTemplateForm : Form
    {
        public int viaje_id;
        public Viaje viaje;
        public bool editando = false;
        public Cliente clienteEditandose;
        public List<DisplayCabina> displayCabinas;
        public string puertoOrigen;

        public ComprarTemplateForm(List<DisplayCabina> cabinas,int viaje_id, string unPuertoOrigen)
        {
            this.displayCabinas = cabinas;
            this.viaje_id = viaje_id;
            InitializeComponent();
            this.informacionCompraLabel.Text = "Usted va a comprar:\n ";
            this.puertoOrigen = unPuertoOrigen;
            //aviso la cantidad de cabinas de cada tipo a comprar
            cabinas.ForEach(x => this.informacionCompraLabel.Text += "--" + x.cantidadSeleccionadaNumeric.Value + " cabina/as " + x.tipoCabinaLabel.Text + "\n");
            this.viaje = new Viaje(viaje_id);
            this.cargarDestinos();
        }


        private void dniTextBox_TextChanged(object sender, EventArgs e)
        {
            this.reset();

            if (dniTextBox.Text.Length > 6)
            {
                int cantidadClientes = this.cantidadClientesSegunDni();
                if (cantidadClientes == 1)
                {
                    this.estoyButton.Visible = true;
                    this.estoyButton.Enabled = true;
                    this.noEstoyButton.Visible = true;
                    var consulta = "  select id_cliente,nombre, apellido, direccion, cast(telefono as nvarchar(255)) as telefono, mail, fecha_nacimiento from [GD1C2019].[LOS_BARONES_DE_LA_CERVEZA].[Clientes] "
                                   + "     where dni = " + dniTextBox.Text;
                    Query miConsulta = new Query(consulta, new List<Parametro>());
                    SqlDataReader datosPersonales = miConsulta.ejecutarReaderFila();


                    Cliente cliente = new Cliente((int)datosPersonales["id_cliente"], Int32.Parse(dniTextBox.Text), datosPersonales["nombre"].ToString(), datosPersonales["apellido"].ToString(), datosPersonales["direccion"].ToString(), datosPersonales["telefono"].ToString(), datosPersonales["mail"].ToString(), (DateTime)datosPersonales["fecha_nacimiento"]);
                    this.clienteEditandose = cliente;   
                    this.mostrarCliente(cliente);
                    miConsulta.cerrarConexionReader();

                    return;
                }
                if (cantidadClientes > 1)
                {
                    this.estoyButton.Visible = true;
                    this.noEstoyButton.Visible = true;
                    this.clientesListBox.Visible = true;
                    this.cargarVariasPersonas(cantidadClientes);
                    this.estoyButton.Enabled = false;
                }

            }
        }

        private void desactivarEdicionDatos()
        {
            this.nombreTextBox.Enabled = false;
            this.apellidoTextBox.Enabled = false;
        }

        private void mostrarCliente(Cliente cliente)
        {
            this.nombreTextBox.Text = cliente.nombre;
            this.apellidoTextBox.Text = cliente.apellido;
            this.direccionTextBox.Text = cliente.direccion;
            this.telefonoTextBox.Text = cliente.telefono.ToString();
            this.mailTextBox.Text = cliente.mail;
            this.dayTextBox.Text = cliente.fechaDeNacimiento.Day.ToString();
            this.mesTextBox.Text = cliente.fechaDeNacimiento.Month.ToString();
            this.anioTextBox.Text = cliente.fechaDeNacimiento.Year.ToString();
        }


        private void cargarVariasPersonas(int cantidadClientes)
        {
            this.clientesListBox.Items.Clear();
            Cliente nuevoCliente;
            var consulta = "  select id_cliente,nombre, apellido, direccion, cast(telefono as nvarchar(255)) as telefono, mail, fecha_nacimiento from [GD1C2019].[LOS_BARONES_DE_LA_CERVEZA].[Clientes] "
               + "     where dni = " + dniTextBox.Text;
            Query miConsulta = new Query(consulta, new List<Parametro>());
            SqlDataReader datosPersonales = miConsulta.ejecutarReaderFila();
            for(int count = 0; count < cantidadClientes; count++)
            {
                nuevoCliente = new Cliente((int)datosPersonales["id_cliente"], Int32.Parse(dniTextBox.Text), datosPersonales["nombre"].ToString(), datosPersonales["apellido"].ToString(), datosPersonales["direccion"].ToString(), datosPersonales["telefono"].ToString(), datosPersonales["mail"].ToString(), (DateTime)datosPersonales["fecha_nacimiento"]);
                this.clientesListBox.Items.Add(nuevoCliente);
                datosPersonales.Read();
            }
        }




        private int cantidadClientesSegunDni()
        {
            string consulta = "select count (nombre) as cantidad from [GD1C2019].[LOS_BARONES_DE_LA_CERVEZA].[Clientes] where dni = " + dniTextBox.Text;
            Query miConsulta = new Query(consulta, new List<Parametro>());
            int result= (int)miConsulta.ejecutarEscalar();
            miConsulta.cerrarConexionReader();
            return result;
        }


        private void cargarDestinos()
        {
            puertosLabel.Text = "que pasara por los puertos:\n";
            string consulta = "SELECT puerto_nombre from[GD1C2019].[LOS_BARONES_DE_LA_CERVEZA].[UF_destinos_segun_recorrido](" + this.viaje.id_recorrido +  ")";

            Query miConsulta = new Query(consulta, new List<Parametro>());
            var destinos = miConsulta.ejecutarReaderUnicaColumna();
            foreach (var o in destinos)
            {
                this.puertosLabel.Text += (o+"\n");
            }
            this.viaje.puertos = this.puertosLabel.Text;
            this.viaje.origen = this.puertoOrigen;
            miConsulta.cerrarConexionReader();
        }


        private void dayTextBox_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void nombreTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void clientesListBox_SelectedValueChanged(object sender, EventArgs e)
        {
            this.estoyButton.Enabled = true;
        }

        private void estoyButton_Click(object sender, EventArgs e)
        {
            this.setEditando(true);
            this.dniTextBox.TextChanged -= new System.EventHandler(this.dniTextBox_TextChanged);
            if (clientesListBox.Visible)
            {
                this.mostrarCliente((Cliente)this.clientesListBox.SelectedItem);
                this.clienteEditandose = (Cliente)this.clientesListBox.SelectedItem;
                dniTextBox.Text = clienteEditandose.dni.ToString();
            }


//------------------------------------------------------------------------------------------------------------------------------------------------------------//
        }




        /************************************
         **********RESET*********************
         * ***********************************/
        private void reset()
        {
            this.estoyButton.Visible = false;
            this.noEstoyButton.Visible = false;
            this.nombreTextBox.Enabled = true;
            this.apellidoTextBox.Enabled = true;
            this.clientesListBox.Visible = false;
            this.vaciarDatosPersonales();
        }

        private void vaciarDatosPersonales()
        {
            this.nombreTextBox.Text = "";
            this.apellidoTextBox.Text = "";
            this.direccionTextBox.Text = "";
            this.telefonoTextBox.Text = "";
            this.mailTextBox.Text = "";
            this.dayTextBox.Text = "";
            this.mesTextBox.Text = "";
            this.anioTextBox.Text = "";
        }

        /************************************
         **********RESET*********************
         * ***********************************/

        private void noEstoyButton_Click(object sender, EventArgs e)
        {
            setEditando(false);
            this.dniTextBox.TextChanged += new System.EventHandler(this.dniTextBox_TextChanged);
            this.reset();
        }

        private void listoButton_Click(object sender, EventArgs e)
        {
            Validaciones.hayCamposObligatoriosNulos();
            string errorMessage = "";
            if (this.dniTextBox.Text.Length < 7) errorMessage += "Longitud minima de DNI es 7 digitos\n";
            if (this.dniTextBox.Text.Length > 9) errorMessage += "Longitud maxima de DNI es 9 digitos\n";
            if (this.nombreTextBox.Text == "") errorMessage += "Ingrese un nombre\n";
            if (this.apellidoTextBox.Text == "") errorMessage += "Ingrese un apellido\n";
            if (this.direccionTextBox.Text == "") errorMessage += "Ingrese una direccion\n";
            if (this.telefonoTextBox.Text == "") errorMessage += "Ingrese un telefono\n";
            if (this.dayTextBox.Text == "") errorMessage += "Ingrese un dia\n";
            if (this.mesTextBox.Text == "") errorMessage += "Ingrese un mes\n";
            if (this.anioTextBox.Text.Length != 4) errorMessage += "Ingrese un anio\n";
            DateTime fechaIngresada;
            try
            {
                fechaIngresada = DateTime.Parse(string.Concat(dayTextBox.Text,"/",mesTextBox.Text,"/",anioTextBox.Text));
                if ((ArchivoConfig.obtenerFechaConfig().Year - fechaIngresada.Year) < 18) errorMessage += "Necesita ser Mayor de 18 para registrarse y hacer un Pago\n";
            }
            catch(Exception aaaa)
            {
                errorMessage += "Fecha no valida\n";
            }

            errorMessage += this.checkDniRepetido();
          

            if (errorMessage != "")
            {
                MessageBox.Show(errorMessage);
                return;
            }
            this.finalizar();
       
        }

        public string checkDniRepetido()
        {
            ///caso en que edite a una persona con DNI duplicado y no le haya cambiado el DNI
            if (this.editando && this.clienteEditandose.dni.ToString() == dniTextBox.Text) return "";

            if (dniTextBox.TextLength < 7) return "Dni muy corto\n";
            string id = "0";
            if(this.editando) id= clienteEditandose.id.ToString();
            string consulta = "  select count(id_cliente) from [GD1C2019].[LOS_BARONES_DE_LA_CERVEZA].[Clientes] c where c.dni = " + this.dniTextBox.Text + " and c.id_cliente <> " + id;
            Query miConsulta = new Query(consulta, new List<Parametro>());
            int repetidos = (int)miConsulta.ejecutarEscalar();
            if(repetidos == 0)
            { return ""; }
            return "Ya hay alguien mas con ese DNI\n";
        
        }

        public void setEditando(bool input)
        {
            this.editando = input;
            if (input)
            {
                listoButton.Text = "Cambiar Datos y Aceptar";
            }
            else
            {
                listoButton.Text = "Registrarme y Aceptar";
            }
        }

        public void finalizar()
        {
            if (editando)
            {
                this.clienteEditandose.dni = Int32.Parse(dniTextBox.Text);
                clienteEditandose.nombre = nombreTextBox.Text;
                clienteEditandose.apellido = apellidoTextBox.Text;
                clienteEditandose.direccion = direccionTextBox.Text;
                clienteEditandose.mail = mailTextBox.Text;
                clienteEditandose.telefono = telefonoTextBox.Text;

            }
            else
            {
                clienteEditandose = new Cliente(0, Int32.Parse(dniTextBox.Text), nombreTextBox.Text, apellidoTextBox.Text, direccionTextBox.Text, telefonoTextBox.Text, mailTextBox.Text,   DateTime.Parse(string.Concat(dayTextBox.Text,"/",mesTextBox.Text,"/",anioTextBox.Text))  );
            }
            clienteEditandose.saveOrUpdate();
            Form form;
            if(comprarRadio.Checked) form= new PagoForm(displayCabinas, viaje,clienteEditandose);
            else form = this.hacerReserva();

            form.ShowDialog();
            this.Close();
        }
        public Form hacerReserva()
        {

            throw new NotImplementedException();
        }

        private void efectuarReserva()
        {
            string consulta = " select sum(t.tramo_precio) from [GD1C2019].[LOS_BARONES_DE_LA_CERVEZA].[Tramos_por_Recorrido] txr join [GD1C2019].[LOS_BARONES_DE_LA_CERVEZA].[Tramo] t on t.id_tramo = txr.id_tramo " +
        " where id_recorrido = " + viaje.id_recorrido.ToString();
            Query miConsulta = new Query(consulta, new List<Parametro>());
            double precioBase = double.Parse(miConsulta.ejecutarEscalar().ToString());

            int idReserva = this.generarReserva();
            List<Cabina> cabinasReservadas = new List<Cabina>();
            displayCabinas.ForEach(display => cabinasReservadas.AddRange(display.cabinasPagadas(viaje.id_viaje, idReserva)));
            double precioTotal = 0;
            foreach (var tipoCabina in displayCabinas)
            {
                precioTotal += tipoCabina.costoFinal(precioBase);
            }
            Form form = new VoucherForm(cabinasReservadas, clienteEditandose, viaje, idReserva, false, precioTotal);  //el true es para marcar que es una compra y no una reserva
        }


        public int generarReserva()
        {
            List<Parametro> parametros = new List<Parametro>();

            //agregamos parametro cantidad de cabinas
            Parametro paramCantidadCabinas = new Parametro("@cantidad_cabinas", SqlDbType.Int, 5);
            parametros.Add(paramCantidadCabinas);

            // Añadimos el parámetro identificador del viaje asociado a la compra
            Parametro paramIdViaje = new Parametro("@id_viaje", SqlDbType.Int, viaje.id_viaje);
            parametros.Add(paramIdViaje);

            Parametro paramIdCliente = new Parametro("@id_cliente", SqlDbType.Int, clienteEditandose.id);
            parametros.Add(paramIdCliente);



            // Añadimos el parámetro de salida donde obtenemos el id_reserva generado

            Parametro paramIdReserva = new Parametro("@id_reserva", SqlDbType.Int);
            paramIdReserva.esParametroOut();
            parametros.Add(paramIdReserva);

            StoreProcedure spGenerarReserva = new StoreProcedure("LOS_BARONES_DE_LA_CERVEZA.USP_generar_reserva", parametros);
            int cantidadFilasActualizadas = spGenerarReserva.ejecutarNonQuery();

            // Comprobamos que la compra se inserte correctamente
            if (!cantidadFilasActualizadas.Equals(1))
                MessageBox.Show("No se genero bien la reserva----filas afectadas= " + cantidadFilasActualizadas.ToString());
            else
            {
                // label9.Text = cantidadFilasActualizadas.ToString();
                MessageBox.Show("Reserva generada bien, el id es = " + paramIdReserva.obtenerValor().ToString());
            }

            return Int32.Parse(paramIdReserva.obtenerValor().ToString());
        }


    }
}



