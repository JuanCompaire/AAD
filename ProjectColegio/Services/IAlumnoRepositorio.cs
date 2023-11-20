using Modelos;

namespace Services
{
    public interface IAlumnoRepositorio
    {

        IEnumerable<Alumno> GetAll();

        Alumno GetById(int id);

        void Update(Alumno alumnoupdate);

    }
}