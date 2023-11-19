using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;
using Modelos;

namespace Services
{
    public class AlumnoRepositorio : IAlumnoRepositorio
    {
        private readonly ColegioDbContext context;

        public AlumnoRepositorio(ColegioDbContext context)
        {
            this.context = context;
        }

        public IEnumerable<Alumno> GetAll()
        {
            return context.Alumno.FromSqlRaw<Alumno>("SELECT * FROM Alumnos").ToList();

        }
    }
}
