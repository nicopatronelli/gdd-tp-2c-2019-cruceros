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
            this.recargoLabel5 = new System.Windows.Forms.Label();
            this.recargoLabel4 = new System.Windows.Forms.Label();
            this.recargoLabel2 = new System.Windows.Forms.Label();
            this.recargoLabel3 = new System.Windows.Forms.Label();
            this.recargoLabel1 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cabinas5Numeric = new System.Windows.Forms.NumericUpDown();
            this.cabinas5Label = new System.Windows.Forms.Label();
            this.cabinas5DisponiblesLabel = new System.Windows.Forms.Label();
            this.cabinas4Numeric = new System.Windows.Forms.NumericUpDown();
            this.cabinas3Numeric = new System.Windows.Forms.NumericUpDown();
            this.cabinas2Numeric = new System.Windows.Forms.NumericUpDown();
            this.cabinas4Label = new System.Windows.Forms.Label();
            this.cabinas4DisponiblesLabel = new System.Windows.Forms.Label();
            this.cabinas3DisponiblesLabel = new System.Windows.Forms.Label();
            this.cabinas2Label = new System.Windows.Forms.Label();
            this.cabinas3Label = new System.Windows.Forms.Label();
            this.cabinas2DisponiblesLabel = new System.Windows.Forms.Label();
            this.cabinas1Label = new System.Windows.Forms.Label();
            this.cabinas1DisponiblesLabel = new System.Windows.Forms.Label();
            this.cabinas1Numeric = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.buttonComprar = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cabinas5Numeric)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cabinas4Numeric)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cabinas3Numeric)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cabinas2Numeric)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cabinas1Numeric)).BeginInit();
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
            this.recorridosList.TabIndex = 0;
            this.recorridosList.SelectedValueChanged += new System.EventHandler(this.recorridosList_SelectedValueChanged);
            // 
            // puertosList
            // 
            this.puertosList.FormattingEnabled = true;
            this.puertosList.Location = new System.Drawing.Point(21, 218);
            this.puertosList.Name = "puertosList";
            this.puertosList.Size = new System.Drawing.Size(186, 108);
            this.puertosList.TabIndex = 2;
            // 
            // crucerosList
            // 
            this.crucerosList.FormattingEnabled = true;
            this.crucerosList.Location = new System.Drawing.Point(130, 58);
            this.crucerosList.Name = "crucerosList";
            this.crucerosList.Size = new System.Drawing.Size(77, 108);
            this.crucerosList.TabIndex = 1;
            this.crucerosList.SelectedValueChanged += new System.EventHandler(this.crucerosList_SelectedValueChanged);
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
            this.groupBox2.Controls.Add(this.recargoLabel5);
            this.groupBox2.Controls.Add(this.recargoLabel4);
            this.groupBox2.Controls.Add(this.recargoLabel2);
            this.groupBox2.Controls.Add(this.recargoLabel3);
            this.groupBox2.Controls.Add(this.recargoLabel1);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.cabinas5Numeric);
            this.groupBox2.Controls.Add(this.cabinas5Label);
            this.groupBox2.Controls.Add(this.cabinas5DisponiblesLabel);
            this.groupBox2.Controls.Add(this.cabinas4Numeric);
            this.groupBox2.Controls.Add(this.cabinas3Numeric);
            this.groupBox2.Controls.Add(this.cabinas2Numeric);
            this.groupBox2.Controls.Add(this.cabinas4Label);
            this.groupBox2.Controls.Add(this.cabinas4DisponiblesLabel);
            this.groupBox2.Controls.Add(this.cabinas3DisponiblesLabel);
            this.groupBox2.Controls.Add(this.cabinas2Label);
            this.groupBox2.Controls.Add(this.cabinas3Label);
            this.groupBox2.Controls.Add(this.cabinas2DisponiblesLabel);
            this.groupBox2.Controls.Add(this.cabinas1Label);
            this.groupBox2.Controls.Add(this.cabinas1DisponiblesLabel);
            this.groupBox2.Controls.Add(this.cabinas1Numeric);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Location = new System.Drawing.Point(320, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(468, 343);
            this.groupBox2.TabIndex = 16;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Cabinas Disponibles";
            // 
            // recargoLabel5
            // 
            this.recargoLabel5.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.recargoLabel5.AutoSize = true;
            this.recargoLabel5.Location = new System.Drawing.Point(362, 295);
            this.recargoLabel5.Name = "recargoLabel5";
            this.recargoLabel5.Size = new System.Drawing.Size(13, 13);
            this.recargoLabel5.TabIndex = 43;
            this.recargoLabel5.Text = "--";
            // 
            // recargoLabel4
            // 
            this.recargoLabel4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.recargoLabel4.AutoSize = true;
            this.recargoLabel4.Location = new System.Drawing.Point(362, 241);
            this.recargoLabel4.Name = "recargoLabel4";
            this.recargoLabel4.Size = new System.Drawing.Size(13, 13);
            this.recargoLabel4.TabIndex = 42;
            this.recargoLabel4.Text = "--";
            // 
            // recargoLabel2
            // 
            this.recargoLabel2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.recargoLabel2.AutoSize = true;
            this.recargoLabel2.Location = new System.Drawing.Point(362, 140);
            this.recargoLabel2.Name = "recargoLabel2";
            this.recargoLabel2.Size = new System.Drawing.Size(13, 13);
            this.recargoLabel2.TabIndex = 41;
            this.recargoLabel2.Text = "--";
            // 
            // recargoLabel3
            // 
            this.recargoLabel3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.recargoLabel3.AutoSize = true;
            this.recargoLabel3.Location = new System.Drawing.Point(362, 189);
            this.recargoLabel3.Name = "recargoLabel3";
            this.recargoLabel3.Size = new System.Drawing.Size(13, 13);
            this.recargoLabel3.TabIndex = 40;
            this.recargoLabel3.Text = "--";
            // 
            // recargoLabel1
            // 
            this.recargoLabel1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.recargoLabel1.AutoSize = true;
            this.recargoLabel1.Location = new System.Drawing.Point(362, 94);
            this.recargoLabel1.Name = "recargoLabel1";
            this.recargoLabel1.Size = new System.Drawing.Size(13, 13);
            this.recargoLabel1.TabIndex = 39;
            this.recargoLabel1.Text = "--";
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(320, 41);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(96, 13);
            this.label6.TabIndex = 38;
            this.label6.Text = "Factor de Recargo";
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(221, 41);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(63, 13);
            this.label5.TabIndex = 37;
            this.label5.Text = "Tipo cabina";
            // 
            // cabinas5Numeric
            // 
            this.cabinas5Numeric.Location = new System.Drawing.Point(129, 283);
            this.cabinas5Numeric.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.cabinas5Numeric.Name = "cabinas5Numeric";
            this.cabinas5Numeric.ReadOnly = true;
            this.cabinas5Numeric.Size = new System.Drawing.Size(37, 20);
            this.cabinas5Numeric.TabIndex = 4;
            // 
            // cabinas5Label
            // 
            this.cabinas5Label.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cabinas5Label.AutoSize = true;
            this.cabinas5Label.Location = new System.Drawing.Point(221, 288);
            this.cabinas5Label.Name = "cabinas5Label";
            this.cabinas5Label.Size = new System.Drawing.Size(13, 13);
            this.cabinas5Label.TabIndex = 35;
            this.cabinas5Label.Text = "--";
            // 
            // cabinas5DisponiblesLabel
            // 
            this.cabinas5DisponiblesLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cabinas5DisponiblesLabel.AutoSize = true;
            this.cabinas5DisponiblesLabel.Location = new System.Drawing.Point(34, 288);
            this.cabinas5DisponiblesLabel.Name = "cabinas5DisponiblesLabel";
            this.cabinas5DisponiblesLabel.Size = new System.Drawing.Size(13, 13);
            this.cabinas5DisponiblesLabel.TabIndex = 34;
            this.cabinas5DisponiblesLabel.Text = "--";
            // 
            // cabinas4Numeric
            // 
            this.cabinas4Numeric.Location = new System.Drawing.Point(129, 229);
            this.cabinas4Numeric.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.cabinas4Numeric.Name = "cabinas4Numeric";
            this.cabinas4Numeric.ReadOnly = true;
            this.cabinas4Numeric.Size = new System.Drawing.Size(37, 20);
            this.cabinas4Numeric.TabIndex = 3;
            // 
            // cabinas3Numeric
            // 
            this.cabinas3Numeric.Location = new System.Drawing.Point(129, 182);
            this.cabinas3Numeric.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.cabinas3Numeric.Name = "cabinas3Numeric";
            this.cabinas3Numeric.ReadOnly = true;
            this.cabinas3Numeric.Size = new System.Drawing.Size(37, 20);
            this.cabinas3Numeric.TabIndex = 2;
            // 
            // cabinas2Numeric
            // 
            this.cabinas2Numeric.Location = new System.Drawing.Point(129, 133);
            this.cabinas2Numeric.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.cabinas2Numeric.Name = "cabinas2Numeric";
            this.cabinas2Numeric.ReadOnly = true;
            this.cabinas2Numeric.Size = new System.Drawing.Size(37, 20);
            this.cabinas2Numeric.TabIndex = 1;
            // 
            // cabinas4Label
            // 
            this.cabinas4Label.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cabinas4Label.AutoSize = true;
            this.cabinas4Label.Location = new System.Drawing.Point(221, 234);
            this.cabinas4Label.Name = "cabinas4Label";
            this.cabinas4Label.Size = new System.Drawing.Size(13, 13);
            this.cabinas4Label.TabIndex = 30;
            this.cabinas4Label.Text = "--";
            // 
            // cabinas4DisponiblesLabel
            // 
            this.cabinas4DisponiblesLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cabinas4DisponiblesLabel.AutoSize = true;
            this.cabinas4DisponiblesLabel.Location = new System.Drawing.Point(34, 234);
            this.cabinas4DisponiblesLabel.Name = "cabinas4DisponiblesLabel";
            this.cabinas4DisponiblesLabel.Size = new System.Drawing.Size(13, 13);
            this.cabinas4DisponiblesLabel.TabIndex = 29;
            this.cabinas4DisponiblesLabel.Text = "--";
            // 
            // cabinas3DisponiblesLabel
            // 
            this.cabinas3DisponiblesLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cabinas3DisponiblesLabel.AutoSize = true;
            this.cabinas3DisponiblesLabel.Location = new System.Drawing.Point(34, 182);
            this.cabinas3DisponiblesLabel.Name = "cabinas3DisponiblesLabel";
            this.cabinas3DisponiblesLabel.Size = new System.Drawing.Size(13, 13);
            this.cabinas3DisponiblesLabel.TabIndex = 28;
            this.cabinas3DisponiblesLabel.Text = "--";
            // 
            // cabinas2Label
            // 
            this.cabinas2Label.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cabinas2Label.AutoSize = true;
            this.cabinas2Label.Location = new System.Drawing.Point(221, 133);
            this.cabinas2Label.Name = "cabinas2Label";
            this.cabinas2Label.Size = new System.Drawing.Size(13, 13);
            this.cabinas2Label.TabIndex = 27;
            this.cabinas2Label.Text = "--";
            // 
            // cabinas3Label
            // 
            this.cabinas3Label.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cabinas3Label.AutoSize = true;
            this.cabinas3Label.Location = new System.Drawing.Point(221, 182);
            this.cabinas3Label.Name = "cabinas3Label";
            this.cabinas3Label.Size = new System.Drawing.Size(13, 13);
            this.cabinas3Label.TabIndex = 26;
            this.cabinas3Label.Text = "--";
            // 
            // cabinas2DisponiblesLabel
            // 
            this.cabinas2DisponiblesLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cabinas2DisponiblesLabel.AutoSize = true;
            this.cabinas2DisponiblesLabel.Location = new System.Drawing.Point(34, 133);
            this.cabinas2DisponiblesLabel.Name = "cabinas2DisponiblesLabel";
            this.cabinas2DisponiblesLabel.Size = new System.Drawing.Size(13, 13);
            this.cabinas2DisponiblesLabel.TabIndex = 25;
            this.cabinas2DisponiblesLabel.Text = "--";
            // 
            // cabinas1Label
            // 
            this.cabinas1Label.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cabinas1Label.AutoSize = true;
            this.cabinas1Label.Location = new System.Drawing.Point(221, 87);
            this.cabinas1Label.Name = "cabinas1Label";
            this.cabinas1Label.Size = new System.Drawing.Size(13, 13);
            this.cabinas1Label.TabIndex = 24;
            this.cabinas1Label.Text = "--";
            // 
            // cabinas1DisponiblesLabel
            // 
            this.cabinas1DisponiblesLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cabinas1DisponiblesLabel.AutoSize = true;
            this.cabinas1DisponiblesLabel.Location = new System.Drawing.Point(34, 87);
            this.cabinas1DisponiblesLabel.Name = "cabinas1DisponiblesLabel";
            this.cabinas1DisponiblesLabel.Size = new System.Drawing.Size(13, 13);
            this.cabinas1DisponiblesLabel.TabIndex = 19;
            this.cabinas1DisponiblesLabel.Text = "--";
            // 
            // cabinas1Numeric
            // 
            this.cabinas1Numeric.Location = new System.Drawing.Point(129, 87);
            this.cabinas1Numeric.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.cabinas1Numeric.Name = "cabinas1Numeric";
            this.cabinas1Numeric.ReadOnly = true;
            this.cabinas1Numeric.Size = new System.Drawing.Size(37, 20);
            this.cabinas1Numeric.TabIndex = 0;
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(113, 41);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 13);
            this.label4.TabIndex = 17;
            this.label4.Text = "A Comprar";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 41);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(101, 13);
            this.label3.TabIndex = 17;
            this.label3.Text = "Cantidad Disponible";
            // 
            // buttonComprar
            // 
            this.buttonComprar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.buttonComprar.Location = new System.Drawing.Point(414, 361);
            this.buttonComprar.Name = "buttonComprar";
            this.buttonComprar.Size = new System.Drawing.Size(140, 77);
            this.buttonComprar.TabIndex = 0;
            this.buttonComprar.Text = "Ingresar Datos Personales";
            this.buttonComprar.UseVisualStyleBackColor = true;
            this.buttonComprar.Click += new System.EventHandler(this.ingresar_datos_click);
            // 
            // ElegirViajeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.buttonComprar);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "ElegirViajeForm";
            this.Text = "ElegirViajeForm";
            this.Load += new System.EventHandler(this.ElegirViajeFormLoad);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cabinas5Numeric)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cabinas4Numeric)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cabinas3Numeric)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cabinas2Numeric)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cabinas1Numeric)).EndInit();
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
        private System.Windows.Forms.Label cabinas1DisponiblesLabel;
        private System.Windows.Forms.NumericUpDown cabinas1Numeric;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button buttonComprar;
        private System.Windows.Forms.NumericUpDown cabinas4Numeric;
        private System.Windows.Forms.NumericUpDown cabinas3Numeric;
        private System.Windows.Forms.NumericUpDown cabinas2Numeric;
        private System.Windows.Forms.Label cabinas4Label;
        private System.Windows.Forms.Label cabinas4DisponiblesLabel;
        private System.Windows.Forms.Label cabinas3DisponiblesLabel;
        private System.Windows.Forms.Label cabinas2Label;
        private System.Windows.Forms.Label cabinas3Label;
        private System.Windows.Forms.Label cabinas2DisponiblesLabel;
        private System.Windows.Forms.Label cabinas1Label;
        private System.Windows.Forms.NumericUpDown cabinas5Numeric;
        private System.Windows.Forms.Label cabinas5Label;
        private System.Windows.Forms.Label cabinas5DisponiblesLabel;
        private System.Windows.Forms.Label recargoLabel5;
        private System.Windows.Forms.Label recargoLabel4;
        private System.Windows.Forms.Label recargoLabel2;
        private System.Windows.Forms.Label recargoLabel3;
        private System.Windows.Forms.Label recargoLabel1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
    }
}