using AutoMapper;
using DeliveryCafe.API.Interface.Domain;
using DeliveryCafe.API.Interface.DTO;
using DeliveryCafe.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeliveryCafe.API.Services
{
    public class ProdutoService : IProdutoDTOInterface
    {
        private readonly IProdutoInterface _produtoInterface;
        private readonly IMapper _mapper;
        public ProdutoService(IProdutoInterface produtoInterface, IMapper mapper)
        {
            _produtoInterface = produtoInterface;
            _mapper = mapper;
        }
        public ProdutoDTO Insert(ProdutoDTO model)
        {
            if (model == null)
            {
                return null;
            }
            var produto = _mapper.Map<Produto>(model);
            var produtoRetorno = _produtoInterface.Insert(produto);
            return _mapper.Map<ProdutoDTO>(produtoRetorno);
        }

        public bool Update(int id, ProdutoDTO model)
        {
            if (id == 0 || model == null)
            {
                return false;
            }
            var produto = _mapper.Map<Produto>(model);
            return _produtoInterface.Update(id, produto);
        }
        public bool Delete(int id)
        {
            if (id == 0)
            {
                return false;
            }
            return _produtoInterface.Delete(id);
        }
        public ProdutoDTO GetById(int id)
        {
            if (id == 0)
            {
                return null;
            }
            var produto = _produtoInterface.GetById(id);
            return _mapper.Map<ProdutoDTO>(produto);
        }

        public List<ProdutoDTO> GetAll()
        {
            var produtos = _produtoInterface.GetAll();
            return _mapper.Map<List<ProdutoDTO>>(produtos);
        }

        

      
    }
}
