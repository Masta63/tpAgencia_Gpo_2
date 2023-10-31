namespace tpAgencia_Gpo_2
{
    public class ReservaHotel
    {
        public int idReservaHotel { get; set; }
        public Hotel miHotel { get; set; }
        public Usuario miUsuario { get; set; }
        public DateTime fechaDesde { get; set; }
        public DateTime fechaHasta { get; set; }
        public double pagado { get; set; }

        //constructor
        public ReservaHotel() { }
        public ReservaHotel(Hotel miHotel,
                            Usuario miUsuario,
                            DateTime fechaDesde,
                            DateTime fechaHasta,
                            double pagado)
        {
            this.miHotel = miHotel;
            this.miUsuario = miUsuario;
            this.fechaDesde = fechaDesde;
            this.fechaHasta = fechaHasta;
            this.pagado = pagado;
        }


        //metodos
    
   


    }
}