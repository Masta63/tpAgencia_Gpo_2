using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using static tpAgencia_Gpo_2.FormUsuario;

namespace tpAgencia_Gpo_2
{
    public partial class FormUsuarioSimple : Form
    {
        private Agencia refAgencia;
        private Form1 form1;
        private Usuario usuarioActual;
        public TransfDelegadoFormUsuarioSimple TransfEventoFormUsuarioSimple;
        public FormUsuarioSimple(Agencia agencia, Form1 form1)
        {
            InitializeComponent();
            this.refAgencia = agencia;
            this.form1 = form1;
            this.MdiParent = form1;
            usuarioActual = agencia.getUsuarioActual();
            this.WindowState = FormWindowState.Maximized;

            //seleccionado = new(1, "juan", "Perez", "33444555", "juan@perez.com", "12345", false);
            //agencia.agregarUsuarioobjet(seleccionado);
            //agencia.setUsuarioActual(seleccionado);
            actualizarDatos();

        }
        public delegate void TransfDelegadoFormUsuarioSimple();
        private void FormUsuarioSimple_Load(object sender, EventArgs e)
        {

        }

        private void button_agregar_credito_Click(object sender, EventArgs e)
        {

            if (usuarioActual != null)
            {
                if (double.TryParse(textBox_MiCredito.Text, out double nuevoCredito))
                {
                    if (refAgencia.AgregarCreditoDal(usuarioActual.id, nuevoCredito))
                    {
                        MessageBox.Show("Modificado con éxito");
                    }
                    else
                    {
                        MessageBox.Show("Problemas al modificar");
                    }
                }
                else
                {
                    MessageBox.Show("El valor ingresado en 'Mi Crédito' no es válido.");
                }
            }
            else
            {
                MessageBox.Show("Debe seleccionar un usuario");
            }
            actualizarDatos();

        }



        private void button_modificar_password_Click(object sender, EventArgs e)
        {

            if (usuarioActual != null)
            {
                if (refAgencia.getUsuarioActual().password.Trim() != textBox_pass_nuevo.Text.Trim())
                {

                    if (refAgencia.modificarUsuarioDal(usuarioActual.id,usuarioActual.name,usuarioActual.apellido,int.Parse(usuarioActual.dni),usuarioActual.mail, textBox_pass_nuevo.Text))
                    {

                        MessageBox.Show("Modificado con éxito");
                    }

                    else
                    {
                        MessageBox.Show("Problemas al modificar");//corregir problema de porque entra aca
                    }
                }

            }
            else
            {
                MessageBox.Show("Debe seleccionar un usuario");
            }
            actualizarDatos();
        }

        private void actualizarDatos()
        {
            textBox_MiCredito.Text = string.Empty;

            if (usuarioActual != null)
            {
                label_ver_saldo_credito.Text = refAgencia.getUsuarioActual().credito.ToString().Trim();
                usuarioActual = refAgencia.getUsuarioActual();
                label_set_usuario_actual.Text = refAgencia.getUsuarioActual().name.Trim();
                label_ver_saldo_credito.Text = (refAgencia.getUsuarioActual()?.credito ?? 0) == 0 ? "No posee saldo actual" : refAgencia.getUsuarioActual().credito.ToString().Trim();
                textBox_id.Text = refAgencia.getUsuarioActual().id.ToString().Trim();
                textBox_nombre.Text = refAgencia.getUsuarioActual().name.Trim(); ;
                textBox_apellido.Text = refAgencia.getUsuarioActual().apellido.Trim(); ;
                textBox_email.Text = refAgencia.getUsuarioActual().mail.Trim();
                textBox_dni.Text = refAgencia.getUsuarioActual().dni.Trim();
            }


        }

        private void button_Modificar_Click(object sender, EventArgs e)
        {

            //isnullorempty devuelve true si esta vacio
            if (usuarioActual != null)
            {
                if (!string.IsNullOrEmpty(textBox_nombre.Text) && !string.IsNullOrEmpty(textBox_apellido.Text) &&
                    !string.IsNullOrEmpty(textBox_dni.Text) && !string.IsNullOrEmpty(textBox_email.Text))
                {
                    //id    nombre  apellido    dni     email
                    if (refAgencia.modificarUsuarioDal(usuarioActual.id, textBox_nombre.Text, textBox_apellido.Text, int.Parse(textBox_dni.Text), textBox_email.Text,textBox_pass_nuevo.Text))
                    {
                        MessageBox.Show("Modificado con éxito");
                    }
                    else
                    {
                        MessageBox.Show("Problemas al modificar");
                    }
                }
                else
                {
                    MessageBox.Show("no pueden haber datos incompletos");
                }

            }
            else
            {
                MessageBox.Show("Debe seleccionar un usuario y no puede haber datos incompletos");
            }

            actualizarDatos();
        }

        private void Volver_desde_usuario_Click(object sender, EventArgs e)
        {
            this.Close();
            if (refAgencia.getUsuarioActual().esAdmin)
            {
                MenuAgenciaAdm menuAgenciaAdm = new MenuAgenciaAdm(refAgencia, form1);
                menuAgenciaAdm.MdiParent = form1;
                menuAgenciaAdm.Show();
            }
            else
            {
                MenuAgencia MenuAgencia = new MenuAgencia(refAgencia, form1);
                MenuAgencia.MdiParent = form1;
                MenuAgencia.Show();
            }
        }
    }
}
