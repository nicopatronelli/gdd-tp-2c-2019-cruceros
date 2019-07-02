namespace FrbaCrucero.ListadoEstadistico
{
    partial class SeleccionListadoEstadisticoForm
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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnFueraServicio = new System.Windows.Forms.Button();
            this.btnCabinasLibres = new System.Windows.Forms.Button();
            this.btnComprados = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpAnio = new System.Windows.Forms.DateTimePicker();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.gpbxSemestre = new System.Windows.Forms.GroupBox();
            this.rbtnSegundoSemestre = new System.Windows.Forms.RadioButton();
            this.rbtnPrimerSemestre = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.gpbxSemestre.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnFueraServicio);
            this.groupBox2.Controls.Add(this.btnCabinasLibres);
            this.groupBox2.Controls.Add(this.btnComprados);
            this.groupBox2.Location = new System.Drawing.Point(20, 133);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(469, 131);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Seleccione el listado estadístico que desea visualizar:";
            // 
            // btnFueraServicio
            // 
            this.btnFueraServicio.Location = new System.Drawing.Point(46, 88);
            this.btnFueraServicio.Name = "btnFueraServicio";
            this.btnFueraServicio.Size = new System.Drawing.Size(381, 23);
            this.btnFueraServicio.TabIndex = 2;
            this.btnFueraServicio.Text = "Los cinco cruceros con mayor cantidad de días fuera de servicio";
            this.btnFueraServicio.UseVisualStyleBackColor = true;
            this.btnFueraServicio.Click += new System.EventHandler(this.btnFueraServicio_Click);
            // 
            // btnCabinasLibres
            // 
            this.btnCabinasLibres.Location = new System.Drawing.Point(46, 59);
            this.btnCabinasLibres.Name = "btnCabinasLibres";
            this.btnCabinasLibres.Size = new System.Drawing.Size(381, 23);
            this.btnCabinasLibres.TabIndex = 1;
            this.btnCabinasLibres.Text = "Los 5 recorridos con más cabinas libres en cada uno de sus viajes";
            this.btnCabinasLibres.UseVisualStyleBackColor = true;
            this.btnCabinasLibres.Click += new System.EventHandler(this.btnCabinasLibres_Click);
            // 
            // btnComprados
            // 
            this.btnComprados.Location = new System.Drawing.Point(46, 30);
            this.btnComprados.Name = "btnComprados";
            this.btnComprados.Size = new System.Drawing.Size(381, 23);
            this.btnComprados.TabIndex = 0;
            this.btnComprados.Text = "Los cinco recorridos con más pasajes comprados";
            this.btnComprados.UseVisualStyleBackColor = true;
            this.btnComprados.Click += new System.EventHandler(this.btnComprados_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Elija el año:";
            // 
            // dtpAnio
            // 
            this.dtpAnio.Location = new System.Drawing.Point(94, 31);
            this.dtpAnio.Name = "dtpAnio";
            this.dtpAnio.Size = new System.Drawing.Size(84, 20);
            this.dtpAnio.TabIndex = 0;
            this.dtpAnio.Value = new System.DateTime(2018, 6, 1, 0, 0, 0, 0);
            // 
            // btnCerrar
            // 
            this.btnCerrar.Location = new System.Drawing.Point(414, 270);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(75, 23);
            this.btnCerrar.TabIndex = 1;
            this.btnCerrar.Text = "Cerrar";
            this.btnCerrar.UseVisualStyleBackColor = true;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnCerrar);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.dtpAnio);
            this.groupBox1.Controls.Add(this.gpbxSemestre);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(504, 300);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Listados Estadísticos";
            // 
            // gpbxSemestre
            // 
            this.gpbxSemestre.Controls.Add(this.rbtnSegundoSemestre);
            this.gpbxSemestre.Controls.Add(this.rbtnPrimerSemestre);
            this.gpbxSemestre.Location = new System.Drawing.Point(20, 65);
            this.gpbxSemestre.Name = "gpbxSemestre";
            this.gpbxSemestre.Size = new System.Drawing.Size(301, 55);
            this.gpbxSemestre.TabIndex = 9;
            this.gpbxSemestre.TabStop = false;
            this.gpbxSemestre.Text = "Elija el semestre:";
            // 
            // rbtnSegundoSemestre
            // 
            this.rbtnSegundoSemestre.AutoSize = true;
            this.rbtnSegundoSemestre.Location = new System.Drawing.Point(157, 22);
            this.rbtnSegundoSemestre.Name = "rbtnSegundoSemestre";
            this.rbtnSegundoSemestre.Size = new System.Drawing.Size(115, 17);
            this.rbtnSegundoSemestre.TabIndex = 1;
            this.rbtnSegundoSemestre.TabStop = true;
            this.rbtnSegundoSemestre.Text = "Segundo Semestre";
            this.rbtnSegundoSemestre.UseVisualStyleBackColor = true;
            // 
            // rbtnPrimerSemestre
            // 
            this.rbtnPrimerSemestre.AutoSize = true;
            this.rbtnPrimerSemestre.Location = new System.Drawing.Point(30, 22);
            this.rbtnPrimerSemestre.Name = "rbtnPrimerSemestre";
            this.rbtnPrimerSemestre.Size = new System.Drawing.Size(101, 17);
            this.rbtnPrimerSemestre.TabIndex = 0;
            this.rbtnPrimerSemestre.TabStop = true;
            this.rbtnPrimerSemestre.Text = "Primer Semestre";
            this.rbtnPrimerSemestre.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 322);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(384, 26);
            this.label2.TabIndex = 10;
            this.label2.Text = "Nota: Para ver resultados provenientes de la migración, seleccione el año 2018 \r\n" +
    "y el primer semestre.";
            // 
            // SeleccionListadoEstadisticoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(532, 363);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "SeleccionListadoEstadisticoForm";
            this.Text = "Listados Estadisticos";
            this.groupBox2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.gpbxSemestre.ResumeLayout(false);
            this.gpbxSemestre.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnFueraServicio;
        private System.Windows.Forms.Button btnCabinasLibres;
        private System.Windows.Forms.Button btnComprados;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpAnio;
        private System.Windows.Forms.Button btnCerrar;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox gpbxSemestre;
        private System.Windows.Forms.RadioButton rbtnSegundoSemestre;
        private System.Windows.Forms.RadioButton rbtnPrimerSemestre;
        private System.Windows.Forms.Label label2;
    }
}