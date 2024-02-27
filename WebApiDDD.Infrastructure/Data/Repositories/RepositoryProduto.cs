using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using WebApiDDD.Domain.Core.Interfaces.Repositories;
using WebApiDDD.Domain.Entities;

namespace WebApiDDD.Infrastructure.Data.Repositories
{
    public class RepositoryProduto : RepositoryBase<Produto>, IRepositoryProduto
    {
        private readonly SqlContext sqlContext;

        public RepositoryProduto(SqlContext sqlContext)
            : base(sqlContext)
        {
            this.sqlContext = sqlContext;
        }

        public override IEnumerable<Produto> GetAll()
        {
            return sqlContext.Set<Produto>().Where(x => x.Ativo == true).ToList();
        }

        public override IEnumerable<Produto> GetAll(string orderBy, string query, string value, int pag)
        {
            var registrosAtivos = sqlContext.Set<Produto>().ToList();

            orderBy = orderBy ?? "";
            query = query ?? "";
            value = value ?? "";

            if (!string.IsNullOrEmpty(query) && !string.IsNullOrEmpty(value))
                registrosAtivos = registrosAtivos.Where(y => y.GetType().GetProperty(query).GetValue(y).ToString().Contains(value)).ToList();

            if (!string.IsNullOrEmpty(orderBy))
                registrosAtivos = registrosAtivos.OrderBy(s => s.GetType().GetProperty(orderBy).GetValue(s)).ToList();

            return registrosAtivos.Take(pag);
        }

        public override Produto GetById(long id)
        {
            return sqlContext.Set<Produto>().AsNoTracking().FirstOrDefault(x => x.Id == id);
        }
    }
}