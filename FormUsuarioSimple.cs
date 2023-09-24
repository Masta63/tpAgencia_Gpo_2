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

namespace tpAgencia_Gpo_2
{
    public partial class FormUsuarioSimple : Form
    {
        private Agencia refAgencia;
        private int usuarioSeleccionado = -1;
        private Usuario seleccionado;
        public FormUsuarioSimple(Agencia agencia)
        {
            InitializeComponent();
            this.refAgencia = agencia;
            //seleccionado = new(1, "juan", "Perez", "33444555", "juan@perez.com", "12345", false);
            //agencia.agregarUsuarioobjet(seleccionado);
           //agencia.setUsuarioActual(seleccionado);

            usuarioSeleccionado = refAgencia.getUsuarioActual().id;
            label_set_usuario_actual.Text = refAgencia.getUsuarioActual().name;
            label_ver_saldo_credito.Text = (refAgencia.getUsuarioActual()?.credito ?? 0) == 0 ? "No posee saldo actual" : refAgencia.getUsuarioActual().credito.ToString();
            textBox_id.Text = refAgencia.getUsuarioActual().id.ToString();
            textBox_nombre.Text = refAgencia.getUsuarioActual().name; ;
            textBox_apellido.Text = refAgencia.getUsuarioActual().apellido; ;
            textBox_email.Text = refAgencia.getUsuarioActual().mail;
            textBox_dni.Text = refAgencia.getUsuarioActual().dni;

        }

        private void FormUsuarioSimple_Load(object sender, EventArgs e)
        {

        }

        private void button_agregar_credito_Click(object sender, EventArgs e)
        {

            if (usuarioSeleccionado != -1)
            {
                if (refAgencia.agregarCredito(usuarioSeleccionado, double.Parse(textBox_MiCredito.Text)))
                {
                    actualizarDatos();
                    MessageBox.Show("Modificado con éxito");
                }

                else
                {
                    MessageBox.Show("Problemas al modificar");//corregir problema de porque entra aca
                }
            }
            else
                MessageBox.Show("Debe seleccionar un usuario");
        }



        private void button_modificar_password_Click(object sender, EventArgs e)
        {

            if (usuarioSeleccionado != -1)
            {
                if(refAgencia.getUsuarioActual().password == textBox_pass_viejo.Text)
                {
                    
                    if (refAgencia.modificarPassword(usuarioSeleccionado, textBox_pass_nuevo.Text))
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
                MessageBox.Show("Debe seleccionar un usuario");
        }

        private void actualizarDatos()
        {
            textBox_MiCredito.Text = string.Empty;
            label_ver_saldo_credito.Text = refAgencia.getUsuarioActual().credito.ToString();


            usuarioSeleccionado = refAgencia.getUsuarioActual().id;
            label_set_usuario_actual.Text = refAgencia.getUsuarioActual().name;
            label_ver_saldo_credito.Text = (refAgencia.getUsuarioActual()?.credito ?? 0) == 0 ? "No posee saldo actual" : refAgencia.getUsuarioActual().credito.ToString();
            textBox_id.Text = refAgencia.getUsuarioActual().id.ToString();
            textBox_nombre.Text = refAgencia.getUsuarioActual().name; ;
            textBox_apellido.Text = refAgencia.getUsuarioActual().apellido; ;
            textBox_email.Text = refAgencia.getUsuarioActual().mail;
            textBox_dni.Text = refAgencia.getUsuarioActual().dni;
        }
    }
}
