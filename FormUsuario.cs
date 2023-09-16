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
        private Agencia RefAgencia;
        public FormUsuario(Agencia agencia)
        {
            InitializeComponent();
            this.RefAgencia = agencia;
        }

        private void FormUsuario_Load(object sender, EventArgs e)
        {

        }

    }
}
