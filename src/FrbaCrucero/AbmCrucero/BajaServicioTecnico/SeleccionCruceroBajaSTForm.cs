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
    public partial class SeleccionCruceroBajaSTForm : SeleccionCruceroEditarForm
    {
        public SeleccionCruceroBajaSTForm()
        {
            InitializeComponent();
        }

        protected override void SeleccionCruceroEditarForm_Load(object sender, EventArgs e)
        {
            string miConsulta = querySeleccionCruceros();
            base.cargarDgvCruceros(miConsulta);
            base.agregarBotonEditar("Acción", "Baja Servicio Técnico");
            dgvEditarCrucero.CellClick += base.dgvSeleccionarCrucero_CellContentClick; ;
            base.autoajustarDgv();
            this.Text = "Selección de crucero";
            base.lblSeleccionCrucero.Text = "Presione el botón al final del crucero elegido para proceder a su baja por servicio técnico.";
        }

        override protected string querySeleccionCruceros()
        {
            string miConsulta = "SELECT cru.identificador 'Identificador', cru.modelo 'Modelo', mar.marca 'Marca', COUNT(cab.crucero) 'Cantidad de cabinas' "
                                 + "FROM LOS_BARONES_DE_LA_CERVEZA.Cruceros cru "
                                     + "JOIN LOS_BARONES_DE_LA_CERVEZA.Marcas_Cruceros mar "
                                         + "ON cru.marca = mar.id_marca "
                                     + "JOIN LOS_BARONES_DE_LA_CERVEZA.Cabinas cab "
                                         + "ON cru.id_crucero = cab.crucero "
                                 + "WHERE cru.baja_vida_util = 0 " // No tiene sentido mostrar los cruceros ya dados de baja en forma definitiva...
                                    + "AND cru.baja_fuera_servicio = 0 " // ... ni los que ya están fuera de servicio 
                                 + "GROUP BY cru.identificador, cru.modelo, mar.marca";
            return miConsulta;
        }

        protected override void cargarFormulario(string identificadorCrucero)
        {
            // Abrimos la forma para ingresar la fecha de baja y reinicio del crucero por servicio técnico
            BajaServicioTecnicoCruceroForm formBajaServicioTecnico = new BajaServicioTecnicoCruceroForm(identificadorCrucero);
            formBajaServicioTecnico.ShowDialog();
        }

        // Obtenemos el identificador del crucero seleccionado y mostramos el form de baja por servicio técnico 
        //private void dgvBajaSTCrucero_CellContentClick(object sender, DataGridViewCellEventArgs e)
        //{
        //    var senderGrid = (DataGridView)sender;

        //    if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
        //        e.RowIndex >= 0)
        //    {
        //        // Obtenemos el identificador del crucero a dar de baja 
        //        string identificadorCrucero = Convert.ToString(dgvEditarCrucero.Rows[e.RowIndex].Cells["identificador"].Value);

        //        // Abrimos la forma para ingresar la fecha de baja y reinicio del crucero por servicio técnico
        //        BajaServicioTecnicoCruceroForm formBajaServicioTecnico = new BajaServicioTecnicoCruceroForm(identificadorCrucero);
        //        formBajaServicioTecnico.ShowDialog();

        //        // Recargamos el dgv de cruceros para no mostrar el daddo de baja por servicio técnico
        //        this.recargarDgvCruceros();
        //    }
        //}

    }
}
