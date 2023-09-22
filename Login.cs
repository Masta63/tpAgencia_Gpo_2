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
                var usuariosSeleccionados = agencia.getListUsuario().Where(x => x.mail == mail).ToList();
                validacionEstadoUsuario(usuariosSeleccionados, mail, cont);
            }
            else
                MessageBox.Show("Debe ingresar un usuario y contraseña!");
        }


        private void validacionEstadoUsuario(List<Usuario> usuariosSeleccionados, string mailInput, string Inputpass)
        {
            if (usuariosSeleccionados.Count == 0)
            {
                MessageBox.Show("Error, debe ingresar un usuario existente");
            }
            else
            {
                string respLogin = agencia.iniciarSesion(usuariosSeleccionados, mailInput, Inputpass, checkBoxEsAdmin.Checked);
                switch (respLogin)
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
                    default:
                        break;
                }
            }
        }

    }

}

