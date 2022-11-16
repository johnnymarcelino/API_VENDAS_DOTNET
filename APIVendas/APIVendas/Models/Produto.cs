using Dapper.Contrib.Extensions;
using System;

namespace APIVendas.Models
{
    [Table("produto")]  // declaração da tabela prduto
    public class Produto : BaseModel
    {
        [ExplicitKey]  // passar valores de forma manual
        public int Id { get; set; }
        public string Descricao { get; set; }
        public int Estoque { get; set; }
        public decimal Valor { get; set; }

        public static implicit operator Produto(Cliente v)
        {
            throw new NotImplementedException();
        }
    }
}
