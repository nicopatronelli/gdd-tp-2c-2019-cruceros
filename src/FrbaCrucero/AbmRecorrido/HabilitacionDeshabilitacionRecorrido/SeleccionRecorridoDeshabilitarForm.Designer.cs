namespace FrbaCrucero.AbmRecorrido.HabilitacionDeshabilitacionRecorrido
{
    partial class SeleccionRecorridoDeshabilitarForm
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
            this.Puerto = new System.Windows.Forms.Label();
            this.txtbxPuertoFin = new System.Windows.Forms.TextBox();
            this.btnBuscarRecorridos = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.txtbxPuertoInicio = new System.Windows.Forms.TextBox();
            this.dgvRecorridos = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnCerrar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRecorridos)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Puerto
            // 
            this.Puerto.AutoSize = true;
            this.Puerto.Location = new System.Drawing.Point(13, 24);
            this.Puerto.Name = "Puerto";
            this.Puerto.Size = new System.Drawing.Size(83, 13);
            this.Puerto.TabIndex = 13;
            this.Puerto.Text = "Puerto de inicio:";
            // 
            // txtbxPuertoFin
            // 
            this.txtbxPuertoFin.Location = new System.Drawing.Point(302, 20);
            this.txtbxPuertoFin.Name = "txtbxPuertoFin";
            this.txtbxPuertoFin.Size = new System.Drawing.Size(100, 20);
            this.txtbxPuertoFin.TabIndex = 18;
            // 
            // btnBuscarRecorridos
            // 
            this.btnBuscarRecorridos.Location = new System.Drawing.Point(435, 18);
            this.btnBuscarRecorridos.Name = "btnBuscarRecorridos";
            this.btnBuscarRecorridos.Size = new System.Drawing.Size(75, 23);
            this.btnBuscarRecorridos.TabIndex = 16;
            this.btnBuscarRecorridos.Text = "Buscar";
            this.btnBuscarRecorridos.UseVisualStyleBackColor = true;
            this.btnBuscarRecorridos.Click += new System.EventHandler(this.btnBuscarRecorridos_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(226, 24);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 13);
            this.label4.TabIndex = 17;
            this.label4.Text = "Puerto de fin:";
            // 
            // txtbxPuertoInicio
            // 
            this.txtbxPuertoInicio.Location = new System.Drawing.Point(102, 20);
            this.txtbxPuertoInicio.Name = "txtbxPuertoInicio";
            this.txtbxPuertoInicio.Size = new System.Drawing.Size(100, 20);
            this.txtbxPuertoInicio.TabIndex = 15;
            // 
            // dgvRecorridos
            // 
            this.dgvRecorridos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvRecorridos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRecorridos.Location = new System.Drawing.Point(16, 61);
            this.dgvRecorridos.Name = "dgvRecorridos";
            this.dgvRecorridos.Size = new System.Drawing.Size(494, 154);
            this.dgvRecorridos.TabIndex = 14;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.Puerto);
            this.groupBox1.Controls.Add(this.txtbxPuertoFin);
            this.groupBox1.Controls.Add(this.btnBuscarRecorridos);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtbxPuertoInicio);
            this.groupBox1.Controls.Add(this.dgvRecorridos);
            this.groupBox1.Location = new System.Drawing.Point(12, 8);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(533, 239);
            this.groupBox1.TabIndex = 19;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Selección Recorrido";
            // 
            // btnCerrar
            // 
            this.btnCerrar.Location = new System.Drawing.Point(470, 259);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(75, 23);
            this.btnCerrar.TabIndex = 19;
            this.btnCerrar.Text = "Cerrar";
            this.btnCerrar.UseVisualStyleBackColor = true;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // SeleccionRecorridoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(560, 288);
            this.Controls.Add(this.btnCerrar);
            this.Controls.Add(this.groupBox1);
            this.Name = "SeleccionRecorridoForm";
            this.Text = "Seleccion Recorrido";
            this.Load += new System.EventHandler(this.SeleccionRecorridoForm_Load_1);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRecorridos)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label Puerto;
        private System.Windows.Forms.TextBox txtbxPuertoFin;
        private System.Windows.Forms.Button btnBuscarRecorridos;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtbxPuertoInicio;
        private System.Windows.Forms.DataGridView dgvRecorridos;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnCerrar;
    }
}