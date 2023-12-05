using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Modelos;
using Services;
using System.IO;

namespace FrutaPrueba.Pages.Fruterias
{
    public class EditModel : PageModel
    {
        [BindProperty]
        public Fruteria fruteria { get; set; }

        [BindProperty]
        public IFormFile Photo { get; set; }

        private readonly IFruteriaRepositorio fruteriaRepositorio;
        public IWebHostEnvironment HostEnvironment { get; }

        public EditModel(IFruteriaRepositorio fruteriaRepositorio, IWebHostEnvironment hostEnvironment)
        {
            this.fruteriaRepositorio = fruteriaRepositorio;
            HostEnvironment = hostEnvironment;
        }

        public IActionResult OnGet(int? id)
        {
            if (id.HasValue)
            {
                fruteria = fruteriaRepositorio.GetFruteriaById(id.Value);
            }
            else
            {
                fruteria = new Fruteria();
            }
            return Page();
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                if (Photo != null)
                {
                    if (fruteria.foto != null)
                    {
                        string filePath = Path.Combine(HostEnvironment.WebRootPath, "images", fruteria.foto);
                        System.IO.File.Delete(filePath);
                    }

                    fruteria.foto = ProcessUploadedFile();
                }

                if (fruteria.id != 0)
                    fruteriaRepositorio.Update(fruteria);
                else
                    fruteriaRepositorio.Add(fruteria);

                return RedirectToPage("Index");
            }
            else
            {
                return Page();
            }
        }

        private string ProcessUploadedFile()
        {
            string uploadsFolder = Path.Combine(HostEnvironment.WebRootPath, "images");
            string filePath = Path.Combine(uploadsFolder, Photo.FileName);

            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                Photo.CopyTo(fileStream);
            }

            return Photo.FileName;
        }
    }
}
