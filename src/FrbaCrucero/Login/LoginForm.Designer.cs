namespace FrbaCrucero.Login
{
    partial class LoginForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginForm));
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnIngresarClientes = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.btnIngresarAdmins = new System.Windows.Forms.Button();
            this.txtbxPass = new System.Windows.Forms.TextBox();
            this.txtbxUsuario = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.Transparent;
            this.groupBox2.Controls.Add(this.btnIngresarClientes);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.ForeColor = System.Drawing.Color.Cornsilk;
            this.groupBox2.Location = new System.Drawing.Point(40, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(305, 56);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Zona Clientes";
            // 
            // btnIngresarClientes
            // 
            this.btnIngresarClientes.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIngresarClientes.ForeColor = System.Drawing.Color.Black;
            this.btnIngresarClientes.Location = new System.Drawing.Point(89, 19);
            this.btnIngresarClientes.Name = "btnIngresarClientes";
            this.btnIngresarClientes.Size = new System.Drawing.Size(118, 23);
            this.btnIngresarClientes.TabIndex = 6;
            this.btnIngresarClientes.Text = "Ingresar";
            this.btnIngresarClientes.UseVisualStyleBackColor = true;
            this.btnIngresarClientes.Click += new System.EventHandler(this.btnIngresarClientes_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(280, 317);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 13);
            this.label5.TabIndex = 2;
            this.label5.Text = "FrbaCrucero";
            // 
            // btnIngresarAdmins
            // 
            this.btnIngresarAdmins.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIngresarAdmins.ForeColor = System.Drawing.Color.Black;
            this.btnIngresarAdmins.Location = new System.Drawing.Point(160, 145);
            this.btnIngresarAdmins.Name = "btnIngresarAdmins";
            this.btnIngresarAdmins.Size = new System.Drawing.Size(118, 23);
            this.btnIngresarAdmins.TabIndex = 5;
            this.btnIngresarAdmins.Text = "Ingresar";
            this.btnIngresarAdmins.UseVisualStyleBackColor = true;
            this.btnIngresarAdmins.Click += new System.EventHandler(this.btnIngresarAdmins_Click);
            // 
            // txtbxPass
            // 
            this.txtbxPass.Location = new System.Drawing.Point(25, 107);
            this.txtbxPass.Name = "txtbxPass";
            this.txtbxPass.Size = new System.Drawing.Size(253, 22);
            this.txtbxPass.TabIndex = 4;
            this.txtbxPass.UseSystemPasswordChar = true;
            // 
            // txtbxUsuario
            // 
            this.txtbxUsuario.Location = new System.Drawing.Point(25, 52);
            this.txtbxUsuario.Name = "txtbxUsuario";
            this.txtbxUsuario.Size = new System.Drawing.Size(253, 22);
            this.txtbxUsuario.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "Usuario*:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 80);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(97, 16);
            this.label2.TabIndex = 3;
            this.label2.Text = "Contraseña*:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(22, 178);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(166, 16);
            this.label4.TabIndex = 6;
            this.label4.Text = "* Campos obligatorios.";
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtbxUsuario);
            this.groupBox1.Controls.Add(this.txtbxPass);
            this.groupBox1.Controls.Add(this.btnIngresarAdmins);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.White;
            this.groupBox1.Location = new System.Drawing.Point(40, 94);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(305, 209);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Zona Administradores";
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(385, 339);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.MaximizeBox = false;
            this.Name = "LoginForm";
            this.Text = "Bienvenido a FRBA-Cruceros ";
            this.groupBox2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnIngresarClientes;
        private System.Windows.Forms.Button btnIngresarAdmins;
        private System.Windows.Forms.TextBox txtbxPass;
        private System.Windows.Forms.TextBox txtbxUsuario;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}