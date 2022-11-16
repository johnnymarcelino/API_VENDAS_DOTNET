using APIVendas.Models;
using APIVendas.Responses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System;
using APIVendas.Repositories;
using System.Linq;

namespace APIVendas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoRequestController : ControllerBase
    {
        [HttpGet]  // retorna para o navegador 
        public ActionResult<List<Produto>> Get()
        {
            //var produto = new ProdutoResponse()
            //{
            //    Id = "1",
            //    Descricao = "Notebook",
            //    Estoque = "2",
            //    Valor = "2999"
            //};

            //var produto2 = new ProdutoResponse()
            //{
            //    Id = "2",
            //    Descricao = "Mouse",
            //    Estoque = "10",
            //    Valor = "50"
            //};

            return ProdutoRepository.Buscar(0, "");

            //var produtos = new List<ProdutoResponse>();
            //produtos.Add(produto);
            //produtos.Add(produto2);
            //return produtos;
        }

        [HttpGet("{id}")]
        public ActionResult<Produto> Get(int id)
        {
            //var produto = new ProdutoResponse()
            //{
            //    Id = "3",
            //    Descricao = "Teclado",
            //    Estoque = "25",
            //    Valor = "80"
            //};

            //return produto;

            return ProdutoRepository.Buscar(id).FirstOrDefault();

        }

        [HttpPost]  // somente no corpo da requisição - formato JSON
        public ActionResult<ReturnResponse> Post([FromBody] ProdutoRequest request)
        {
            var retorno = new ReturnResponse()
            {
                Code = 200,
                Message = $"Registro {request} cadastrado com sucesso!"
            };

            return retorno;
        }

        [HttpPut]  // somente no corpo da requisição - formato JSON
        public ActionResult<ReturnResponse> Put([FromBody] ProdutoRequest request)  // vem no corpo da requisição
        {
            var retorno = new ReturnResponse()
            {
                Code = 200,
                Message = "Registro cadastrado com sucesso!"
            };

            return retorno;
        }

        [HttpDelete("{id}")]  // passar o id de quem vai deletar
        public ActionResult<ReturnResponse> Delete(string id)  // recebe o id de quem vai deletar
        {
            var retorno = new ReturnResponse()
            {
                Code = 200,
                Message = "Registro cadastrado com sucesso!"
            };

            return retorno;
        }
    }
}
