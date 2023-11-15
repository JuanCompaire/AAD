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
	public class EquipoRepositorio : IEquiposRepositorio
	{

		private readonly FutbolDbContext context;

		public EquipoRepositorio(FutbolDbContext context)
		{
			this.context = context;
		}
		public IEnumerable<Equipo> GetEquipos()
		{
			return context.Equipo.FromSqlRaw<Equipo>("SELECT * FROM Equipo").ToList();
		}
	}	
	
}
