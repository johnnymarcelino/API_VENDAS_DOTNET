using APIVendas.Models;
using Dapper;
using Dapper.Contrib.Extensions;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;

namespace APIVendas.Repositories
{
    public static class BaseRepository
    {
        public static List<T> QuerySql<T>(string sql, object parameter = null)
        {
            List<T> orderDetail;
            using (var connection = new SqlConnection("Server=.\\sqlexpress;Database=Vendas;Trusted_Connection=True;"))
            {
                orderDetail = connection.Query<T>(sql, parameter).ToList();
            }

            return orderDetail;
        }

        public static void Delete<T>(int id) where T : BaseModel // <T> tipo anônimo de qualquer objeto
        {
            using (var connection = new SqlConnection("Server=.\\sqlexpress;Database=Vendas;Trusted_Connection=True;"))
            {
                string query = $"select * from {typeof(T).Name} where id = @id";  // typeof pega o tipo do objeto retornado para identificar
                var objeto = connection.Query<T>(query, new { id });
                connection.Delete(objeto);
            }
        }

        public static void Command<T>(T objeto, bool editar = false, object parameter = null) where T : BaseModel // <T> tipo anônimo de qualquer objeto
        {
            using (var connection = new SqlConnection("Server=.\\sqlexpress;Database=Vendas;Trusted_Connection=True;"))
            {
                if (editar)
                {
                    connection.Update(objeto);
                }
                else
                    connection.Insert(objeto);
            }
        }
    }
}
