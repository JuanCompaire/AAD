namespace Repaso_2EV.Models
{
    public class MarcaModelo
    {

        public int Id { get; set; }
        public string Nom_Marca { get; set; }

        public List<SerieModelo> Series { get; set; }
       
    }
}
