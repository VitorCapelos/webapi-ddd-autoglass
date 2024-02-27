using System.Collections.Generic;
using WebApiDDD.Application.DTOs;

namespace WebApiDDD.Application.Interfaces
{
    public interface IApplicationServiceProduto
    {
        void Add(ProdutoDTO produtoDTO);

        void Update(ProdutoDTO produtoDTO);

        void Remove(ProdutoDTO produtoDTO);

        IEnumerable<ProdutoDTO> GetAll();

        IEnumerable<ProdutoDTO> GetAll(string orderBy, string query, string value, int pag);

        ProdutoDTO GetById(long id);
    }
}