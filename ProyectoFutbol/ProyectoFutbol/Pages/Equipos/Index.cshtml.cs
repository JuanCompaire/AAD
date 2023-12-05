using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Modelos;
using Services;

namespace ProyectoFutbol.Pages.Equipos
{
    public class IndexModel : PageModel
    {
        private readonly IEquiposRepositorio equiposRepositorio;

        public IEnumerable<Equipo> equipos { get; set; }


        [BindProperty(SupportsGet = true)]
        public string elementoABuscar { get; set; }    
        public IndexModel(IEquiposRepositorio equiposRepositorio)
        {
            this.equiposRepositorio = equiposRepositorio;
        }
        public void OnGet()
        {
            equipos = equiposRepositorio.BuscarEquipos(elementoABuscar);

           
        }

        

        
        }
    }

