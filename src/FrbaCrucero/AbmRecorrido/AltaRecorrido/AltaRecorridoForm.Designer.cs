namespace FrbaCrucero.AbmRecorrido
{
    partial class AltaRecorridoForm
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
            this.btnEliminarUltimoTramo = new System.Windows.Forms.Button();
            this.dgvTramosRecorrido = new System.Windows.Forms.DataGridView();
            this.id_tramo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.puerto_inicio_tramo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.puerto_fin_tramo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.precio_tramo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label3 = new System.Windows.Forms.Label();
            this.btnEliminarTodo = new System.Windows.Forms.Button();
            this.lblPrecioRecorrido = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dgvElegirTramos = new System.Windows.Forms.DataGridView();
            this.tramo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.puerto_inicio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.puerto_fin = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.precio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.elegir_tramo = new System.Windows.Forms.DataGridViewButtonColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.txtbxCodRecorrido = new System.Windows.Forms.TextBox();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.btnEnviar = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTramosRecorrido)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvElegirTramos)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.btnEliminarUltimoTramo);
            this.groupBox1.Controls.Add(this.dgvTramosRecorrido);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.btnEliminarTodo);
            this.groupBox1.Controls.Add(this.lblPrecioRecorrido);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.dgvElegirTramos);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtbxCodRecorrido);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1110, 330);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Alta Nuevo Recorrido";
            // 
            // btnEliminarUltimoTramo
            // 
            this.btnEliminarUltimoTramo.Location = new System.Drawing.Point(810, 291);
            this.btnEliminarUltimoTramo.Name = "btnEliminarUltimoTramo";
            this.btnEliminarUltimoTramo.Size = new System.Drawing.Size(141, 23);
            this.btnEliminarUltimoTramo.TabIndex = 13;
            this.btnEliminarUltimoTramo.Text = "Eliminar Ultimo Tramo";
            this.btnEliminarUltimoTramo.UseVisualStyleBackColor = true;
            this.btnEliminarUltimoTramo.Click += new System.EventHandler(this.btnEliminarUltimoTramo_Click);
            // 
            // dgvTramosRecorrido
            // 
            this.dgvTramosRecorrido.AllowUserToAddRows = false;
            this.dgvTramosRecorrido.AllowUserToDeleteRows = false;
            this.dgvTramosRecorrido.AllowUserToResizeColumns = false;
            this.dgvTramosRecorrido.AllowUserToResizeRows = false;
            this.dgvTramosRecorrido.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTramosRecorrido.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id_tramo,
            this.puerto_inicio_tramo,
            this.puerto_fin_tramo,
            this.precio_tramo});
            this.dgvTramosRecorrido.Location = new System.Drawing.Point(645, 80);
            this.dgvTramosRecorrido.Name = "dgvTramosRecorrido";
            this.dgvTramosRecorrido.ReadOnly = true;
            this.dgvTramosRecorrido.Size = new System.Drawing.Size(443, 205);
            this.dgvTramosRecorrido.TabIndex = 12;
            // 
            // id_tramo
            // 
            this.id_tramo.HeaderText = "Tramo";
            this.id_tramo.Name = "id_tramo";
            this.id_tramo.ReadOnly = true;
            // 
            // puerto_inicio_tramo
            // 
            this.puerto_inicio_tramo.HeaderText = "Puerto Inicio";
            this.puerto_inicio_tramo.Name = "puerto_inicio_tramo";
            this.puerto_inicio_tramo.ReadOnly = true;
            // 
            // puerto_fin_tramo
            // 
            this.puerto_fin_tramo.HeaderText = "Puerto Fin";
            this.puerto_fin_tramo.Name = "puerto_fin_tramo";
            this.puerto_fin_tramo.ReadOnly = true;
            // 
            // precio_tramo
            // 
            this.precio_tramo.HeaderText = "Precio";
            this.precio_tramo.Name = "precio_tramo";
            this.precio_tramo.ReadOnly = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(642, 64);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(250, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Detalle del recorrido (en orden de visita de puertos):";
            // 
            // btnEliminarTodo
            // 
            this.btnEliminarTodo.Location = new System.Drawing.Point(979, 291);
            this.btnEliminarTodo.Name = "btnEliminarTodo";
            this.btnEliminarTodo.Size = new System.Drawing.Size(109, 23);
            this.btnEliminarTodo.TabIndex = 6;
            this.btnEliminarTodo.Text = "Eliminar Todo";
            this.btnEliminarTodo.UseVisualStyleBackColor = true;
            this.btnEliminarTodo.Click += new System.EventHandler(this.btnEliminarTodo_Click);
            // 
            // lblPrecioRecorrido
            // 
            this.lblPrecioRecorrido.AutoSize = true;
            this.lblPrecioRecorrido.Location = new System.Drawing.Point(737, 296);
            this.lblPrecioRecorrido.Name = "lblPrecioRecorrido";
            this.lblPrecioRecorrido.Size = new System.Drawing.Size(13, 13);
            this.lblPrecioRecorrido.TabIndex = 4;
            this.lblPrecioRecorrido.Text = "0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(642, 296);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Precio Recorrido:";
            // 
            // dgvElegirTramos
            // 
            this.dgvElegirTramos.AllowUserToAddRows = false;
            this.dgvElegirTramos.AllowUserToDeleteRows = false;
            this.dgvElegirTramos.AllowUserToResizeColumns = false;
            this.dgvElegirTramos.AllowUserToResizeRows = false;
            this.dgvElegirTramos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvElegirTramos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.tramo,
            this.puerto_inicio,
            this.puerto_fin,
            this.precio,
            this.elegir_tramo});
            this.dgvElegirTramos.Location = new System.Drawing.Point(25, 80);
            this.dgvElegirTramos.Name = "dgvElegirTramos";
            this.dgvElegirTramos.Size = new System.Drawing.Size(597, 234);
            this.dgvElegirTramos.TabIndex = 2;
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
            this.elegir_tramo.HeaderText = "Agregar Tramo";
            this.elegir_tramo.Name = "elegir_tramo";
            this.elegir_tramo.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.elegir_tramo.Text = "Agregar";
            this.elegir_tramo.UseColumnTextForButtonValue = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Código Recorrido*:";
            // 
            // txtbxCodRecorrido
            // 
            this.txtbxCodRecorrido.Location = new System.Drawing.Point(120, 28);
            this.txtbxCodRecorrido.Name = "txtbxCodRecorrido";
            this.txtbxCodRecorrido.Size = new System.Drawing.Size(100, 20);
            this.txtbxCodRecorrido.TabIndex = 0;
            // 
            // btnCerrar
            // 
            this.btnCerrar.Location = new System.Drawing.Point(1047, 353);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(75, 23);
            this.btnCerrar.TabIndex = 10;
            this.btnCerrar.Text = "Cerrar";
            this.btnCerrar.UseVisualStyleBackColor = true;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // btnEnviar
            // 
            this.btnEnviar.Location = new System.Drawing.Point(952, 353);
            this.btnEnviar.Name = "btnEnviar";
            this.btnEnviar.Size = new System.Drawing.Size(75, 23);
            this.btnEnviar.TabIndex = 5;
            this.btnEnviar.Text = "Enviar";
            this.btnEnviar.UseVisualStyleBackColor = true;
            this.btnEnviar.Click += new System.EventHandler(this.btnEnviar_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 363);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(322, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "* Campos obligatorios (Además, debe incluir por lo menos un tramo)";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(22, 64);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(100, 13);
            this.label5.TabIndex = 14;
            this.label5.Text = "Tramos disponibles:";
            // 
            // AltaRecorridoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1134, 386);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnCerrar);
            this.Controls.Add(this.btnEnviar);
            this.Name = "AltaRecorridoForm";
            this.Text = "Abm Recorrido";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTramosRecorrido)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvElegirTramos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dgvElegirTramos;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtbxCodRecorrido;
        private System.Windows.Forms.Button btnEliminarTodo;
        private System.Windows.Forms.Button btnEnviar;
        private System.Windows.Forms.Label lblPrecioRecorrido;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnCerrar;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridViewTextBoxColumn tramo;
        private System.Windows.Forms.DataGridViewTextBoxColumn puerto_inicio;
        private System.Windows.Forms.DataGridViewTextBoxColumn puerto_fin;
        private System.Windows.Forms.DataGridViewTextBoxColumn precio;
        private System.Windows.Forms.DataGridViewButtonColumn elegir_tramo;
        private System.Windows.Forms.Button btnEliminarUltimoTramo;
        private System.Windows.Forms.DataGridView dgvTramosRecorrido;
        private System.Windows.Forms.DataGridViewTextBoxColumn id_tramo;
        private System.Windows.Forms.DataGridViewTextBoxColumn puerto_inicio_tramo;
        private System.Windows.Forms.DataGridViewTextBoxColumn puerto_fin_tramo;
        private System.Windows.Forms.DataGridViewTextBoxColumn precio_tramo;
        private System.Windows.Forms.Label label5;
    }
}