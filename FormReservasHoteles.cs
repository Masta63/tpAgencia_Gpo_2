using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static tpAgencia_Gpo_2.FormReservaHotel;

namespace tpAgencia_Gpo_2
{
    public partial class FormReservasHoteles : Form
    {

        private Agencia agencia;
        private Form1 form1;
        private Usuario usuarioActual;
        public TransfDelegadoReservasHoteles TransfEventoReservasHoteles;
        public FormReservasHoteles(Agencia agencia, Form1 form1)
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            this.MdiParent = form1;
            this.agencia = agencia;
            this.form1 = form1;
            usuarioActual = agencia.getUsuarioActual();
            this.Load += FormReservasHoteles_Load;
        }

        public delegate void TransfDelegadoReservasHoteles();

        private void FormReservasHoteles_Load(object sender, EventArgs e)
        {
            MostrarHoteles();
        }
        private void MostrarHoteles()
        {
            dataGridView1.Rows.Clear();

            if (usuarioActual != null)
            {
                List<Hotel> hotelesFuturos = agencia.misReservasHoteles(usuarioActual);

                var hotelesIguales = hotelesFuturos.GroupBy(v => v.id).Select(group => new
                {
                    Hotel = group.Key,
                    Cantidad = group.Count(),
                    MontoTotal = group.Sum(v => v.costo)
                });

                foreach (var hotelesAgrupado in hotelesIguales)
                {
                    Hotel hotel = hotelesFuturos.FirstOrDefault(v => v.id == hotelesAgrupado.Hotel);
                    if (hotel != null)
                    {

                        dataGridView1.Rows.Add(
                            hotel.ubicacion.nombre,
                            hotelesAgrupado.MontoTotal,
                            hotel.nombre, hotel.capacidad, hotelesAgrupado.Cantidad);
                    }

                }



            }

        }

        private void Volver_desde_usuario_Click(object sender, EventArgs e)
        {
            this.Close();
            if (agencia.getUsuarioActual().esAdmin)
            {
                MenuAgenciaAdm menuAgenciaAdm = new MenuAgenciaAdm(agencia, form1);
                menuAgenciaAdm.MdiParent = form1;
                menuAgenciaAdm.Show();
            }
            else
            {
                MenuAgencia MenuAgencia = new MenuAgencia(agencia, form1);
                MenuAgencia.MdiParent = form1;
                MenuAgencia.Show();
            }
        }
    }
}
