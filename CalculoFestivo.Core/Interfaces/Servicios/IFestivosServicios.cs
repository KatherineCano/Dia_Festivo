using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculoFestivo.Core.Interfaces.Servicios
{
    public interface IFestivosServicios
    {
        Task<IEnumerable<Festivos>> ObtenerTodos();

        Task<Festivos> Obtener(int Id);

        Task<IEnumerable<Festivos>> Buscar(int IndiceDato, String Dato);

        Task<Festivos> Agregar(Festivos Dato);

        Task<Festivos> Modificar(Festivos Dato);

        Task<bool> Eliminar(int Id);
    }
}
