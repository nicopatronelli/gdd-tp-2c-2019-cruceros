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
using System.IO;
using FrbaCrucero.Utils;
using FrbaCrucero.PantallaPrincipal;
using FrbaCrucero.Rol;

namespace FrbaCrucero.Login
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {   
            if (this.hayCamposNulos())
                MensajeBox.error("Hay campos obligatorios sin completar.");
            else
                this.verificarUsuario();
        }

        private bool hayCamposNulos() { return (txtbxUsuario.Text.Equals("") || txtbxPass.Text.Equals("")); }

        private void verificarUsuario()
        {
            Parametro paramUsuario = new Parametro("@usuario_ingresado", SqlDbType.NVarChar, txtbxUsuario.Text, 100);
            Parametro paramPass = new Parametro("@pass_ingresada", SqlDbType.NVarChar, txtbxPass.Text, 100);
            Parametro paramResultado = new Parametro("@resultado", SqlDbType.Int);
            paramResultado.esParametroOut();
            List<Parametro> parametros = new List<Parametro>();
            parametros.Add(paramUsuario);
            parametros.Add(paramPass);
            parametros.Add(paramResultado);
            StoreProcedure spLogin = new StoreProcedure("LOS_BARONES_DE_LA_CERVEZA.USP_Login", parametros);
            spLogin.ejecutar();
            ResultadoLogin resultadoLogin = this.factoryMethodLogin(Convert.ToInt32(paramResultado.obtenerValor()));
            resultadoLogin.procesarResultado(txtbxUsuario.Text);
 
        } // FIN verificarUsuario()

        /* Aplico el pattern Factory Method para encapsular el condicional (switch)
         * que determina que instancia de ResultadoLogin instanciar de acuerdo al valor 
         * resultado del login (resultadoLogin).
         * https://realpython.com/factory-method-python/#introducing-factory-method 
         */
        private ResultadoLogin factoryMethodLogin(int resultadoLogin)
        {
            switch (resultadoLogin)
            {
                case DEF.USUARIO_NO_EXISTE:
                    return new UsuarioInexistente(); 
                case DEF.PASSWORD_INCORRECTO:
                    return new PasswordIncorrecto();
                case DEF.USUARIO_INHABILITADO:
                    return new UsuarioInhabilitado();
                case DEF.INGRESO_CORRECTO:
                    return new IngresoCorrecto();
                default:
                    return new ErrorLogin();
            } // Fin switch    
        } // Fin factoryMethodLogin()

    } // FIN LoginForm
}
