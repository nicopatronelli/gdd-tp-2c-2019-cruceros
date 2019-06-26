namespace FrbaCrucero.CompraReservaPasaje
{
    partial class ComprarTemplateForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected  void Dispose(bool disposing)
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
            this.mailTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dniTextBox = new System.Windows.Forms.TextBox();
            this.dayTextBox = new System.Windows.Forms.TextBox();
            this.telefonoTextBox = new System.Windows.Forms.TextBox();
            this.direccionTextBox = new System.Windows.Forms.TextBox();
            this.nombreTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.mesTextBox = new System.Windows.Forms.TextBox();
            this.anioTextBox = new System.Windows.Forms.TextBox();
            this.informacionCompraLabel = new System.Windows.Forms.Label();
            this.puertosLabel = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.apellidoTextBox = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.clientesListBox = new System.Windows.Forms.ListBox();
            this.estoyButton = new System.Windows.Forms.Button();
            this.noEstoyButton = new System.Windows.Forms.Button();
            this.listoButton = new System.Windows.Forms.Button();
            this.comprarRadio = new System.Windows.Forms.RadioButton();
            this.reservarRadio = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // mailTextBox
            // 
            this.mailTextBox.Location = new System.Drawing.Point(47, 279);
            this.mailTextBox.Name = "mailTextBox";
            this.mailTextBox.Size = new System.Drawing.Size(163, 20);
            this.mailTextBox.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(153, 100);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(26, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "DNI";
            // 
            // dniTextBox
            // 
            this.dniTextBox.Location = new System.Drawing.Point(47, 97);
            this.dniTextBox.MaxLength = 10;
            this.dniTextBox.Name = "dniTextBox";
            this.dniTextBox.Size = new System.Drawing.Size(100, 20);
            this.dniTextBox.TabIndex = 2;
            this.dniTextBox.TextChanged += new System.EventHandler(this.dniTextBox_TextChanged);
            this.dniTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dayTextBox_KeyPress_1);
            // 
            // dayTextBox
            // 
            this.dayTextBox.Location = new System.Drawing.Point(47, 314);
            this.dayTextBox.MaxLength = 2;
            this.dayTextBox.Name = "dayTextBox";
            this.dayTextBox.Size = new System.Drawing.Size(22, 20);
            this.dayTextBox.TabIndex = 3;
            this.dayTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dayTextBox_KeyPress_1);
            // 
            // telefonoTextBox
            // 
            this.telefonoTextBox.Location = new System.Drawing.Point(47, 244);
            this.telefonoTextBox.Name = "telefonoTextBox";
            this.telefonoTextBox.Size = new System.Drawing.Size(100, 20);
            this.telefonoTextBox.TabIndex = 4;
            this.telefonoTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dayTextBox_KeyPress_1);
            // 
            // direccionTextBox
            // 
            this.direccionTextBox.Location = new System.Drawing.Point(47, 204);
            this.direccionTextBox.Name = "direccionTextBox";
            this.direccionTextBox.Size = new System.Drawing.Size(167, 20);
            this.direccionTextBox.TabIndex = 5;
            // 
            // nombreTextBox
            // 
            this.nombreTextBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Lower;
            this.nombreTextBox.Location = new System.Drawing.Point(47, 136);
            this.nombreTextBox.Name = "nombreTextBox";
            this.nombreTextBox.Size = new System.Drawing.Size(100, 20);
            this.nombreTextBox.TabIndex = 6;
            this.nombreTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.nombreTextBox_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(220, 207);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Dirección";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(153, 136);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Nombre";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(153, 244);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Teléfono";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(216, 286);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(77, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Mail (Opcional)";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(185, 317);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(108, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "Fecha de Nacimiento";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.label7.Location = new System.Drawing.Point(71, 310);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(15, 24);
            this.label7.TabIndex = 12;
            this.label7.Text = "/";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.label8.Location = new System.Drawing.Point(114, 310);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(15, 24);
            this.label8.TabIndex = 13;
            this.label8.Text = "/";
            // 
            // mesTextBox
            // 
            this.mesTextBox.Location = new System.Drawing.Point(86, 313);
            this.mesTextBox.MaxLength = 2;
            this.mesTextBox.Name = "mesTextBox";
            this.mesTextBox.Size = new System.Drawing.Size(22, 20);
            this.mesTextBox.TabIndex = 14;
            this.mesTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dayTextBox_KeyPress_1);
            // 
            // anioTextBox
            // 
            this.anioTextBox.Location = new System.Drawing.Point(128, 313);
            this.anioTextBox.MaxLength = 4;
            this.anioTextBox.Name = "anioTextBox";
            this.anioTextBox.Size = new System.Drawing.Size(39, 20);
            this.anioTextBox.TabIndex = 15;
            this.anioTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dayTextBox_KeyPress_1);
            // 
            // informacionCompraLabel
            // 
            this.informacionCompraLabel.AutoSize = true;
            this.informacionCompraLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.informacionCompraLabel.Location = new System.Drawing.Point(376, 49);
            this.informacionCompraLabel.Name = "informacionCompraLabel";
            this.informacionCompraLabel.Size = new System.Drawing.Size(130, 17);
            this.informacionCompraLabel.TabIndex = 16;
            this.informacionCompraLabel.Text = "informacionCompra";
            // 
            // puertosLabel
            // 
            this.puertosLabel.AutoSize = true;
            this.puertosLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.puertosLabel.Location = new System.Drawing.Point(376, 171);
            this.puertosLabel.Name = "puertosLabel";
            this.puertosLabel.Size = new System.Drawing.Size(56, 17);
            this.puertosLabel.TabIndex = 17;
            this.puertosLabel.Text = "puertos";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label9.Location = new System.Drawing.Point(53, 58);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(136, 20);
            this.label9.TabIndex = 18;
            this.label9.Text = "Ingrese sus datos";
            // 
            // apellidoTextBox
            // 
            this.apellidoTextBox.Location = new System.Drawing.Point(47, 170);
            this.apellidoTextBox.Name = "apellidoTextBox";
            this.apellidoTextBox.Size = new System.Drawing.Size(100, 20);
            this.apellidoTextBox.TabIndex = 19;
            this.apellidoTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.nombreTextBox_KeyPress);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(153, 173);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(44, 13);
            this.label10.TabIndex = 20;
            this.label10.Text = "Apellido";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(210, 99);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(106, 13);
            this.label11.TabIndex = 21;
            this.label11.Text = "9329200 para probar";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(213, 116);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(110, 13);
            this.label12.TabIndex = 22;
            this.label12.Text = "46721206 es repetido";
            // 
            // clientesListBox
            // 
            this.clientesListBox.FormattingEnabled = true;
            this.clientesListBox.HorizontalScrollbar = true;
            this.clientesListBox.Location = new System.Drawing.Point(213, 81);
            this.clientesListBox.Name = "clientesListBox";
            this.clientesListBox.Size = new System.Drawing.Size(120, 95);
            this.clientesListBox.TabIndex = 23;
            this.clientesListBox.Visible = false;
            this.clientesListBox.SelectedValueChanged += new System.EventHandler(this.clientesListBox_SelectedValueChanged);
            // 
            // estoyButton
            // 
            this.estoyButton.Enabled = false;
            this.estoyButton.Location = new System.Drawing.Point(213, 175);
            this.estoyButton.Name = "estoyButton";
            this.estoyButton.Size = new System.Drawing.Size(120, 23);
            this.estoyButton.TabIndex = 24;
            this.estoyButton.Text = "Soy esta persona!";
            this.estoyButton.UseVisualStyleBackColor = true;
            this.estoyButton.Visible = false;
            this.estoyButton.Click += new System.EventHandler(this.estoyButton_Click);
            // 
            // noEstoyButton
            // 
            this.noEstoyButton.Location = new System.Drawing.Point(269, 202);
            this.noEstoyButton.Name = "noEstoyButton";
            this.noEstoyButton.Size = new System.Drawing.Size(64, 35);
            this.noEstoyButton.TabIndex = 25;
            this.noEstoyButton.Text = "No soy este";
            this.noEstoyButton.UseVisualStyleBackColor = true;
            this.noEstoyButton.Visible = false;
            this.noEstoyButton.Click += new System.EventHandler(this.noEstoyButton_Click);
            // 
            // listoButton
            // 
            this.listoButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.listoButton.Location = new System.Drawing.Point(47, 351);
            this.listoButton.Name = "listoButton";
            this.listoButton.Size = new System.Drawing.Size(218, 87);
            this.listoButton.TabIndex = 26;
            this.listoButton.Text = "Registrarme y Aceptar";
            this.listoButton.UseVisualStyleBackColor = true;
            this.listoButton.Click += new System.EventHandler(this.listoButton_Click);
            // 
            // comprarRadio
            // 
            this.comprarRadio.AutoSize = true;
            this.comprarRadio.Checked = true;
            this.comprarRadio.Location = new System.Drawing.Point(292, 351);
            this.comprarRadio.Name = "comprarRadio";
            this.comprarRadio.Size = new System.Drawing.Size(64, 17);
            this.comprarRadio.TabIndex = 27;
            this.comprarRadio.TabStop = true;
            this.comprarRadio.Text = "Comprar";
            this.comprarRadio.UseVisualStyleBackColor = true;
            // 
            // reservarRadio
            // 
            this.reservarRadio.AutoSize = true;
            this.reservarRadio.Location = new System.Drawing.Point(292, 373);
            this.reservarRadio.Name = "reservarRadio";
            this.reservarRadio.Size = new System.Drawing.Size(68, 17);
            this.reservarRadio.TabIndex = 28;
            this.reservarRadio.Text = "Reservar";
            this.reservarRadio.UseVisualStyleBackColor = true;
            // 
            // ComprarTemplateForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.reservarRadio);
            this.Controls.Add(this.comprarRadio);
            this.Controls.Add(this.listoButton);
            this.Controls.Add(this.noEstoyButton);
            this.Controls.Add(this.estoyButton);
            this.Controls.Add(this.clientesListBox);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.apellidoTextBox);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.puertosLabel);
            this.Controls.Add(this.informacionCompraLabel);
            this.Controls.Add(this.anioTextBox);
            this.Controls.Add(this.mesTextBox);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.nombreTextBox);
            this.Controls.Add(this.direccionTextBox);
            this.Controls.Add(this.telefonoTextBox);
            this.Controls.Add(this.dayTextBox);
            this.Controls.Add(this.dniTextBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.mailTextBox);
            this.Name = "ComprarTemplateForm";
            this.Text = "ComprarForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox mailTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox dniTextBox;
        private System.Windows.Forms.TextBox dayTextBox;
        private System.Windows.Forms.TextBox telefonoTextBox;
        private System.Windows.Forms.TextBox direccionTextBox;
        private System.Windows.Forms.TextBox nombreTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox mesTextBox;
        private System.Windows.Forms.TextBox anioTextBox;
        private System.Windows.Forms.Label informacionCompraLabel;
        private System.Windows.Forms.Label puertosLabel;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox apellidoTextBox;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ListBox clientesListBox;
        private System.Windows.Forms.Button estoyButton;
        private System.Windows.Forms.Button noEstoyButton;
        private System.Windows.Forms.Button listoButton;
        private System.Windows.Forms.RadioButton comprarRadio;
        private System.Windows.Forms.RadioButton reservarRadio;
    }
}