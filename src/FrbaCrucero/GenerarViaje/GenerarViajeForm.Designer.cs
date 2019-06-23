namespace FrbaCrucero.GeneracionViaje
{
    partial class GenerarViajeForm
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
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnEnviar = new System.Windows.Forms.Button();
            this.dtpFechaFin = new System.Windows.Forms.DateTimePicker();
            this.dtpFechaInicio = new System.Windows.Forms.DateTimePicker();
            this.cmbxCrucero = new System.Windows.Forms.ComboBox();
            this.Puerto = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.gpbxRecorridos = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtbxTramosPorRecorrido = new System.Windows.Forms.TextBox();
            this.txtbxPuertoFin = new System.Windows.Forms.TextBox();
            this.btnBuscarRecorridos = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.txtbxPuertoInicio = new System.Windows.Forms.TextBox();
            this.dgvRecorridos = new System.Windows.Forms.DataGridView();
            this.groupBox1.SuspendLayout();
            this.gpbxRecorridos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRecorridos)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnCancelar);
            this.groupBox1.Controls.Add(this.btnEnviar);
            this.groupBox1.Controls.Add(this.dtpFechaFin);
            this.groupBox1.Controls.Add(this.dtpFechaInicio);
            this.groupBox1.Controls.Add(this.cmbxCrucero);
            this.groupBox1.Controls.Add(this.Puerto);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.gpbxRecorridos);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(796, 410);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Generar Viaje";
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(715, 381);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 11;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnEnviar
            // 
            this.btnEnviar.Location = new System.Drawing.Point(619, 381);
            this.btnEnviar.Name = "btnEnviar";
            this.btnEnviar.Size = new System.Drawing.Size(75, 23);
            this.btnEnviar.TabIndex = 8;
            this.btnEnviar.Text = "Enviar";
            this.btnEnviar.UseVisualStyleBackColor = true;
            this.btnEnviar.Click += new System.EventHandler(this.btnEnviar_Click);
            // 
            // dtpFechaFin
            // 
            this.dtpFechaFin.Location = new System.Drawing.Point(105, 66);
            this.dtpFechaFin.Name = "dtpFechaFin";
            this.dtpFechaFin.Size = new System.Drawing.Size(200, 20);
            this.dtpFechaFin.TabIndex = 7;
            // 
            // dtpFechaInicio
            // 
            this.dtpFechaInicio.Location = new System.Drawing.Point(105, 32);
            this.dtpFechaInicio.Name = "dtpFechaInicio";
            this.dtpFechaInicio.Size = new System.Drawing.Size(200, 20);
            this.dtpFechaInicio.TabIndex = 6;
            this.dtpFechaInicio.ValueChanged += new System.EventHandler(this.dtpFechaInicio_ValueChanged);
            // 
            // cmbxCrucero
            // 
            this.cmbxCrucero.DisplayMember = "identificador";
            this.cmbxCrucero.FormattingEnabled = true;
            this.cmbxCrucero.Location = new System.Drawing.Point(105, 102);
            this.cmbxCrucero.Name = "cmbxCrucero";
            this.cmbxCrucero.Size = new System.Drawing.Size(121, 21);
            this.cmbxCrucero.TabIndex = 4;
            // 
            // Puerto
            // 
            this.Puerto.AutoSize = true;
            this.Puerto.Location = new System.Drawing.Point(17, 159);
            this.Puerto.Name = "Puerto";
            this.Puerto.Size = new System.Drawing.Size(83, 13);
            this.Puerto.TabIndex = 3;
            this.Puerto.Text = "Puerto de inicio:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(17, 66);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Fecha de fin:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Fecha de inicio:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 105);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Crucero:";
            // 
            // gpbxRecorridos
            // 
            this.gpbxRecorridos.Controls.Add(this.label5);
            this.gpbxRecorridos.Controls.Add(this.txtbxTramosPorRecorrido);
            this.gpbxRecorridos.Controls.Add(this.txtbxPuertoFin);
            this.gpbxRecorridos.Controls.Add(this.btnBuscarRecorridos);
            this.gpbxRecorridos.Controls.Add(this.label4);
            this.gpbxRecorridos.Controls.Add(this.txtbxPuertoInicio);
            this.gpbxRecorridos.Controls.Add(this.dgvRecorridos);
            this.gpbxRecorridos.Location = new System.Drawing.Point(6, 131);
            this.gpbxRecorridos.Name = "gpbxRecorridos";
            this.gpbxRecorridos.Size = new System.Drawing.Size(784, 244);
            this.gpbxRecorridos.TabIndex = 10;
            this.gpbxRecorridos.TabStop = false;
            this.gpbxRecorridos.Text = "Recorrido";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(559, 24);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(166, 26);
            this.label5.TabIndex = 13;
            this.label5.Text = "Puertos que visita el recorrido \r\nseleccionado (en orden de visita):";
            // 
            // txtbxTramosPorRecorrido
            // 
            this.txtbxTramosPorRecorrido.Location = new System.Drawing.Point(562, 65);
            this.txtbxTramosPorRecorrido.Multiline = true;
            this.txtbxTramosPorRecorrido.Name = "txtbxTramosPorRecorrido";
            this.txtbxTramosPorRecorrido.ReadOnly = true;
            this.txtbxTramosPorRecorrido.Size = new System.Drawing.Size(202, 154);
            this.txtbxTramosPorRecorrido.TabIndex = 12;
            // 
            // txtbxPuertoFin
            // 
            this.txtbxPuertoFin.Location = new System.Drawing.Point(300, 24);
            this.txtbxPuertoFin.Name = "txtbxPuertoFin";
            this.txtbxPuertoFin.Size = new System.Drawing.Size(100, 20);
            this.txtbxPuertoFin.TabIndex = 12;
            // 
            // btnBuscarRecorridos
            // 
            this.btnBuscarRecorridos.Location = new System.Drawing.Point(433, 22);
            this.btnBuscarRecorridos.Name = "btnBuscarRecorridos";
            this.btnBuscarRecorridos.Size = new System.Drawing.Size(75, 23);
            this.btnBuscarRecorridos.TabIndex = 11;
            this.btnBuscarRecorridos.Text = "Buscar";
            this.btnBuscarRecorridos.UseVisualStyleBackColor = true;
            this.btnBuscarRecorridos.Click += new System.EventHandler(this.btnBuscarRecorridos_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(224, 28);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Puerto de fin:";
            // 
            // txtbxPuertoInicio
            // 
            this.txtbxPuertoInicio.Location = new System.Drawing.Point(100, 24);
            this.txtbxPuertoInicio.Name = "txtbxPuertoInicio";
            this.txtbxPuertoInicio.Size = new System.Drawing.Size(100, 20);
            this.txtbxPuertoInicio.TabIndex = 10;
            // 
            // dgvRecorridos
            // 
            this.dgvRecorridos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvRecorridos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRecorridos.Location = new System.Drawing.Point(14, 65);
            this.dgvRecorridos.Name = "dgvRecorridos";
            this.dgvRecorridos.Size = new System.Drawing.Size(494, 154);
            this.dgvRecorridos.TabIndex = 9;
            // 
            // GenerarViajeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(820, 434);
            this.Controls.Add(this.groupBox1);
            this.Name = "GenerarViajeForm";
            this.Text = "Generar Viaje";
            this.Load += new System.EventHandler(this.GenerarViajeForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.gpbxRecorridos.ResumeLayout(false);
            this.gpbxRecorridos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRecorridos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cmbxCrucero;
        private System.Windows.Forms.Label Puerto;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpFechaFin;
        private System.Windows.Forms.DateTimePicker dtpFechaInicio;
        private System.Windows.Forms.Button btnEnviar;
        private System.Windows.Forms.GroupBox gpbxRecorridos;
        private System.Windows.Forms.TextBox txtbxPuertoInicio;
        private System.Windows.Forms.DataGridView dgvRecorridos;
        private System.Windows.Forms.Button btnBuscarRecorridos;
        private System.Windows.Forms.TextBox txtbxPuertoFin;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.TextBox txtbxTramosPorRecorrido;
        private System.Windows.Forms.Label label5;
    }
}