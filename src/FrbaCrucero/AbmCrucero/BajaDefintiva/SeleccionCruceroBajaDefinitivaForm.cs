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
using FrbaCrucero.AbmCrucero.CancelarViajes;

namespace FrbaCrucero.AbmCrucero
{
    public partial class SeleccionCruceroBajaDefinitiva : SeleccionCruceroEditarForm
    {
        public SeleccionCruceroBajaDefinitiva()
        {
            InitializeComponent();
        }

        protected override void SeleccionCruceroEditarForm_Load(object sender, EventArgs e)
        {
            string miConsulta = querySeleccionCruceros();
            base.cargarDgvCruceros(miConsulta);
            base.agregarBotonEditar("Acción", "Baja definitiva");
            dgvEditarCrucero.CellClick += base.dgvSeleccionarCrucero_CellContentClick;
            base.autoajustarDgv();
            base.lblSeleccionCrucero.Text = "Presione el botón al final del crucero elegido para proceder a su baja definitiva.";
        }

        override protected string querySeleccionCruceros()
        {
            return "SELECT identificador 'Identificador', modelo 'Modelo', marca 'Marca', fecha_alta 'Fecha de alta', cantidad_cabinas 'Cantidad de cabinas' " 
                + "FROM LOS_BARONES_DE_LA_CERVEZA.Cruceros_Activos_Vida_Util";
        }

        override protected void cargarFormulario(string identificadorCrucero)
        {
            // 1. Chequeamos que el crucero no esté en viaje o no tenga viajes pendientes 
            if (this.tieneViajesPendientes(identificadorCrucero))
            {
                CancelarViajesForm formCancelarViajes = new CancelarViajesForm(identificadorCrucero);
                formCancelarViajes.ShowDialog();
            }

            // Abrimos el cuadro de advertencia para obtener confirmación o no
            AvisoBajaDefinitivaForm formAvisoBajaDefintiva = new AvisoBajaDefinitivaForm(identificadorCrucero);
            formAvisoBajaDefintiva.ShowDialog();
        }

        private bool tieneViajesPendientes(string identificadorCrucero)
        {
            List<Parametro> parametros = new List<Parametro>();
            Parametro paramIdentificadorCrucero = new Parametro("@identificador_crucero", SqlDbType.NVarChar, identificadorCrucero, 50);
            parametros.Add(paramIdentificadorCrucero);
            Parametro paramFechaActual = new Parametro("@fecha_actual", SqlDbType.NVarChar, ArchivoConfig.obtenerFechaConfig().ToString("yyyy-MM-dd h:mm tt"), 255);
            parametros.Add(paramFechaActual);
            FuncionSQL funcViajesPendientesCrucero = new FuncionSQL("LOS_BARONES_DE_LA_CERVEZA.UF_viajes_pendientes_crucero", parametros, SqlDbType.Int);
            return Convert.ToInt32(funcViajesPendientesCrucero.ejecutar()) > 0;
        }

    }
}
