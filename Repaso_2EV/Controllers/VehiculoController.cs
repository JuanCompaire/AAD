using System.Drawing;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Repaso_2EV.Models;

namespace Repaso_2EV.Controllers
{
    public class VehiculoController : Controller
    {

        public class VehiculoTotal
        {
            public string Nom_Marca { get; set; }
            public string Nom_Serie { get; set; }
            public string Matricula { get; set; }
            public string Color { get; set; }
        }
        public Contexto Contexto { get; set; }
        public VehiculoController(Contexto contexto)
        {
            Contexto = contexto;
        }
        // GET: VehiculoController
        public ActionResult Index()
        {
            List<VehiculoModelo> listav = Contexto.Vehiculos.Include(v => v.Serie.Marca).Include(v => v.VehiculoExtras).ToList();
            ViewBag.marcas = Contexto.Marcas.ToList();
            ViewBag.ex = Contexto.Extras.ToList();
            return View(listav);
        }

		public ActionResult Seleccion(int marcaId = 1, int serieId = 0)
		{
			ViewBag.lasMarcas = new SelectList(this.Contexto.Marcas, "Id", "NomMarca", marcaId);
			ViewBag.lasSeries = new SelectList(this.Contexto.Series.Where(s => s.MarcaID == marcaId), "Id", "NomSerie", serieId);
			List<VehiculoModelo> listaVehiculos = this.Contexto.Vehiculos.Include(s => s.Serie).Where(v => v.SerieId == serieId).Include(m => m.Serie.Marca).Where(v => v.Serie.MarcaID == marcaId).ToList();
			return View(listaVehiculos);
		}

        public ActionResult Listado2()
        {
            var lista = Contexto.VistaTotal.FromSql($"SELECT dbo.Marcas.Nom_Marca, dbo.Series.Nom_Serie, dbo.Vehiculos.Matricula, dbo.Vehiculos.Color FROM   dbo.Marcas INNER JOIN  dbo.Series ON dbo.Marcas.Id = dbo.Series.MarcaID INNER JOIN           dbo.Vehiculos ON dbo.Series.ID = dbo.Vehiculos.SerieId");
            //List<VehiculoTotal> lista = Contexto.VistaTotal.ToList();
            return View(lista);
        }

		public ActionResult Listado3(string color="%")
		{

			ViewBag.elcolor = new SelectList(this.Contexto.Vehiculos.Select(v => v.Color).Distinct().ToList(), color);
			//ViewBag.loscolores = new SelectList(this.Contexto.Vehiculos.Select(v => new { Color = v.Color }).Distinct().ToList(), "Color", "Color");// Agustin Mode
			var color2 = "%";// "%" Significa que EMPLEA TODOS LOS COLORES
			if (color == null) { color = "%"; }//Este es EXTRA: Si no se selecciona ningun color, se seleccionan todos
			var lista2 = this.Contexto.VistaTotal.FromSql($"EXECUTE getVehiculosPorColor {color}");// {color}, {color2}
			return View(lista2);
		}
		public ActionResult Busqueda(string matriculaVehiculo = "")
        {
            ViewBag.buscar = matriculaVehiculo;
            var lista = from v in Contexto.Vehiculos.Include(s => s.Serie).Include(m => m.Serie.Marca)
                        where (v.Matricula.Contains(matriculaVehiculo))
                        select v;
            if (matriculaVehiculo == null)
            {
                lista = from v in Contexto.Vehiculos.Include(s => s.Serie).Include(m => m.Serie.Marca)
                        select v;
            }
            
            return View(lista);
        }

			public ActionResult Busqueda2(string matriculaVehiculo = "")
        {
            ViewBag.listaMatriculas = new SelectList(Contexto.Vehiculos, "Matricula", "Matricula", matriculaVehiculo);
            var lista = from v in Contexto.Vehiculos.Include(s => s.Serie).Include(m => m.Serie.Marca)
                        where (v.Matricula.Equals(matriculaVehiculo))
                        select v;
            if (matriculaVehiculo == "")
            {
                lista = from v in Contexto.Vehiculos.Include(s => s.Serie).Include(m => m.Serie.Marca)
                        select v;
            }
            return View(lista);
        }

        // GET: VehiculoController/Details/5
        public ActionResult Details(int id)
        {
            VehiculoModelo vehiculo = Contexto.Vehiculos.Include(v => v.Serie).Include(m =>m.Serie.Marca).FirstOrDefault(v => v.ID == id);
            return View(vehiculo);
        }

        // GET: VehiculoController/Create
        public ActionResult Create()
        {
            ViewBag.SerieID = new SelectList(Contexto.Series, "ID", "Nom_Serie");
            ViewBag.ExtrasSeleccionados = new MultiSelectList(Contexto.Extras, "ID", "NomExtra");
            return View();
        }

        // POST: VehiculoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(VehiculoModelo vehiculo)
        {
            Contexto.Vehiculos.Add(vehiculo);
            Contexto.Database.EnsureCreated();
            Contexto.SaveChanges();

            foreach (var xtraID in vehiculo.ExtrasSeleccionados)
            {
                var obj = new VehiculoExtraModelo() 
                {
                    vehiculoID = vehiculo.ID,
                    extraID = xtraID
                };
				Contexto.VehiculosExtras.Add(obj);

			}
			Contexto.SaveChanges();

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
            ViewBag.SerieID = new SelectList(Contexto.Series, "ID", "Nom_Serie");
            VehiculoModelo vehiculo = Contexto.Vehiculos.Find(id);
            return View(vehiculo);
        }

        // POST: VehiculoController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, VehiculoModelo vehiculoModificado)
        {
            try
            {
                VehiculoModelo vehiculoActual = Contexto.Vehiculos.FirstOrDefault(v => v.ID == id);
                vehiculoActual.Matricula = vehiculoModificado.Matricula;
                vehiculoActual.Color = vehiculoModificado.Color;
                vehiculoActual.SerieId = vehiculoModificado.SerieId;
                Contexto.SaveChanges();
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
            VehiculoModelo vehiculo = Contexto.Vehiculos.Include(v => v.Serie).Include(m => m.Serie.Marca).FirstOrDefault(v => v.ID == id);
            return View(vehiculo);
        }

        // POST: VehiculoController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                VehiculoModelo vehiculo = Contexto.Vehiculos.Find(id);
                Contexto.Vehiculos.Remove(vehiculo);
                Contexto.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
