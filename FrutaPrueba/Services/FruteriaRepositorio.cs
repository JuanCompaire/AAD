using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Modelos;
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

        public IEnumerable<Fruteria> GetFruterias()
        {
            return context.Fruteria.FromSqlRaw<Fruteria>("SELECT * FROM Fruteria").ToList();
        }

        public Fruteria GetFruteriaById(int id)
        {
            SqlParameter parameter = new SqlParameter("@id", id);

            return context.Fruteria.Find(id);
        }

        public Fruteria Delete(int id)
        {
            Fruteria fruteriadelete = context.Fruteria.Find(id);

            if (fruteriadelete != null)
            {
                context.Fruteria.Remove(fruteriadelete);
                context.SaveChanges();
            }

            return fruteriadelete;
        }  

        public void Update(Fruteria fruteriaActualizado)
        {
            context.Database.ExecuteSqlRaw("actualizarFruteria {0},{1},{2}",
                fruteriaActualizado.nombre,
                fruteriaActualizado.fruta,
                fruteriaActualizado.foto);
        }

        public void Add(Fruteria fruteriaNuevo)
        {
            context.Database.ExecuteSqlRaw("insertarFruteria {0},{1},{2}",
                fruteriaNuevo.nombre,
                fruteriaNuevo.fruta,
                fruteriaNuevo.foto);
                

            return;
        }

        



        
    }
}
