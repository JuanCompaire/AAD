using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Repaso_2EV.Models;

namespace Repaso_2EV.Controllers
{
    public class MarcaController : Controller
    {

        public Contexto Contexto { get; }

        public MarcaController(Contexto contexto)
        {
            Contexto = contexto;
        }
        // GET: MarcaController1
        public ActionResult Index()
        {
            var lista = Contexto.Marcas.ToList();
            return View(lista);
        }

        public ActionResult Listado()
        {
            List<MarcaModelo> lista = Contexto.Marcas.Include("Series").ToList();
            return View(lista);
        }

        public ActionResult Desplegable()
        {
            ViewBag.Marcas = new SelectList(Contexto.Marcas, "Id", "Nom_Marca");
            ViewBag.Marcas2 = Contexto.Marcas.ToList();
            return View();
        }

        // GET: MarcaController1/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: MarcaController1/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MarcaController1/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MarcaModelo marca)
        {
            try
            {

                Contexto.Marcas.Add(marca);
                Contexto.Database.EnsureCreated();
                Contexto.SaveChanges();
                return View("Create");
            }
            catch
            {
                return View("Create");
            }
        }

        // GET: MarcaController1/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: MarcaController1/Edit/5
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

        // GET: MarcaController1/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: MarcaController1/Delete/5
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
