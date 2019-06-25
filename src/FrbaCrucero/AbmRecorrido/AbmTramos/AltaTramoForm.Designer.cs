namespace FrbaCrucero.AbmRecorrido.AbmTramos
{
    partial class AltaTramoForm
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
            this.cmbxPuertoInicio = new System.Windows.Forms.ComboBox();
            this.cmbxPuertoFin = new System.Windows.Forms.ComboBox();
            this.txtbxPrecio = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnEnviar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cmbxPuertoInicio
            // 
            this.cmbxPuertoInicio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbxPuertoInicio.FormattingEnabled = true;
            this.cmbxPuertoInicio.Location = new System.Drawing.Point(54, 48);
            this.cmbxPuertoInicio.Name = "cmbxPuertoInicio";
            this.cmbxPuertoInicio.Size = new System.Drawing.Size(121, 21);
            this.cmbxPuertoInicio.Sorted = true;
            this.cmbxPuertoInicio.TabIndex = 0;
            this.cmbxPuertoInicio.SelectedIndexChanged += new System.EventHandler(this.cmbxPuertosInicio_SelectedIndexChanged);
            // 
            // cmbxPuertoFin
            // 
            this.cmbxPuertoFin.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbxPuertoFin.FormattingEnabled = true;
            this.cmbxPuertoFin.Location = new System.Drawing.Point(215, 48);
            this.cmbxPuertoFin.Name = "cmbxPuertoFin";
            this.cmbxPuertoFin.Size = new System.Drawing.Size(121, 21);
            this.cmbxPuertoFin.TabIndex = 1;
            // 
            // txtbxPrecio
            // 
            this.txtbxPrecio.Location = new System.Drawing.Point(54, 109);
            this.txtbxPrecio.Name = "txtbxPrecio";
            this.txtbxPrecio.Size = new System.Drawing.Size(100, 20);
            this.txtbxPrecio.TabIndex = 2;
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(449, 129);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Complete los datos del nuevo tramo:";
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(386, 153);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 4;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnEnviar
            // 
            this.btnEnviar.Location = new System.Drawing.Point(305, 153);
            this.btnEnviar.Name = "btnEnviar";
            this.btnEnviar.Size = new System.Drawing.Size(75, 23);
            this.btnEnviar.TabIndex = 5;
            this.btnEnviar.Text = "Enviar";
            this.btnEnviar.UseVisualStyleBackColor = true;
            // 
            // AltaTramoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(473, 188);
            this.Controls.Add(this.btnEnviar);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.txtbxPrecio);
            this.Controls.Add(this.cmbxPuertoFin);
            this.Controls.Add(this.cmbxPuertoInicio);
            this.Controls.Add(this.groupBox1);
            this.Name = "AltaTramoForm";
            this.Text = "Alta Nuevo Tramo";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbxPuertoInicio;
        private System.Windows.Forms.ComboBox cmbxPuertoFin;
        private System.Windows.Forms.TextBox txtbxPrecio;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnEnviar;
    }
}