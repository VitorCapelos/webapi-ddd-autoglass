using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using WebApiDDD.Application.DTOs;
using WebApiDDD.Application.Interfaces;

namespace WebApiDDD.API.Controllers
{
    [Route("produto/")]
    [ApiController]
    public class ProdutosController : Controller
    {
        private readonly IApplicationServiceProduto _applicationServiceProduto;

        public ProdutosController(IApplicationServiceProduto applicationServiceProduto)
        {
            _applicationServiceProduto = applicationServiceProduto;
        }

        [HttpGet("/produto/query")]
        public ActionResult<IEnumerable<string>> Get(string orderBy, string query, string value, int pag)
        {
            pag = pag == 0 ? 10 : pag;

            return Ok(_applicationServiceProduto.GetAll(orderBy, query, value, pag));
        }


        [HttpGet("{id}")]
        public ActionResult<string> Get(long id)
        {
            try
            {
                return Ok(_applicationServiceProduto.GetById(id));
            }
            catch (Exception ex)
            {
                return BadRequest("Não foi possível encontrar o registro solicitado. Ex: " + ex.Message);
            }
        }

        [HttpPost]
        public ActionResult Post([FromBody] ProdutoDTO produtoDTO)
        {
            try
            { 
                if (produtoDTO == null)
                    return NotFound();

                _applicationServiceProduto.Add(produtoDTO);
                return Ok("Produto cadastrado com sucesso!");
            }
            catch (Exception ex)
            {
                return BadRequest("Não foi possível cadastrar o produto");
            }
        }

        [HttpPut("/produto/alteraStatus/{id}")]
        public ActionResult<string> Put(long id)
        {
            try
            {
                _applicationServiceProduto.Remove(_applicationServiceProduto.GetById(id)) ;
                return Ok("Status do produto alterado com sucesso!");
            }
            catch (Exception ex)
            {
                return BadRequest("Não foi possível alterar o status do produto mencionado. Ex: " + ex);
            }
        }

        [HttpPut]
        public ActionResult Put([FromBody] ProdutoDTO produtoDTO)
        {
            try
            {
                if (produtoDTO == null)
                    return NotFound();

                _applicationServiceProduto.Update(produtoDTO);
                return Ok("Produto atualizado com sucesso!");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
