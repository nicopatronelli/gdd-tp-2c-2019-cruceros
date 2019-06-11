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
    public partial class SeleccionCruceroBajaDefinitiva : SeleccionCruceroEditarForm
    {
        public SeleccionCruceroBajaDefinitiva()
        {
            InitializeComponent();
        }

        protected override void SeleccionCruceroEditarForm_Load(object sender, EventArgs e)
        {
            string miConsulta = querySeleccionCruceros();
            cargarDgvCruceros(miConsulta);
            agregarBotonEditar("Acción", "Baja definitiva");
            dgvEditarCrucero.CellClick += dgvBajaDefinitivaCrucero_CellContentClick;
            autoajustarDgv();
        }

        override protected string querySeleccionCruceros()
        {
            string miConsulta = "SELECT cru.identificador 'Identificador', cru.modelo 'Modelo', mar.marca 'Marca', cru.fecha_alta 'Fecha alta', COUNT(cab.crucero) 'Cantidad de cabinas' "
                                 + "FROM LOS_BARONES_DE_LA_CERVEZA.Cruceros cru "
                                     + "JOIN LOS_BARONES_DE_LA_CERVEZA.Marcas_Cruceros mar "
                                         + "ON cru.marca = mar.id_marca "
                                     + "JOIN LOS_BARONES_DE_LA_CERVEZA.Cabinas cab "
                                         + "ON cru.id_crucero = cab.crucero "
                                 + "WHERE cru.fecha_baja_vida_util IS NULL " // No tiene sentido mostrar los cruceros que ya fueron dados de baja en forma definitiva
                                 + "GROUP BY cru.identificador, cru.modelo, mar.marca, cru.fecha_alta";
            return miConsulta;
        }

        // Abrimos la pantalla de edición de la publicación seleccionada con los datos que ya tenga cargados
        private void dgvBajaDefinitivaCrucero_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
                e.RowIndex >= 0)
            {
                // Obtenemos el identificador del crucero a dar de baja 
                string identificadorCrucero = Convert.ToString(dgvEditarCrucero.Rows[e.RowIndex].Cells["identificador"].Value);

                // Abrimos el cuadro de advertencia para obtener confirmación o no
                AvisoBajaDefinitivaForm formAvisoBajaDefintiva = new AvisoBajaDefinitivaForm(identificadorCrucero);
                formAvisoBajaDefintiva.ShowDialog();

                // Recargamos el dgv de cruceros para no mostrar el dado de baja definitiva 
                this.recargarDgvCruceros();
            }
        }

    }
}
