namespace FrbaCrucero.AbmCrucero
{
    partial class AbmCruceros
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
            this.btnAltaCrucero = new System.Windows.Forms.Button();
            this.btnModificacionCrucero = new System.Windows.Forms.Button();
            this.btnBajaServicioTecnico = new System.Windows.Forms.Button();
            this.btnBajaDefinitiva = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnAltaCrucero
            // 
            this.btnAltaCrucero.Location = new System.Drawing.Point(30, 37);
            this.btnAltaCrucero.Name = "btnAltaCrucero";
            this.btnAltaCrucero.Size = new System.Drawing.Size(118, 23);
            this.btnAltaCrucero.TabIndex = 0;
            this.btnAltaCrucero.Text = "Alta Nuevo Crucero";
            this.btnAltaCrucero.UseVisualStyleBackColor = true;
            this.btnAltaCrucero.Click += new System.EventHandler(this.btnAltaCrucero_Click);
            // 
            // btnModificacionCrucero
            // 
            this.btnModificacionCrucero.Location = new System.Drawing.Point(186, 37);
            this.btnModificacionCrucero.Name = "btnModificacionCrucero";
            this.btnModificacionCrucero.Size = new System.Drawing.Size(127, 23);
            this.btnModificacionCrucero.TabIndex = 1;
            this.btnModificacionCrucero.Text = "Modificación Crucero";
            this.btnModificacionCrucero.UseVisualStyleBackColor = true;
            this.btnModificacionCrucero.Click += new System.EventHandler(this.btnModificacionCrucero_Click);
            // 
            // btnBajaServicioTecnico
            // 
            this.btnBajaServicioTecnico.Location = new System.Drawing.Point(350, 37);
            this.btnBajaServicioTecnico.Name = "btnBajaServicioTecnico";
            this.btnBajaServicioTecnico.Size = new System.Drawing.Size(166, 23);
            this.btnBajaServicioTecnico.TabIndex = 2;
            this.btnBajaServicioTecnico.Text = "Baja Por Servicio Técnico";
            this.btnBajaServicioTecnico.UseVisualStyleBackColor = true;
            this.btnBajaServicioTecnico.Click += new System.EventHandler(this.btnBajaServicioTecnico_Click);
            // 
            // btnBajaDefinitiva
            // 
            this.btnBajaDefinitiva.Location = new System.Drawing.Point(544, 37);
            this.btnBajaDefinitiva.Name = "btnBajaDefinitiva";
            this.btnBajaDefinitiva.Size = new System.Drawing.Size(166, 23);
            this.btnBajaDefinitiva.TabIndex = 3;
            this.btnBajaDefinitiva.Text = "Baja Definitiva";
            this.btnBajaDefinitiva.UseVisualStyleBackColor = true;
            this.btnBajaDefinitiva.Click += new System.EventHandler(this.btnBajaDefinitiva_Click);
            // 
            // AbmCruceros
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(738, 89);
            this.Controls.Add(this.btnBajaDefinitiva);
            this.Controls.Add(this.btnBajaServicioTecnico);
            this.Controls.Add(this.btnModificacionCrucero);
            this.Controls.Add(this.btnAltaCrucero);
            this.Name = "AbmCruceros";
            this.Text = "AbmCruceros";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnAltaCrucero;
        private System.Windows.Forms.Button btnModificacionCrucero;
        private System.Windows.Forms.Button btnBajaServicioTecnico;
        private System.Windows.Forms.Button btnBajaDefinitiva;
    }
}