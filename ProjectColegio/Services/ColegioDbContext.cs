using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Modelos;

namespace Services
{
    public class ColegioDbContext : DbContext
    {

        public DbSet<Alumno> Alumno { get; set; }

        public ColegioDbContext(DbContextOptions<ColegioDbContext> options) : base(options)
        {

        }
    }
}
 