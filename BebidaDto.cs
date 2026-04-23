using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection.Metadata;
using System.Threading.Tasks;

namespace CardapioAPI
{
    public class BebidaDto
    {
        public string? Nome { get; set; }
        public string? Tipo { get; set; }
        public decimal Preco { get; set; }
    }
}