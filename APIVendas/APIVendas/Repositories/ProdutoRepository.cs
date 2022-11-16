using APIVendas.Models;
using System.Collections.Generic;

namespace APIVendas.Repositories
{
    public static class ProdutoRepository
    {
        public static void Gravar(Produto produto)
        {
            BaseRepository.Command(produto);
        }

        public static void Atualizar(Produto produto)
        {
            BaseRepository.Command(produto, true);
        }

        public static List<Produto> Buscar(int id = 0, string descricao = "")
        {
            string sql = "select*from produto";

            if (id > 0)
            {
                sql += " where id = @idProduto";
            }

            if (!string.IsNullOrEmpty(descricao))
            {
                if (sql.Contains(descricao))
                {
                    sql += " and descricao like = @descricaoProduto";
                }
                else
                {
                    sql += " where descricao like = @descricaoProduto";
                }
            }

            var retorno = BaseRepository.QuerySql<Produto>(sql, new { idProduto = id, descricaoProduto = "%" + descricao + "%" });
            return retorno;
        }

    }
}
