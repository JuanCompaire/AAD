using Microsoft.EntityFrameworkCore;
using static Repaso_2EV.Controllers.VehiculoController;

namespace Repaso_2EV.Models
{
    public class Contexto : DbContext
    {

        public Contexto(DbContextOptions<Contexto> options) : base(options)
        {


        }

        public DbSet<MarcaModelo> Marcas { get; set; }

        public DbSet<SerieModelo> Series { get; set; }

        public DbSet<VehiculoModelo> Vehiculos { get; set;}

        public DbSet<VehiculoTotal> VistaTotal { get; set; }

		public DbSet<ExtraModelo>? Extras { get; set; }

		public DbSet<VehiculoExtraModelo>? VehiculosExtras { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<VehiculoTotal>().HasNoKey();
			// // Metodo de Agustin (Mas facil lo de arriba @Made_By_Copilot)
			//modelBuilder.Entity<VehiculoTotal>(
			//        eb =>
			//        {
			//            eb.HasNoKey();
			//        }
			//    );
		}


	}
}
