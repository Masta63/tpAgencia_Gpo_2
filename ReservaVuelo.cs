﻿namespace tpAgencia_Gpo_2
{
    public class ReservaVuelo
    {
        public int idReservaVuelo { get; set; }
        public Vuelo miVuelo { get; set; }
        public Usuario miUsuario { get; set; }
        public double pagado {  get; set; }

        public int idUsuario { get; set; }
        //constructor
        public ReservaVuelo() { }
        public ReservaVuelo(Vuelo miVuelo, Usuario miUsuario, double pagado)
        {
            this.miVuelo = miVuelo;
            this.miUsuario = miUsuario;
            this.pagado = pagado;
        }

        //metodos
        public ReservaVuelo(Vuelo miVuelo, Usuario miUsuario)
        {
            this.miVuelo = miVuelo;
            this.miUsuario = miUsuario;

        }


    }
}