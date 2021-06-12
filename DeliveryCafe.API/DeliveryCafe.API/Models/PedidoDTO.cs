using System;
using System.ComponentModel.DataAnnotations;

namespace DeliveryCafe.API.Models
{
    public class PedidoDTO
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public DateTime DataPedido { get; set; }
        [Required]
        public int IdProduto { get; set; }
        [Required]
        public int IdUsuario { get; set; }
    }
}

