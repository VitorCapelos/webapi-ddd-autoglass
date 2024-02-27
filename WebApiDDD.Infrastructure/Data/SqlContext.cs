using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using WebApiDDD.Domain.Entities;

namespace WebApiDDD.Infrastructure.Data
{
    public class SqlContext : DbContext
    {
        public SqlContext()
        {
        }

        public SqlContext(DbContextOptions<SqlContext> options)
            : base(options)
        {
        }

        public DbSet<Produto> Produtos { get; set; }

        public override int SaveChanges()
        {
            foreach (var entrada in ChangeTracker.Entries().Where(entrada => entrada.Entity.GetType().GetProperty("Descricao") != null))
            {
                if ((entrada.State == EntityState.Added || entrada.State == EntityState.Modified)
                    && (DateTime)entrada.Property("DataFabricacao").CurrentValue > (DateTime)entrada.Property("DataValidade").CurrentValue)
                {
                    throw new InvalidOperationException();
                }

                if (entrada.State == EntityState.Added)
                {
                    entrada.Property("DataCadastro").CurrentValue = DateTime.Now;
                    entrada.Property("Ativo").CurrentValue = true;
                }

                if (entrada.State == EntityState.Modified)
                {
                    entrada.Property("DataCadastro").IsModified = false;
                }

                if (entrada.State == EntityState.Deleted)
                {
                    entrada.State = EntityState.Modified;
                    entrada.Property("Ativo").CurrentValue = !(bool)entrada.Property("Ativo").CurrentValue;
                }
            }
            return base.SaveChanges();
        }
    }
}