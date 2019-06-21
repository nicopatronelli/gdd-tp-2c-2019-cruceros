using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrbaCrucero.AbmRecorrido.EditarRecorrido
{
    public partial class SeleccionRecorridoEditarForm : Form
    {
        public SeleccionRecorridoEditarForm()
        {
            InitializeComponent();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        virtual protected void SeleccionRecorridoEditarForm_Load(object sender, EventArgs e)
        {
            string miConsulta = querySeleccionRecorridos();
        }

        virtual protected string querySeleccionRecorridos()
        {
            return "SELECT cru.identificador 'Identificador', cru.modelo 'Modelo', mar.marca 'Marca', COUNT(cab.crucero) 'Cantidad de cabinas' "
                                + "FROM LOS_BARONES_DE_LA_CERVEZA.Cruceros cru "
                                    + "JOIN LOS_BARONES_DE_LA_CERVEZA.Marcas_Cruceros mar "
                                        + "ON cru.marca = mar.id_marca "
                                    + "JOIN LOS_BARONES_DE_LA_CERVEZA.Cabinas cab "
                                        + "ON cru.id_crucero = cab.crucero "
                                + "WHERE cru.fecha_baja_vida_util IS NULL " // No permitimos editar los cruceros dados de baja en forma definitiva
                                + "GROUP BY cru.identificador, cru.modelo, mar.marca";
        }
    }
}
