namespace FrbaCrucero.AbmRecorrido.AbmTramos
{
    partial class ModificarPrecioTramoForm
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
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtbxNuevoPrecioB = new System.Windows.Forms.TextBox();
            this.txtbxNuevoPrecioA = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnEnviar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.lblPrecioActual = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblId = new System.Windows.Forms.Label();
            this.lblPuertoOrigen = new System.Windows.Forms.Label();
            this.lblPuertoDestino = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Location = new System.Drawing.Point(6, 55);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(435, 80);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Ingrese el nuevo precio:";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.lblPrecioActual);
            this.groupBox3.Location = new System.Drawing.Point(22, 19);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(121, 49);
            this.groupBox3.TabIndex = 13;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Precio actual:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtbxNuevoPrecioB);
            this.groupBox2.Controls.Add(this.txtbxNuevoPrecioA);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Location = new System.Drawing.Point(163, 19);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(248, 49);
            this.groupBox2.TabIndex = 11;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Nuevo precio:";
            // 
            // txtbxNuevoPrecioB
            // 
            this.txtbxNuevoPrecioB.Location = new System.Drawing.Point(87, 23);
            this.txtbxNuevoPrecioB.MaxLength = 2;
            this.txtbxNuevoPrecioB.Name = "txtbxNuevoPrecioB";
            this.txtbxNuevoPrecioB.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtbxNuevoPrecioB.Size = new System.Drawing.Size(30, 20);
            this.txtbxNuevoPrecioB.TabIndex = 12;
            // 
            // txtbxNuevoPrecioA
            // 
            this.txtbxNuevoPrecioA.Location = new System.Drawing.Point(15, 23);
            this.txtbxNuevoPrecioA.MaxLength = 10;
            this.txtbxNuevoPrecioA.Name = "txtbxNuevoPrecioA";
            this.txtbxNuevoPrecioA.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtbxNuevoPrecioA.Size = new System.Drawing.Size(61, 20);
            this.txtbxNuevoPrecioA.TabIndex = 11;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(74, 21);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(18, 25);
            this.label4.TabIndex = 13;
            this.label4.Text = ".";
            // 
            // btnEnviar
            // 
            this.btnEnviar.Location = new System.Drawing.Point(297, 164);
            this.btnEnviar.Name = "btnEnviar";
            this.btnEnviar.Size = new System.Drawing.Size(75, 23);
            this.btnEnviar.TabIndex = 7;
            this.btnEnviar.Text = "Enviar";
            this.btnEnviar.UseVisualStyleBackColor = true;
            this.btnEnviar.Click += new System.EventHandler(this.btnEnviar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(378, 164);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 6;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // lblPrecioActual
            // 
            this.lblPrecioActual.AutoSize = true;
            this.lblPrecioActual.Location = new System.Drawing.Point(21, 23);
            this.lblPrecioActual.Name = "lblPrecioActual";
            this.lblPrecioActual.Size = new System.Drawing.Size(13, 13);
            this.lblPrecioActual.TabIndex = 0;
            this.lblPrecioActual.Text = "0";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.lblPuertoDestino);
            this.groupBox4.Controls.Add(this.lblPuertoOrigen);
            this.groupBox4.Controls.Add(this.lblId);
            this.groupBox4.Controls.Add(this.label5);
            this.groupBox4.Controls.Add(this.label3);
            this.groupBox4.Controls.Add(this.label2);
            this.groupBox4.Controls.Add(this.groupBox1);
            this.groupBox4.Location = new System.Drawing.Point(6, 10);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(447, 148);
            this.groupBox4.TabIndex = 8;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Tramo seleccionado:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(18, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "id:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(76, 26);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Puerto origen:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(273, 26);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(55, 13);
            this.label5.TabIndex = 3;
            this.label5.Text = "Puerto fin:";
            // 
            // lblId
            // 
            this.lblId.AutoSize = true;
            this.lblId.Location = new System.Drawing.Point(32, 26);
            this.lblId.Name = "lblId";
            this.lblId.Size = new System.Drawing.Size(15, 13);
            this.lblId.TabIndex = 1;
            this.lblId.Text = "id";
            // 
            // lblPuertoOrigen
            // 
            this.lblPuertoOrigen.AutoSize = true;
            this.lblPuertoOrigen.Location = new System.Drawing.Point(149, 26);
            this.lblPuertoOrigen.Name = "lblPuertoOrigen";
            this.lblPuertoOrigen.Size = new System.Drawing.Size(72, 13);
            this.lblPuertoOrigen.TabIndex = 4;
            this.lblPuertoOrigen.Text = "puerto_origen";
            // 
            // lblPuertoDestino
            // 
            this.lblPuertoDestino.AutoSize = true;
            this.lblPuertoDestino.Location = new System.Drawing.Point(328, 26);
            this.lblPuertoDestino.Name = "lblPuertoDestino";
            this.lblPuertoDestino.Size = new System.Drawing.Size(77, 13);
            this.lblPuertoDestino.TabIndex = 5;
            this.lblPuertoDestino.Text = "puerto_destino";
            // 
            // ModificarPrecioTramoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(465, 197);
            this.Controls.Add(this.btnEnviar);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.groupBox4);
            this.Name = "ModificarPrecioTramoForm";
            this.Text = "Actualizar precio de tramo";
            this.Load += new System.EventHandler(this.ModificarPrecioTramoForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnEnviar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtbxNuevoPrecioB;
        private System.Windows.Forms.TextBox txtbxNuevoPrecioA;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblPrecioActual;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label lblPuertoDestino;
        private System.Windows.Forms.Label lblPuertoOrigen;
        private System.Windows.Forms.Label lblId;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
    }
}