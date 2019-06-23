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

namespace FrbaCrucero.AbmRecorrido.HabilitacionDeshabilitacionRecorrido
{
    public partial class ConfirmarDeshabilitacionRecorridoForm : Form
    {
        private string identificadorRecorrido;

        public ConfirmarDeshabilitacionRecorridoForm()
        {
            InitializeComponent();
        }

        // Constructor que vamos a utilizar
        public ConfirmarDeshabilitacionRecorridoForm(string identificadorRecorridoADeshabilitar)
        {
            InitializeComponent();
            this.identificadorRecorrido = identificadorRecorridoADeshabilitar;
            lblConfirmacion.Text = "IMPORTANTE: ¿Está seguro que desea deshabilitar el recorrido " + identificadorRecorrido + "? " + Environment.NewLine
                                    + "Si es así, pulse Aceptar para deshabilitar el recorrido. " + Environment.NewLine 
                                    + "Caso contrario, pulse Cancelar para volver atrás.";
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            // Deshabilitamos el recorrido seleccionado
            List<Parametro> parametros = new List<Parametro>();
            Parametro paramIdentificadorRecorrido = new Parametro("@identificador_recorrido", SqlDbType.NVarChar, identificadorRecorrido, 255);
            parametros.Add(paramIdentificadorRecorrido);
            string consulta = "UPDATE LOS_BARONES_DE_LA_CERVEZA.Recorrido "
                            + "SET recorrido_estado = 1 "
                            + "WHERE recorrido_codigo = @identificador_recorrido";
            Query miConsulta = new Query(consulta, parametros);
            miConsulta.ejecutarNonQuery();
            this.Close();
        }
    }
}
