using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using WebApiDDD.Application.DTOs;
using WebApiDDD.Application.Interfaces.Mapper;
using WebApiDDD.Domain.Entities;

namespace WebApiDDD.Application.Mapper
{
    public class MapperProduto : IMapperProduto
    {
        public Produto MapperDtoToEntity(ProdutoDTO produtoDTO)
        {
            var produto = new Produto()
            {
                Id = produtoDTO.Id,
                Nome = produtoDTO.Nome,
                Descricao = produtoDTO.Descricao,
                DataCadastro = produtoDTO.DataCadastro,
                DataFabricacao = produtoDTO.DataFabricacao,
                DataValidade = produtoDTO.DataValidade,
                CodigoFornecedor = produtoDTO.CodigoFornecedor,
                DescricaoFornecedor = produtoDTO.DescricaoFornecedor,
                CnpjFornecedor = produtoDTO.CnpjFornecedor,
                Ativo = produtoDTO.Ativo
            };

            return produto;
        }

        public ProdutoDTO MapperEntityToDto(Produto produto)
        {
            try
            {
                var produtoDTO = new ProdutoDTO()
                {
                    Id = produto.Id,
                    Nome = produto.Nome,
                    Descricao = produto.Descricao,
                    DataCadastro = produto.DataCadastro,
                    DataFabricacao = produto.DataFabricacao,
                    DataValidade = produto.DataValidade,
                    CodigoFornecedor = produto.CodigoFornecedor,
                    DescricaoFornecedor = produto.DescricaoFornecedor,
                    CnpjFornecedor = produto.CnpjFornecedor,
                    Ativo = produto.Ativo
                };
                return produtoDTO;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<ProdutoDTO> MapperListProdutoDtop(IEnumerable<Produto> produtos)
        {
            var dto = produtos.Select(x => new ProdutoDTO
            {
                Id = x.Id,
                Nome = x.Nome,
                Descricao = x.Descricao,
                DataCadastro = x.DataCadastro,
                DataFabricacao = x.DataFabricacao,
                DataValidade = x.DataValidade,
                CodigoFornecedor = x.CodigoFornecedor,
                DescricaoFornecedor = x.DescricaoFornecedor,
                CnpjFornecedor = x.CnpjFornecedor,
                Ativo = x.Ativo
            });

            return dto;
        }
    }
}