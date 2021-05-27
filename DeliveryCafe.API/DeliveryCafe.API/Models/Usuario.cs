using DeliveryCafe.API.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DeliveryCafe.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        [Required, MaxLength(100), MinLength(4)]
        public string Nome { get; set; }
        [Required, MaxLength(14)]
        public string Cpf { get; set; }
        [Required, EmailAddress]
        public string Email { get; set; }
        [Required, MinLength(4)] 
        public string Senha { get; set; }
        [Required, MinLength(4)]
        public string ConfirmaSenha { get; set; }
        public List<Endereco>? Enderecos{ get; set; }
        public List<Pedido>? Pedidos { get; set; }
    }
}
