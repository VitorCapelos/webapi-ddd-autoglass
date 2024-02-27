using System;
using System.Collections.Generic;
using WebApiDDD.Application.DTOs;
using WebApiDDD.Application.Interfaces;
using WebApiDDD.Application.Interfaces.Mapper;
using WebApiDDD.Domain.Core.Services;

namespace WebApiDDD.Application
{
    public class ApplicationServiceProduto : IApplicationServiceProduto
    {
        private readonly IServiceProduto serviceProduto;
        private readonly IMapperProduto  mapperProduto;

        public ApplicationServiceProduto(IServiceProduto serviceProduto, IMapperProduto mapperProduto)
        {
            this.serviceProduto = serviceProduto;
            this.mapperProduto = mapperProduto;
        }

        public void Add(ProdutoDTO produtoDTO)
        {
            var produto = mapperProduto.MapperDtoToEntity(produtoDTO);
            serviceProduto.Add(produto);
        }

        public IEnumerable<ProdutoDTO> GetAll()
        {
            var produtosDTO = serviceProduto.GetAll();
            return mapperProduto.MapperListProdutoDtop(produtosDTO);
        }

        public IEnumerable<ProdutoDTO> GetAll(string orderBy, string query, string value, int pag)
        {
            var produtosDTO = serviceProduto.GetAll(orderBy, query, value, pag);
            return mapperProduto.MapperListProdutoDtop(produtosDTO);
        }

        public ProdutoDTO GetById(long id)
        {
            var produto = serviceProduto.GetById(id);
            return mapperProduto.MapperEntityToDto(produto);
        }

        public void Remove(ProdutoDTO produtoDTO)
        {
            var produto = mapperProduto.MapperDtoToEntity(produtoDTO);
            
            serviceProduto.Remove(produto);
        }

        public void Update(ProdutoDTO produtoDTO)
        {
            var produto = mapperProduto.MapperDtoToEntity(produtoDTO);
            serviceProduto.Update(produto);
        }
    }
}
