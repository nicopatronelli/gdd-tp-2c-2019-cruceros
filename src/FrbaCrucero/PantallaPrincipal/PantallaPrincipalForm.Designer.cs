namespace FrbaCrucero.PantallaPrincipal
{
    partial class PantallaPrincipalForm
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnAbmRol = new System.Windows.Forms.Button();
            this.btnListado = new System.Windows.Forms.Button();
            this.btnAbmCruceros = new System.Windows.Forms.Button();
            this.btnGenerarViaje = new System.Windows.Forms.Button();
            this.btnAbmRecorrido = new System.Windows.Forms.Button();
            this.btnAbmPuertos = new System.Windows.Forms.Button();
            this.btnPagarReserva = new System.Windows.Forms.Button();
            this.btnComprarReservar = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCerrar
            // 
            this.btnCerrar.Location = new System.Drawing.Point(386, 162);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(75, 23);
            this.btnCerrar.TabIndex = 15;
            this.btnCerrar.Text = "Cerrar";
            this.btnCerrar.UseVisualStyleBackColor = true;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnAbmRol);
            this.groupBox1.Controls.Add(this.btnListado);
            this.groupBox1.Controls.Add(this.btnAbmCruceros);
            this.groupBox1.Controls.Add(this.btnGenerarViaje);
            this.groupBox1.Controls.Add(this.btnAbmRecorrido);
            this.groupBox1.Controls.Add(this.btnAbmPuertos);
            this.groupBox1.Controls.Add(this.btnPagarReserva);
            this.groupBox1.Controls.Add(this.btnComprarReservar);
            this.groupBox1.Location = new System.Drawing.Point(27, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(434, 144);
            this.groupBox1.TabIndex = 14;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Funcionalidades disponibles";
            // 
            // btnAbmRol
            // 
            this.btnAbmRol.Location = new System.Drawing.Point(15, 28);
            this.btnAbmRol.Name = "btnAbmRol";
            this.btnAbmRol.Size = new System.Drawing.Size(129, 23);
            this.btnAbmRol.TabIndex = 25;
            this.btnAbmRol.Text = "ABM Rol";
            this.btnAbmRol.UseVisualStyleBackColor = true;
            this.btnAbmRol.Click += new System.EventHandler(this.btnAbmRol_Click);
            // 
            // btnListado
            // 
            this.btnListado.Location = new System.Drawing.Point(150, 104);
            this.btnListado.Name = "btnListado";
            this.btnListado.Size = new System.Drawing.Size(129, 23);
            this.btnListado.TabIndex = 24;
            this.btnListado.Text = "Listados Estadísticos";
            this.btnListado.UseVisualStyleBackColor = true;
            this.btnListado.Click += new System.EventHandler(this.btnListado_Click);
            // 
            // btnAbmCruceros
            // 
            this.btnAbmCruceros.Location = new System.Drawing.Point(285, 28);
            this.btnAbmCruceros.Name = "btnAbmCruceros";
            this.btnAbmCruceros.Size = new System.Drawing.Size(129, 23);
            this.btnAbmCruceros.TabIndex = 22;
            this.btnAbmCruceros.Text = "ABM Cruceros";
            this.btnAbmCruceros.UseVisualStyleBackColor = true;
            this.btnAbmCruceros.Click += new System.EventHandler(this.btnAbmCruceros_Click);
            // 
            // btnGenerarViaje
            // 
            this.btnGenerarViaje.Location = new System.Drawing.Point(150, 66);
            this.btnGenerarViaje.Name = "btnGenerarViaje";
            this.btnGenerarViaje.Size = new System.Drawing.Size(129, 23);
            this.btnGenerarViaje.TabIndex = 23;
            this.btnGenerarViaje.Text = "Generar Viaje";
            this.btnGenerarViaje.UseVisualStyleBackColor = true;
            this.btnGenerarViaje.Click += new System.EventHandler(this.btnGenerarViaje_Click);
            // 
            // btnAbmRecorrido
            // 
            this.btnAbmRecorrido.Location = new System.Drawing.Point(15, 66);
            this.btnAbmRecorrido.Name = "btnAbmRecorrido";
            this.btnAbmRecorrido.Size = new System.Drawing.Size(129, 23);
            this.btnAbmRecorrido.TabIndex = 21;
            this.btnAbmRecorrido.Text = "ABM Recorrido";
            this.btnAbmRecorrido.UseVisualStyleBackColor = true;
            this.btnAbmRecorrido.Click += new System.EventHandler(this.btnAbmRecorrido_Click);
            // 
            // btnAbmPuertos
            // 
            this.btnAbmPuertos.Location = new System.Drawing.Point(150, 28);
            this.btnAbmPuertos.Name = "btnAbmPuertos";
            this.btnAbmPuertos.Size = new System.Drawing.Size(129, 23);
            this.btnAbmPuertos.TabIndex = 20;
            this.btnAbmPuertos.Text = "ABM Puertos";
            this.btnAbmPuertos.UseVisualStyleBackColor = true;
            this.btnAbmPuertos.Click += new System.EventHandler(this.btnAbmPuertos_Click);
            // 
            // btnPagarReserva
            // 
            this.btnPagarReserva.Location = new System.Drawing.Point(15, 104);
            this.btnPagarReserva.Name = "btnPagarReserva";
            this.btnPagarReserva.Size = new System.Drawing.Size(129, 23);
            this.btnPagarReserva.TabIndex = 18;
            this.btnPagarReserva.Text = "Pagar Reserva";
            this.btnPagarReserva.UseVisualStyleBackColor = true;
            this.btnPagarReserva.Click += new System.EventHandler(this.btnPagarReserva_Click);
            // 
            // btnComprarReservar
            // 
            this.btnComprarReservar.Location = new System.Drawing.Point(285, 66);
            this.btnComprarReservar.Name = "btnComprarReservar";
            this.btnComprarReservar.Size = new System.Drawing.Size(129, 23);
            this.btnComprarReservar.TabIndex = 16;
            this.btnComprarReservar.Text = "Comprar/Reservar Viaje";
            this.btnComprarReservar.UseVisualStyleBackColor = true;
            this.btnComprarReservar.Click += new System.EventHandler(this.btnComprarReservar_Click);
            // 
            // PantallaPrincipalForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(481, 198);
            this.Controls.Add(this.btnCerrar);
            this.Controls.Add(this.groupBox1);
            this.Name = "PantallaPrincipalForm";
            this.Text = "Pantalla Principal";
            this.Load += new System.EventHandler(this.PantallaPrincipalForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnCerrar;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnAbmRol;
        private System.Windows.Forms.Button btnListado;
        private System.Windows.Forms.Button btnAbmCruceros;
        private System.Windows.Forms.Button btnGenerarViaje;
        private System.Windows.Forms.Button btnAbmRecorrido;
        private System.Windows.Forms.Button btnAbmPuertos;
        private System.Windows.Forms.Button btnPagarReserva;
        private System.Windows.Forms.Button btnComprarReservar;
    }
}