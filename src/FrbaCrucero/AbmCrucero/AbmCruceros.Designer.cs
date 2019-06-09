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
            this.button3 = new System.Windows.Forms.Button();
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
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(353, 37);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 2;
            this.button3.Text = "button3";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // AbmCruceros
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(524, 98);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.btnModificacionCrucero);
            this.Controls.Add(this.btnAltaCrucero);
            this.Name = "AbmCruceros";
            this.Text = "AbmCruceros";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnAltaCrucero;
        private System.Windows.Forms.Button btnModificacionCrucero;
        private System.Windows.Forms.Button button3;
    }
}