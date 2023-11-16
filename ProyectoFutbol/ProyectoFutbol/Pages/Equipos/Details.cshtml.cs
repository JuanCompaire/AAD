using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Modelos;
using Services;

namespace ProyectoFutbol.Pages.Equipos
{
    public class DetailsModel : PageModel
    {
        public Equipo equipo { get; set; }

        private readonly IEquiposRepositorio equipoRepositorio;

        public DetailsModel(IEquiposRepositorio equipoRepositorio)
        {
            this.equipoRepositorio = equipoRepositorio;
        }

        public void OnGet(int id)
        {
            equipo = equipoRepositorio.GetEquipoById(id);
        }
    }
}
