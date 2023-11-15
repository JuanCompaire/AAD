using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RazorPages.Modelos;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;

namespace RazorPages.Services
{
	public class AlumnoRepositorioBD : IAlumnoRepositorio
	{
		private readonly AlumnoDbContext context;

		public AlumnoRepositorioBD(AlumnoDbContext context)
        {
			this.context = context;
		}


		public Alumno GetAlumno(int id)
		{
			SqlParameter parameter = new SqlParameter("@Id", id);
			return context.Alumnos.FromSqlRaw<Alumno>("GetAlumnoBYId {0}", parameter).ToList().FirstOrDefault();
		}

		public Alumno Update(Alumno alumnoActualizado)
		{
			var alumno = context.Alumnos.Attach(alumnoActualizado);
			alumno.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
			return alumnoActualizado;
		}

		public IEnumerable<Alumno> GetAllAlumnos()
		{
			return context.Alumnos.FromSqlRaw<Alumno>("select * from empleados").ToList();
		}

		public Alumno Add(Alumno alumnoNuevo)
		{
			context.Database.ExecuteSqlRaw("InsertarAlumno {0},{1},{2},{3}",
				alumnoNuevo.Nombre,
				alumnoNuevo.Email,
				alumnoNuevo.Foto,
				alumnoNuevo.CursoId);

			return alumnoNuevo;
		}

		public IEnumerable<CursoCuantos> AlumnosPorCurso(Curso? curso)
		{
			IEnumerable<Alumno> consulta = context.Alumnos;
			if(curso.HasValue)
			{
				consulta = consulta.Where(a => a.CursoId == curso);
			}

			return consulta.GroupBy(a => a.CursoId)
				.Select(g => new CursoCuantos()
				{
					Clase = g.Key.Value,
					NumAlumnos = g.Count()
				}).ToList();
			;
		}

		public IEnumerable<Alumno> Busqueda(string elementoABuscar)
		{
			if (string.IsNullOrEmpty(elementoABuscar))
			{
				return context.Alumnos;
			}
			return context.Alumnos.Where(a => a.Nombre.Contains(elementoABuscar) || a.Email.Contains(elementoABuscar));

		}

		public Alumno Delete(int id)
		{
			Alumno alumnoABorrar = context.Alumnos.Find(id);
			if (alumnoABorrar != null)
			{
				context.Alumnos.Remove(alumnoABorrar);	
				context.SaveChanges();
			}
			return alumnoABorrar;
		}

		public IEnumerable<CursoCuantos> AlumnosPorCurso()
		{
			throw new NotImplementedException();
		}

		

		


	}
}
