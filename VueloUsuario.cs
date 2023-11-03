using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tpAgencia_Gpo_2
{
    public class VueloUsuario
    {
        public int idVuelo { get; set; }
        public Vuelo vuelo { get; set; }
        public int idUsuario { get; set; }
        public Usuario user { get; set; }
        public int cantidad { get; set; }

        public VueloUsuario() { }
    }
}
