using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DeliveryCafe.API.Models
{
    public class Produto
    {
        public int Id { get; set; }
        [Required, MaxLength(100), MinLength(4)]
        public string Nome { get; set; }
        [Required]
        public decimal Preco { get; set; }
        [Required]
        public int Qtd { get; set; }
        public List<Pedido>? Pedidos { get; set; }
        public void Update(string nome, decimal preco, int qtd)
        {
            Nome = nome;
            Preco = preco;
            Qtd = qtd;
        }

    }
}
