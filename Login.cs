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

        public TransfDelegadoLogin TransfEventoLogin;

        public Login(Agencia agencia)
        {
            this.agencia = agencia;
            InitializeComponent();
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

    }

}

