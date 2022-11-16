namespace APIVendas.Models
{
    public class ProdutoRequest
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public int Estoque { get; set; }
        public decimal Valor { get; set; }
    }
}
