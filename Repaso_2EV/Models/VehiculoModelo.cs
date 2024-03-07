using System.ComponentModel.DataAnnotations.Schema;

namespace Repaso_2EV.Models
{
    public class VehiculoModelo
    {

        public int ID { get; set; }

        public String Matricula { get; set; }

        public String Color { get; set; }

        public SerieModelo Serie { get; set; }

        public int SerieId { get; set; }
        [NotMapped]
        public List<int> ExtrasSeleccionados { get; set; }
        public List<VehiculoExtraModelo> VehiculoExtras { get; set; }
    }
}
