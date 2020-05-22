using Infra.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infra
{
    public class Context : DbContext
    {
        public DbSet<Cliente> Cliente { get; set; }
        public DbSet<Locacao> Locacao { get; set; }
        public DbSet<Filme> Filme { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //optionsBuilder.UseSqlServer(@"Server=(localdb)\\mssqllocaldb;Database=DbLocadora;Trusted_Connection=True;MultipleActiveResultSets=true");
                optionsBuilder.UseSqlServer(@"Data Source=(localdb)\mssqllocaldb;;Database=DbLocadora;Integrated Security=False;Persist Security Info=True;MultipleActiveResultSets=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cliente>().HasData(
                new Cliente { IdCliente = 1, Nome = "Cecília Luzia Drumond", Email = "cecilialuziadrumond@oticascarol.com.br", Telefone = "(95)98476-3855" },
                new Cliente { IdCliente = 2, Nome = "Gabrielly Gabriela Lima", Email = "gabriellygabrielalima_@mirafactoring.com.br", Telefone = "(95)98697-4886" },
                new Cliente { IdCliente = 3, Nome = "Kaique Marcos Gonçalves", Email = "kaiquemarcos@oticascarol.com.br", Telefone = "(95)98242-7258" },
                new Cliente { IdCliente = 4, Nome = "Louise Catarina", Email = "louisecatarina@oticascarol.com.br", Telefone = "(95)99757-0501" },
                new Cliente { IdCliente = 5, Nome = "Hugo Tiago Silva", Email = "hugotiagosilva_@oticascarol.com.br", Telefone = "(95)98214-0378" }
                );
            modelBuilder.Entity<Filme>().HasData(
                new Filme { Idfilme = 1, Nome = "A Casa Monstro" },
                new Filme { Idfilme = 2, Nome = "Dois Caras Legais" },
                new Filme { Idfilme = 3, Nome = "Entrando Numa Fria" },
                new Filme { Idfilme = 4, Nome = "O Lobo de Wall Street" },
                new Filme { Idfilme = 5, Nome = "O Poderoso Chefão" },
                new Filme { Idfilme = 6, Nome = "De Volta Para o Futuro" }
                );
        }



    }
}

