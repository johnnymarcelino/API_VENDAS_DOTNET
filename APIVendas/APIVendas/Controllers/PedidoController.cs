using APIVendas.Models;
using APIVendas.Responses;
using APIVendas.Requests;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIVendas.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PedidoRequestController : ControllerBase
    {
        [HttpGet]  // retorna para o navegador 
        public ActionResult<List<PedidoResponse>> Get()
        {
            var pedido = new PedidoResponse()
            {
                Nr_Pedido = "1",
                Cliente = new Cliente().ToString(),
                DT_Pedido = DateTime.Now.ToString(),
                Tipo = "Vermelho",
                Itens = new List<PedidoItemRequest>().ToString()
            };

            var pedido2 = new PedidoResponse() {
                Nr_Pedido = "2",
                Cliente = new Cliente().ToString(),
                DT_Pedido = DateTime.Now.ToString(),
                Tipo = "Azul",
                Itens = new List<PedidoItemRequest>().ToString()
            };

            var pedidos = new List<PedidoResponse>();
            pedidos.Add(pedido);
            pedidos.Add(pedido2);
            return pedidos;
        }

        [HttpGet("{nr_pedido}")]
        public ActionResult<PedidoResponse> Get(string nr_pedido)
        {
            var pedido = new PedidoResponse()
            {
                Nr_Pedido = "3",
                Cliente = new Cliente().ToString(),
                DT_Pedido = DateTime.Now.ToString(),
                Tipo = "Diagonal",
                Itens = new List<PedidoItemRequest>().ToString()
            };

            return pedido;
        }

        [HttpPost]  // somente no corpo da requisição - formato JSON
        public ActionResult<ReturnResponse> Post([FromBody] PedidoRequest request)
        {
            var retorno = new ReturnResponse()
            {
                Code = 200,
                Message = "Registro cadastrado com sucesso!"
            };

            return retorno;
        }

        [HttpPut]  // somente no corpo da requisição - formato JSON
        public ActionResult<ReturnResponse> Put([FromBody] PedidoRequest request)  // vem no corpo da requisição
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
        /*
        */
    }
}
