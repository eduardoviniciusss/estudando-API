using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CardapioAPI
{
    public class Bebida
    {
        public int Id { get; set; }
        public string? Nome { get; set; }
        public string? Tipo { get; set; }
        [Column(TypeName = "decimal(10,2)")]
        public decimal? Preco { get; set; }
    }
}