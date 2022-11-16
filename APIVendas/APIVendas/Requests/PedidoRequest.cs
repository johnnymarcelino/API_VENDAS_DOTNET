using System;
using System.Collections.Generic;

namespace APIVendas.Models
{
    public class PedidoRequest
    {
        public int Nr_Pedido { get; set; }
        public DateTime DT_Pedido { get; set; }
        public string Tipo { get; set; }
        public Cliente Cliente { get; set; }
        public List<PedidoItemRequest> Itens { get; set; }
    }
}
