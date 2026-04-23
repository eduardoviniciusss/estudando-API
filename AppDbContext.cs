using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Npgsql.EntityFrameworkCore.PostgreSQL;

namespace CardapioAPI
{
    public class AppDbContext : DbContext
    {
     public AppDbContext(DbContextOptions<AppDbContext>options):
     base(options){}

     protected override void OnModelCreating(ModelBuilder modelBuilder)
     {
         base.OnModelCreating(modelBuilder);
     }

//Criando a tabalela
     public DbSet<Bebida> Bebidas => Set<Bebida>();
     
    }
}


