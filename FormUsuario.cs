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
    public partial class FormUsuario : Form
    {
        private Agencia refAgencia;
        private int usuarioSeleccionado;
        private Usuario usuario;

        public FormUsuario(Agencia agencia)
        {
            InitializeComponent();
            this.refAgencia = agencia;
            usuario = new Usuario(1, "juan", "garcia", 22333444, "juan@mail.com");
            Bienvenida_usuario.Text = usuario.name + " " + usuario.apellido;

        }

        private void FormUsuario_Load(object sender, EventArgs e)
        {

        }

        private void button_Agregar_Click(object sender, EventArgs e)
        {

        }

        private void button_Modificar_Click(object sender, EventArgs e)
        {

        }

        private void button_Eliminar_Click(object sender, EventArgs e)
        {

        }

        private void mostrar_usuario_Click(object sender, EventArgs e)
        {
            actualizarDatos();
            usuarioSeleccionado = -1;
        }

        private void actualizarDatos()
        {
            dataGridView_usuarios.Rows.Clear();

            foreach (Usuario us in refAgencia.getUsuarios())
            {
                dataGridView_usuarios.Rows.Add(us);

                //agregar las rows de
            }
        }

        private void Volver_desde_usuario_Click(object sender, EventArgs e)
        {
            //aca va el metodo delegado para navegar entre paginas
        }

        private void dataGridView_usuarios_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
