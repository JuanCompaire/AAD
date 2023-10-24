using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPages.Modelos;
using RazorPages.Services;

namespace RazorPages.Pages.Alumnos
{
    public class EditModel : PageModel
    {
        private readonly IAlumnoRepositorio AlumnoRepositorio;
		private readonly IWebHostEnvironment webHostEnvironment;

		public Alumno alumno { get; set; }

        public IFormFile Photo { get; set; }

        public EditModel(IAlumnoRepositorio alumnoRepositorio, IWebHostEnvironment webHostEnvironment)
        {
            this.AlumnoRepositorio = alumnoRepositorio;
            this.webHostEnvironment = webHostEnvironment;
        }
        public void OnGet(int id)
        {
            alumno = AlumnoRepositorio.GetAlumno(id);
        }

        public IActionResult OnPost(Alumno alumno)
        {
            if(Photo !=  null)
            {
                if(alumno.Foto != null)
                {
					string filePath = Path.Combine(webHostEnvironment.WebRootPath, "images", alumno.Foto);
					System.IO.File.Delete(filePath);
				}
                alumno.Foto = ProcessUploadedFile();
            }


            AlumnoRepositorio.Update(alumno);
            return RedirectToPage("Index");
        }
		private string ProcessUploadedFile()
		{
			//necesitamos un objeto de una clase que sea capaz de manipular el proyecto por lo que la creamos en el constructor
			string uploadsFolder = Path.Combine(webHostEnvironment.WebRootPath, "images");//lo primero nos devuelve el path a wwwroot
			string filePath = Path.Combine(uploadsFolder, Photo.FileName);
			using (var fileStream = new FileStream(filePath, FileMode.Create))
			{
				Photo.CopyTo(fileStream);
			}
			return Photo.FileName;
		}

	}
}
