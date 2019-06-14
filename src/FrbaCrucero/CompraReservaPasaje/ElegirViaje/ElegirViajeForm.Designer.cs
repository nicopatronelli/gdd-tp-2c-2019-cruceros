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
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.estandarNumeric = new System.Windows.Forms.NumericUpDown();
            this.exteriorNumeric = new System.Windows.Forms.NumericUpDown();
            this.suiteNumeric = new System.Windows.Forms.NumericUpDown();
            this.balconNumeric = new System.Windows.Forms.NumericUpDown();
            this.ejecutivoNumeric = new System.Windows.Forms.NumericUpDown();
            this.estandarMaxLabel = new System.Windows.Forms.Label();
            this.ejecutivoMaxLabel = new System.Windows.Forms.Label();
            this.balconMaxLabel = new System.Windows.Forms.Label();
            this.suitMaxLabel = new System.Windows.Forms.Label();
            this.exteriorMaxLabel = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.estandarNumeric)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.exteriorNumeric)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.suiteNumeric)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.balconNumeric)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ejecutivoNumeric)).BeginInit();
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
            this.label2.Size = new System.Drawing.Size(49, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "Cruceros";
            // 
            // recorridosList
            // 
            this.recorridosList.FormattingEnabled = true;
            this.recorridosList.Location = new System.Drawing.Point(21, 58);
            this.recorridosList.Name = "recorridosList";
            this.recorridosList.Size = new System.Drawing.Size(77, 108);
            this.recorridosList.TabIndex = 12;
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
            this.crucerosList.SelectedValueChanged += new System.EventHandler(this.Eleccion_Crucero);
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
            this.groupBox2.Controls.Add(this.exteriorMaxLabel);
            this.groupBox2.Controls.Add(this.suitMaxLabel);
            this.groupBox2.Controls.Add(this.balconMaxLabel);
            this.groupBox2.Controls.Add(this.ejecutivoMaxLabel);
            this.groupBox2.Controls.Add(this.estandarMaxLabel);
            this.groupBox2.Controls.Add(this.ejecutivoNumeric);
            this.groupBox2.Controls.Add(this.balconNumeric);
            this.groupBox2.Controls.Add(this.suiteNumeric);
            this.groupBox2.Controls.Add(this.exteriorNumeric);
            this.groupBox2.Controls.Add(this.estandarNumeric);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Location = new System.Drawing.Point(372, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(284, 378);
            this.groupBox2.TabIndex = 16;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Cabinas Disponibles";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(39, 35);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(101, 13);
            this.label3.TabIndex = 17;
            this.label3.Text = "Cantidad Disponible";
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(173, 35);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 13);
            this.label4.TabIndex = 17;
            this.label4.Text = "A Comprar";
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(101, 65);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(84, 13);
            this.label5.TabIndex = 18;
            this.label5.Text = "Cabina estandar";
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(101, 123);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(78, 13);
            this.label6.TabIndex = 19;
            this.label6.Text = "Cabina Exterior";
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(124, 179);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(31, 13);
            this.label7.TabIndex = 20;
            this.label7.Text = "Suite";
            // 
            // label8
            // 
            this.label8.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(103, 235);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(76, 13);
            this.label8.TabIndex = 21;
            this.label8.Text = "Cabina Balcón";
            // 
            // label9
            // 
            this.label9.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(113, 292);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(51, 13);
            this.label9.TabIndex = 22;
            this.label9.Text = "Ejecutivo";
            // 
            // estandarNumeric
            // 
            this.estandarNumeric.Location = new System.Drawing.Point(168, 92);
            this.estandarNumeric.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.estandarNumeric.Name = "estandarNumeric";
            this.estandarNumeric.ReadOnly = true;
            this.estandarNumeric.Size = new System.Drawing.Size(37, 20);
            this.estandarNumeric.TabIndex = 23;
            // 
            // exteriorNumeric
            // 
            this.exteriorNumeric.Location = new System.Drawing.Point(168, 155);
            this.exteriorNumeric.Name = "exteriorNumeric";
            this.exteriorNumeric.ReadOnly = true;
            this.exteriorNumeric.Size = new System.Drawing.Size(37, 20);
            this.exteriorNumeric.TabIndex = 24;
            // 
            // suiteNumeric
            // 
            this.suiteNumeric.Location = new System.Drawing.Point(168, 209);
            this.suiteNumeric.Name = "suiteNumeric";
            this.suiteNumeric.ReadOnly = true;
            this.suiteNumeric.Size = new System.Drawing.Size(37, 20);
            this.suiteNumeric.TabIndex = 25;
            // 
            // balconNumeric
            // 
            this.balconNumeric.Location = new System.Drawing.Point(168, 272);
            this.balconNumeric.Name = "balconNumeric";
            this.balconNumeric.ReadOnly = true;
            this.balconNumeric.Size = new System.Drawing.Size(37, 20);
            this.balconNumeric.TabIndex = 26;
            // 
            // ejecutivoNumeric
            // 
            this.ejecutivoNumeric.Location = new System.Drawing.Point(168, 324);
            this.ejecutivoNumeric.Name = "ejecutivoNumeric";
            this.ejecutivoNumeric.ReadOnly = true;
            this.ejecutivoNumeric.Size = new System.Drawing.Size(37, 20);
            this.ejecutivoNumeric.TabIndex = 27;
            // 
            // estandarMaxLabel
            // 
            this.estandarMaxLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.estandarMaxLabel.AutoSize = true;
            this.estandarMaxLabel.Location = new System.Drawing.Point(72, 92);
            this.estandarMaxLabel.Name = "estandarMaxLabel";
            this.estandarMaxLabel.Size = new System.Drawing.Size(19, 13);
            this.estandarMaxLabel.TabIndex = 19;
            this.estandarMaxLabel.Text = "10";
            // 
            // ejecutivoMaxLabel
            // 
            this.ejecutivoMaxLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.ejecutivoMaxLabel.AutoSize = true;
            this.ejecutivoMaxLabel.Location = new System.Drawing.Point(72, 319);
            this.ejecutivoMaxLabel.Name = "ejecutivoMaxLabel";
            this.ejecutivoMaxLabel.Size = new System.Drawing.Size(19, 13);
            this.ejecutivoMaxLabel.TabIndex = 28;
            this.ejecutivoMaxLabel.Text = "10";
            // 
            // balconMaxLabel
            // 
            this.balconMaxLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.balconMaxLabel.AutoSize = true;
            this.balconMaxLabel.Location = new System.Drawing.Point(72, 265);
            this.balconMaxLabel.Name = "balconMaxLabel";
            this.balconMaxLabel.Size = new System.Drawing.Size(19, 13);
            this.balconMaxLabel.TabIndex = 29;
            this.balconMaxLabel.Text = "10";
            // 
            // suitMaxLabel
            // 
            this.suitMaxLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.suitMaxLabel.AutoSize = true;
            this.suitMaxLabel.Location = new System.Drawing.Point(72, 204);
            this.suitMaxLabel.Name = "suitMaxLabel";
            this.suitMaxLabel.Size = new System.Drawing.Size(19, 13);
            this.suitMaxLabel.TabIndex = 30;
            this.suitMaxLabel.Text = "10";
            // 
            // exteriorMaxLabel
            // 
            this.exteriorMaxLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.exteriorMaxLabel.AutoSize = true;
            this.exteriorMaxLabel.Location = new System.Drawing.Point(72, 150);
            this.exteriorMaxLabel.Name = "exteriorMaxLabel";
            this.exteriorMaxLabel.Size = new System.Drawing.Size(19, 13);
            this.exteriorMaxLabel.TabIndex = 31;
            this.exteriorMaxLabel.Text = "10";
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.button1.Location = new System.Drawing.Point(452, 396);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(125, 42);
            this.button1.TabIndex = 17;
            this.button1.Text = "Listo";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // ElegirViajeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "ElegirViajeForm";
            this.Text = "ElegirViajeForm";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.estandarNumeric)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.exteriorNumeric)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.suiteNumeric)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.balconNumeric)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ejecutivoNumeric)).EndInit();
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
        private System.Windows.Forms.Label exteriorMaxLabel;
        private System.Windows.Forms.Label suitMaxLabel;
        private System.Windows.Forms.Label balconMaxLabel;
        private System.Windows.Forms.Label ejecutivoMaxLabel;
        private System.Windows.Forms.Label estandarMaxLabel;
        private System.Windows.Forms.NumericUpDown ejecutivoNumeric;
        private System.Windows.Forms.NumericUpDown balconNumeric;
        private System.Windows.Forms.NumericUpDown suiteNumeric;
        private System.Windows.Forms.NumericUpDown exteriorNumeric;
        private System.Windows.Forms.NumericUpDown estandarNumeric;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button1;
    }
}