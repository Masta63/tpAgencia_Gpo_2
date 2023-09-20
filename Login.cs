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
            if (cont != null && mail != "" && cont != null && mail != "")
            {
                if (agencia.iniciarSesion(cont, mail))
                    this.TransfEventoLogin();
                else
                    MessageBox.Show("Error, usuario o contraseña incorrectos");
            }
            else
                MessageBox.Show("Debe ingresar un usuario y contraseña!");
        }
    }
}
