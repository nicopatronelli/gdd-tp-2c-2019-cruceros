namespace FrbaCrucero.AbmRol
{
    partial class CrearRolForm
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
            this.gpbxCrearNuevoRol = new System.Windows.Forms.GroupBox();
            this.btnCrearRol = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.chbxAbmCruceros = new System.Windows.Forms.CheckBox();
            this.chbxGenerarViaje = new System.Windows.Forms.CheckBox();
            this.chbxAbmRol = new System.Windows.Forms.CheckBox();
            this.chbxListadosEstadisticos = new System.Windows.Forms.CheckBox();
            this.chbxAbmRecorridos = new System.Windows.Forms.CheckBox();
            this.chbxAbmPuertos = new System.Windows.Forms.CheckBox();
            this.chbxPagoReserva = new System.Windows.Forms.CheckBox();
            this.chbxComprarReservarViaje = new System.Windows.Forms.CheckBox();
            this.gpbxNombreRol = new System.Windows.Forms.GroupBox();
            this.txtbxNombreRol = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.gpbxCrearNuevoRol.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.gpbxNombreRol.SuspendLayout();
            this.SuspendLayout();
            // 
            // gpbxCrearNuevoRol
            // 
            this.gpbxCrearNuevoRol.Controls.Add(this.btnCrearRol);
            this.gpbxCrearNuevoRol.Controls.Add(this.button1);
            this.gpbxCrearNuevoRol.Controls.Add(this.groupBox3);
            this.gpbxCrearNuevoRol.Controls.Add(this.gpbxNombreRol);
            this.gpbxCrearNuevoRol.Location = new System.Drawing.Point(21, 12);
            this.gpbxCrearNuevoRol.Name = "gpbxCrearNuevoRol";
            this.gpbxCrearNuevoRol.Size = new System.Drawing.Size(509, 316);
            this.gpbxCrearNuevoRol.TabIndex = 3;
            this.gpbxCrearNuevoRol.TabStop = false;
            this.gpbxCrearNuevoRol.Text = "Complete los campos y pulse Crear para crear un nuevo Rol";
            // 
            // btnCrearRol
            // 
            this.btnCrearRol.Location = new System.Drawing.Point(325, 287);
            this.btnCrearRol.Name = "btnCrearRol";
            this.btnCrearRol.Size = new System.Drawing.Size(75, 23);
            this.btnCrearRol.TabIndex = 5;
            this.btnCrearRol.Text = "Crear";
            this.btnCrearRol.UseVisualStyleBackColor = true;
            this.btnCrearRol.Click += new System.EventHandler(this.btnCrearRol_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(415, 287);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "Cerrar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.chbxAbmCruceros);
            this.groupBox3.Controls.Add(this.chbxGenerarViaje);
            this.groupBox3.Controls.Add(this.chbxAbmRol);
            this.groupBox3.Controls.Add(this.chbxListadosEstadisticos);
            this.groupBox3.Controls.Add(this.chbxAbmRecorridos);
            this.groupBox3.Controls.Add(this.chbxAbmPuertos);
            this.groupBox3.Controls.Add(this.chbxPagoReserva);
            this.groupBox3.Controls.Add(this.chbxComprarReservarViaje);
            this.groupBox3.Location = new System.Drawing.Point(10, 95);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(480, 186);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Marque las funcionalidades deseadas (debe marcar al menos una):";
            // 
            // chbxAbmCruceros
            // 
            this.chbxAbmCruceros.AutoSize = true;
            this.chbxAbmCruceros.Location = new System.Drawing.Point(315, 113);
            this.chbxAbmCruceros.Name = "chbxAbmCruceros";
            this.chbxAbmCruceros.Size = new System.Drawing.Size(94, 17);
            this.chbxAbmCruceros.TabIndex = 11;
            this.chbxAbmCruceros.Text = "ABM Cruceros";
            this.chbxAbmCruceros.UseVisualStyleBackColor = true;
            // 
            // chbxGenerarViaje
            // 
            this.chbxGenerarViaje.AutoSize = true;
            this.chbxGenerarViaje.Location = new System.Drawing.Point(18, 113);
            this.chbxGenerarViaje.Name = "chbxGenerarViaje";
            this.chbxGenerarViaje.Size = new System.Drawing.Size(90, 17);
            this.chbxGenerarViaje.TabIndex = 8;
            this.chbxGenerarViaje.Text = "Generar Viaje";
            this.chbxGenerarViaje.UseVisualStyleBackColor = true;
            // 
            // chbxAbmRol
            // 
            this.chbxAbmRol.AutoSize = true;
            this.chbxAbmRol.Enabled = false;
            this.chbxAbmRol.Location = new System.Drawing.Point(191, 38);
            this.chbxAbmRol.Name = "chbxAbmRol";
            this.chbxAbmRol.Size = new System.Drawing.Size(68, 17);
            this.chbxAbmRol.TabIndex = 7;
            this.chbxAbmRol.Text = "ABM Rol";
            this.chbxAbmRol.UseVisualStyleBackColor = true;
            // 
            // chbxListadosEstadisticos
            // 
            this.chbxListadosEstadisticos.AutoSize = true;
            this.chbxListadosEstadisticos.Location = new System.Drawing.Point(152, 113);
            this.chbxListadosEstadisticos.Name = "chbxListadosEstadisticos";
            this.chbxListadosEstadisticos.Size = new System.Drawing.Size(126, 17);
            this.chbxListadosEstadisticos.TabIndex = 6;
            this.chbxListadosEstadisticos.Text = "Listados Estadísticos";
            this.chbxListadosEstadisticos.UseVisualStyleBackColor = true;
            // 
            // chbxAbmRecorridos
            // 
            this.chbxAbmRecorridos.AutoSize = true;
            this.chbxAbmRecorridos.Location = new System.Drawing.Point(152, 74);
            this.chbxAbmRecorridos.Name = "chbxAbmRecorridos";
            this.chbxAbmRecorridos.Size = new System.Drawing.Size(103, 17);
            this.chbxAbmRecorridos.TabIndex = 4;
            this.chbxAbmRecorridos.Text = "ABM Recorridos";
            this.chbxAbmRecorridos.UseVisualStyleBackColor = true;
            // 
            // chbxAbmPuertos
            // 
            this.chbxAbmPuertos.AutoSize = true;
            this.chbxAbmPuertos.Location = new System.Drawing.Point(20, 74);
            this.chbxAbmPuertos.Name = "chbxAbmPuertos";
            this.chbxAbmPuertos.Size = new System.Drawing.Size(88, 17);
            this.chbxAbmPuertos.TabIndex = 3;
            this.chbxAbmPuertos.Text = "ABM Puertos";
            this.chbxAbmPuertos.UseVisualStyleBackColor = true;
            // 
            // chbxPagoReserva
            // 
            this.chbxPagoReserva.AutoSize = true;
            this.chbxPagoReserva.Location = new System.Drawing.Point(315, 74);
            this.chbxPagoReserva.Name = "chbxPagoReserva";
            this.chbxPagoReserva.Size = new System.Drawing.Size(109, 17);
            this.chbxPagoReserva.TabIndex = 1;
            this.chbxPagoReserva.Text = "Pago de Reserva";
            this.chbxPagoReserva.UseVisualStyleBackColor = true;
            // 
            // chbxComprarReservarViaje
            // 
            this.chbxComprarReservarViaje.AutoSize = true;
            this.chbxComprarReservarViaje.Location = new System.Drawing.Point(20, 38);
            this.chbxComprarReservarViaje.Name = "chbxComprarReservarViaje";
            this.chbxComprarReservarViaje.Size = new System.Drawing.Size(139, 17);
            this.chbxComprarReservarViaje.TabIndex = 0;
            this.chbxComprarReservarViaje.Text = "Comprar/Reservar Viaje";
            this.chbxComprarReservarViaje.UseVisualStyleBackColor = true;
            // 
            // gpbxNombreRol
            // 
            this.gpbxNombreRol.Controls.Add(this.txtbxNombreRol);
            this.gpbxNombreRol.Controls.Add(this.label1);
            this.gpbxNombreRol.Location = new System.Drawing.Point(10, 28);
            this.gpbxNombreRol.Name = "gpbxNombreRol";
            this.gpbxNombreRol.Size = new System.Drawing.Size(480, 51);
            this.gpbxNombreRol.TabIndex = 2;
            this.gpbxNombreRol.TabStop = false;
            this.gpbxNombreRol.Text = "Ingrese un nombre para el nuevo rol (Campo obligatorio):";
            // 
            // txtbxNombreRol
            // 
            this.txtbxNombreRol.Location = new System.Drawing.Point(70, 20);
            this.txtbxNombreRol.Name = "txtbxNombreRol";
            this.txtbxNombreRol.Size = new System.Drawing.Size(189, 20);
            this.txtbxNombreRol.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Nombre:";
            // 
            // CrearRolForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(552, 342);
            this.Controls.Add(this.gpbxCrearNuevoRol);
            this.Name = "CrearRolForm";
            this.Text = "Crear nuevo Rol";
            this.Load += new System.EventHandler(this.CrearRolForm_Load);
            this.gpbxCrearNuevoRol.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.gpbxNombreRol.ResumeLayout(false);
            this.gpbxNombreRol.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gpbxCrearNuevoRol;
        private System.Windows.Forms.Button btnCrearRol;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.CheckBox chbxAbmCruceros;
        private System.Windows.Forms.CheckBox chbxGenerarViaje;
        private System.Windows.Forms.CheckBox chbxAbmRol;
        private System.Windows.Forms.CheckBox chbxListadosEstadisticos;
        private System.Windows.Forms.CheckBox chbxAbmRecorridos;
        private System.Windows.Forms.CheckBox chbxAbmPuertos;
        private System.Windows.Forms.CheckBox chbxPagoReserva;
        private System.Windows.Forms.CheckBox chbxComprarReservarViaje;
        private System.Windows.Forms.GroupBox gpbxNombreRol;
        private System.Windows.Forms.TextBox txtbxNombreRol;
        private System.Windows.Forms.Label label1;
    }
}