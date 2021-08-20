using AutoMapper;
using DeliveryCafe.API.Interface.Especification;
using DeliveryCafe.API.Models;
using DeliveryCafe.API.Repository;
using DeliveryCafe.Models;

namespace DeliveryCafe.API.Especification
{
    public class EnderecoEspecification : ISpecification<EnderecoDTO>
    {
        private readonly EnderecoRepository _enderecoRepository;
        private readonly IMapper _mapper;

        public EnderecoEspecification(EnderecoRepository enderecoRepository, IMapper mapper)
        {
            _enderecoRepository = enderecoRepository;
            _mapper = mapper;
        }
        public bool IsSatisfiedBy(EnderecoDTO Entity)
        {
            var endereco = _mapper.Map<Endereco>(Entity);
            return _enderecoRepository.CheckDuplicity(endereco);
        }
    }
}
