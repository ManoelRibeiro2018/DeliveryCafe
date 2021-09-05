using AutoMapper;
using DeliveryCafe.API.Interface.Especification;
using DeliveryCafe.API.Models;
using DeliveryCafe.API.Repository;
using DeliveryCafe.Models;

namespace DeliveryCafe.API.Especification
{
    public class EnderecoEspecification : ISpecification<EnderecoDTO>
    {
        private readonly IRepositoryGenerics<Endereco> _enderecoRepository;
        private readonly IUsuarioRepository  _usuarioInterface;
        private readonly IMapper _mapper;

        public EnderecoEspecification(IRepositoryGenerics<Endereco> enderecoRepository, IMapper mapper, IUsuarioRepository usuarioInterface)
        {
            _enderecoRepository = enderecoRepository;
            _mapper = mapper;
            _usuarioInterface = usuarioInterface;
        }
        public bool IsSatisfiedBy(EnderecoDTO Entity)
        {
            var endereco = _mapper.Map<Endereco>(Entity);
            return _enderecoRepository.CheckDuplicity(endereco);
        }

        public bool VerifyExistEntity(EnderecoDTO Entity)
        {
            return _usuarioInterface.GetById(Entity.IdUsuario) != null;
        }
    }
}
