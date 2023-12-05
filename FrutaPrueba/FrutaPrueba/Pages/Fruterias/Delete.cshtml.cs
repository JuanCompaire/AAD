using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Modelos;
using Services;

namespace FrutaPrueba.Pages.Fruterias
{
    public class DeleteModel : PageModel
    {

        public readonly IFruteriaRepositorio fruteriaRepositorio;

        public DeleteModel(IFruteriaRepositorio fruteriaRepositorio)
        {
            this.fruteriaRepositorio = fruteriaRepositorio;
        }

        [BindProperty]
        public Fruteria fruteria { get; set; }

        public void OnGet(int id)
        {
            fruteria = fruteriaRepositorio.GetFruteriaById(id);
        }

        public IActionResult OnPost(int id)
        {
            fruteriaRepositorio.Delete(id);
            return RedirectToPage("./Index");
            
        }
    }
}
