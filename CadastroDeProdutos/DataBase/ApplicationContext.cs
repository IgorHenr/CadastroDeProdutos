using CadastroDeProdutos.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadastroDeProdutos.DataBase
{
    internal class ApplicationContext : DbContext
    {
        public DbSet<Produtos> produtos { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("ConexionString");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Produtos>()
                    .Property(a => a.Id)
                    .ValueGeneratedOnAdd();
        }
    }
}
