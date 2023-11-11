using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static tpAgencia_Gpo_2.Login;

namespace tpAgencia_Gpo_2
{
    public partial class FormRegistroUsuario : Form
    {
        private Agencia refAgencia;
        public TransfDelegadoRegistro TransfEventoRegistro;
        private Login Login;
        private MenuAgencia MenuAgencia;
        private MenuAgenciaAdm MenuAgenciaAdm;
        private Form1 form1;
        public FormRegistroUsuario(Agencia agencia, Form1 form1)
        {
            InitializeComponent();
            refAgencia = agencia;
            this.MdiParent = form1;
            this.form1 = form1;
        }


        private void btn_Registrar_Click(object sender, EventArgs e)
        {

            //empty devuelve true si esta vacio
            if (string.IsNullOrEmpty(textBox_nombre.Text) || string.IsNullOrEmpty(textBox_apellido.Text) || string.IsNullOrEmpty(textBox_pass.Text) ||
                string.IsNullOrEmpty(textBox_dni.Text) || string.IsNullOrEmpty(textBox_email.Text) && (refAgencia.existeUsuarioConDniOMail(textBox_dni.Text, textBox_email.Text)))

            {
                MessageBox.Show("Debe completar todos los campos para agregar un usuario.");
            }
            else
            {
                if ((refAgencia.existeUsuarioConDniOMail(textBox_dni.Text, textBox_email.Text)))
                {
                    MessageBox.Show("ya existe un usuario con el mismo mail o dni.");
                    //true
                }
                else
                {
                    if (textBox_nombre.Text.Length >= 3 && textBox_apellido.Text.Length >= 3 && textBox_dni.Text.Length == 8 && textBox_email.Text.Contains("@"))
                    {
                        refAgencia.agregarUsuarioContexto(textBox_dni.Text, textBox_nombre.Text, textBox_apellido.Text, textBox_email.Text, textBox_pass.Text, bool.Parse("false"), bool.Parse("false"));
                        MessageBox.Show("Agregado con éxito");
                        this.volver();
                    }
                    else
                    {
                        MessageBox.Show("Problemas al agregar");
                    }
                }
            }

        }
        public delegate void TransfDelegadoRegistro();
        private void buttonRegistro_volver_Click(object sender, EventArgs e)
        {
            this.volver();
        }

        private void volver()
        {
            this.Close();
            Login = new Login(refAgencia, form1);
            Login.MdiParent = form1;
            Login.TransfEventoLogin += TransfDelegadoLogin;
            Login.Show();
        }


        private void TransfDelegadoLogin()
        {
            MessageBox.Show("Log correcto, Usuario: " + refAgencia.nombreLogueado(), "Inicio de Sesión", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Login.Close();

            if (refAgencia.getUsuarioActual().esAdmin)
            {
                MenuAgenciaAdm = new MenuAgenciaAdm(refAgencia, form1);
                MenuAgenciaAdm.MdiParent = form1;
                MenuAgenciaAdm.Show();
            }
            else
            {
                MenuAgencia = new MenuAgencia(refAgencia, form1);
                MenuAgencia.MdiParent = form1;
                MenuAgencia.Show();
            }
        }

        private void FormRegistroUsuario_Load(object sender, EventArgs e)
        {

        }
    }
}
