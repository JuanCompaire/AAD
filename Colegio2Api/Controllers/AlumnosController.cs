using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Colegio2Api.Controllers
{
    public class AlumnosController : Controller
    {
		public IEnumerable<Alumnos> Get()//Obtener todos los alumnos
		{
			using (Colegio2Entities1 colegio = new Colegio2Entities1())
			{
				return colegio.Alumnos.ToList();
			}
		}
		public Alumnos Get(int id)//Obtener un alumno por id
		{
			using (Colegio2Entities1 colegio = new Colegio2Entities1())
			{
				return colegio.Alumnos.Find(id);
			}
		}
	}
}
