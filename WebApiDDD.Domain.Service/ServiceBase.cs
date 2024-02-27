using System;
using System.Collections.Generic;
using WebApiDDD.Domain.Core.Interfaces.Repositories;
using WebApiDDD.Domain.Core.Services;

namespace WebApiDDD.Domain.Services
{
    public class ServiceBase<TEntity> : IServiceBase<TEntity> where TEntity : class
    {
        private readonly IRepositoryBase<TEntity> repository;

        public ServiceBase(IRepositoryBase<TEntity> repository)
        {
            this.repository = repository;
        }

        public void Add(TEntity entity)
        {
            try
            {
                repository.Add(entity);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<TEntity> GetAll()
        {
            return repository.GetAll();
        }

        public IEnumerable<TEntity> GetAll(string orderBy, string query, string value, int pag)
        {
            return repository.GetAll(orderBy, query, value, pag);
        }

        public TEntity GetById(long id)
        {
            return repository.GetById(id);
        }

        public void Remove(TEntity entity)
        {
            repository.Remove(entity);
        }

        public void Update(TEntity entity)
        {
            repository.Update(entity);
        }
    }
}