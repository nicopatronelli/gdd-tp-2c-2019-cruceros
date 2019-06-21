namespace FrbaCrucero.AbmRecorrido
{
    partial class AltaRecorridoForm
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtbxTramosSeleccionados = new System.Windows.Forms.TextBox();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.btnEnviar = new System.Windows.Forms.Button();
            this.lblPrecioRecorrido = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dgvElegirTramos = new System.Windows.Forms.DataGridView();
            this.tramo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.puerto_inicio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.puerto_fin = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.precio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.elegir_tramo = new System.Windows.Forms.DataGridViewButtonColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.txtbxCodRecorrido = new System.Windows.Forms.TextBox();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvElegirTramos)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnCerrar);
            this.groupBox1.Controls.Add(this.txtbxTramosSeleccionados);
            this.groupBox1.Controls.Add(this.btnLimpiar);
            this.groupBox1.Controls.Add(this.btnEnviar);
            this.groupBox1.Controls.Add(this.lblPrecioRecorrido);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.dgvElegirTramos);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtbxCodRecorrido);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(904, 333);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Abm Recorrido";
            // 
            // txtbxTramosSeleccionados
            // 
            this.txtbxTramosSeleccionados.Location = new System.Drawing.Point(645, 64);
            this.txtbxTramosSeleccionados.Multiline = true;
            this.txtbxTramosSeleccionados.Name = "txtbxTramosSeleccionados";
            this.txtbxTramosSeleccionados.ReadOnly = true;
            this.txtbxTramosSeleccionados.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtbxTramosSeleccionados.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtbxTramosSeleccionados.Size = new System.Drawing.Size(238, 186);
            this.txtbxTramosSeleccionados.TabIndex = 9;
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Location = new System.Drawing.Point(726, 291);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(75, 23);
            this.btnLimpiar.TabIndex = 6;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = true;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // btnEnviar
            // 
            this.btnEnviar.Location = new System.Drawing.Point(645, 291);
            this.btnEnviar.Name = "btnEnviar";
            this.btnEnviar.Size = new System.Drawing.Size(75, 23);
            this.btnEnviar.TabIndex = 5;
            this.btnEnviar.Text = "Enviar";
            this.btnEnviar.UseVisualStyleBackColor = true;
            this.btnEnviar.Click += new System.EventHandler(this.btnEnviar_Click);
            // 
            // lblPrecioRecorrido
            // 
            this.lblPrecioRecorrido.AutoSize = true;
            this.lblPrecioRecorrido.Location = new System.Drawing.Point(737, 263);
            this.lblPrecioRecorrido.Name = "lblPrecioRecorrido";
            this.lblPrecioRecorrido.Size = new System.Drawing.Size(13, 13);
            this.lblPrecioRecorrido.TabIndex = 4;
            this.lblPrecioRecorrido.Text = "0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(642, 263);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Precio Recorrido:";
            // 
            // dgvElegirTramos
            // 
            this.dgvElegirTramos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvElegirTramos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.tramo,
            this.puerto_inicio,
            this.puerto_fin,
            this.precio,
            this.elegir_tramo});
            this.dgvElegirTramos.Location = new System.Drawing.Point(25, 64);
            this.dgvElegirTramos.Name = "dgvElegirTramos";
            this.dgvElegirTramos.Size = new System.Drawing.Size(597, 250);
            this.dgvElegirTramos.TabIndex = 2;
            // 
            // tramo
            // 
            this.tramo.DataPropertyName = "tramo";
            this.tramo.HeaderText = "Tramo";
            this.tramo.Name = "tramo";
            this.tramo.ReadOnly = true;
            // 
            // puerto_inicio
            // 
            this.puerto_inicio.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.puerto_inicio.DataPropertyName = "puerto_inicio";
            this.puerto_inicio.HeaderText = "Puerto Inicio";
            this.puerto_inicio.Name = "puerto_inicio";
            this.puerto_inicio.ReadOnly = true;
            // 
            // puerto_fin
            // 
            this.puerto_fin.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.puerto_fin.DataPropertyName = "puerto_fin";
            this.puerto_fin.HeaderText = "Puerto Fin";
            this.puerto_fin.Name = "puerto_fin";
            this.puerto_fin.ReadOnly = true;
            // 
            // precio
            // 
            this.precio.DataPropertyName = "precio";
            this.precio.HeaderText = "Precio";
            this.precio.Name = "precio";
            this.precio.ReadOnly = true;
            // 
            // elegir_tramo
            // 
            this.elegir_tramo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.elegir_tramo.DataPropertyName = "btnSeleccionarTramo";
            this.elegir_tramo.HeaderText = "Seleccionar Tramo";
            this.elegir_tramo.Name = "elegir_tramo";
            this.elegir_tramo.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.elegir_tramo.Text = "Seleccionar";
            this.elegir_tramo.UseColumnTextForButtonValue = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Código Recorrido:";
            // 
            // txtbxCodRecorrido
            // 
            this.txtbxCodRecorrido.Location = new System.Drawing.Point(120, 28);
            this.txtbxCodRecorrido.Name = "txtbxCodRecorrido";
            this.txtbxCodRecorrido.Size = new System.Drawing.Size(100, 20);
            this.txtbxCodRecorrido.TabIndex = 0;
            // 
            // btnCerrar
            // 
            this.btnCerrar.Location = new System.Drawing.Point(807, 291);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(75, 23);
            this.btnCerrar.TabIndex = 10;
            this.btnCerrar.Text = "Cerrar";
            this.btnCerrar.UseVisualStyleBackColor = true;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // AltaRecorridoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(928, 352);
            this.Controls.Add(this.groupBox1);
            this.Name = "AltaRecorridoForm";
            this.Text = "Abm Recorrido";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvElegirTramos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dgvElegirTramos;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtbxCodRecorrido;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.Button btnEnviar;
        private System.Windows.Forms.Label lblPrecioRecorrido;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtbxTramosSeleccionados;
        private System.Windows.Forms.DataGridViewTextBoxColumn tramo;
        private System.Windows.Forms.DataGridViewTextBoxColumn puerto_inicio;
        private System.Windows.Forms.DataGridViewTextBoxColumn puerto_fin;
        private System.Windows.Forms.DataGridViewTextBoxColumn precio;
        private System.Windows.Forms.DataGridViewButtonColumn elegir_tramo;
        private System.Windows.Forms.Button btnCerrar;
    }
}