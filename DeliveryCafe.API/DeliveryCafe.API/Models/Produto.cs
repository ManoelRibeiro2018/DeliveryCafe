using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeliveryCafe.API.Models
{
    public class Produto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public decimal Preco { get; set; }
        public int Qtd { get; set; }
        public int? IdPedido { get; set; }
        public Pedido? Pedido { get; set; }

    }
}
