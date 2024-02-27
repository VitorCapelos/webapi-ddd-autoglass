using WebApiDDD.Domain.Core.Interfaces.Repositories;
using WebApiDDD.Domain.Core.Services;
using WebApiDDD.Domain.Entities;

namespace WebApiDDD.Domain.Services
{
    public class ServiceProduto : ServiceBase<Produto>, IServiceProduto
    {
        private readonly IRepositoryProduto repositoryProduto;

        public ServiceProduto(IRepositoryProduto repositoryProduto)
            : base(repositoryProduto)
        {
            this.repositoryProduto = repositoryProduto;
        }
    }
}