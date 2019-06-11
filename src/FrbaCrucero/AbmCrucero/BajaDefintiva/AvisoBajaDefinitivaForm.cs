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
using FrbaCrucero.Utils;

namespace FrbaCrucero.AbmCrucero
{
    public partial class AvisoBajaDefinitivaForm : Form
    {
        private string identificadorCruceroBaja;

        //public AvisoBajaDefinitivaForm()
        //{
        //    InitializeComponent();
        //}
        
        // Constructor que vamos a utilizar 
        public AvisoBajaDefinitivaForm(string identificadorCrucero)
        {
            InitializeComponent();
            identificadorCruceroBaja = identificadorCrucero;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnConfirmarBaja_Click(object sender, EventArgs e)
        {
            // Obtenemos la fecha actual (fecha de la baja) del archivo de configuración
            DateTime fechaBajaDefinitiva = ArchivoConfig.obtenerFechaConfig();

            // Damos de baja definitiva el crucero seleccionado (es una baja lógica, se marca un campo)
            List<Parametro> parametros = new List<Parametro>();
            Parametro paramIdentificadorCrucero = new Parametro("@identificador_crucero", SqlDbType.NVarChar, identificadorCruceroBaja, 255);
            parametros.Add(paramIdentificadorCrucero);
            string fecha = fechaBajaDefinitiva.ToString("yyyy-MM-dd h:mm tt");
            Parametro paramFechaBajaDefinitiva = new Parametro("@fecha_baja_definitiva", SqlDbType.NVarChar, fecha, 255);
            parametros.Add(paramFechaBajaDefinitiva);
            string consulta = "UPDATE LOS_BARONES_DE_LA_CERVEZA.Cruceros "
                            + "SET "
                                + "baja_vida_util = 1, "
                                + "fecha_baja_vida_util = (CONVERT(DATETIME2(3), @fecha_baja_definitiva, 121)) "
                            + "WHERE identificador = @identificador_crucero";
            Query miConsulta = new Query(consulta, parametros);
            miConsulta.ejecutarNonQuery();
            this.Close();
        }
    }
}
