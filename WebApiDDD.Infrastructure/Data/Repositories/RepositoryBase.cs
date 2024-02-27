using Microsoft.Data.SqlClient.Server;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using WebApiDDD.Domain.Core.Interfaces.Repositories;

namespace WebApiDDD.Infrastructure.Data.Repositories
{
    public class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : class
    {
        private readonly SqlContext sqlContext;

        public RepositoryBase(SqlContext sqlContext)
        {
            this.sqlContext = sqlContext;
        }

        public void Add(TEntity entity)
        {
            try
            {
                sqlContext.Set<TEntity>().Add(entity);
                sqlContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public virtual IEnumerable<TEntity> GetAll()
        {
            return sqlContext.Set<TEntity>().ToList();
        }

        public virtual IEnumerable<TEntity> GetAll(string orderBy, string query, string value, int pag)
        {
            return sqlContext.Set<TEntity>().ToList().OrderBy(x => orderBy);
        }

        public virtual TEntity GetById(long id)
        {
            return sqlContext.Set<TEntity>().Find(id);
        }

        public void Remove(TEntity entity)
        {
            try
            {
                sqlContext.Set<TEntity>().Remove(entity);
                sqlContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Update(TEntity entity)
        {
            try
            {
                sqlContext.Entry(entity).State = EntityState.Modified;
                sqlContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}