using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Modelos;
using Services;

namespace JuanCompaire.Pages.Provincias
{
    public class ComunidadModel : PageModel


    {

        public IEnumerable<Provincia> Provincias;

        private readonly IProvinciaRepositorio provinciaRepositorio;

        public ComunidadModel(IProvinciaRepositorio provinciaRepositorio)
        {
            this.provinciaRepositorio = provinciaRepositorio;
        }

        [BindProperty(SupportsGet = true)]
        public Comunidad comunidadABuscar { get; set; }



        public void OnGet()
        {
            Provincias = provinciaRepositorio.BuscarProvinciasPorComunidad(comunidadABuscar);

        }


    }
}
