using System.Collections.Generic;

namespace WebApiDDD.Domain.Core.Services
{
    public interface IServiceBase<TEntity> where TEntity : class
    {
        void Add(TEntity entity);

        void Update(TEntity entity);

        void Remove(TEntity entity);

        IEnumerable<TEntity> GetAll();
        IEnumerable<TEntity> GetAll(string orderBy, string query, string value, int pag);

        TEntity GetById(long id);
    }
}