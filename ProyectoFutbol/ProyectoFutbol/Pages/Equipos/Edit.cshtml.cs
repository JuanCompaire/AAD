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
        public IWebHostEnvironment WebHostEnvironment { get; }

        public EditModel(IEquiposRepositorio equipoRepositorio, IWebHostEnvironment webHostEnvironment)
        {
            this.equipoRepositorio = equipoRepositorio;
            WebHostEnvironment = webHostEnvironment;
        }

        public void OnGet(int id)
        {

            equipo = equipoRepositorio.GetEquipoById(id);
        }
    }
}
