using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Modelos;
using Services;

namespace ProyectoFutbol.Pages.Equipos
{
    public class EditModel : PageModel
    {
        public Equipo equipo { get; set; }



        private readonly IEquiposRepositorio equipoRepositorio;

        public EditModel(IEquiposRepositorio equipoRepositorio)
        {
            this.equipoRepositorio = equipoRepositorio;
        }

        public void OnGet(int id)
        {

            equipo = equipoRepositorio.GetEquipoById(id);
        }
    }
}
