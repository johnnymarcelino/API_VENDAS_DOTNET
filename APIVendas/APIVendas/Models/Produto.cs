using Dapper.Contrib.Extensions;

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
    }
}
