using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FrbaCrucero.Utils;

namespace FrbaCrucero.AbmCrucero
{
    public partial class BajaServicioTecnicoCruceroForm : Form
    {
        private string identificadorCruceroST;

        public BajaServicioTecnicoCruceroForm()
        {
            InitializeComponent();
        }

        // Constructor que vamos a utilizar
        public BajaServicioTecnicoCruceroForm(string identificadorCrucero)
        {
            InitializeComponent();
            identificadorCruceroST = identificadorCrucero;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            DateTime fechaDesde = ArchivoConfig.obtenerFechaConfig();
            DateTime fechaHasta = dtpFechaHasta.Value;

            // Validamos que la fecha de reinicio sea posterior a la actual (el sistema la toma del archivo de configuración)
            if (DateTime.Compare(fechaDesde, fechaHasta) > 0)
            {
                MensajeBox.error("La fecha de reinicio debe ser posterior a la actual (fecha del archivo de configuración).");
                return;
            }

            string consulta = "UPDATE LOS_BARONES_DE_LA_CERVEZA.Cruceros "
                + "SET baja_fuera_servicio = 1 "
                + "WHERE identificador = @identificador; "
                + "INSERT INTO LOS_BARONES_DE_LA_CERVEZA.Cruceros_Fuera_Servicio "
                + "(id_crucero, fecha_inicio_fuera_servicio, fecha_fin_fuera_servicio) "
                + "SELECT id_crucero, @fecha_desde, @fecha_hasta "
                + "FROM LOS_BARONES_DE_LA_CERVEZA.Cruceros "
                + "WHERE identificador = @identificador ";

            List<Parametro> parametros = new List<Parametro>();
            Parametro paramIdCrucero = new Parametro("@identificador", SqlDbType.NVarChar, identificadorCruceroST, 50);
            parametros.Add(paramIdCrucero);
            Parametro paramFechaDesde = new Parametro("@fecha_desde", SqlDbType.NVarChar, fechaDesde.ToString("yyyy-MM-dd h:mm tt"), 255);
            parametros.Add(paramFechaDesde);
            Parametro paramFechaHasta = new Parametro("@fecha_hasta", SqlDbType.NVarChar, fechaHasta.ToString("yyyy-MM-dd h:mm tt"), 255);
            parametros.Add(paramFechaHasta);

            Query miConsulta = new Query(consulta, parametros);
            miConsulta.ejecutarNonQuery();
            
            this.Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
