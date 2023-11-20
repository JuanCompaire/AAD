using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Modelos;
using Services;

namespace ProjectColegio.Pages.Alumnos
{
    public class EditModel : PageModel
    {
        [BindProperty]
        public Alumno Alumno { get; set; }

        [BindProperty]
        public IFormFile Photo { get; set; }

        private readonly IAlumnoRepositorio alumnoRepositorio;

        public IWebHostEnvironment HostEnvironment { get; }

        public EditModel(IAlumnoRepositorio alumnoRepositorio, IWebHostEnvironment hostEnvironment)
        {
            this.alumnoRepositorio = alumnoRepositorio;
            HostEnvironment = hostEnvironment;
        }
        public IActionResult OnGet(int? id)
        {
            if(id.HasValue)
            {
                Alumno = alumnoRepositorio.GetById(id.Value);
            }
            else
            {
                Alumno = new Alumno();
            }
            return Page();
        }
        public IActionResult OnPost()
        {
               if (ModelState.IsValid)
            {
                if (Photo != null)
                {
                    if (Alumno.Foto != null)
                    {
                        string filePath = Path.Combine(HostEnvironment.WebRootPath, "images", Alumno.Foto);
                        System.IO.File.Delete(filePath);
                    }
                    Alumno.Foto = ProcessUploadedFile();
                }
                if (Alumno.Id != 0)
                {
                    Alumno = alumnoRepositorio.Update(Alumno);
                }
                else
                {
                    Alumno = alumnoRepositorio.Add(Alumno);
                }
                return RedirectToPage("/Alumnos/Index");
            }
            return Page();
        }

        private string ProcessUploadedFile()
        {
            string uploadsFolder = Path.Combine(HostEnvironment.WebRootPath, "images");//lo primero nos devuelve el path a wwwroot
            string filePath = Path.Combine(uploadsFolder, Photo.FileName);
            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                Photo.CopyTo(fileStream);
            }
            return Photo.FileName;
        }
    }
}
