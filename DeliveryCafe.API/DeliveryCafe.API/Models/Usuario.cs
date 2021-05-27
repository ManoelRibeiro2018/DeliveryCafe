using DeliveryCafe.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeliveryCafe.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public string ConfirmaSenha { get; set; }
        public List<Endereco> Enderecos{ get; set; }
        public int IdPedido { get; set; }
        public Pedido Perdido { get; set; }
    }
}
