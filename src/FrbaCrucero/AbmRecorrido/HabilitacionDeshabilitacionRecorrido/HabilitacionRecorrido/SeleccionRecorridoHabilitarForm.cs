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
    public partial class SeleccionRecorridoHabilitarForm : SeleccionRecorridoDeshabilitarForm
    {
        public SeleccionRecorridoHabilitarForm()
        {
            InitializeComponent();
        }

        private void SeleccionRecorridoHabilitarForm_Load(object sender, EventArgs e)
        {
            this.Text = "Habilitar Recorrido";
        }

        override protected void recargarDgvRecorridos(string puertoInicio, string puertoFin)
        {
            // Limpiamos el listado (datagridview) de recorridos
            this.listadoRecorridos.limpiarDgv();
            this.listadoRecorridos.popularRecorridos(puertoInicio, puertoFin, this.listadoRecorridos.queryRecorridosEstado(DEF.RECORRIDOS_DESHABILITADOS));
            this.listadoRecorridos.agregarBotonEditar("Habilitar Recorrido", "Habilitar");
        }

        override protected void dgvSeleccionarRecorrido_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
                e.RowIndex >= 0)
            {
                string identificadorRecorrido = Convert.ToString(this.listadoRecorridos.getDgvRecorridos().Rows[e.RowIndex].Cells["Identificador"].Value);

                // Habilitamos el recorrido seleccionado
                List<Parametro> parametros = new List<Parametro>();
                Parametro paramIdentificadorRecorrido = new Parametro("@identificador_recorrido", SqlDbType.NVarChar, identificadorRecorrido, 255);
                parametros.Add(paramIdentificadorRecorrido);
                string consulta = "UPDATE LOS_BARONES_DE_LA_CERVEZA.Recorrido "
                                + "SET recorrido_estado = 0 " 
                                + "WHERE recorrido_codigo = @identificador_recorrido";
                Query miConsulta = new Query(consulta, parametros);
                miConsulta.ejecutarNonQuery();

                MensajeBox.info("CONFIRMACION: El recorrido " + identificadorRecorrido + " se habilito correctamente.");

                // Recargamos el dgv con los recorridos deshabilitados, excluyendo el que acabamos de habilitar
                this.recargarDgvRecorridos(puertoInicio, puertoFin);
            }
        }
    }
}
