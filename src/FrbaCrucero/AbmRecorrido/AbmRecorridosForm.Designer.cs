namespace FrbaCrucero.AbmRecorrido
{
    partial class AbmRecorridosForm
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
            this.btnNuevoRecorrido = new System.Windows.Forms.Button();
            this.btnDeshabilitarRecorrido = new System.Windows.Forms.Button();
            this.btnEditarRecorrido = new System.Windows.Forms.Button();
            this.btnHabilitarRecorrido = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnNuevoRecorrido
            // 
            this.btnNuevoRecorrido.Location = new System.Drawing.Point(25, 22);
            this.btnNuevoRecorrido.Name = "btnNuevoRecorrido";
            this.btnNuevoRecorrido.Size = new System.Drawing.Size(181, 23);
            this.btnNuevoRecorrido.TabIndex = 0;
            this.btnNuevoRecorrido.Text = "Alta Nuevo Recorrido";
            this.btnNuevoRecorrido.UseVisualStyleBackColor = true;
            this.btnNuevoRecorrido.Click += new System.EventHandler(this.btnNuevoRecorrido_Click);
            // 
            // btnDeshabilitarRecorrido
            // 
            this.btnDeshabilitarRecorrido.Location = new System.Drawing.Point(400, 22);
            this.btnDeshabilitarRecorrido.Name = "btnDeshabilitarRecorrido";
            this.btnDeshabilitarRecorrido.Size = new System.Drawing.Size(158, 23);
            this.btnDeshabilitarRecorrido.TabIndex = 1;
            this.btnDeshabilitarRecorrido.Text = "Deshabilitar Recorrido";
            this.btnDeshabilitarRecorrido.UseVisualStyleBackColor = true;
            this.btnDeshabilitarRecorrido.Click += new System.EventHandler(this.btnDeshabilitarRecorrido_Click);
            // 
            // btnEditarRecorrido
            // 
            this.btnEditarRecorrido.Location = new System.Drawing.Point(226, 22);
            this.btnEditarRecorrido.Name = "btnEditarRecorrido";
            this.btnEditarRecorrido.Size = new System.Drawing.Size(158, 23);
            this.btnEditarRecorrido.TabIndex = 2;
            this.btnEditarRecorrido.Text = "Editar Recorrido";
            this.btnEditarRecorrido.UseVisualStyleBackColor = true;
            this.btnEditarRecorrido.Click += new System.EventHandler(this.btnEditarRecorrido_Click);
            // 
            // btnHabilitarRecorrido
            // 
            this.btnHabilitarRecorrido.Location = new System.Drawing.Point(579, 22);
            this.btnHabilitarRecorrido.Name = "btnHabilitarRecorrido";
            this.btnHabilitarRecorrido.Size = new System.Drawing.Size(158, 23);
            this.btnHabilitarRecorrido.TabIndex = 3;
            this.btnHabilitarRecorrido.Text = "Habilitar Recorrido";
            this.btnHabilitarRecorrido.UseVisualStyleBackColor = true;
            this.btnHabilitarRecorrido.Click += new System.EventHandler(this.btnHabilitarRecorrido_Click);
            // 
            // AbmRecorridosForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(789, 66);
            this.Controls.Add(this.btnHabilitarRecorrido);
            this.Controls.Add(this.btnEditarRecorrido);
            this.Controls.Add(this.btnDeshabilitarRecorrido);
            this.Controls.Add(this.btnNuevoRecorrido);
            this.Name = "AbmRecorridosForm";
            this.Text = "AbmRecorrido";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnNuevoRecorrido;
        private System.Windows.Forms.Button btnDeshabilitarRecorrido;
        private System.Windows.Forms.Button btnEditarRecorrido;
        private System.Windows.Forms.Button btnHabilitarRecorrido;
    }
}