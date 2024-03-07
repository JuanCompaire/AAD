using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace Colegio2Api.Controllers
{
    public class CursosController : Controller
    {
			public IEnumerable<Cursos> Get()//Obtener todos los alumnos
			{
				using (Colegio2Entities1 colegio = new Colegio2Entities1())
				{
					return colegio.Cursos.ToList();
				}
			}
			public Cursos Get(int id)//Obtener un alumno por id
			{
				using (Colegio2Entities1 colegio = new Colegio2Entities1())
				{
					return colegio.Cursos.Find(id);
				}
			}
	}
}
