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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AltaTramoForm));
            this.cmbxPuertoInicio = new System.Windows.Forms.ComboBox();
            this.cmbxPuertoFin = new System.Windows.Forms.ComboBox();
            this.txtbxPrecioA = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtbxPrecioB = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnEnviar = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmbxPuertoInicio
            // 
            this.cmbxPuertoInicio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbxPuertoInicio.FormattingEnabled = true;
            this.cmbxPuertoInicio.Location = new System.Drawing.Point(12, 119);
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
            this.cmbxPuertoFin.Location = new System.Drawing.Point(165, 119);
            this.cmbxPuertoFin.Name = "cmbxPuertoFin";
            this.cmbxPuertoFin.Size = new System.Drawing.Size(121, 21);
            this.cmbxPuertoFin.TabIndex = 1;
            // 
            // txtbxPrecioA
            // 
            this.txtbxPrecioA.Location = new System.Drawing.Point(323, 120);
            this.txtbxPrecioA.MaxLength = 10;
            this.txtbxPrecioA.Name = "txtbxPrecioA";
            this.txtbxPrecioA.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtbxPrecioA.Size = new System.Drawing.Size(61, 20);
            this.txtbxPrecioA.TabIndex = 2;
            this.txtbxPrecioA.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtbxPrecio_KeyPress);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtbxPrecioB);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtbxPrecioA);
            this.groupBox1.Controls.Add(this.cmbxPuertoInicio);
            this.groupBox1.Controls.Add(this.cmbxPuertoFin);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Location = new System.Drawing.Point(19, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(449, 162);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Complete los datos del nuevo tramo:";
            // 
            // txtbxPrecioB
            // 
            this.txtbxPrecioB.Location = new System.Drawing.Point(395, 120);
            this.txtbxPrecioB.MaxLength = 2;
            this.txtbxPrecioB.Name = "txtbxPrecioB";
            this.txtbxPrecioB.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtbxPrecioB.Size = new System.Drawing.Size(30, 20);
            this.txtbxPrecioB.TabIndex = 6;
            this.txtbxPrecioB.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtbxPrecio_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(162, 100);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Puerto Destino:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 100);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Puerto Origen:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(381, 117);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(18, 25);
            this.label4.TabIndex = 7;
            this.label4.Text = ".";
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(393, 180);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 4;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnEnviar
            // 
            this.btnEnviar.Location = new System.Drawing.Point(298, 180);
            this.btnEnviar.Name = "btnEnviar";
            this.btnEnviar.Size = new System.Drawing.Size(75, 23);
            this.btnEnviar.TabIndex = 5;
            this.btnEnviar.Text = "Enviar";
            this.btnEnviar.UseVisualStyleBackColor = true;
            this.btnEnviar.Click += new System.EventHandler(this.btnEnviar_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Location = new System.Drawing.Point(306, 100);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(137, 49);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Precio Tramo:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 190);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(176, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "* Todos los campos son obligatorios";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(10, 26);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(433, 52);
            this.label5.TabIndex = 7;
            this.label5.Text = resources.GetString("label5.Text");
            // 
            // AltaTramoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(480, 218);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnEnviar);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.groupBox1);
            this.Name = "AltaTramoForm";
            this.Text = "Alta Nuevo Tramo";
            this.Load += new System.EventHandler(this.AltaTramoForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbxPuertoInicio;
        private System.Windows.Forms.ComboBox cmbxPuertoFin;
        private System.Windows.Forms.TextBox txtbxPrecioA;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnEnviar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtbxPrecioB;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label3;
    }
}