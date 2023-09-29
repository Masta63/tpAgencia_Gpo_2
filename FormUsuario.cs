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
using static tpAgencia_Gpo_2.Login;

namespace tpAgencia_Gpo_2
{
    public partial class FormUsuario : Form
    {
        private Agencia refAgencia;
        private int usuarioSeleccionado;
        public TransfDelegadoFormUsuario TransfEventoFormUsuario;
        private Form1 form1;
        public FormUsuario(Agencia agencia, Form1 form1)
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            this.refAgencia = agencia;

            //usuario = new Usuario("juan", "garcia", "22333444", "juan@mail.com");
            //agencia.agregarUsuarioobjet(usuario);
            //usuario = new Usuario("pedro", "pascal", "33444555", "pedro@mail.com");
            //agencia.agregarUsuarioobjet(usuario);
            //usuario = new Usuario("florencia", "pereyra", "3555444", "flor@mail.com");
            //agencia.agregarUsuarioobjet(usuario);
            //cuando este iniciada la sesion y el usuario que inicio se guarde en la variable usuario actual deberia mostrarse el nombre y apellido
            //Bienvenida_usuario.Text = refAgencia.mostarUsuarioActual();


            Bienvenida_usuario.Text = agencia.getUsuarioActual().name + " " + agencia.getUsuarioActual().apellido;
            this.form1 = form1;

        }

        private void FormUsuario_Load(object sender, EventArgs e)
        {

        }
        public delegate void TransfDelegadoFormUsuario();

        private void button_Agregar_Click(object sender, EventArgs e)
        {

            //empty devuelve true si esta vacio
            if (string.IsNullOrEmpty(textBox_nombre.Text) || string.IsNullOrEmpty(textBox_apellido.Text) ||
                string.IsNullOrEmpty(textBox_dni.Text) || string.IsNullOrEmpty(textBox_email.Text) && (refAgencia.ExisteUsuarioConDniOMail(textBox_dni.Text, textBox_email.Text)))

            {
                MessageBox.Show("Debe completar todos los campos para agregar un usuario.");
            }
            else
            {
                if ((refAgencia.ExisteUsuarioConDniOMail(textBox_dni.Text, textBox_email.Text)))
                {
                    MessageBox.Show("ya existe un usuario con el mismo maiol o dni.");
                    //true
                }
                else
                {
                    if (usuarioSeleccionado != -1  )                       
                    {
                        refAgencia.agregarUsuario(textBox_nombre.Text, textBox_apellido.Text, textBox_dni.Text, textBox_email.Text);
                        MessageBox.Show("Agregado con éxito");
                    }
                    else
                    {
                        MessageBox.Show("Problemas al agregar");
                    }
                }
            }

        }


        private void button_Modificar_Click(object sender, EventArgs e)
        {

            //isnullorempty devuelve true si esta vacio
            if (usuarioSeleccionado != -1)
            {
                if (!string.IsNullOrEmpty(textBox_nombre.Text) && !string.IsNullOrEmpty(textBox_apellido.Text) &&
                    !string.IsNullOrEmpty(textBox_dni.Text) && !string.IsNullOrEmpty(textBox_email.Text))
                {
                    if (refAgencia.modificarUsuario(usuarioSeleccionado, textBox_nombre.Text, textBox_apellido.Text, textBox_dni.Text, textBox_email.Text))
                    {
                        MessageBox.Show("Modificado con éxito");
                    }
                    else
                    {
                        MessageBox.Show("Problemas al modificar");
                    }
                }
                else
                {
                    MessageBox.Show("no pueden haber datos incompletos");
                }
                
            }
            else
            {
                MessageBox.Show("Debe seleccionar un usuario y no puede haber datos incompletos");
            }
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
            this.Close();
            MenuAgencia MenuAgencia = new MenuAgencia(refAgencia, form1);
            MenuAgencia.MdiParent = form1;
            MenuAgencia.Show();
        }

        private void dataGridView_usuarios_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {



            try
            {
                string? id = dataGridView_usuarios[0, e.RowIndex]?.Value?.ToString();
                string? nombre = dataGridView_usuarios[1, e.RowIndex]?.Value?.ToString();
                string? apellido = dataGridView_usuarios[2, e.RowIndex]?.Value?.ToString();
                string? dni = dataGridView_usuarios[3, e.RowIndex]?.Value?.ToString();
                string? credito = dataGridView_usuarios[4, e.RowIndex]?.Value?.ToString();
                string? email = dataGridView_usuarios[5, e.RowIndex]?.Value?.ToString();
                string? resHotel = dataGridView_usuarios[6, e.RowIndex]?.Value?.ToString();
                string? resVuelo = dataGridView_usuarios[7, e.RowIndex]?.Value?.ToString();
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
            catch (Exception)
            {
            }

        }


        private void textBox_credito_TextChanged(object sender, EventArgs e)
        {
            foreach (Usuario us in refAgencia.getUsuarios())
            {
                textBox_credito.Text = us.credito.ToString();
            }
        }

        private void btn_agregarCredito_Click(object sender, EventArgs e)
        {//metodos para agregar credito al usuario verifica que sea un numero
            if (usuarioSeleccionado != -1)
            {
                if (double.TryParse(textBox_credito.Text, out double nuevoCredito))
                {
                    if (refAgencia.agregarCredito(usuarioSeleccionado, nuevoCredito))
                    {
                        MessageBox.Show("Modificado con éxito");
                        // Aquí podrías actualizar la vista para reflejar el nuevo crédito.
                    }
                    else
                    {
                        MessageBox.Show("Problemas al modificar");
                    }
                }
                else
                {
                    MessageBox.Show("El valor ingresado en 'Crédito' no es válido.");
                }
            }
            else
            {
                MessageBox.Show("Debe seleccionar un usuario");
            }
        }


        private void btn_modificarCredito_Click_1(object sender, EventArgs e)
        {//metodos para modificar credito al usuario verifica que sea un numero
            if (usuarioSeleccionado != -1)
            {
                if (double.TryParse(textBox_credito.Text, out double nuevoCredito))
                {
                    if (refAgencia.modificarCredito(usuarioSeleccionado, nuevoCredito))
                    {
                        MessageBox.Show("Modificado con éxito");
                        // Aquí podrías actualizar la vista para reflejar el nuevo crédito.
                    }
                    else
                    {
                        MessageBox.Show("Problemas al modificar");
                    }
                }
                else
                {
                    MessageBox.Show("El valor ingresado en 'Crédito' no es válido.");
                }
            }
            else
            {
                MessageBox.Show("Debe seleccionar un usuario");
            }
        }


        private void btn_buscarUsuario_Click(object sender, EventArgs e)
        {

            string dniABuscar = textBox_buscarUsuario.Text;

            BuscarUsuarioPorDNI(dniABuscar);
        }

        private void BuscarUsuarioPorDNI(string dni)
        {
            // Lógica de búsqueda de usuario por DNI
            bool usuarioEncontrado = false;

            foreach (Usuario us in refAgencia.getUsuarios())
            {
                if (us.dni == dni)
                {
                    dataGridView_usuarios.Rows.Clear();
                    dataGridView_usuarios.Rows.Add(new string[] { us.id.ToString(), us.name, us.apellido, us.dni.ToString(), us.credito.ToString(), us.mail, us.misReservasHoteles.ToString(), us.misReservasVuelo.ToString() });

                    usuarioEncontrado = true;
                    break; // Como se encontró el usuario, podemos salir del bucle.
                }
            }

            if (!usuarioEncontrado)
            {
                MessageBox.Show("Debe introducir un DNI de usuario válido");
            }
        }
    }
}
