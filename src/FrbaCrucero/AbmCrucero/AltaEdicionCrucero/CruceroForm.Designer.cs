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
            this.label1 = new System.Windows.Forms.Label();
            this.txtbxIdentificadorB = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnEnviar = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.dgvCabinas = new System.Windows.Forms.DataGridView();
            this.Numero = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Piso = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvcmbxTipo = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.cmbxMarca = new System.Windows.Forms.ComboBox();
            this.lblMarca = new System.Windows.Forms.Label();
            this.lblIdentificador = new System.Windows.Forms.Label();
            this.txtbxIdentificadorA = new System.Windows.Forms.TextBox();
            this.lblModelo = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCabinas)).BeginInit();
            this.SuspendLayout();
            // 
            // txtbxModelo
            // 
            this.txtbxModelo.Location = new System.Drawing.Point(75, 26);
            this.txtbxModelo.Name = "txtbxModelo";
            this.txtbxModelo.Size = new System.Drawing.Size(100, 20);
            this.txtbxModelo.TabIndex = 0;
            // 
            // groupBox1
            // 
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
            this.groupBox1.Size = new System.Drawing.Size(719, 461);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Detalles del Crucero";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(153, 64);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(14, 20);
            this.label1.TabIndex = 9;
            this.label1.Text = "-";
            // 
            // txtbxIdentificadorB
            // 
            this.txtbxIdentificadorB.Location = new System.Drawing.Point(170, 66);
            this.txtbxIdentificadorB.MaxLength = 5;
            this.txtbxIdentificadorB.Name = "txtbxIdentificadorB";
            this.txtbxIdentificadorB.Size = new System.Drawing.Size(49, 20);
            this.txtbxIdentificadorB.TabIndex = 8;
            this.txtbxIdentificadorB.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.IdentificadorB_SoloNumeros_KeyPress);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnGuardar);
            this.groupBox2.Controls.Add(this.btnEnviar);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.dgvCabinas);
            this.groupBox2.Location = new System.Drawing.Point(13, 141);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(686, 298);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Cabinas";
            // 
            // btnEnviar
            // 
            this.btnEnviar.Location = new System.Drawing.Point(584, 261);
            this.btnEnviar.Name = "btnEnviar";
            this.btnEnviar.Size = new System.Drawing.Size(75, 23);
            this.btnEnviar.TabIndex = 3;
            this.btnEnviar.Text = "Enviar";
            this.btnEnviar.UseVisualStyleBackColor = true;
            this.btnEnviar.Click += new System.EventHandler(this.btnEnviar_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(26, 19);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(490, 39);
            this.label7.TabIndex = 21;
            this.label7.Text = resources.GetString("label7.Text");
            // 
            // dgvCabinas
            // 
            this.dgvCabinas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCabinas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Numero,
            this.Piso,
            this.dgvcmbxTipo});
            this.dgvCabinas.Location = new System.Drawing.Point(26, 75);
            this.dgvCabinas.Name = "dgvCabinas";
            this.dgvCabinas.Size = new System.Drawing.Size(633, 167);
            this.dgvCabinas.TabIndex = 20;
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
            this.cmbxMarca.Location = new System.Drawing.Point(75, 106);
            this.cmbxMarca.Name = "cmbxMarca";
            this.cmbxMarca.Size = new System.Drawing.Size(121, 21);
            this.cmbxMarca.TabIndex = 6;
            // 
            // lblMarca
            // 
            this.lblMarca.AutoSize = true;
            this.lblMarca.Location = new System.Drawing.Point(21, 109);
            this.lblMarca.Name = "lblMarca";
            this.lblMarca.Size = new System.Drawing.Size(40, 13);
            this.lblMarca.TabIndex = 5;
            this.lblMarca.Text = "Marca:";
            // 
            // lblIdentificador
            // 
            this.lblIdentificador.AutoSize = true;
            this.lblIdentificador.Location = new System.Drawing.Point(21, 69);
            this.lblIdentificador.Name = "lblIdentificador";
            this.lblIdentificador.Size = new System.Drawing.Size(68, 13);
            this.lblIdentificador.TabIndex = 4;
            this.lblIdentificador.Text = "Identificador:";
            // 
            // txtbxIdentificadorA
            // 
            this.txtbxIdentificadorA.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtbxIdentificadorA.Location = new System.Drawing.Point(95, 66);
            this.txtbxIdentificadorA.MaxLength = 6;
            this.txtbxIdentificadorA.Name = "txtbxIdentificadorA";
            this.txtbxIdentificadorA.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtbxIdentificadorA.Size = new System.Drawing.Size(52, 20);
            this.txtbxIdentificadorA.TabIndex = 3;
            this.txtbxIdentificadorA.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.IdentificadorA_SoloLetras_KeyPress);
            // 
            // lblModelo
            // 
            this.lblModelo.AutoSize = true;
            this.lblModelo.Location = new System.Drawing.Point(36, 41);
            this.lblModelo.Name = "lblModelo";
            this.lblModelo.Size = new System.Drawing.Size(45, 13);
            this.lblModelo.TabIndex = 2;
            this.lblModelo.Text = "Modelo:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 493);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(201, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Nota: Todos los campos son obligatorios.";
            // 
            // btnGuardar
            // 
            this.btnGuardar.Location = new System.Drawing.Point(584, 262);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(75, 23);
            this.btnGuardar.TabIndex = 22;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // CruceroForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(743, 512);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblModelo);
            this.Controls.Add(this.groupBox1);
            this.Name = "CruceroForm";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.CrucerosForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCabinas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtbxModelo;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblModelo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtbxIdentificadorB;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label7;
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
    }
}