using _2ºEV.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace _2ºEV.Controllers
{
    public class VehiculoController : Controller

    {
        public Contexto Contexto { get; }

        public VehiculoController(Contexto contexto)
        {
            Contexto = contexto;
        }

        // GET: VehiculoController
        public ActionResult Index()
        {
            ViewBag.LasMarcas = Contexto.Marcas.ToList();
            var lista = Contexto.Vehiculos.Include(v => v.Serie);
            return View(lista);
        }

        // GET: VehiculoController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: VehiculoController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: VehiculoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: VehiculoController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: VehiculoController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: VehiculoController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: VehiculoController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
