using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Modelos;
using Services;

namespace ProjectColegio.Pages.Alumnos
{
    public class DetailsModel : PageModel
    {
        public Alumno alumno { get; set; }

        private readonly IAlumnoRepositorio alumnoRepositorio;

        public DetailsModel(IAlumnoRepositorio alumnoRepositorio)
        {
            this.alumnoRepositorio = alumnoRepositorio;
        }
        public void OnGet(int id)
        {

            alumno = alumnoRepositorio.GetById(id);

        }
    }
}
