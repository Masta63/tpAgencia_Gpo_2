﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static tpAgencia_Gpo_2.BuscadorVuelos;

namespace tpAgencia_Gpo_2
{
    public partial class FormMisHoteles : Form
    {

        private Agencia agencia;
        private Form1 form1;
        private Usuario usuarioActual;
        public TransfDelegadoMisHoteles TransfEventoMisHoteles;
        public FormMisHoteles(Agencia agencia, Form1 form1)
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            this.MdiParent = form1;
            this.agencia = agencia;
            this.form1 = form1;
            usuarioActual = agencia.getUsuarioActual();
            this.Load += FormMisHoteles_Load;
        }

        public delegate void TransfDelegadoMisHoteles();

        private void FormMisHoteles_Load(object sender, EventArgs e)
        {
            MostrarHoteles();
        }
        private void MostrarHoteles()
        {
            dataGridView1.Rows.Clear();
            DateTime fechaActual = DateTime.Now;

            if (usuarioActual != null)
            {
                foreach (var item in agencia.traerMisHoteles(agencia.getUsuarioActual().id))
                {
                    dataGridView1.Rows.Add(item.nombre, item.ubicacion.nombre, item.capacidad, item.costo);
                }
            }
        }

        private void Volver_desde_usuario_Click(object sender, EventArgs e)
        {
            this.Close();
            if (agencia.getUsuarioActual().esAdmin)
            {
                MenuAgenciaAdm menuAgenciaAdm = new MenuAgenciaAdm(agencia, form1);
                menuAgenciaAdm.MdiParent = form1;
                menuAgenciaAdm.Show();
            }
            else
            {
                MenuAgencia MenuAgencia = new MenuAgencia(agencia, form1);
                MenuAgencia.MdiParent = form1;
                MenuAgencia.Show();
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
