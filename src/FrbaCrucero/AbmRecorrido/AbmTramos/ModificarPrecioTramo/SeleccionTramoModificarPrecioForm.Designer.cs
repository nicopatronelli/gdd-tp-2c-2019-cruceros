namespace FrbaCrucero.AbmRecorrido.AbmTramos.ModificarPrecioTramo
{
    partial class SeleccionTramoModificarPrecioForm
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
            this.dgvTramosDisponibles = new System.Windows.Forms.DataGridView();
            this.tramo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.puerto_inicio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.puerto_fin = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.precio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.elegir_tramo = new System.Windows.Forms.DataGridViewButtonColumn();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.Puerto = new System.Windows.Forms.Label();
            this.txtbxPuertoFin = new System.Windows.Forms.TextBox();
            this.btnBuscarTramos = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.txtbxPuertoInicio = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTramosDisponibles)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvTramosDisponibles
            // 
            this.dgvTramosDisponibles.AllowUserToAddRows = false;
            this.dgvTramosDisponibles.AllowUserToDeleteRows = false;
            this.dgvTramosDisponibles.AllowUserToResizeColumns = false;
            this.dgvTramosDisponibles.AllowUserToResizeRows = false;
            this.dgvTramosDisponibles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTramosDisponibles.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.tramo,
            this.puerto_inicio,
            this.puerto_fin,
            this.precio,
            this.elegir_tramo});
            this.dgvTramosDisponibles.Location = new System.Drawing.Point(18, 60);
            this.dgvTramosDisponibles.Name = "dgvTramosDisponibles";
            this.dgvTramosDisponibles.Size = new System.Drawing.Size(512, 230);
            this.dgvTramosDisponibles.TabIndex = 3;
            // 
            // tramo
            // 
            this.tramo.DataPropertyName = "tramo";
            this.tramo.HeaderText = "Tramo";
            this.tramo.Name = "tramo";
            this.tramo.ReadOnly = true;
            // 
            // puerto_inicio
            // 
            this.puerto_inicio.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.puerto_inicio.DataPropertyName = "puerto_inicio";
            this.puerto_inicio.HeaderText = "Puerto Inicio";
            this.puerto_inicio.Name = "puerto_inicio";
            this.puerto_inicio.ReadOnly = true;
            // 
            // puerto_fin
            // 
            this.puerto_fin.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.puerto_fin.DataPropertyName = "puerto_fin";
            this.puerto_fin.HeaderText = "Puerto Fin";
            this.puerto_fin.Name = "puerto_fin";
            this.puerto_fin.ReadOnly = true;
            // 
            // precio
            // 
            this.precio.DataPropertyName = "precio";
            this.precio.HeaderText = "Precio";
            this.precio.Name = "precio";
            this.precio.ReadOnly = true;
            // 
            // elegir_tramo
            // 
            this.elegir_tramo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.elegir_tramo.DataPropertyName = "btnSeleccionarTramo";
            this.elegir_tramo.HeaderText = "Editar Precio";
            this.elegir_tramo.Name = "elegir_tramo";
            this.elegir_tramo.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.elegir_tramo.Text = "Editar";
            this.elegir_tramo.UseColumnTextForButtonValue = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.Puerto);
            this.groupBox1.Controls.Add(this.txtbxPuertoFin);
            this.groupBox1.Controls.Add(this.btnBuscarTramos);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtbxPuertoInicio);
            this.groupBox1.Controls.Add(this.dgvTramosDisponibles);
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(549, 306);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Seleccione el tramo para el cual desea actualizar su precio";
            // 
            // btnCerrar
            // 
            this.btnCerrar.Location = new System.Drawing.Point(487, 325);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(75, 23);
            this.btnCerrar.TabIndex = 8;
            this.btnCerrar.Text = "Cerrar";
            this.btnCerrar.UseVisualStyleBackColor = true;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // Puerto
            // 
            this.Puerto.AutoSize = true;
            this.Puerto.Location = new System.Drawing.Point(16, 26);
            this.Puerto.Name = "Puerto";
            this.Puerto.Size = new System.Drawing.Size(83, 13);
            this.Puerto.TabIndex = 13;
            this.Puerto.Text = "Puerto de inicio:";
            // 
            // txtbxPuertoFin
            // 
            this.txtbxPuertoFin.Location = new System.Drawing.Point(315, 23);
            this.txtbxPuertoFin.Name = "txtbxPuertoFin";
            this.txtbxPuertoFin.Size = new System.Drawing.Size(100, 20);
            this.txtbxPuertoFin.TabIndex = 17;
            // 
            // btnBuscarTramos
            // 
            this.btnBuscarTramos.Location = new System.Drawing.Point(455, 21);
            this.btnBuscarTramos.Name = "btnBuscarTramos";
            this.btnBuscarTramos.Size = new System.Drawing.Size(75, 23);
            this.btnBuscarTramos.TabIndex = 15;
            this.btnBuscarTramos.Text = "Buscar";
            this.btnBuscarTramos.UseVisualStyleBackColor = true;
            this.btnBuscarTramos.Click += new System.EventHandler(this.btnBuscarTramos_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(239, 27);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 13);
            this.label4.TabIndex = 16;
            this.label4.Text = "Puerto de fin:";
            // 
            // txtbxPuertoInicio
            // 
            this.txtbxPuertoInicio.Location = new System.Drawing.Point(105, 23);
            this.txtbxPuertoInicio.Name = "txtbxPuertoInicio";
            this.txtbxPuertoInicio.Size = new System.Drawing.Size(100, 20);
            this.txtbxPuertoInicio.TabIndex = 14;
            // 
            // SeleccionTramoModificarPrecioForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(575, 357);
            this.Controls.Add(this.btnCerrar);
            this.Controls.Add(this.groupBox1);
            this.Name = "SeleccionTramoModificarPrecioForm";
            this.Text = "Selección de tramo a editar precio";
            ((System.ComponentModel.ISupportInitialize)(this.dgvTramosDisponibles)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvTramosDisponibles;
        private System.Windows.Forms.DataGridViewTextBoxColumn tramo;
        private System.Windows.Forms.DataGridViewTextBoxColumn puerto_inicio;
        private System.Windows.Forms.DataGridViewTextBoxColumn puerto_fin;
        private System.Windows.Forms.DataGridViewTextBoxColumn precio;
        private System.Windows.Forms.DataGridViewButtonColumn elegir_tramo;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnCerrar;
        private System.Windows.Forms.Label Puerto;
        private System.Windows.Forms.TextBox txtbxPuertoFin;
        private System.Windows.Forms.Button btnBuscarTramos;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtbxPuertoInicio;

    }
}