using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculoFestivo.Dominio.codigocalculofestivo
{
    public class codigocalculofestivo
    {
        private readonly ApplicationDbContext _context;

        public Festivo(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> EsFestivoAsync(DateTime fecha)
        {
            // Verificar si es un festivo fijo
            var festivoFijo = await _context.Festivos
                .Where(f => f.Fecha.Date == fecha.Date && f.EsFijo)
                .FirstOrDefaultAsync();

            if (festivoFijo != null)
                return true;

            // Lógica para verificar festivos por ley de puente
            var fechaModificada = ObtenerFechaModificada(fecha);
            var festivoLeyPuente = await _context.Festivos
                .Where(f => f.Fecha.Date == fechaModificada.Date)
                .FirstOrDefaultAsync();

            if (festivoLeyPuente != null)
                return true;

            // Verificar festivos basados en el Domingo de Pascua
            var domingoPascua = CalcularDomingoPascua(fecha.Year);
            if (fecha.Date == domingoPascua.Date || fecha.Date == domingoPascua.AddDays(7).Date)
                return true;

            return false;
        }

        private DateTime ObtenerFechaModificada(DateTime fecha)
        {
            // Lógica para trasladar la fecha al siguiente lunes si cae en fin de semana
            if (fecha.DayOfWeek == DayOfWeek.Saturday)
                return fecha.AddDays(2); // Sábado se convierte en Lunes
            if (fecha.DayOfWeek == DayOfWeek.Sunday)
                return fecha.AddDays(1); // Domingo se convierte en Lunes

            return fecha;
        }

        private DateTime CalcularDomingoPascua(int año)
        {
            // Fórmula para calcular el Domingo de Pascua
            int a = año % 19;
            int b = año % 4;
            int c = año % 7;
            int d = (19 * a + 24) % 30;
            int días = (d + (2 * b + 4 * c + 6 * d + 5) % 7);

            DateTime domingoRamos = new DateTime(año, 3, 15).AddDays(días);
            DateTime domingoPascua = domingoRamos.AddDays(7); // Domingo de Pascua es una semana después de Domingo de Ramos

            return domingoPascua;
        }
    }
}
    
