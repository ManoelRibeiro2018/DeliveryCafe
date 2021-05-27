using DeliveryCafe.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DeliveryCafe.API.Models
{
    public class Pedido
    {
        public int Id { get; set; }
        [Required, Range(1, 100)]
        public int Qtd { get; set; }
        [Required]
        public decimal Total { get; set; }        
        public string Descricao { get; set; }
        public DateTime DataPedido { get; set; }
        [Required]
        public List<Produto> Produtos { get; set; }
        [Required]
        public int IdUsuario { get; set; }
        public Usuario Usuario { get; set; }
    }
}
