using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace tpAgencia_Gpo_2
{
    public partial class Login : Form
    {

        private Agencia agencia;
        private FormRegistroUsuario FormRegistroUsuario;
        public TransfDelegadoLogin TransfEventoLogin;
        private Form1 form1;
        public Login(Agencia agencia, Form1 form1)
        {
            this.agencia = agencia;
            InitializeComponent();        
            this.FormRegistroUsuario = new FormRegistroUsuario(agencia, form1);
            FormRegistroUsuario.MdiParent = form1;
            FormRegistroUsuario.TransfEventoRegistro += TransfDelegadoRegistro;
            this.form1 = form1;
        }

        private void TransfDelegadoRegistro()
        {
            this.MdiParent = form1;
            this.Close();
            FormRegistroUsuario = new FormRegistroUsuario(agencia, form1);
            FormRegistroUsuario.Show();
        }


        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textContrasenia_TextChanged(object sender, EventArgs e)
        {

        }

        public delegate void TransfDelegadoLogin();

        private void Aceptar_Click(object sender, EventArgs e)
        {
            string cont = textContrasenia.Text;
            string mail = textMail.Text;
            string resp = agencia.login(textContrasenia.Text, textMail.Text);

            switch (resp)
            {
                case "OK":
                    agencia.volverIntentosFallidosCeroContext();
                    this.TransfEventoLogin();
                    break;
                case "BLOQUEADO":
                    MessageBox.Show("Error, usuario bloqueado");
                    textContrasenia.Enabled = false;
                    textMail.Enabled = false;
                    Aceptar.Enabled = false;
                    break;
                case "MAILERROR":
                    MessageBox.Show("Error, usuario o contraseña incorrectos");
                    break;
                case "INGRESARDATOS":
                    MessageBox.Show("Debe ingresar un usuario y contraseña!");
                    break;
                case "FALTAUSUARIO":
                    MessageBox.Show("No existe el usuario");
                    break;
                default:
                    break;
            }

        }

        private void btn_registrarse_Click(object sender, EventArgs e)
        {
            this.TransfDelegadoRegistro();
        }
    }

}

