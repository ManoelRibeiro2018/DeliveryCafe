using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeliveryCafe.API.Models
{
    public class CarrinhoCompra
    {
        public int Id { get; set; }
        public int Qtd { get; set; }
        public decimal Total { get; set; }
        public int IdPedido { get; set; }
        public Pedido Pedido { get; set; }
        public int IdProduto { get; set; }
        public Produto Produto { get; set; }
        
    }
}
