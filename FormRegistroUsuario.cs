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
    public partial class FormRegistroUsuario : Form
    {
        private Agencia refAgencia;

        public FormRegistroUsuario(Agencia agencia)
        {
            InitializeComponent();
            refAgencia = agencia;
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
                        refAgencia.agregarUsuarioDal(textBox_dni.Text, textBox_nombre.Text, textBox_apellido.Text, textBox_email.Text, textBox_pass.Text,bool.Parse("false"), bool.Parse("false"));
                        MessageBox.Show("Agregado con éxito");
                    }
                    else
                    {
                        MessageBox.Show("Problemas al agregar");
                    }
                }
            }
        }
    }
}
