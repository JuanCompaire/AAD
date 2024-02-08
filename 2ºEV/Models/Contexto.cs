using Microsoft.EntityFrameworkCore;


namespace _2ºEV.Models
{
    public class Contexto : DbContext
    {

        public Contexto(DbContextOptions<Contexto> options): base(options)
        {
            
        }
        public DbSet<MarcaModelo> Marcas { get; set; }

        public DbSet<SerieModelo> Series { get; set; }

        public DbSet<VehiculoModelo> Vehiculos { get; set; }
    }
}
