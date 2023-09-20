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
using System.Xml.Linq;

namespace tpAgencia_Gpo_2
{
    public partial class FormLoginNuevoUsuario : Form
    {

        public FormLoginNuevoUsuario()
        {
            InitializeComponent();
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void buttonCargarUsuario_Click(object sender, EventArgs e)
        {

        }

        private void CargaNombreNew_TextChanged(object sender, EventArgs e)
        {

        }

        private void checkBoxSiEresAdmin_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void CargaApellidoNew_TextChanged(object sender, EventArgs e)
        {

        }

        private void CargaEmailNew_TextChanged(object sender, EventArgs e)
        {

        }

        private void FormLoginNuevoUsuario_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click_2(object sender, EventArgs e)
        {

        }

        private void textBoxConfirmaEmail_TextChanged(object sender, EventArgs e)
        {

        }

        private void buttonCancelarCargaUsuario_Click(object sender, EventArgs e)
        {
            FormLogin formLogin = new FormLogin();//va a la pagina Login
            this.Hide();
            formLogin.ShowDialog();
        }
    }
}
