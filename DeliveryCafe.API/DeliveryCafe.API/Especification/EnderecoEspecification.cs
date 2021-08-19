using DeliveryCafe.API.Interface.Especification;
using DeliveryCafe.API.Repository;
using DeliveryCafe.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeliveryCafe.API.Especification
{
    public class EnderecoEspecification : ISpecification<Endereco>
    {
        private readonly EnderecoRepository _enderecoRepository;

        public EnderecoEspecification(EnderecoRepository enderecoRepository)
        {
            _enderecoRepository = enderecoRepository;
        }
        public bool IsSatisfiedBy(Endereco Entity)
        {
            return _enderecoRepository.CheckDuplicity(Entity);
        }
    }
}
