using RazorPages.Modelos;
namespace RazorPages.Services
{
	public interface IAlumnoRepositorio
	{
		IEnumerable<Alumno> GetAllAlumnos();

		Alumno GetAlumno(int id);

		Alumno Update(Alumno alumnoActualizado);

		Alumno Add(Alumno alumnoNuevo);

		Alumno Delete(int id);

		IEnumerable<CursoCuantos> AlumnosPorCurso();

		IEnumerable<Alumno> Busqueda(String elementoABuscar);


	}
}