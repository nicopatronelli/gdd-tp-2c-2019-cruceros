namespace FrbaCrucero.CompraReservaPasaje
{
    partial class VoucherForm
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
            this.esCompraOReservaLabel = new System.Windows.Forms.Label();
            this.precioTotalLabel = new System.Windows.Forms.Label();
            this.codigoVoucherLabel = new System.Windows.Forms.Label();
            this.viajeLabel = new System.Windows.Forms.Label();
            this.cabinasLabel = new System.Windows.Forms.Label();
            this.clienteLabel = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // esCompraOReservaLabel
            // 
            this.esCompraOReservaLabel.AutoSize = true;
            this.esCompraOReservaLabel.Location = new System.Drawing.Point(32, 9);
            this.esCompraOReservaLabel.Name = "esCompraOReservaLabel";
            this.esCompraOReservaLabel.Size = new System.Drawing.Size(68, 13);
            this.esCompraOReservaLabel.TabIndex = 0;
            this.esCompraOReservaLabel.Text = "Voucher de: ";
            // 
            // precioTotalLabel
            // 
            this.precioTotalLabel.AutoSize = true;
            this.precioTotalLabel.Location = new System.Drawing.Point(32, 36);
            this.precioTotalLabel.Name = "precioTotalLabel";
            this.precioTotalLabel.Size = new System.Drawing.Size(92, 13);
            this.precioTotalLabel.TabIndex = 1;
            this.precioTotalLabel.Text = "El Precio total es: ";
            // 
            // codigoVoucherLabel
            // 
            this.codigoVoucherLabel.AutoSize = true;
            this.codigoVoucherLabel.Location = new System.Drawing.Point(32, 65);
            this.codigoVoucherLabel.Name = "codigoVoucherLabel";
            this.codigoVoucherLabel.Size = new System.Drawing.Size(151, 13);
            this.codigoVoucherLabel.TabIndex = 2;
            this.codigoVoucherLabel.Text = "El codigo de este voucher es: ";
            // 
            // viajeLabel
            // 
            this.viajeLabel.AutoSize = true;
            this.viajeLabel.Location = new System.Drawing.Point(32, 91);
            this.viajeLabel.Name = "viajeLabel";
            this.viajeLabel.Size = new System.Drawing.Size(55, 13);
            this.viajeLabel.TabIndex = 3;
            this.viajeLabel.Text = "viajeLabel";
            // 
            // cabinasLabel
            // 
            this.cabinasLabel.AutoSize = true;
            this.cabinasLabel.Location = new System.Drawing.Point(243, 9);
            this.cabinasLabel.Name = "cabinasLabel";
            this.cabinasLabel.Size = new System.Drawing.Size(10, 13);
            this.cabinasLabel.TabIndex = 4;
            this.cabinasLabel.Text = "-";
            // 
            // clienteLabel
            // 
            this.clienteLabel.AutoSize = true;
            this.clienteLabel.Location = new System.Drawing.Point(556, 9);
            this.clienteLabel.Name = "clienteLabel";
            this.clienteLabel.Size = new System.Drawing.Size(100, 13);
            this.clienteLabel.TabIndex = 5;
            this.clienteLabel.Text = "Informacion Cliente:";
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.button1.Location = new System.Drawing.Point(559, 359);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(194, 49);
            this.button1.TabIndex = 6;
            this.button1.Text = "IMPRIMIR";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // VoucherForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1013, 420);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.clienteLabel);
            this.Controls.Add(this.cabinasLabel);
            this.Controls.Add(this.viajeLabel);
            this.Controls.Add(this.codigoVoucherLabel);
            this.Controls.Add(this.precioTotalLabel);
            this.Controls.Add(this.esCompraOReservaLabel);
            this.Name = "VoucherForm";
            this.Text = "VoucherForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label esCompraOReservaLabel;
        private System.Windows.Forms.Label precioTotalLabel;
        private System.Windows.Forms.Label codigoVoucherLabel;
        private System.Windows.Forms.Label viajeLabel;
        private System.Windows.Forms.Label cabinasLabel;
        private System.Windows.Forms.Label clienteLabel;
        private System.Windows.Forms.Button button1;
    }
}