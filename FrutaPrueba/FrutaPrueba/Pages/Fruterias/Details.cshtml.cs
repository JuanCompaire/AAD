using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Modelos;
using Services;

namespace FrutaPrueba.Pages.Fruterias
{
    public class DetailsModel : PageModel


    {

        public Fruteria fruteria { get; set;}

        private readonly IFruteriaRepositorio fruteriaRepositorio;

        public DetailsModel(IFruteriaRepositorio fruteriaRepositorio)
        {
            this.fruteriaRepositorio = fruteriaRepositorio;
        }

        public void OnGet(int id)
        {
            fruteria = fruteriaRepositorio.GetFruteriaById(id);

        }
    }
}
