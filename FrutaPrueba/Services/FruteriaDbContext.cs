using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Modelos;


namespace Services
{
    public class FruteriaDbContext : DbContext
    {

        public DbSet<Fruteria> Fruteria { get; set; }

        public FruteriaDbContext(DbContextOptions<FruteriaDbContext> options) : base(options)
        {

        }
    }
}
