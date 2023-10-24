using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPages.Services;
using RazorPages.Modelos;

namespace RazorPages.Pages.Alumnos
{
    public class DeleteModel : PageModel
    {
		public IAlumnoRepositorio AlumnoRepositorio { get; }

		public DeleteModel(IAlumnoRepositorio alumnoRepositorio)
        {
			AlumnoRepositorio = alumnoRepositorio;
		}
        [BindProperty]
        public Alumno alumno { get; set; }

		public IActionResult OnGet(int id)
        {
            alumno = AlumnoRepositorio.GetAlumno(id);
            return Page();
        }

        public IActionResult OnPost()
        {
            AlumnoRepositorio.Delete(alumno.Id);
            return RedirectToPage("Index");
        }
    }
}
