﻿using System;
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
using FrbaCrucero.AbmCrucero.Dominio;
using FrbaCrucero.Utils.Excepciones;

namespace FrbaCrucero.AbmCrucero
{
    public partial class CruceroForm : Form
    {
        private string modelo;
        private string identificadorA;
        private string identificadorB;
        private string marca;
        private string identificadorCrucero;
        private int tipoServicio;
        private bool flagCruceroConViaje; 

        // Constructor para ALTA
        public CruceroForm()
        {
            InitializeComponent();
            btnGuardar.Visible = false;
            btnGuardarSinCabinas.Visible = false;
            popularTipoCabinaCmbx();
            
            // Establecemos un valor por defecto para el comboBox de Marca (para evitar nulls)
            cmbxMarca.SelectedIndex = 0;
            
            // Establecemos como valor por defecto "Cabina estandar" para los tipos de Cabina
            dgvcmbxTipo.DefaultCellStyle.NullValue = DEF.CABINA_ESTANDAR;

            // Establecemos por defecto el tipo de servicio de 3 estrellas
            rbtnTresEstrellas.Checked = true;

        } // FIN Constructor para ALTA

        // Constructor para MODIFICACION
        public CruceroForm(string identificadorCruceroAEditar)
        {
            InitializeComponent();
            identificadorCrucero = identificadorCruceroAEditar;
            this.Text = "Modificar crucero";
            btnEnviar.Visible = false;
            btnGuardarSinCabinas.Visible = false;
            this.popularTipoCabinaCmbx();
            dgvcmbxTipo.DefaultCellStyle.NullValue = DEF.CABINA_ESTANDAR;
            this.popularCampos(); // Cargamos los campos del crucero a editar
            this.popularCabinas();  // Cargamos las cabinas del crucero a editar en el dgvCabinas  

            // Por esta iteración, para evitar problemas, si el crucero tuvo algún viaje alguna vez (se creo un viaje con este crucero)
            // no permitimos la edición de sus cabinas (ni modificar, agregar o eliminar), así que el datagridview lo establecemos
            // como de solo lectura
            this.flagCruceroConViaje = false; // Por default, asumimos que el crucero a editar no se asigno a ningún viaje
            if (this.cruceroAEditarTuvoAlgunViaje(identificadorCrucero).Equals(true))
            {
                this.dgvCabinas.ReadOnly = true;
                this.flagCruceroConViaje = true;
                dgvCabinas.ForeColor = Color.Gray;
                dgvCabinas.ColumnHeadersDefaultCellStyle.ForeColor = Color.Gray;
                dgvCabinas.EnableHeadersVisualStyles = false;
                this.lblInfoCabinas.Text = 
                    "AVISO: El crucero posee viajes asignados o se encuentra en viaje. Se listan sus cabinas pero no se permite su edición.";
                lblTipEliminarCabinas.Visible = false;
                btnGuardar.Visible = false;
                btnGuardarSinCabinas.Visible = true;
            }

        } // FIN Constructor para MODIFICACIÓN

        // Comportamiento común a ambos constructores (sin importar el orden)
        private void CrucerosForm_Load(object sender, EventArgs e)
        {
            // Para que no se pueda editar el comboBox de Marca 
            cmbxMarca.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        /*** ALTA DE NUEVO CRUCERO ***/

        private void btnAlta_Click(object sender, EventArgs e)
        {
            // 1. Obtenemos los atributos del crucero 
            this.cargarCampos();
            DateTime fechaAlta = ArchivoConfig.obtenerFechaConfig();

            // 2. Construimos el objeto crucero 
            Crucero crucero;
            try
            {
                crucero = new CruceroBuilder()
                    .setModelo(modelo)
                    .setMarca(marca)
                    .setIdentificador(identificadorA, identificadorB)
                    .setFechaAlta(fechaAlta)
                    .setTipoServicio(this.obtenerTipoServicio())
                    .buildCrucero();
            }
            catch (CamposObligatoriosVaciosException ex)
            {
                ex.mensajeError();
                return;
            }

            // 3. Validamos que el identificador del crucero esté disponible
            if (Crucero.identificadorDisponible(crucero.getIdentificador()).Equals(false))
            {
                MensajeBox.error("El identificador ingresado para el crucero ya se encuentra registrado.");
                return;
            }

            // 4. Validamos que se haya ingresado al menos una cabina 
            int cantidadCabinas = calcularCantidadCabinas();
            try
            {
                Cabina.validarCantidadCabinas(cantidadCabinas);
            }
            catch (CruceroSinCabinasException ex)
            {
                ex.mensajeError();
                return;
            }

            // 5. Guardamos las cabinas ingresadas en el objeto crucero
            guardarCabinas(crucero, cantidadCabinas);

            // 6. Validamos que no haya cabinas repetidas (Numero-Piso debería ser único por crucero)
            if (crucero.hayCabinasRepetidas())
            {
                MensajeBox.error("Cabinas repetidas: Hay cabinas con igual número y piso. Revise los datos e intente nuevamente.");
                return;
            }

            // 7. En este punto ya tenemos un crucero correctamente construido y listo para ser INSERTADO (incluyendo sus cabinas)
            try
            {
                crucero.insertar();
                MensajeBox.info("El crucero se dió de alta correctamente.");
            }
            catch (InsertarCruceroException ex)
            {
                ex.mensajeError();
                return;
            }
        }// FIN btnEnviar_Click()

        /*** MODIFICACIÓN DE CRUCERO EXISTENTE ***/
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            string identificadorCruceroAnterior = identificadorCrucero;

            // 1. Obtenemos los atributos del crucero 
            this.cargarCampos();

            // 2. Construimos el objeto crucero 
            Crucero crucero;
            try
            {
                crucero = new CruceroBuilder()
                    .setModelo(modelo)
                    .setMarca(marca)
                    .setIdentificador(identificadorA, identificadorB)
                    .setTipoServicio(this.obtenerTipoServicio())
                    .buildCrucero();
            }
            catch (CamposObligatoriosVaciosException ex)
            {
                ex.mensajeError();
                return;
            }

            // 3. Validamos que se haya ingresado al menos una cabina 
            int cantidadCabinas = calcularCantidadCabinas();
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
            guardarCabinas(crucero, cantidadCabinas);

            // 5. Validamos que no haya cabinas repetidas (Numero-Piso debería ser único por crucero)
            if (crucero.hayCabinasRepetidas())
            {
                MensajeBox.error("Cabinas repetidas: Hay cabinas con igual número y piso. Revise los datos e intente nuevamente.");
                return;
            }

            // 6. En este punto ya tenemos un crucero correctamente construido y listo para ser ACTUALIZADO (incluyendo sus cabinas)
            try
            {
                crucero.actualizar(identificadorCruceroAnterior);
                MensajeBox.info("El crucero se actualizo correctamente.");
            }
            catch (ActualizarCruceroException ex)
            {
                ex.mensajeError();
                return;
            }
        } // FIN btnGuardar_Click()

