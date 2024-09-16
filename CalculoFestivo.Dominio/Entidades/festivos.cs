using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CalculoFestivo.Dominio.Entidades
{

    [Table("Festivo")]
    public class festivos

    {
        [Column("id")]
        public int Id { get; set; }

        [Column("Nombre"), StringLength(100)]
        public string Nombre { get; set; }

        [Column("Dia")]
        public int Dia { get; set; }

        [Column("Mes")]
        public int Mes { get; set; }

        [Column("DiasPascua")]
        public int DiasPascua { get; set; }

        [Column("idtipo")]
        public int IdTipo { get; set; }
        public Tipo tipo { get; set; }



    }
}
