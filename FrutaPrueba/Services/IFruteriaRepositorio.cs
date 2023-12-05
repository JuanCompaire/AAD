using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelos;

namespace Services
{
    public interface IFruteriaRepositorio
    {

        IEnumerable<Fruteria> GetFruterias();

        Fruteria GetFruteriaById(int id);

        Fruteria Delete(int id);

        void Update(Fruteria fruteriaActualizado);

        void Add(Fruteria fruteriaNuevo);



    }
}
