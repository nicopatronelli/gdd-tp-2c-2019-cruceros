namespace FrbaCrucero.CompraReservaPasaje
{
    partial class ElegirViajeForm
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
            this.labelRecorridos = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.recorridosList = new System.Windows.Forms.ListBox();
            this.puertosList = new System.Windows.Forms.ListBox();
            this.crucerosList = new System.Windows.Forms.ListBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cabinasDisponiblesLabel = new System.Windows.Forms.Label();
            this.cabinasNumeric = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.buttonComprar = new System.Windows.Forms.Button();
            this.buttonReservar = new System.Windows.Forms.Button();
            this.selectorCabinas = new System.Windows.Forms.ComboBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cabinasNumeric)).BeginInit();
            this.SuspendLayout();
            // 
            // labelRecorridos
            // 
            this.labelRecorridos.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelRecorridos.AutoSize = true;
            this.labelRecorridos.Location = new System.Drawing.Point(28, 42);
            this.labelRecorridos.Name = "labelRecorridos";
            this.labelRecorridos.Size = new System.Drawing.Size(58, 13);
            this.labelRecorridos.TabIndex = 9;
            this.labelRecorridos.Text = "Recorridos";
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(42, 202);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(109, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Puertos del Recorrido";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(144, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "Viaje (id)";
            // 
            // recorridosList
            // 
            this.recorridosList.FormattingEnabled = true;
            this.recorridosList.Location = new System.Drawing.Point(21, 58);
            this.recorridosList.Name = "recorridosList";
            this.recorridosList.Size = new System.Drawing.Size(77, 108);
            this.recorridosList.TabIndex = 12;
            this.recorridosList.SelectedValueChanged += new System.EventHandler(this.recorridosList_SelectedValueChanged);
            // 
            // puertosList
            // 
            this.puertosList.FormattingEnabled = true;
            this.puertosList.Location = new System.Drawing.Point(21, 218);
            this.puertosList.Name = "puertosList";
            this.puertosList.Size = new System.Drawing.Size(186, 108);
            this.puertosList.TabIndex = 13;
            // 
            // crucerosList
            // 
            this.crucerosList.FormattingEnabled = true;
            this.crucerosList.Location = new System.Drawing.Point(130, 58);
            this.crucerosList.Name = "crucerosList";
            this.crucerosList.Size = new System.Drawing.Size(77, 108);
            this.crucerosList.TabIndex = 14;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.recorridosList);
            this.groupBox1.Controls.Add(this.crucerosList);
            this.groupBox1.Controls.Add(this.labelRecorridos);
            this.groupBox1.Controls.Add(this.puertosList);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(38, 21);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(225, 378);
            this.groupBox1.TabIndex = 15;
            this.groupBox1.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.selectorCabinas);
            this.groupBox2.Controls.Add(this.cabinasDisponiblesLabel);
            this.groupBox2.Controls.Add(this.cabinasNumeric);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Location = new System.Drawing.Point(320, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(403, 193);
            this.groupBox2.TabIndex = 16;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Cabinas Disponibles";
            // 
            // cabinasDisponiblesLabel
            // 
            this.cabinasDisponiblesLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cabinasDisponiblesLabel.AutoSize = true;
            this.cabinasDisponiblesLabel.Location = new System.Drawing.Point(48, 87);
            this.cabinasDisponiblesLabel.Name = "cabinasDisponiblesLabel";
            this.cabinasDisponiblesLabel.Size = new System.Drawing.Size(13, 13);
            this.cabinasDisponiblesLabel.TabIndex = 19;
            this.cabinasDisponiblesLabel.Text = "--";
            // 
            // cabinasNumeric
            // 
            this.cabinasNumeric.Location = new System.Drawing.Point(152, 85);
            this.cabinasNumeric.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.cabinasNumeric.Name = "cabinasNumeric";
            this.cabinasNumeric.ReadOnly = true;
            this.cabinasNumeric.Size = new System.Drawing.Size(37, 20);
            this.cabinasNumeric.TabIndex = 23;
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(149, 30);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 13);
            this.label4.TabIndex = 17;
            this.label4.Text = "A Comprar";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 30);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(101, 13);
            this.label3.TabIndex = 17;
            this.label3.Text = "Cantidad Disponible";
            // 
            // buttonComprar
            // 
            this.buttonComprar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.buttonComprar.Location = new System.Drawing.Point(320, 396);
            this.buttonComprar.Name = "buttonComprar";
            this.buttonComprar.Size = new System.Drawing.Size(140, 42);
            this.buttonComprar.TabIndex = 17;
            this.buttonComprar.Text = "Comprar";
            this.buttonComprar.UseVisualStyleBackColor = true;
            this.buttonComprar.Click += new System.EventHandler(this.buttonComprar_Click);
            // 
            // buttonReservar
            // 
            this.buttonReservar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.buttonReservar.Location = new System.Drawing.Point(466, 396);
            this.buttonReservar.Name = "buttonReservar";
            this.buttonReservar.Size = new System.Drawing.Size(138, 42);
            this.buttonReservar.TabIndex = 18;
            this.buttonReservar.Text = "Reservar";
            this.buttonReservar.UseVisualStyleBackColor = true;
            // 
            // selectorCabinas
            // 
            this.selectorCabinas.FormattingEnabled = true;
            this.selectorCabinas.Location = new System.Drawing.Point(221, 84);
            this.selectorCabinas.Name = "selectorCabinas";
            this.selectorCabinas.Size = new System.Drawing.Size(121, 21);
            this.selectorCabinas.TabIndex = 19;
            this.selectorCabinas.SelectedValueChanged += new System.EventHandler(this.selectorCabinas_SelectedValueChanged);
            // 
            // ElegirViajeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.buttonReservar);
            this.Controls.Add(this.buttonComprar);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "ElegirViajeForm";
            this.Text = "ElegirViajeForm";
            this.Load += new System.EventHandler(this.ElegirViajeFormLoad);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cabinasNumeric)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label labelRecorridos;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox recorridosList;
        private System.Windows.Forms.ListBox puertosList;
        private System.Windows.Forms.ListBox crucerosList;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label cabinasDisponiblesLabel;
        private System.Windows.Forms.NumericUpDown cabinasNumeric;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button buttonComprar;
        private System.Windows.Forms.Button buttonReservar;
        private System.Windows.Forms.ComboBox selectorCabinas;
    }
}