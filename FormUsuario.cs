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
    public partial class FormUsuario : Form
    {
        private Agencia refAgencia;
        private int usuarioSeleccionado;
        private Usuario usuario;

        public FormUsuario(Agencia agencia)
        {
            InitializeComponent();
            this.refAgencia = agencia;
            usuario = new Usuario("juan", "garcia", "22333444", "juan@mail.com");
            agencia.agregarUsuarioobjet(usuario);
            agencia.agregarUsuarioobjet(usuario);
            agencia.agregarUsuarioobjet(usuario);
            Bienvenida_usuario.Text = usuario.name + " " + usuario.apellido;

        }

        private void FormUsuario_Load(object sender, EventArgs e)
        {

        }

        private void button_Agregar_Click(object sender, EventArgs e)
        {
            if (textBox_nombre.Text == " " || textBox_apellido.Text == " " || textBox_dni.Text == " " || textBox_email.Text == " " ||
                textBox_nombre.Text == null || textBox_apellido.Text == null || textBox_dni.Text == null || textBox_email.Text == null
                )
                MessageBox.Show("Debe completar los campos para agregar");
            else
                if (refAgencia.agregarUsuario(textBox_nombre.Text, textBox_apellido.Text, textBox_dni.Text, textBox_email.Text))
                MessageBox.Show("Agregado con éxito");
            else
                MessageBox.Show("Problemas al agregar");
        }

        private void button_Modificar_Click(object sender, EventArgs e)
        {

            if (usuarioSeleccionado != -1)
            {
                if (refAgencia.modificarUsuario(usuarioSeleccionado, textBox_nombre.Text, textBox_apellido.Text, textBox_dni.Text, textBox_email.Text))
                    MessageBox.Show("Modificado con éxito");
                else
                    MessageBox.Show("Problemas al modificar");
            }
            else
                MessageBox.Show("Debe seleccionar un usuario");
        }

        private void button_Eliminar_Click(object sender, EventArgs e)
        {
            if (usuarioSeleccionado != -1)
            {
                if (refAgencia.eliminarUsuario(usuarioSeleccionado))
                    MessageBox.Show("Eliminado con éxito");
                else
                    MessageBox.Show("Problemas al eliminar");
            }
            else
                MessageBox.Show("Debe seleccionar un usuario");
        }

        private void mostrar_usuario_Click(object sender, EventArgs e)
        {
            actualizarDatos();
            usuarioSeleccionado = -1;
        }

        private void actualizarDatos()
        {
            //borro datos
            dataGridView_usuarios.Rows.Clear();

            //agrego
            foreach (Usuario us in refAgencia.getUsuarios())//para cada usuario en el clon de listado de usuarios de mi referencia de agencia
            {
                dataGridView_usuarios.Rows.Add(new string[] { us.id.ToString(), us.name, us.apellido, us.dni.ToString(), us.credito.ToString(), us.mail, us.misReservasHoteles.ToString(), us.misReservasVuelo.ToString() });

                textBox_id.Text = " ";
                textBox_nombre.Text = " ";
                textBox_credito.Text = " ";
                textBox_apellido.Text = " ";
                textBox_email.Text = " ";
                textBox_dni.Text = " ";
                textBox_resHotel.Text = " ";
                textBox_resVuelo.Text = " ";

            }
        }

        private void Volver_desde_usuario_Click(object sender, EventArgs e)
        {
            //aca va el metodo delegado para navegar entre paginas
        }

        private void dataGridView_usuarios_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string id = dataGridView_usuarios[0, e.RowIndex].Value.ToString();
            string nombre = dataGridView_usuarios[1, e.RowIndex].Value.ToString();
            string apellido = dataGridView_usuarios[2, e.RowIndex].Value.ToString();
            string dni = dataGridView_usuarios[3, e.RowIndex].Value.ToString();
            string credito = dataGridView_usuarios[4, e.RowIndex].Value.ToString();
            string email = dataGridView_usuarios[5, e.RowIndex].Value.ToString();
            string resHotel = dataGridView_usuarios[6, e.RowIndex].Value.ToString();
            string resVuelo = dataGridView_usuarios[7, e.RowIndex].Value.ToString();
            textBox_id.Text = id;
            textBox_nombre.Text = nombre;
            textBox_apellido.Text = apellido;
            textBox_email.Text = email;
            textBox_dni.Text = dni;
            textBox_credito.Text = credito;
            textBox_resHotel.Text = resHotel;
            textBox_resVuelo.Text = resVuelo;


            usuarioSeleccionado = int.Parse(id);

        }


        private void textBox_credito_TextChanged(object sender, EventArgs e)
        {
            foreach (Usuario us in refAgencia.getUsuarios())
            {
                textBox_credito.Text = us.credito.ToString();
            }
        }

        private void btn_agregarCredito_Click(object sender, EventArgs e)
        {
            if (usuarioSeleccionado != -1)
            {
                if (refAgencia.agregarCredito(usuarioSeleccionado, double.Parse(textBox_credito.Text)))
                    MessageBox.Show("Modificado con éxito");
                else
                    MessageBox.Show("Problemas al modificar");
            }
            else
                MessageBox.Show("Debe seleccionar un usuario");
        }

        private void btn_modificarCredito_Click_1(object sender, EventArgs e)
        {
            if (usuarioSeleccionado != -1)
            {
                if (refAgencia.modificarCredito(usuarioSeleccionado, double.Parse(textBox_credito.Text)))
                    MessageBox.Show("Modificado con éxito");
                else
                    MessageBox.Show("Problemas al modificar");
            }
            else
                MessageBox.Show("Debe seleccionar un usuario");
        }
    }
}
