using DeliveryCafe.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeliveryCafe.API.Models
{
    public class Pedido
    {
        public int Id { get; set; }
        public int Qtd { get; set; }
        public decimal Total { get; set; }
        public string Descricao { get; set; }
        public List<Produto> Produtos { get; set; }
        public int IdUsuario { get; set; }
        public Usuario Usuario { get; set; }
    }
}
