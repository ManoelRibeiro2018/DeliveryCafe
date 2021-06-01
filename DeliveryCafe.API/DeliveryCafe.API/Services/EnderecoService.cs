using AutoMapper;
using DeliveryCafe.API.Interface.Domain;
using DeliveryCafe.API.Interface.DTO;
using DeliveryCafe.API.Models;
using DeliveryCafe.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeliveryCafe.API.Services
{
    public class EnderecoService : IEnderecoDTOInterface
    {
        private readonly IEnderecoInterface _enderecoContext;
        private readonly IMapper _mapper;
        public EnderecoService(IEnderecoInterface endereco, IMapper mapper)
        {
            _enderecoContext = endereco;
            _mapper = mapper;
        }
        public EnderecoDTO Insert(EnderecoDTO model)
        {
            if (model == null)
            {
                return null;
            }
            var endereco = _mapper.Map<Endereco>(model);
            var enderecoRetorno = _enderecoContext.Insert(endereco);
            return _mapper.Map<EnderecoDTO>(enderecoRetorno);
        }

        public bool Update(int id, EnderecoDTO model)
        {
            if (id == 0 || model == null)
            {
                return false;
            }
            var endereco = _mapper.Map<Endereco>(model);
            return _enderecoContext.Update(id, endereco);
        }

        public bool Delete(int id)
        {
            if (id == 0)
            {
                return false;
            }
            return _enderecoContext.Delete(id);
        }

        public EnderecoDTO GetById(int id)
        {
            if (id == 0)
            {
                return null;
            }
            var endereco = _enderecoContext.GetById(id);
            return _mapper.Map<EnderecoDTO>(endereco);            
        }

        public List<EnderecoDTO> GetAll()
        {
            var enderecos = _enderecoContext.GetAll();
            return _mapper.Map<List<EnderecoDTO>>(enderecos);
        }
    }
}
