using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RazorPages.Modelos;
using System.Linq;

namespace RazorPages.Services
{
	public class AlumnoRepositorio : IAlumnoRepositorio
	{

		public List<Alumno> listaAlumnos;

        public AlumnoRepositorio()
        {
			listaAlumnos = new List<Alumno>()
			{
				new Alumno(){
					Id=1,Nombre="Alberto Saz",Email="saz@zaragoza.salesianos.edu",Foto="Alberto.jpg",CursoId = Curso.H2
				},
				new Alumno(){
					Id=2,Nombre="Jesús Montero",Email="montero@zaragoza.salesianos.edu",Foto="Jesus.jpg",CursoId = Curso.H2
				},
				new Alumno(){
					Id=3,Nombre="Ismael Bernad",Email="bernad@zaragoza.salesianos.edu",Foto="Ismael2.jpg",CursoId = Curso.H1
				},
				new Alumno(){
					Id=4,Nombre="Ismael Abed",Email="abed@zaragoza.salesianos.edu",Foto="Isma1.jpg",CursoId = Curso.H1
				}
			};
        }
        public IEnumerable<Alumno> GetAllAlumnos()
		{
			return listaAlumnos;
		}

		public Alumno GetAlumno(int id)
		{
			return listaAlumnos.FirstOrDefault(a => a.Id == id);
		}

		public Alumno Update(Alumno alumnoActualizado)
		{
			Alumno alumno = listaAlumnos.FirstOrDefault(a => a.Id == alumnoActualizado.Id);
			alumno.Nombre = alumnoActualizado.Nombre;
			alumno.Email = alumnoActualizado.Email;
			alumno.CursoId = alumnoActualizado.CursoId;
			alumno.Foto = alumnoActualizado .Foto;
			return alumno;
		}

		public Alumno Add(Alumno alumnoNuevo)
		{
			alumnoNuevo.Id = listaAlumnos.Max(a => a.Id) + 1;
			listaAlumnos.Add(alumnoNuevo);
			return alumnoNuevo;
		}

		public Alumno Delete(int id)
		{
			Alumno alumnoABorrar = listaAlumnos.FirstOrDefault(a => a.Id == id);
			if( alumnoABorrar != null)
			{
				listaAlumnos.Remove(alumnoABorrar);
			}
			return alumnoABorrar;
		}
		public IEnumerable<CursoCuantos> AlumnosPorCurso()
		{
			return listaAlumnos.GroupBy(a => a.CursoId)
				.Select(g => new CursoCuantos()
				{
					Clase = g.Key.Value,
					NumAlumnos = g.Count()
				}).ToList();
		}

		public IEnumerable<Alumno> Busqueda(string elementoABuscar)
		{
			if (string.IsNullOrEmpty(elementoABuscar))
			{
				return listaAlumnos;
			}
			return  listaAlumnos.Where(a => a.Nombre.Contains(elementoABuscar)|| a.Email.Contains(elementoABuscar));
			
		}

		
	}
}
