using Autofac;
using WebApiDDD.Application;
using WebApiDDD.Application.Interfaces;
using WebApiDDD.Application.Interfaces.Mapper;
using WebApiDDD.Application.Mapper;
using WebApiDDD.Domain.Core.Interfaces.Repositories;
using WebApiDDD.Domain.Core.Services;
using WebApiDDD.Domain.Services;
using WebApiDDD.Infrastructure.Data.Repositories;

namespace WebApiDDD.Infrastructure.CrossCuting.IOC
{
    public class ConfigurationIOC
    {
        public static void Load(ContainerBuilder builder)
        {
            #region IOC

            builder.RegisterType<ApplicationServiceProduto>().As<IApplicationServiceProduto>();
            builder.RegisterType<ServiceProduto>().As<IServiceProduto>();
            builder.RegisterType<RepositoryProduto>().As<IRepositoryProduto>();
            builder.RegisterType<MapperProduto>().As<IMapperProduto>();

            #endregion IOC
        }
    }
}