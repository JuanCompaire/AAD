using Microsoft.AspNetCore.Mvc;
using Modelos;
using Services;
using System;

namespace JuanCompaire.Components

{
    public class ProvinciasComunidadViewComponent : ViewComponent
    {

        public IProvinciaRepositorio ProvinciaRepository { get;}

        public ProvinciasComunidadViewComponent(IProvinciaRepositorio provinciaRepository)
        {
            ProvinciaRepository = provinciaRepository;
        }

        public IViewComponentResult Invoke()
        {
            var resultado = ProvinciaRepository.ProvinciasPorComunidad();
            return View(resultado);
        }
    }
}
