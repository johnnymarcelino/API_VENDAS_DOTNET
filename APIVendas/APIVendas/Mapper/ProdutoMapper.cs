using APIVendas.Models;
using APIVendas.Requests;
using APIVendas.Responses;

namespace APIVendas.Mapper
{
    public static class ProdutoMapper
    {
        public static Produto Mapper(ProdutoRequest produtoRequest)
        {
            return new Produto()
            {
                Id = produtoRequest.Id,
                Descricao = produtoRequest.Descricao,
                Estoque = produtoRequest.Estoque,
                Valor = produtoRequest.Valor
            };
        }

        public static ProdutoResponse Mapper(Produto produto)  // mapeando o produto e retornando response
        {
            return new ProdutoResponse()
            {
                Id = produto.Id.ToString(),
                Descricao = produto.Descricao.ToString(),
                Estoque = produto.Estoque.ToString(),
                Valor = produto.Valor.ToString()
            };
        }
    }
}
