namespace FrbaCrucero.AbmCrucero.CancelarViajes
{
    partial class CancelarViajesForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CancelarViajesForm));
            this.label1 = new System.Windows.Forms.Label();
            this.btnCancelarPasajes = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtbxMotivoCancelacion = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(408, 39);
            this.label1.TabIndex = 0;
            this.label1.Text = resources.GetString("label1.Text");
            // 
            // btnCancelarPasajes
            // 
            this.btnCancelarPasajes.Location = new System.Drawing.Point(301, 127);
            this.btnCancelarPasajes.Name = "btnCancelarPasajes";
            this.btnCancelarPasajes.Size = new System.Drawing.Size(109, 23);
            this.btnCancelarPasajes.TabIndex = 1;
            this.btnCancelarPasajes.Text = "Cancelar Pasajes";
            this.btnCancelarPasajes.UseVisualStyleBackColor = true;
            this.btnCancelarPasajes.Click += new System.EventHandler(this.btnCancelarPasajes_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtbxMotivoCancelacion);
            this.groupBox1.Controls.Add(this.btnCancelarPasajes);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 8);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(429, 158);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Cancelar pasajes";
            // 
            // txtbxMotivoCancelacion
            // 
            this.txtbxMotivoCancelacion.Location = new System.Drawing.Point(15, 75);
            this.txtbxMotivoCancelacion.Multiline = true;
            this.txtbxMotivoCancelacion.Name = "txtbxMotivoCancelacion";
            this.txtbxMotivoCancelacion.Size = new System.Drawing.Size(395, 44);
            this.txtbxMotivoCancelacion.TabIndex = 2;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(329, 217);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(112, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "Cancelar Baja";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // CancelarViajesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(453, 252);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox1);
            this.Name = "CancelarViajesForm";
            this.Text = "Cancelar Viajes";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnCancelarPasajes;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtbxMotivoCancelacion;
        private System.Windows.Forms.Button button1;
    }
}