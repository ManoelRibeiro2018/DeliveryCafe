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
        public List<Pedido> Pedidos { get; set; }
        public List<Produto> Produtos { get; set; }
        
    }
}
