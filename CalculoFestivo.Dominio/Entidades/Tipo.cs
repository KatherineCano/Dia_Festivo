using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculoFestivo.Dominio.Entidades
{
    [Table("Tipo")]
    public class Tipo
    {

        [Column("id")]
        public int Id { get; set; }

        [Column("tipo"), StringLength(100)]
        public string tipo { get; set; }

        
    }
}
