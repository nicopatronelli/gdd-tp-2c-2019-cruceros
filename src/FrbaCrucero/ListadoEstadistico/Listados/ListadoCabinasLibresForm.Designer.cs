namespace FrbaCrucero.ListadoEstadistico
{
    partial class ListadoCabinasLibresForm
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
            this.btnCerrar = new System.Windows.Forms.Button();
            this.gpbxListadoRecPasajeros = new System.Windows.Forms.GroupBox();
            this.dgvListadoEstadistico = new System.Windows.Forms.DataGridView();
            this.gpbxListadoRecPasajeros.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListadoEstadistico)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCerrar
            // 
            this.btnCerrar.Location = new System.Drawing.Point(486, 214);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(75, 23);
            this.btnCerrar.TabIndex = 7;
            this.btnCerrar.Text = "Cerrar";
            this.btnCerrar.UseVisualStyleBackColor = true;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click_1);
            // 
            // gpbxListadoRecPasajeros
            // 
            this.gpbxListadoRecPasajeros.Controls.Add(this.dgvListadoEstadistico);
            this.gpbxListadoRecPasajeros.Location = new System.Drawing.Point(12, 12);
            this.gpbxListadoRecPasajeros.Name = "gpbxListadoRecPasajeros";
            this.gpbxListadoRecPasajeros.Size = new System.Drawing.Size(549, 196);
            this.gpbxListadoRecPasajeros.TabIndex = 6;
            this.gpbxListadoRecPasajeros.TabStop = false;
            this.gpbxListadoRecPasajeros.Text = "Resultados:";
            // 
            // dgvListadoEstadistico
            // 
            this.dgvListadoEstadistico.AllowUserToAddRows = false;
            this.dgvListadoEstadistico.AllowUserToDeleteRows = false;
            this.dgvListadoEstadistico.AllowUserToOrderColumns = true;
            this.dgvListadoEstadistico.AllowUserToResizeColumns = false;
            this.dgvListadoEstadistico.AllowUserToResizeRows = false;
            this.dgvListadoEstadistico.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvListadoEstadistico.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListadoEstadistico.Location = new System.Drawing.Point(11, 23);
            this.dgvListadoEstadistico.Name = "dgvListadoEstadistico";
            this.dgvListadoEstadistico.ReadOnly = true;
            this.dgvListadoEstadistico.Size = new System.Drawing.Size(527, 151);
            this.dgvListadoEstadistico.TabIndex = 0;
            // 
            // ListadoCabinasLibresForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(577, 247);
            this.Controls.Add(this.btnCerrar);
            this.Controls.Add(this.gpbxListadoRecPasajeros);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "ListadoCabinasLibresForm";
            this.Text = "Listado de los primeros 5 recorridos con más cabinas libres";
            this.Load += new System.EventHandler(this.ListadoCabinasLibresForm_Load);
            this.gpbxListadoRecPasajeros.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvListadoEstadistico)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnCerrar;
        private System.Windows.Forms.GroupBox gpbxListadoRecPasajeros;
        protected System.Windows.Forms.DataGridView dgvListadoEstadistico;
    }
}