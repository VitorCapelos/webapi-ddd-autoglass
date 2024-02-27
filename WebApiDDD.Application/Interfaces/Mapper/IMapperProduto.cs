using System.Collections.Generic;
using WebApiDDD.Application.DTOs;
using WebApiDDD.Domain.Entities;

namespace WebApiDDD.Application.Interfaces.Mapper
{
    public interface IMapperProduto
    {
        Produto MapperDtoToEntity(ProdutoDTO produtoDTO);

        IEnumerable<ProdutoDTO> MapperListProdutoDtop(IEnumerable<Produto> produtos);

        ProdutoDTO MapperEntityToDto(Produto produto);
    }
}
