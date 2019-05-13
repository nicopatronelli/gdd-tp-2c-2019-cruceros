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
            this.verificarUsuario();
        }

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
            int resultado = (int)paramResultado.obtenerValor();

            switch (resultado)
            {
                case DEF.USUARIO_NO_EXISTE:
                    MensajeBox.error("No existe el usuario.");
                    break;
                case DEF.PASSWORD_INCORRECTO:
                    MensajeBox.error("Contraseña incorrecta.");
                    break;
                case DEF.USUARIO_INHABILITADO:
                    MensajeBox.info("El usuario se encuentra inhabilitado. Contacte al administrador.");
                    break;
                case DEF.INGRESO_CORRECTO:
                    // Si el usuario tiene un único rol lo redirigo a la pantalla de ese rol
                    if (Roles.cantidad(txtbxUsuario.Text).Equals(DEF.UNICO_ROL))
                    {
                        // 1. Verificamos que el rol esté habilitado
                        if (Roles.rolHabilitado(txtbxUsuario.Text))
                        {
                            // El rol está habilitado 

                            // 2. Me traigo las funcionalidades de ese rol
                            List<string> funcionalidades = Roles.funcionalidadesUnicoRol(txtbxUsuario.Text);

                            // 3. Llamo al método generarPantallaPrincipal con las funcionalidades como parámetros y el nombre de usuario
                            PantallaPrincipalForm formPantallaPrincipal = new PantallaPrincipalForm(funcionalidades, txtbxUsuario.Text);
                            formPantallaPrincipal.ShowDialog();
                        }
                        else
                        {
                            // El rol NO está habilitado 
                            MensajeBox.error("El rol asociado a su usuario se encuentra deshabilitado. No es posible ingresar en estos momentos.");
                            return;
                        }
                    }
                    // Si el usuario tiene más de un rol, desplegamos un menú para elija el rol (Funcionalidad a implementar en un futuro)
                    break;
                default:
                    MensajeBox.error("Error en el logueo.");
                    break;

            } // Fin switch     
        } // FIN verificarUsuario()
    }
}
