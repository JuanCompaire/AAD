using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Modelos;
using Services;

namespace ProyectoFutbol.Pages.Equipos
{
    public class EditModel : PageModel
    {
        [BindProperty]
        public Equipo equipo { get; set; }

        [BindProperty]
        public IFormFile Photo { get; set; }


        private readonly IEquiposRepositorio equipoRepositorio;
        public IWebHostEnvironment WebHostEnvironment { get; }

        public EditModel(IEquiposRepositorio equipoRepositorio, IWebHostEnvironment webHostEnvironment)
        {
            this.equipoRepositorio = equipoRepositorio;
            WebHostEnvironment = webHostEnvironment;
        }

        public IActionResult OnGet(int? id)
        {
            if(id.HasValue){
                equipo = equipoRepositorio.GetEquipoById(id.Value);
            }
            else
            {
                equipo = new Equipo();

            }
            return Page();

            
        }

        public IActionResult OnPost(Equipo equipo) {

            if (ModelState.IsValid)
            {

                if(Photo != null)
                {
                    {
                        if (equipo.foto != null)
                        {
                            string filePath = Path.Combine(WebHostEnvironment.WebRootPath, "images", equipo.foto);
                            System.IO.File.Delete(filePath);
                        }
                    }
                    equipo.foto = ProcessUploadedFile();
                }

                if (equipo.Id != 0)
                {
                    equipoRepositorio.Update(equipo);

                }
                else
                    equipoRepositorio.Add(equipo);
                return RedirectToPage("Index");
            }
            else
                return Page();

        }

        private string ProcessUploadedFile()
        {
            string uploadsFolder = Path.Combine(WebHostEnvironment.WebRootPath, "images");//lo primero nos devuelve el path a wwwroot
            string filePath = Path.Combine(uploadsFolder, Photo.FileName);
            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                Photo.CopyTo(fileStream);
            }
            return Photo.FileName;

        }
    }
}
