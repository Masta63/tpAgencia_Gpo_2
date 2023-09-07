namespace tpAgencia_Gpo_2
{
    public class ReservaHotel
    {
        public Hotel miHotel { get; set; }
        public Usuario miUsuario { get; set; }
        public DateTime FechaDesde { get; set; }
        public DateTime fechaHasta { get;set; }
        public Double Pagado {  get; set; }

        //constructor
        public ReservaHotel(Hotel miHotel,
                            Usuario miUsuario,
                            DateTime fechaDesde,
                            DateTime fechaHasta,
                            double pagado)
        {
            this.miHotel = miHotel;
            this.miUsuario = miUsuario;
            FechaDesde = fechaDesde;
            this.fechaHasta = fechaHasta;
            Pagado = pagado;
        }

        
        //metodos


    }
}