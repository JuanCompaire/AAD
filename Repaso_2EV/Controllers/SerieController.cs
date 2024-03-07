using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Repaso_2EV.Models;

namespace Repaso_2EV.Controllers
{
    public class SerieController : Controller
    {
        Contexto Contexto { get; set; }

        public SerieController(Contexto contexto)
        {
            Contexto = contexto;
        }
        // GET: SerieController
        public ActionResult Index()
        {
            var lista = Contexto.Series.Include(s => s.Marca).ToList();
            return View(lista);
        }

        public ActionResult Listado(int id)
        {
            List<SerieModelo> lista = this.Contexto.Series.Include("Marca").ToList();
            // Encuentra el índice del elemento con el ID especificado
            List<SerieModelo> listaMarca = lista.FindAll(item => item.MarcaID == id);
            // List<SerieModelo> listaMarca = lista.FindAll(item => item.MarcaId == id);
            if (id > 0)
            {
                // Si se encontró, pasa el elemento correspondiente a la vista
                return View(listaMarca);
            }
            else
            {
                return RedirectToAction("Error");
            }
        }

        // GET: SerieController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: SerieController/Create
        public ActionResult Create()
        {
            ViewBag.MarcaID = new SelectList(Contexto.Marcas, "Id", "Nom_Marca");
            return View();
        }

        // POST: SerieController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SerieModelo serie)
        {
            try
            {
                Contexto.Series.Add(serie);
                Contexto.SaveChanges();

                return View("Create");
            }
            catch
            {
                return View("Create");
            }
        }

        // GET: SerieController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: SerieController/Edit/5
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

        // GET: SerieController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: SerieController/Delete/5
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