        private void cargarCampos()
        {
            this.modelo = txtbxModelo.Text;
            this.identificadorA = txtbxIdentificadorA.Text;
            this.identificadorB = txtbxIdentificadorB.Text;
            this.marca = cmbxMarca.SelectedItem.ToString();
            this.identificadorCrucero = txtbxIdentificadorA.Text + '-' + txtbxIdentificadorB.Text;
            this.tipoServicio = obtenerTipoServicio();
        }

        private int obtenerTipoServicio()
        {
            if (rbtnUnaEstrella.Checked)
                return 1;
            else if (rbtnDosEstrellas.Checked)
                return 2;
            else if (rbtnTresEstrellas.Checked)
                return 3;
            else if (rbtnCuatroEstrellas.Checked)
                return 4;
            else
                return 5;
        }

        private int calcularCantidadCabinas()
        {
            // Cantidad de filas del DataGridView (debemos restarla 1 por la última fila en blanco)
            return dgvCabinas.Rows.Count - 1;
        }

        private void guardarCabinas(Crucero crucero, int cantidadCabinas)
        {
            for (int i = 0; i < cantidadCabinas; i++)
            {
                Cabina unaCabina = new Cabina();
                unaCabina.setNumero(Convert.ToInt32(dgvCabinas.Rows[i].Cells[0].Value))
                    .setPiso(Convert.ToInt32(dgvCabinas.Rows[i].Cells[1].Value))
                    .setTipo(Cabina.tipoCabinaPorDefecto(Convert.ToString(dgvCabinas.Rows[i].Cells[2].Value)));
                crucero.agregarCabina(unaCabina);
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

        private void popularTipoCabinaCmbx()
        {
            ConexionBD conexion = new ConexionBD();
            conexion.abrir();
            SqlDataAdapter dataAdapter = new SqlDataAdapter("SELECT tipo_cabina FROM LOS_BARONES_DE_LA_CERVEZA.Tipos_Cabinas ", conexion.obtenerConexion());
            DataTable dt = new DataTable();
            dataAdapter.Fill(dt);
            dgvcmbxTipo.ValueMember = "tipo_cabina";
            dgvcmbxTipo.DisplayMember = "tipo_cabina";
            dgvcmbxTipo.DataSource = dt;
        }

        private void popularCabinas()
        {
            ConexionBD conexion = new ConexionBD();
            conexion.abrir();
            /**
             * @IMPORTANTE: No permitimos la modificación ni la eliminación de cabinas cuyo estado sea 1, 
             * es decir, pertenezcan a pasajes comprados o reservados. 
            **/
            string miConsulta = "SELECT cab.numero numero, cab.piso piso, tc.tipo_cabina tipo_cabina "
                              + "FROM LOS_BARONES_DE_LA_CERVEZA.Cabinas cab "
                                 + "JOIN LOS_BARONES_DE_LA_CERVEZA.Tipos_Cabinas tc "
                                    + "ON cab.tipo_cabina = tc.id_tipo_cabina "
                                + "JOIN LOS_BARONES_DE_LA_CERVEZA.Cruceros cru "
                                    + "ON cab.crucero = cru.id_crucero "
                              + "WHERE cru.identificador = @identificador_crucero ";
                                // + "AND e.compra IS NULL "
                                // + "AND e.reserva IS NULL";
            SqlDataAdapter dataAdapter = new SqlDataAdapter(miConsulta, conexion.obtenerConexion());
            Parametro paramIdentificadorCrucero = new Parametro("@identificador_crucero", SqlDbType.NVarChar, identificadorCrucero, 50);
            dataAdapter.SelectCommand.Parameters.Add(paramIdentificadorCrucero.obtenerSqlParameter());
            SqlCommandBuilder commandBuilder = new SqlCommandBuilder(dataAdapter);
            DataTable dt = new DataTable();
            dataAdapter.Fill(dt);
            dgvCabinas.DataSource = dt;
            conexion.cerrar();
        }

        private void popularCampos()
        {
            string consulta = "SELECT cru.modelo modelo, mar.marca marca, cru.tipo_servicio tipo_servicio "
                            + "FROM LOS_BARONES_DE_LA_CERVEZA.Cruceros cru "
                                + "JOIN LOS_BARONES_DE_LA_CERVEZA.Marcas_Cruceros mar "
                                    + "ON cru.marca = mar.id_marca "
                            + "WHERE cru.identificador = @identificador_crucero";
            List<Parametro> parametros = new List<Parametro>();
            Parametro paramIdentificadorCrucero = new Parametro("@identificador_crucero", SqlDbType.NVarChar, identificadorCrucero, 50);
            parametros.Add(paramIdentificadorCrucero);
            Query miConsulta = new Query(consulta, parametros);
            SqlDataReader camposCrucero = miConsulta.ejecutarReaderFila();
            camposCrucero.Read();
            txtbxModelo.Text = Convert.ToString(camposCrucero["modelo"]);
            cmbxMarca.SelectedItem = Convert.ToString(camposCrucero["marca"]);
            this.cargarTipoServicio(Convert.ToInt32(camposCrucero["tipo_servicio"]));
            miConsulta.cerrarConexionReader();

            string[] identificadorPartes = identificadorCrucero.Split('-');
            txtbxIdentificadorA.Text = identificadorPartes[0];
            txtbxIdentificadorB.Text = identificadorPartes[1];

        }

        private void cargarTipoServicio(int tipoServicio)
        {
            if (tipoServicio.Equals(DEF.TIPO_SERVICIO_UNA_ESTRELLA))
                rbtnUnaEstrella.Checked = true;
            else if (tipoServicio.Equals(DEF.TIPO_SERVICIO_DOS_ESTRELLAS))
                rbtnDosEstrellas.Checked = true;
            else if (tipoServicio.Equals(DEF.TIPO_SERVICIO_TRES_ESTRELLAS))
                rbtnTresEstrellas.Checked = true;
            else if (tipoServicio.Equals(DEF.TIPO_SERVICIO_CUATRO_ESTRELLAS))
                rbtnCuatroEstrellas.Checked = true;
            else
                rbtnCincoEstrellas.Checked = true;
        }

        private bool cruceroAEditarTuvoAlgunViaje(string identificadorCrucero)
        {
            string consulta = "SELECT COUNT(*) "
                            + "FROM LOS_BARONES_DE_LA_CERVEZA.Viaje v "
                                + "JOIN LOS_BARONES_DE_LA_CERVEZA.Cruceros cru "
                                    + "ON v.viaje_id_crucero = cru.id_crucero "
                            + "WHERE cru.identificador = @identificador_crucero";
            List<Parametro> parametros = new List<Parametro>();
            Parametro paramIdentificadorCrucero = new Parametro("@identificador_crucero", SqlDbType.NVarChar, identificadorCrucero, 50);
            parametros.Add(paramIdentificadorCrucero);
            Query miConsulta = new Query(consulta, parametros);
            int resultado = Convert.ToInt32(miConsulta.ejecutarEscalar());
            if (resultado > 0)
                return true;
            else
                return false;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // Botón para guardar los cambios en los campos de un crucero con viajes asignados, es decir, solo 
        // se guardan sus atributos principales, no sus cabinas
        private void btnGuardarSinCabinas_Click(object sender, EventArgs e)
        {
            string identificadorCruceroAnterior = identificadorCrucero;

            // 1. Obtenemos los atributos del crucero 
            this.cargarCampos();

            // 2. Construimos el objeto crucero 
            Crucero crucero;
            try
            {
                crucero = new CruceroBuilder()
                    .setModelo(modelo)
                    .setMarca(marca)
                    .setIdentificador(identificadorA, identificadorB)
                    .setTipoServicio(this.obtenerTipoServicio())
                    .buildCrucero();
            }
            catch (CamposObligatoriosVaciosException ex)
            {
                ex.mensajeError();
                return;
            }

            // 6. En este punto ya tenemos un crucero correctamente construido y listo para ser ACTUALIZADO (incluyendo sus cabinas)
            try
            {
                crucero.actualizarCrucero(identificadorCruceroAnterior);
                MensajeBox.info("El crucero se actualizo correctamente.");
            }
            catch (ActualizarCruceroException ex)
            {
                ex.mensajeError();
                return;
            }
        }

    }
}
