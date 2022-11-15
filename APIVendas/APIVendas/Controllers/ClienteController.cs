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
    [Route("[controller]")]
    public class ClienteController : ControllerBase
    {
        [HttpGet]  // retorna para o navegador 
        public ActionResult<List<Cliente>> Get()
        {
            var cliente = new Cliente()
            {
                Id = 1,
                Nome = "Johnny Marcelino",
                Email = "marcelino@email.com",
                DT_Nascimento = DateTime.Now.AddYears(-20)
            };

            var cliente2 = new Cliente()
            {
                Id = 2,
                Nome = "Johnny Gabriel",
                Email = "gabriel@email.com",
                DT_Nascimento = DateTime.Now.AddYears(-27)
            };

            var clientes = new List<Cliente>();
            clientes.Add(cliente);
            clientes.Add(cliente2);
            return clientes;
        }

        [HttpGet("{id}")]
        public ActionResult<Cliente> Get(string id)
        {
            var cliente = new Cliente()
            {
                Id = 3,
                Nome = "Johnny",
                Email = "johnny@email.com",
                DT_Nascimento = DateTime.Now.AddYears(-20)
            };

            return cliente;
        }

        [HttpPost]  // somente no corpo da requisição - formato JSON
        public ActionResult<ReturnResponse> Post([FromBody] Cliente request)
        {
            var retorno = new ReturnResponse()
            {
                Code = 200,
                Message = "Registro cadastrado com sucesso!"
            };

            return retorno;
        }

        [HttpPut]  // somente no corpo da requisição - formato JSON
        public ActionResult<ReturnResponse> Put([FromBody] Cliente request)  // vem no corpo da requisição
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
