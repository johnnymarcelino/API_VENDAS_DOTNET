using APIVendas.Models;
using Dapper;
using Microsoft.OpenApi.Models;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection.Metadata;

namespace APIVendas.Repositories
{
    public static class PedidoRepository
    {
        public static void Gravar(Pedido pedido)
        {
            BaseRepository.Command(pedido);
        }

        public static void Atualizar(Pedido pedido)
        {
            BaseRepository.Command(pedido, true);
        }

        public static List<Pedido> Buscar(int nrpedido, int clienteId = 0)
        {
            string sql = @" select
                            p.NumeroPedido,
                            p.Data,
                            p.Tipo,
                            p.id_cliente,
                            c.id,
                            c.Nome,
                            c.Email,
                            c.Dt_Nascimento from pedido p
                            join Cliente c on p.id_cliente = c.id";

            if (nrpedido > 0)
            {
                sql += " where id = @NrPedido";
            }

            if (clienteId > 0)
            {
                if (sql.Contains("where"))
                {
                    sql += " and id_cliente = @Id_cliente";
                }
                else
                {
                    sql += " where id_cliente = @Id_cliente";
                }
            }

            List<Pedido> orderDetail;
            using (var connection = new SqlConnection(BaseRepository.ConnectionString))
            {
                orderDetail = connection.Query<Pedido, Cliente, Pedido>(sql, map : mapPropriedades, splitOn: "id", param: new { NrPedido = nrpedido, Id_cliente = clienteId  }).ToList();
            }

            const string sqlItem = @"select from pedidoItem where NumeroPedido = @NumeroPedido";

            foreach (var item in orderDetail)
            {
                using (var connection = new SqlConnection(BaseRepository.ConnectionString))
                {
                    item.Itens.AddRange(connection.QuerySingle<PedidoItem>(
                        sqlItem,
                        map: mapPropriedades,
                        splitOn: "id",
                        param: new { NrPedido = nrpedido, Id_cliente = clienteId }).ToList());
                }
                //item.Itens.AddRange();
            }

            return orderDetail;
        }

        private static Pedido mapPropriedades(Pedido pedido, Cliente cliente)
        {
            pedido.Cliente = cliente;
            return pedido;
        }
    }
}
