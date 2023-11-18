using Modelos;

namespace Services
{
	public interface IEquiposRepositorio
	{

		IEnumerable<Equipo> GetEquipos();
		Equipo GetEquipoById(int id);

		void Update(Equipo equipoActualizado);

		void Add(Equipo nuevoEquipo);

		Equipo Delete(int id);

	}
}