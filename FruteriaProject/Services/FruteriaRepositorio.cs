using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelos;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;


namespace Services
{
    public class FruteriaRepositorio : IFruteriaRepositorio
    {

        private readonly FruteriaDbContext context;

        public FruteriaRepositorio(FruteriaDbContext context)
        {
            this.context = context;
        }

   //     public IEnumerable<Fruteria> GetFruteria()
        
           // return context.Fruteria.FromSqlRaw<Fruteria>("SELECT * FROM Fruteria").ToList();
        
    }
}
