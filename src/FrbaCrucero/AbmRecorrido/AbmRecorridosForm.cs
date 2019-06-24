﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FrbaCrucero.AbmRecorrido.EditarRecorrido;
using FrbaCrucero.AbmRecorrido.HabilitacionDeshabilitacionRecorrido;

namespace FrbaCrucero.AbmRecorrido
{
    public partial class AbmRecorridosForm : Form
    {
        public AbmRecorridosForm()
        {
            InitializeComponent();
        }

        private void btnNuevoRecorrido_Click(object sender, EventArgs e)
        {
            AltaRecorridoForm formAltaRecorrido = new AltaRecorridoForm();
            formAltaRecorrido.ShowDialog();
        }

        private void btnEditarRecorrido_Click(object sender, EventArgs e)
        {
            SeleccionRecorridoEditarForm formSeleccionRecorridoEditar = new SeleccionRecorridoEditarForm();
            formSeleccionRecorridoEditar.ShowDialog();
        }

        private void btnDeshabilitarRecorrido_Click(object sender, EventArgs e)
        {
            SeleccionRecorridoDeshabilitarForm formSeleccionRecorridoDeshabilitar = new SeleccionRecorridoDeshabilitarForm();
            formSeleccionRecorridoDeshabilitar.ShowDialog();
        }

        private void btnHabilitarRecorrido_Click(object sender, EventArgs e)
        {
            SeleccionRecorridoHabilitarForm formSeleccionRecorridoHabilitar = new SeleccionRecorridoHabilitarForm();
            formSeleccionRecorridoHabilitar.ShowDialog();
        }
    }
}