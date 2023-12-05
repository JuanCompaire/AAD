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

        public Equipo GetEquipoById(int id)
        {
            SqlParameter parameter = new SqlParameter("@Id", id);

            return context.Equipo.Find(id);
        }

        public IEnumerable<Equipo> GetEquipos()
		{
			return context.Equipo.FromSqlRaw<Equipo>("SELECT * FROM Equipo").ToList();
		}

		public void Add(Equipo nuevoEquipo)
		{
            context.Database.ExecuteSqlRaw("insertarEquipo {0}, {1}, {2}, {3}, {4}, {5}",
				nuevoEquipo.nomEquipo,
				nuevoEquipo.ciudad,
				nuevoEquipo.nomEstadio,
				nuevoEquipo.anoFundacion,
				nuevoEquipo.foto,
				nuevoEquipo.categoria);

			return;
        }

		public void Update(Equipo equipoActualizado)
		{
            var equipo = context.Equipo.Attach(equipoActualizado);
            equipo.State = EntityState.Modified;
            context.SaveChanges();
        }

		public Equipo Delete(int id)
		{
            Equipo equipoDelete = context.Equipo.Find(id);
            if (equipoDelete != null)
			{
                context.Equipo.Remove(equipoDelete);
                context.SaveChanges();
            }
            return equipoDelete;
        }   

		public Equipo GetEquipoByNombre(string nombreABuscar)
		{
            SqlParameter parameter = new SqlParameter("@nombreABuscar", nombreABuscar);

            return context.Equipo.FromSqlRaw<Equipo>("SELECT * FROM Equipo WHERE nomEquipo = @nombreABuscar", parameter).FirstOrDefault();
		}

		public IEnumerable<Equipo> BuscarEquipos(string elementoABuscar)
		{
            if(string.IsNullOrEmpty(elementoABuscar))
			{
				return context.Equipo;
            }
			return context.Equipo.Where(e => e.nomEquipo.Contains(elementoABuscar) || e.ciudad.Contains(elementoABuscar));
            
        }

		

	}	
	
}
