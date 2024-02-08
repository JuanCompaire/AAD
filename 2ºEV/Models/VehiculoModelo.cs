namespace _2ºEV.Models
{
    public class VehiculoModelo
    {
        public int ID { get; set; }

        public String Matricula { get; set; }

        public String Color { get; set; }

        public SerieModelo Serie { get; set; }

        public int SerieID { get; set; }
    }
}
