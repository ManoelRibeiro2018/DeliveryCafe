using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeliveryCafe.Models
{
    public class Endereco
    {
        public int Id { get; set; }
        public string CEP { get; set; }
        public string Logadouro { get; set; }
        public string Cidade { get; set; }
        public string Bairro { get; set; }
        public int IdUsuario { get; set; }
        public Usuario Usuario { get; set; }
    }
}
