﻿using System.Windows.Forms;
namespace FrbaCrucero.AbmCrucero
{
    partial class CruceroForm 
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CruceroForm));
            this.txtbxModelo = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnGuardarSinCabinas = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnAlta = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.rbtnCincoEstrellas = new System.Windows.Forms.RadioButton();
            this.rbtnCuatroEstrellas = new System.Windows.Forms.RadioButton();
            this.rbtnTresEstrellas = new System.Windows.Forms.RadioButton();
            this.rbtnDosEstrellas = new System.Windows.Forms.RadioButton();
            this.rbtnUnaEstrella = new System.Windows.Forms.RadioButton();
            this.lblModelo = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtbxIdentificadorB = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblTipEliminarCabinas = new System.Windows.Forms.Label();
            this.lblInfoCabinas = new System.Windows.Forms.Label();
            this.dgvCabinas = new System.Windows.Forms.DataGridView();
            this.Numero = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Piso = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvcmbxTipo = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.cmbxMarca = new System.Windows.Forms.ComboBox();
            this.lblMarca = new System.Windows.Forms.Label();
            this.lblIdentificador = new System.Windows.Forms.Label();
            this.txtbxIdentificadorA = new System.Windows.Forms.TextBox();
            this.btnEnviar = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCabinas)).BeginInit();
            this.SuspendLayout();
            // 
            // txtbxModelo
            // 
            this.txtbxModelo.Location = new System.Drawing.Point(75, 23);
            this.txtbxModelo.Name = "txtbxModelo";
            this.txtbxModelo.Size = new System.Drawing.Size(100, 20);
            this.txtbxModelo.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnGuardarSinCabinas);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.btnCancelar);
            this.groupBox1.Controls.Add(this.btnGuardar);
            this.groupBox1.Controls.Add(this.btnAlta);
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Controls.Add(this.lblModelo);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtbxIdentificadorB);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.txtbxModelo);
            this.groupBox1.Controls.Add(this.cmbxMarca);
            this.groupBox1.Controls.Add(this.lblMarca);
            this.groupBox1.Controls.Add(this.lblIdentificador);
            this.groupBox1.Controls.Add(this.txtbxIdentificadorA);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(719, 491);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Detalles del Crucero";
            // 
            // btnGuardarSinCabinas
            // 
            this.btnGuardarSinCabinas.Location = new System.Drawing.Point(529, 455);
            this.btnGuardarSinCabinas.Name = "btnGuardarSinCabinas";
            this.btnGuardarSinCabinas.Size = new System.Drawing.Size(75, 23);
            this.btnGuardarSinCabinas.TabIndex = 11;
            this.btnGuardarSinCabinas.Text = "Guardar";
            this.btnGuardarSinCabinas.UseVisualStyleBackColor = true;
            this.btnGuardarSinCabinas.Click += new System.EventHandler(this.btnGuardarSinCabinas_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 460);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(201, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Nota: Todos los campos son obligatorios.";
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(627, 455);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 12;
            this.btnCancelar.Text = "Cerrar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnGuardar
            // 
            this.btnGuardar.Location = new System.Drawing.Point(529, 455);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(75, 23);
            this.btnGuardar.TabIndex = 22;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnAlta
            // 
            this.btnAlta.Location = new System.Drawing.Point(529, 455);
            this.btnAlta.Name = "btnAlta";
            this.btnAlta.Size = new System.Drawing.Size(75, 23);
            this.btnAlta.TabIndex = 23;
            this.btnAlta.Text = "Enviar";
            this.btnAlta.UseVisualStyleBackColor = true;
            this.btnAlta.Click += new System.EventHandler(this.btnAlta_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.rbtnCincoEstrellas);
            this.groupBox3.Controls.Add(this.rbtnCuatroEstrellas);
            this.groupBox3.Controls.Add(this.rbtnTresEstrellas);
            this.groupBox3.Controls.Add(this.rbtnDosEstrellas);
            this.groupBox3.Controls.Add(this.rbtnUnaEstrella);
            this.groupBox3.Location = new System.Drawing.Point(16, 118);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(410, 54);
            this.groupBox3.TabIndex = 8;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Tipo de servicio:";
            // 
            // rbtnCincoEstrellas
            // 
            this.rbtnCincoEstrellas.AutoSize = true;
            this.rbtnCincoEstrellas.Location = new System.Drawing.Point(322, 24);
            this.rbtnCincoEstrellas.Name = "rbtnCincoEstrellas";
            this.rbtnCincoEstrellas.Size = new System.Drawing.Size(72, 17);
            this.rbtnCincoEstrellas.TabIndex = 4;
            this.rbtnCincoEstrellas.TabStop = true;
            this.rbtnCincoEstrellas.Text = "5 estrellas";
            this.rbtnCincoEstrellas.UseVisualStyleBackColor = true;
            // 
            // rbtnCuatroEstrellas
            // 
            this.rbtnCuatroEstrellas.AutoSize = true;
            this.rbtnCuatroEstrellas.Location = new System.Drawing.Point(244, 24);
            this.rbtnCuatroEstrellas.Name = "rbtnCuatroEstrellas";
            this.rbtnCuatroEstrellas.Size = new System.Drawing.Size(72, 17);
            this.rbtnCuatroEstrellas.TabIndex = 3;
            this.rbtnCuatroEstrellas.TabStop = true;
            this.rbtnCuatroEstrellas.Text = "4 estrellas";
            this.rbtnCuatroEstrellas.UseVisualStyleBackColor = true;
            // 
            // rbtnTresEstrellas
            // 
            this.rbtnTresEstrellas.AutoSize = true;
            this.rbtnTresEstrellas.Location = new System.Drawing.Point(166, 24);
            this.rbtnTresEstrellas.Name = "rbtnTresEstrellas";
            this.rbtnTresEstrellas.Size = new System.Drawing.Size(72, 17);
            this.rbtnTresEstrellas.TabIndex = 2;
            this.rbtnTresEstrellas.TabStop = true;
            this.rbtnTresEstrellas.Text = "3 estrellas";
            this.rbtnTresEstrellas.UseVisualStyleBackColor = true;
            // 
            // rbtnDosEstrellas
            // 
            this.rbtnDosEstrellas.AutoSize = true;
            this.rbtnDosEstrellas.Location = new System.Drawing.Point(88, 24);
            this.rbtnDosEstrellas.Name = "rbtnDosEstrellas";
            this.rbtnDosEstrellas.Size = new System.Drawing.Size(72, 17);
            this.rbtnDosEstrellas.TabIndex = 1;
            this.rbtnDosEstrellas.TabStop = true;
            this.rbtnDosEstrellas.Text = "2 estrellas";
            this.rbtnDosEstrellas.UseVisualStyleBackColor = true;
            // 
            // rbtnUnaEstrella
            // 
            this.rbtnUnaEstrella.AutoSize = true;
            this.rbtnUnaEstrella.Location = new System.Drawing.Point(15, 24);
            this.rbtnUnaEstrella.Name = "rbtnUnaEstrella";
            this.rbtnUnaEstrella.Size = new System.Drawing.Size(67, 17);
            this.rbtnUnaEstrella.TabIndex = 0;
            this.rbtnUnaEstrella.TabStop = true;
            this.rbtnUnaEstrella.Text = "1 estrella";
            this.rbtnUnaEstrella.UseVisualStyleBackColor = true;
            // 
            // lblModelo
            // 
            this.lblModelo.AutoSize = true;
            this.lblModelo.Location = new System.Drawing.Point(24, 26);
            this.lblModelo.Name = "lblModelo";
            this.lblModelo.Size = new System.Drawing.Size(45, 13);
            this.lblModelo.TabIndex = 0;
            this.lblModelo.Text = "Modelo:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(157, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(14, 20);
            this.label1.TabIndex = 4;
            this.label1.Text = "-";
            // 
            // txtbxIdentificadorB
            // 
            this.txtbxIdentificadorB.Location = new System.Drawing.Point(174, 55);
            this.txtbxIdentificadorB.MaxLength = 5;
            this.txtbxIdentificadorB.Name = "txtbxIdentificadorB";
            this.txtbxIdentificadorB.Size = new System.Drawing.Size(49, 20);
            this.txtbxIdentificadorB.TabIndex = 5;
            this.txtbxIdentificadorB.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.IdentificadorB_SoloNumeros_KeyPress);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lblTipEliminarCabinas);
            this.groupBox2.Controls.Add(this.lblInfoCabinas);
            this.groupBox2.Controls.Add(this.dgvCabinas);
            this.groupBox2.Location = new System.Drawing.Point(16, 180);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(686, 269);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Cabinas";
            // 
            // lblTipEliminarCabinas
            // 
            this.lblTipEliminarCabinas.AutoSize = true;
            this.lblTipEliminarCabinas.Location = new System.Drawing.Point(23, 243);
            this.lblTipEliminarCabinas.Name = "lblTipEliminarCabinas";
            this.lblTipEliminarCabinas.Size = new System.Drawing.Size(540, 13);
            this.lblTipEliminarCabinas.TabIndex = 2;
            this.lblTipEliminarCabinas.Text = "Tip: Para descartar una cabina ingresada, presione la flecha a la izquierda del r" +
    "egistro y luego pulse la tecla Supr.";
            // 
            // lblInfoCabinas
            // 
            this.lblInfoCabinas.AutoSize = true;
            this.lblInfoCabinas.Location = new System.Drawing.Point(23, 22);
            this.lblInfoCabinas.Name = "lblInfoCabinas";
            this.lblInfoCabinas.Size = new System.Drawing.Size(490, 39);
            this.lblInfoCabinas.TabIndex = 0;
            this.lblInfoCabinas.Text = resources.GetString("lblInfoCabinas.Text");
            // 
            // dgvCabinas
            // 
            this.dgvCabinas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCabinas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Numero,
            this.Piso,
            this.dgvcmbxTipo});
            this.dgvCabinas.Location = new System.Drawing.Point(26, 64);
            this.dgvCabinas.Name = "dgvCabinas";
            this.dgvCabinas.Size = new System.Drawing.Size(633, 167);
            this.dgvCabinas.TabIndex = 1;
            this.dgvCabinas.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dgvCabinas_EditingControlShowing);
            // 
            // Numero
            // 
            this.Numero.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Numero.DataPropertyName = "numero";
            this.Numero.HeaderText = "Número";
            this.Numero.Name = "Numero";
            this.Numero.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // Piso
            // 
            this.Piso.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Piso.DataPropertyName = "piso";
            this.Piso.HeaderText = "Piso";
            this.Piso.Name = "Piso";
            this.Piso.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // dgvcmbxTipo
            // 
            this.dgvcmbxTipo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dgvcmbxTipo.DataPropertyName = "tipo_cabina";
            this.dgvcmbxTipo.HeaderText = "Tipo";
            this.dgvcmbxTipo.Name = "dgvcmbxTipo";
            this.dgvcmbxTipo.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // cmbxMarca
            // 
            this.cmbxMarca.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbxMarca.FormattingEnabled = true;
            this.cmbxMarca.Items.AddRange(new object[] {
            "P&O Cruises",
            "Costa Cruises",
            "fathom Cruise Line",
            "Holland America Line",
            "P&O Cruises Australia",
            "Princess Cruises",
            "AIDA Cruises",
            "Seabourn Cruise Line",
            "Cunard Line",
            "Carnival Cruise Lines",
            "Otra"});
            this.cmbxMarca.Location = new System.Drawing.Point(75, 88);
            this.cmbxMarca.Name = "cmbxMarca";
            this.cmbxMarca.Size = new System.Drawing.Size(121, 21);
            this.cmbxMarca.TabIndex = 7;
            // 
            // lblMarca
            // 
            this.lblMarca.AutoSize = true;
            this.lblMarca.Location = new System.Drawing.Point(24, 91);
            this.lblMarca.Name = "lblMarca";
            this.lblMarca.Size = new System.Drawing.Size(40, 13);
            this.lblMarca.TabIndex = 6;
            this.lblMarca.Text = "Marca:";
            // 
            // lblIdentificador
            // 
            this.lblIdentificador.AutoSize = true;
            this.lblIdentificador.Location = new System.Drawing.Point(24, 58);
            this.lblIdentificador.Name = "lblIdentificador";
            this.lblIdentificador.Size = new System.Drawing.Size(68, 13);
            this.lblIdentificador.TabIndex = 2;
            this.lblIdentificador.Text = "Identificador:";
            // 
            // txtbxIdentificadorA
            // 
            this.txtbxIdentificadorA.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtbxIdentificadorA.Location = new System.Drawing.Point(99, 55);
            this.txtbxIdentificadorA.MaxLength = 6;
            this.txtbxIdentificadorA.Name = "txtbxIdentificadorA";
            this.txtbxIdentificadorA.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtbxIdentificadorA.Size = new System.Drawing.Size(52, 20);
            this.txtbxIdentificadorA.TabIndex = 3;
            this.txtbxIdentificadorA.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.IdentificadorA_SoloLetras_KeyPress);
            // 
            // btnEnviar
            // 
            this.btnEnviar.Location = new System.Drawing.Point(524, 480);
            this.btnEnviar.Name = "btnEnviar";
            this.btnEnviar.Size = new System.Drawing.Size(75, 23);
            this.btnEnviar.TabIndex = 3;
            this.btnEnviar.Text = "Enviar";
            this.btnEnviar.UseVisualStyleBackColor = true;
            // 
            // CruceroForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(743, 514);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnEnviar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "CruceroForm";
            this.Text = "Alta de un nuevo crucero";
            this.Load += new System.EventHandler(this.CrucerosForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCabinas)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtbxModelo;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblModelo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtbxIdentificadorB;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label lblInfoCabinas;
        private System.Windows.Forms.ComboBox cmbxMarca;
        private System.Windows.Forms.Label lblMarca;
        private System.Windows.Forms.Label lblIdentificador;
        private System.Windows.Forms.TextBox txtbxIdentificadorA;
        private System.Windows.Forms.Button btnEnviar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Numero;
        private System.Windows.Forms.DataGridViewTextBoxColumn Piso;
        protected System.Windows.Forms.DataGridViewComboBoxColumn dgvcmbxTipo;
        protected DataGridView dgvCabinas;
        private Button btnGuardar;
        private GroupBox groupBox3;
        private RadioButton rbtnCincoEstrellas;
        private RadioButton rbtnCuatroEstrellas;
        private RadioButton rbtnTresEstrellas;
        private RadioButton rbtnDosEstrellas;
        private RadioButton rbtnUnaEstrella;
        private Button btnCancelar;
        private Button btnAlta;
        private Label lblTipEliminarCabinas;
        private Button btnGuardarSinCabinas;
    }
}