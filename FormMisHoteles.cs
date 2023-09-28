using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static tpAgencia_Gpo_2.BuscadorVuelos;

namespace tpAgencia_Gpo_2
{
    public partial class FormMisHoteles : Form
    {

        private Agencia agencia;
        private Form1 form1;
        private Usuario usuarioActual;
        public TransfDelegadoMisHoteles TransfEventoMisVuelos;
        public FormMisHoteles(Agencia agencia, Form1 form1)
        {
            InitializeComponent();
            this.agencia = agencia;
            this.form1 = form1;
            usuarioActual = agencia.getUsuarioActual();
            this.Load += FormMisHoteles_Load;
        }

        public delegate void TransfDelegadoMisHoteles();

        private void FormMisHoteles_Load(object sender, EventArgs e)
        {
            MostrarHoteles();
        }
        private void MostrarHoteles()
        {
            dataGridView1.Rows.Clear();

            if (usuarioActual != null)
            {
                List<Hotel> hotelesPasados = agencia.misHoteles(usuarioActual);

                foreach (var hoteles in hotelesPasados)
                {
                    Hotel hotel = hotelesPasados.FirstOrDefault(v => v.id == hoteles.Hotel);
                    if (hotel != null)
                    {

                        dataGridView1.Rows.Add(
                            hotel.ubicacion,
                            hotel.capacidad,
                            hotel.costo,
                            hotel.nombre,
                            hotel.huespedes
                            );
                    }

                }



            }

        }

        private void Volver_desde_usuario_Click(object sender, EventArgs e)
        {
            this.Close();
            MenuAgencia MenuAgencia = new MenuAgencia(agencia, form1);
            MenuAgencia.MdiParent = form1;
            MenuAgencia.Show();
        }
    }
}
