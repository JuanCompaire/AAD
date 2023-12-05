using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Modelos;
using Services;


namespace FrutaPrueba.Pages.Fruterias
{
    public class IndexModel : PageModel
    { 

        private readonly IFruteriaRepositorio fruteriaRepositorio;
        public IEnumerable<Fruteria> Fruterias { get;set;}

        public IndexModel(IFruteriaRepositorio fruteriaRepositorio)
        {
            this.fruteriaRepositorio = fruteriaRepositorio;
        }
    
        public void OnGet()
        {
            Fruterias = fruteriaRepositorio.GetFruterias();
        }
    }
}
