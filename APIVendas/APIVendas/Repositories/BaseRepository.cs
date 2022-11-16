using APIVendas.Models;
using Dapper;
using Dapper.Contrib.Extensions;
using System.Collections.Generic;
using System.Data.SqlClient;
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
