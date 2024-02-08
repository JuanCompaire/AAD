using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Modelos;

namespace Services
{
    public class GeografiaDbContext : DbContext
    {
        public DbSet<Provincia> Provincias { get; set; }

        public GeografiaDbContext(DbContextOptions<GeografiaDbContext> options) : base(options)
        {
        }
    }
}
