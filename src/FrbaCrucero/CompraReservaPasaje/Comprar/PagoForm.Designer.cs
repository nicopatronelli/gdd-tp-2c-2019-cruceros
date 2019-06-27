namespace FrbaCrucero.CompraReservaPasaje
{
    partial class PagoForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected void Dispose(bool disposing)
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
            this.label1 = new System.Windows.Forms.Label();
            this.formaPagoUpDown = new System.Windows.Forms.DomainUpDown();
            this.button1 = new System.Windows.Forms.Button();
            this.infoCompraLabel = new System.Windows.Forms.Label();
            this.labelFormaPago = new System.Windows.Forms.Label();
            this.tarjetaTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 195);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Metodo de Pago";
            // 
            // formaPagoUpDown
            // 
            this.formaPagoUpDown.Location = new System.Drawing.Point(104, 195);
            this.formaPagoUpDown.Name = "formaPagoUpDown";
            this.formaPagoUpDown.ReadOnly = true;
            this.formaPagoUpDown.Size = new System.Drawing.Size(120, 20);
            this.formaPagoUpDown.TabIndex = 1;
            this.formaPagoUpDown.SelectedItemChanged += new System.EventHandler(this.formaPagoUpDown_SelectedItemChanged);
            // 
            // button1
            // 
            this.button1.Enabled = false;
            this.button1.Location = new System.Drawing.Point(369, 235);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(132, 41);
            this.button1.TabIndex = 2;
            this.button1.Text = "Comprar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // infoCompraLabel
            // 
            this.infoCompraLabel.AutoSize = true;
            this.infoCompraLabel.Location = new System.Drawing.Point(32, 27);
            this.infoCompraLabel.Name = "infoCompraLabel";
            this.infoCompraLabel.Size = new System.Drawing.Size(35, 13);
            this.infoCompraLabel.TabIndex = 3;
            this.infoCompraLabel.Text = "label2";
            // 
            // labelFormaPago
            // 
            this.labelFormaPago.AutoSize = true;
            this.labelFormaPago.Location = new System.Drawing.Point(319, 130);
            this.labelFormaPago.Name = "labelFormaPago";
            this.labelFormaPago.Size = new System.Drawing.Size(13, 13);
            this.labelFormaPago.TabIndex = 4;
            this.labelFormaPago.Text = "--";
            // 
            // tarjetaTextBox
            // 
            this.tarjetaTextBox.Location = new System.Drawing.Point(379, 194);
            this.tarjetaTextBox.MaxLength = 16;
            this.tarjetaTextBox.Name = "tarjetaTextBox";
            this.tarjetaTextBox.PasswordChar = '*';
            this.tarjetaTextBox.Size = new System.Drawing.Size(110, 20);
            this.tarjetaTextBox.TabIndex = 5;
            this.tarjetaTextBox.Visible = false;
            this.tarjetaTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tarjetaTextBox_KeyPress);
            // 
            // PagoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(663, 304);
            this.Controls.Add(this.tarjetaTextBox);
            this.Controls.Add(this.labelFormaPago);
            this.Controls.Add(this.infoCompraLabel);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.formaPagoUpDown);
            this.Controls.Add(this.label1);
            this.Name = "PagoForm";
            this.Text = "PagoForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DomainUpDown formaPagoUpDown;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label infoCompraLabel;
        private System.Windows.Forms.Label labelFormaPago;
        private System.Windows.Forms.TextBox tarjetaTextBox;
    }
}