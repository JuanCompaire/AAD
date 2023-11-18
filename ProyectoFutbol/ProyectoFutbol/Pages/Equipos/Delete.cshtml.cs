using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Modelos;
using Services;

namespace ProyectoFutbol.Pages.Equipos
{
    public class DeleteModel : PageModel
    {

        private readonly IEquiposRepositorio repositorioEquipo;

        [BindProperty]
        public Equipo Equipo { get; set; }

        public DeleteModel(IEquiposRepositorio repositorioEquipo)
        {
            this.repositorioEquipo = repositorioEquipo;
        }
        public void OnGet(int id)
        {
            Equipo = repositorioEquipo.GetEquipoById(id);
        }

        public IActionResult OnPost(int id)
        {
            repositorioEquipo.Delete(id);
            return RedirectToPage("Index");
        }
    }
}
