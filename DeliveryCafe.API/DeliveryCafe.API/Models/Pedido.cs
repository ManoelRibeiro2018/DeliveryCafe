using DeliveryCafe.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DeliveryCafe.API.Models
{
    public class Pedido
    {
        public int Id { get; set; }
        [Required]
        public decimal Total { get; set; }        
        public string Descricao { get; set; }
        public DateTime DataPedido { get; set; }
        public List<CarrinhoCompra> CarrinhoCompras  { get; set; }

        [Required]
        public int IdUsuario { get; set; }
        public Usuario Usuario { get; set; }
    }
}
