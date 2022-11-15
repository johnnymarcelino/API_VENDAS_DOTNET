using APIVendas.Models;
using APIVendas.Responses;
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
    public class PedidoController : ControllerBase
    {
        [HttpGet]  // retorna para o navegador 
        public ActionResult<List<Pedido>> Get()
        {
            var pedido = new Pedido()
            {
                Nr_Pedido = 1,
                Cliente = new Cliente(),
                DT_Pedido = DateTime.Now,
                Tipo = "V",
                Itens = new List<PedidoItem>()
            };

            var pedido2 = new Pedido() {
                Nr_Pedido = 1,
                Cliente = new Cliente(),
                DT_Pedido = DateTime.Now,
                Tipo = "V",
                Itens = new List<PedidoItem>()
            };

            var pedidos = new List<Pedido>();
            pedidos.Add(pedido);
            pedidos.Add(pedido2);
            return pedidos;
        }

        [HttpGet("{nr_pedido}")]
        public ActionResult<Pedido> Get(string nr_pedido)
        {
            var pedido = new Pedido()
            {
                Nr_Pedido = 3,
                Cliente = new Cliente(),
                DT_Pedido = DateTime.Now,
                Tipo = "Diagonal",
                Itens = new List<PedidoItem>()
            };

            return pedido;
        }

        [HttpPost]  // somente no corpo da requisição - formato JSON
        public ActionResult<ReturnResponse> Post([FromBody] Pedido request)
        {
            var retorno = new ReturnResponse()
            {
                Code = 200,
                Message = "Registro cadastrado com sucesso!"
            };

            return retorno;
        }

        [HttpPut]  // somente no corpo da requisição - formato JSON
        public ActionResult<ReturnResponse> Put([FromBody] Pedido request)  // vem no corpo da requisição
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
