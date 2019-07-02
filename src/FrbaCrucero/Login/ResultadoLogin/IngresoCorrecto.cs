using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FrbaCrucero.Rol;
using FrbaCrucero.Utils;
using FrbaCrucero.PantallaPrincipal;
using FrbaCrucero.Login.ChequeosPostLoginExitoso;

namespace FrbaCrucero.Login
{
    class IngresoCorrecto : ResultadoLogin
    {
        public void procesarResultado(string nombreUsuario)
        {
            // Si el usuario tiene un único rol lo redirigo a la pantalla de ese rol
            if (Roles.cantidad(nombreUsuario).Equals(DEF.UNICO_ROL))
            {
                // 1. Verificamos que el rol esté habilitado
                if (Roles.rolHabilitado(nombreUsuario))
                {
                    // El rol está habilitado (INGRESO EXITOSO)
                    
                    // 2. Hacemos chequeos de negocio cuando se efectua un login exitoso
                    ChequeoPostLoginExitoso chequeoAltaCruceroST = new ChequeoAltaCrucerosServicioTecnico();
                    chequeoAltaCruceroST.chequear();

                    // 3. Me traigo las funcionalidades de ese rol
                    List<string> funcionalidades = Roles.funcionalidadesUnicoRol(nombreUsuario);

                    // 4. Llamo al método generarPantallaPrincipal con las funcionalidades como parámetros y el nombre de usuario
                    PantallaPrincipalForm formPantallaPrincipal = new PantallaPrincipalForm(funcionalidades, nombreUsuario);
                    formPantallaPrincipal.ShowDialog();
                }
                else
                {
                    // El rol NO está habilitado 
                    MensajeBox.info("El acceso de clientes está temporalmente suspendido. Disculpe las molestias.");
                }
            }
            // Si el usuario tiene más de un rol, desplegamos un menú para elija el rol (Funcionalidad a implementar en un futuro)
        }

    }
}
