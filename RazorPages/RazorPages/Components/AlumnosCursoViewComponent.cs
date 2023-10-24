using Microsoft.AspNetCore.Mvc;
using RazorPages.Services;

namespace RazorPages.Components
{
	public class AlumnosCursoViewComponent : ViewComponent
	{
		public IAlumnoRepositorio AlumnoRepositorio { get; }

		public AlumnosCursoViewComponent(IAlumnoRepositorio alumnoRepositorio)
        {
			AlumnoRepositorio = alumnoRepositorio;
		}

		public IViewComponentResult Invoke()
		{
			var resultado = AlumnoRepositorio.AlumnosPorCurso();
			return View(resultado);
		}

	}
}
