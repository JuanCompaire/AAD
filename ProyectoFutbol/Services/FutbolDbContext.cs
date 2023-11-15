using System;
using Modelos;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Services
{
	public class FutbolDbContext : DbContext
	{

		public DbSet<Equipo> Equipos { get; set; }

		public FutbolDbContext(DbContextOptions<FutbolDbContext> options) : base(options)
		{
		}
	}
}
