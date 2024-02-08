using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Services;
using Modelos;
using System.Reflection.Metadata.Ecma335;

namespace JuanCompaire.Pages.Provincias
{
    public class IndexModel : PageModel
    {

        private readonly IProvinciaRepositorio provinciaRepositorio;

        public IEnumerable<Provincia> provincias { get; set; }

        public IndexModel(IProvinciaRepositorio provinciaRepositorio)
        {
            this.provinciaRepositorio = provinciaRepositorio;
        }
        public void OnGet()
        {
            provincias = provinciaRepositorio.GetAllProvincias();
        }
    }
}
