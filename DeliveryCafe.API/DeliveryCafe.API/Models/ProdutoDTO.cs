using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DeliveryCafe.API.Models
{
    public class ProdutoDTO
    {
        public int Id { get; set; }
        [Required, MaxLength(100), MinLength(4)]
        public string Nome { get; set; }
        [Required]
        public decimal Preco { get; set; }
        [Required]
        public int Qtd { get; set; }
    }
}
