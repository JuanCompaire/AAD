using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Modelos;
using Services;

namespace ProyectoFutbol.Pages.Equipos
{
    public class IndexModel : PageModel
    {
        private readonly IEquiposRepositorio equiporepositorio;
        public IEnumerable<Equipo> Equipos;
    
        public IndexModel(IEquiposRepositorio equiporepositorio)
        {
            this.equiporepositorio = equiporepositorio;
        }
        public void OnGet()
        {


        }
    }
}
