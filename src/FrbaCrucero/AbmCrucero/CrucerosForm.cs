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
using FrbaCrucero.AbmCrucero.Utils;
using FrbaCrucero.Utils.Excepciones;

namespace FrbaCrucero.AbmCrucero
{
    public partial class CrucerosForm : Form
    {
        public CrucerosForm()
        {
            InitializeComponent();
        }

        private void CrucerosForm_Load(object sender, EventArgs e)
        {   
            // Establecemos como valor por defecto "Cabina estandar" para los tipos de Cabina
            dgvcmbxTipo.DefaultCellStyle.NullValue = DEF.CABINA_ESTANDAR;

            // Para que no se pueda editar el comboBox de Marca 
            cmbxMarca.DropDownStyle = ComboBoxStyle.DropDownList;

            // Establecemos un valor por defecto para el comboBox de Marca (para evitar nulls)
            cmbxMarca.SelectedIndex = 0;
        }

        // Alta de nuevo crucero 
        private void btnEnviar_Click(object sender, EventArgs e)
        {
            string modelo = txtbxModelo.Text;
            string identificadorA = txtbxIdentificadorA.Text;
            string identificadorB = txtbxIdentificadorB.Text;
            string marca = cmbxMarca.SelectedItem.ToString();
            DateTime fechaAlta = ArchivoConfig.obtenerFechaConfig();

            // 1. Validamos que no haya campos obligatorios nulos 
            try
            {
                Validaciones.hayCamposObligatoriosNulos(modelo, identificadorA, identificadorB).Equals(true);
            }
            catch 
            {
                MensajeBox.error("Hay campos obligatorios sin completar.");
            }
            
            // Cantidad de filas del DataGridView (debemos restarla 1 por la última fila en blanco)
            int cantidadCabinas = dgvCabinas.Rows.Count - 1;

            try
            {
                if (cantidadCabinas.Equals(DEF.NINGUNA_CABINA))
                    throw new CruceroSinCabinasException();
            }
            catch
            {
                MensajeBox.error("Debe ingresar al menos una cabina.");
            }

            // 2. Guardamos las cabinas ingresadas
            Dictionary<int, List<String>> cabinas = new Dictionary<int, List<string>>();
            for (int i = 0; i < cantidadCabinas; i++)
            {   
                // Debería crear un objeto Cabina y tener una lista de cabinas
                List<string> cabina = new List<string>();

                // Añadimos el número de cabina 
                cabina.Add(Convert.ToString(dgvCabinas.Rows[i].Cells[0].Value));

                // Añadimos el piso de la cabina
                cabina.Add(Convert.ToString(dgvCabinas.Rows[i].Cells[1].Value));

                // Añadimos el tipo de la cabina 
                cabina.Add(Convert.ToString(dgvCabinas.Rows[i].Cells[2].Value));
            }

            // 3. Insertamos el nuevo Crucero en la base de datos
        }

        private void dgvCabinas_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            e.Control.KeyPress -= new KeyPressEventHandler(Column1_KeyPress);
            if (dgvCabinas.CurrentCell.ColumnIndex == 0 ||
                    dgvCabinas.CurrentCell.ColumnIndex == 1) //Desired Column
            {
                TextBox tb = e.Control as TextBox;
                if (tb != null)
                {
                    tb.KeyPress += new KeyPressEventHandler(Column1_KeyPress);
                }
            }
        }

        private void Column1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

    }
}
