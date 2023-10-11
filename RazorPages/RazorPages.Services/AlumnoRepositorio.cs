using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RazorPages.Modelos;

namespace RazorPages.Services
{
	internal class AlumnoRepositorio : IAlumnoRepositorio
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
			throw new NotImplementedException();
		}
	}
}
