namespace tpAgencia_Gpo_2
{
    public class ReservaVuelo
    {
        public Vuelo miVuelo { get; set; }
        public Usuario miUsuario { get; set; }
        public Double pagado {  get; set; }

        //constructor
        public ReservaVuelo(Vuelo miVuelo, Usuario miUsuario, double pagado)
        {
            this.miVuelo = miVuelo;
            this.miUsuario = miUsuario;
            this.pagado = pagado;
        }

        //metodos
        


    }
}