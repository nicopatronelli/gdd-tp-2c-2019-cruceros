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
            // Para que no se pueda editar el comboBox de Marca 
            cmbxMarca.DropDownStyle = ComboBoxStyle.DropDownList;

            // Establecemos un valor por defecto para el comboBox de Marca (para evitar nulls)
            cmbxMarca.SelectedIndex = 0;

            // Establecemos como valor por defecto "Cabina estandar" para los tipos de Cabina
            dgvcmbxTipo.DefaultCellStyle.NullValue = DEF.CABINA_ESTANDAR;
        }

        // Alta de nuevo crucero 
        private void btnEnviar_Click(object sender, EventArgs e)
        {
            // 1. Obtenemos los atributos del crucero 
            string modelo = txtbxModelo.Text;
            string identificadorA = txtbxIdentificadorA.Text;
            string identificadorB = txtbxIdentificadorB.Text;
            string marca = cmbxMarca.SelectedItem.ToString();
            DateTime fechaAlta = ArchivoConfig.obtenerFechaConfig();

            // 2. Construimos el objeto crucero 
            Crucero crucero = new Crucero();
            try
            {
                crucero
                .setModelo(modelo)
                .setMarca(marca)
                .setIdentificador(identificadorA, identificadorB)
                .setFechaAlta(fechaAlta);
            }
            catch (InsertarCruceroException ex)
            {
                ex.mensajeError();
                return;
            }

            // 3. Validamos que se haya ingresado al menos una cabina 
            // Cantidad de filas del DataGridView (debemos restarla 1 por la última fila en blanco)
            int cantidadCabinas = dgvCabinas.Rows.Count - 1;
            try
            {
                Cabina.validarCantidadCabinas(cantidadCabinas);
            }
            catch (CruceroSinCabinasException ex)
            {
                ex.mensajeError();
                return;
            }

            // 4. Guardamos las cabinas ingresadas en el crucero
            for (int i = 0; i < cantidadCabinas; i++)
            {
                Cabina unaCabina = new Cabina();
                unaCabina.setNumero(Convert.ToInt32(dgvCabinas.Rows[i].Cells[0].Value))
                    .setPiso(Convert.ToInt32(dgvCabinas.Rows[i].Cells[1].Value))
                    .setTipo(Cabina.tipoCabinaPorDefecto(Convert.ToString(dgvCabinas.Rows[i].Cells[2].Value)));
                crucero.agregarCabina(unaCabina);
            }

            // 5. En este punto ya tenemos un crucero correctamente construido y listo para ser insertado (incluyendo sus cabinas)
            try
            {
                crucero.insertar();
            }
            catch (InsertarCruceroException ex)
            {
                ex.mensajeError();
                return;
            }
        }

        private void dgvCabinas_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            e.Control.KeyPress -= new KeyPressEventHandler(NumeroYTipo_SoloNumeros_KeyPress);
            if (dgvCabinas.CurrentCell.ColumnIndex == 0 ||
                    dgvCabinas.CurrentCell.ColumnIndex == 1) 
            {
                TextBox tb = e.Control as TextBox;
                if (tb != null)
                {
                    tb.KeyPress += new KeyPressEventHandler(NumeroYTipo_SoloNumeros_KeyPress);
                }
            }
        }

        private void NumeroYTipo_SoloNumeros_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(Char.IsDigit(e.KeyChar)) && !(Char.IsControl(e.KeyChar)))
                e.Handled = true;
        }

        private void IdentificadorA_SoloLetras_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(Char.IsLetter(e.KeyChar)) && !(Char.IsControl(e.KeyChar)))
                e.Handled = true;
        }

        private void IdentificadorB_SoloNumeros_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(Char.IsDigit(e.KeyChar)) && !(Char.IsControl(e.KeyChar)))
                e.Handled = true;
        }

    }
}
