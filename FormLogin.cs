using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace tpAgencia_Gpo_2
{
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            ingresoUsuario.Clear();
            ingresoClave.Clear();
        }

        private void checkBoxAdmin_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void FormLogin_Load(object sender, EventArgs e)
        {

        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            if (checkBoxAdmin.Checked == true && ingresoUsuario.Text == "admin" && ingresoClave.Text == "1234")
            {
                Form1 form1 = new Form1();//va a la pagina de crud
                this.Hide();
                form1.ShowDialog();
            }
            else if (checkBoxAdmin.Checked == false && ingresoUsuario.Text == "usuario" && ingresoClave.Text == "1234")
            {
                Form1 form1 = new Form1();//va a la pagina de cliente
                this.Hide();
                form1.ShowDialog();
            }
            else
            {
                MessageBox.Show("Los datos ingresados no son correctos");
                ingresoUsuario.Clear();
                ingresoClave.Clear();
            }

        }

        private void btnNuevoUsuario_Click(object sender, EventArgs e)
        {
            FormLoginNuevoUsuario formLoginNuevoUsuario = new FormLoginNuevoUsuario();//va a la pagina para crear nuevo cliente/usuario
            this.Hide();
            formLoginNuevoUsuario.ShowDialog();
        }
    }
}
