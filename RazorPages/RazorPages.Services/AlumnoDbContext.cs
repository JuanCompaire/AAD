using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RazorPages.Modelos;

namespace RazorPages.Services
{
	public class AlumnoDbContext : DbContext
	{
		public AlumnoDbContext(DbContextOptions<AlumnoDbContext> options) : base(options)
		{
		}
        public DbSet<Alumno> Alumnos { get; set; }
    }
}
