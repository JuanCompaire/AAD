using Modelos;

namespace Services
{
	public interface IEquiposRepositorio
	{

		IEnumerable<Equipo> GetEquipos();

	}
}