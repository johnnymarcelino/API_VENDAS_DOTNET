using System;
using System.Collections.Generic;

namespace APIVendas.Models
{
    public class PedidoResponse
    {
        public string Nr_Pedido { get; set; }
        public string DT_Pedido { get; set; }
        public string Tipo { get; set; }
        public string Cliente { get; set; }
        public string Itens { get; set; }
    }
}
