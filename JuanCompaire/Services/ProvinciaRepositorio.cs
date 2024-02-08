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
    public class ProvinciaRepositorio : IProvinciaRepositorio
    {

        private readonly GeografiaDbContext context;

        public ProvinciaRepositorio(GeografiaDbContext context)
        {
            this.context = context;
        }

        public IEnumerable<Provincia> GetAllProvincias()
        {
            return context.Provincias.FromSqlRaw<Provincia>("SELECT * FROM Provincias").ToList();
        }

        public IEnumerable<Provincia> BuscarProvincias(int comunidadABuscar)
        {
            return context.Provincias.Where(p => p.codComunidad.Equals(comunidadABuscar));
        }

        public IEnumerable<Provincia> BuscarProvinciasPorComunidad(Comunidad comunidadABuscar)
        {
            IEnumerable<Provincia> provincias = context.Provincias;
            provincias = provincias.Where(p => p.codComunidad == comunidadABuscar + 1);
            return provincias;
        }

        public IEnumerable<ComunidadCuantos> ProvinciasPorComunidad()
        {
            return context.Provincias.GroupBy(e =>e.codComunidad).Select(g => new ComunidadCuantos{
            Comunidad = g.Key,
            numComunidades = g.Count()
            }).ToList();}

    }

    
}
