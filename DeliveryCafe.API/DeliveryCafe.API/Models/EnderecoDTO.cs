using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DeliveryCafe.API.Models
{
    public class EnderecoDTO
    {
        public int Id { get; set; }
        public string CEP { get; set; }
        public string Logadouro { get; set; }
        public string Cidade { get; set; }
        public string Bairro { get; set; }
        public int IdUsuario { get; set; }
    }
}
