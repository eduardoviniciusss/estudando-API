using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CardapioAPI
{
    public class Bebida
    {
        public int Id { get; set; }
        public string? Nome { get; set; }
        public string? Tipo { get; set; }
        public float Preço { get; set; }
    }
}