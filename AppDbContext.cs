using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace CardapioAPI
{
    public class AppDbContext : DbContext
    {
     public AppDbContext(DbContextOptions<AppDbContext>options):
     base(options){}

//Criando a tabalela
     public DbSet<Bebida> Bebidas => Set<Bebida>();
    }
}