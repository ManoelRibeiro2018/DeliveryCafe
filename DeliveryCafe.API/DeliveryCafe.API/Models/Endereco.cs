using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DeliveryCafe.Models
{
    public class Endereco
    {
        public int Id { get; set; }
        [Required]
        public string CEP { get; set; }
        [Required]
        public string Logadouro { get; set; }
        [Required]
        public string Cidade { get; set; }
        [Required]
        public string Bairro { get; set; }
        [Required]
        public int IdUsuario { get; set; }
        public Usuario Usuario { get; set; }
    }
}
