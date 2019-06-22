namespace FrbaCrucero.AbmRecorrido.EditarRecorrido
{
    partial class SeleccionRecorridoEditarForm
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
            this.btnCerrar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvSeleccionRecorrido = new System.Windows.Forms.DataGridView();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSeleccionRecorrido)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnCerrar);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.dgvSeleccionRecorrido);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(827, 378);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Recorridos";
            // 
            // btnCerrar
            // 
            this.btnCerrar.Location = new System.Drawing.Point(742, 349);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(79, 23);
            this.btnCerrar.TabIndex = 5;
            this.btnCerrar.Text = "Cerrar";
            this.btnCerrar.UseVisualStyleBackColor = true;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(445, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Seleccione el recorrido a editar presionando el botón Editar al final de su fila " +
    "correspondiente.";
            // 
            // dgvSeleccionRecorrido
            // 
            this.dgvSeleccionRecorrido.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSeleccionRecorrido.Location = new System.Drawing.Point(6, 55);
            this.dgvSeleccionRecorrido.Name = "dgvSeleccionRecorrido";
            this.dgvSeleccionRecorrido.Size = new System.Drawing.Size(293, 287);
            this.dgvSeleccionRecorrido.TabIndex = 0;
            // 
            // SeleccionRecorridoEditarForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(851, 410);
            this.Controls.Add(this.groupBox1);
            this.Name = "SeleccionRecorridoEditarForm";
            this.Text = "SeleccionRecorridoForm";
            this.Load += new System.EventHandler(this.SeleccionRecorridoForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSeleccionRecorrido)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnCerrar;
        protected System.Windows.Forms.DataGridView dgvSeleccionRecorrido;
    }
}