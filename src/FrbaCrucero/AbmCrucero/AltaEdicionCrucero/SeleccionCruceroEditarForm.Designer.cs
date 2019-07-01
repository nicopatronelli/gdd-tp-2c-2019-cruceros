namespace FrbaCrucero.AbmCrucero
{
    partial class SeleccionCruceroEditarForm
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
            this.lblSeleccionCrucero = new System.Windows.Forms.Label();
            this.dgvEditarCrucero = new System.Windows.Forms.DataGridView();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEditarCrucero)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnCerrar);
            this.groupBox1.Controls.Add(this.lblSeleccionCrucero);
            this.groupBox1.Controls.Add(this.dgvEditarCrucero);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(776, 358);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Cruceros";
            // 
            // btnCerrar
            // 
            this.btnCerrar.Location = new System.Drawing.Point(683, 330);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(79, 23);
            this.btnCerrar.TabIndex = 4;
            this.btnCerrar.Text = "Cerrar";
            this.btnCerrar.UseVisualStyleBackColor = true;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // lblSeleccionCrucero
            // 
            this.lblSeleccionCrucero.AutoSize = true;
            this.lblSeleccionCrucero.Location = new System.Drawing.Point(9, 27);
            this.lblSeleccionCrucero.Name = "lblSeleccionCrucero";
            this.lblSeleccionCrucero.Size = new System.Drawing.Size(440, 13);
            this.lblSeleccionCrucero.TabIndex = 3;
            this.lblSeleccionCrucero.Text = "Seleccione el crucero a editar presionando el botón Editar al final de su fila co" +
    "rrespondiente.";
            // 
            // dgvEditarCrucero
            // 
            this.dgvEditarCrucero.AllowUserToAddRows = false;
            this.dgvEditarCrucero.AllowUserToDeleteRows = false;
            this.dgvEditarCrucero.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEditarCrucero.Location = new System.Drawing.Point(12, 52);
            this.dgvEditarCrucero.Name = "dgvEditarCrucero";
            this.dgvEditarCrucero.ReadOnly = true;
            this.dgvEditarCrucero.Size = new System.Drawing.Size(751, 271);
            this.dgvEditarCrucero.TabIndex = 0;
            // 
            // SeleccionCruceroEditarForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(803, 385);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "SeleccionCruceroEditarForm";
            this.Text = "Selección de crucero";
            this.Load += new System.EventHandler(this.SeleccionCruceroEditarForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEditarCrucero)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnCerrar;
        protected System.Windows.Forms.DataGridView dgvEditarCrucero;
        protected System.Windows.Forms.Label lblSeleccionCrucero;
    }
}