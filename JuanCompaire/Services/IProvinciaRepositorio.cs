using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelos;


namespace Services
{
    public interface IProvinciaRepositorio
    {
        IEnumerable<Provincia> GetAllProvincias();

        IEnumerable<Provincia> BuscarProvinciasPorComunidad(Comunidad comunidadABuscar);

        IEnumerable<ComunidadCuantos> ProvinciasPorComunidad();

    }

}
