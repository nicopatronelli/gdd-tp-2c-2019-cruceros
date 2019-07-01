namespace FrbaCrucero.AbmRol
{
    partial class AbmRolForm
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
            this.btnCrearRol = new System.Windows.Forms.Button();
            this.btnDeshabilitarRol = new System.Windows.Forms.Button();
            this.btnModificarRol = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnCrearRol);
            this.groupBox1.Controls.Add(this.btnDeshabilitarRol);
            this.groupBox1.Controls.Add(this.btnModificarRol);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(536, 67);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Elija una de las siguientes opciones:";
            // 
            // btnCrearRol
            // 
            this.btnCrearRol.Location = new System.Drawing.Point(13, 23);
            this.btnCrearRol.Name = "btnCrearRol";
            this.btnCrearRol.Size = new System.Drawing.Size(152, 23);
            this.btnCrearRol.TabIndex = 0;
            this.btnCrearRol.Text = "Crear Rol";
            this.btnCrearRol.UseVisualStyleBackColor = true;
            this.btnCrearRol.Click += new System.EventHandler(this.btnCrearRol_Click);
            // 
            // btnDeshabilitarRol
            // 
            this.btnDeshabilitarRol.Location = new System.Drawing.Point(359, 23);
            this.btnDeshabilitarRol.Name = "btnDeshabilitarRol";
            this.btnDeshabilitarRol.Size = new System.Drawing.Size(152, 23);
            this.btnDeshabilitarRol.TabIndex = 2;
            this.btnDeshabilitarRol.Text = "Habilitar/Deshabilitar Rol";
            this.btnDeshabilitarRol.UseVisualStyleBackColor = true;
            this.btnDeshabilitarRol.Click += new System.EventHandler(this.btnDeshabilitarRol_Click);
            // 
            // btnModificarRol
            // 
            this.btnModificarRol.Location = new System.Drawing.Point(186, 23);
            this.btnModificarRol.Name = "btnModificarRol";
            this.btnModificarRol.Size = new System.Drawing.Size(152, 23);
            this.btnModificarRol.TabIndex = 1;
            this.btnModificarRol.Text = "Modificar Rol";
            this.btnModificarRol.UseVisualStyleBackColor = true;
            this.btnModificarRol.Click += new System.EventHandler(this.btnModificarRol_Click);
            // 
            // AbmRolForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(566, 96);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MinimizeBox = false;
            this.Name = "AbmRolForm";
            this.Text = "ABM Rol";
            this.Load += new System.EventHandler(this.AbmRolForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnCrearRol;
        private System.Windows.Forms.Button btnDeshabilitarRol;
        private System.Windows.Forms.Button btnModificarRol;
    }
}