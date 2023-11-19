using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Modelos;
using Services;

namespace ProjectColegio.Pages.Alumnos
{
    public class IndexModel : PageModel
    {
        private readonly IAlumnoRepositorio alumnoRepositorio;
        public IEnumerable<Alumno> Alumnos { get; set; }

        public IndexModel(IAlumnoRepositorio alumnoRepositorio)
        {
            this.alumnoRepositorio = alumnoRepositorio;
        }
        public void OnGet()
        {

            Alumnos = alumnoRepositorio.GetAll();
        }
    }
}
