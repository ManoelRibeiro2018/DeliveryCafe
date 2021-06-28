using DeliveryCafe.API.Interface.Domain;
using DeliveryCafe.API.Persistence;
using DeliveryCafe.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeliveryCafe.API.Repository
{
    public class EnderecoRepository : IEnderecoInterface, IRepositoryGenerics<Endereco>
    {
        private readonly DeliveryContext _context;
        public EnderecoRepository(DeliveryContext context)
        {
            _context = context;
        }
       
        public Endereco Insert(Endereco model)
        {
            if (CheckDuplicity(model))
            {
                return null;
            }
            _context.Enderecos.Add(model);
            _context.SaveChanges();
            return model;
        }

        public bool Update(int id, Endereco model)
        {
            var endereco = _context.Enderecos.SingleOrDefault(e => e.Id == id);
            if (endereco == null)
            {
                return false;
            }
            _context.Update(endereco);
            _context.SaveChanges();
            return true;
        }

        public bool Delete(int id)
        {
            var endereco = _context.Enderecos.SingleOrDefault(e => e.Id == id);
            if (endereco == null)
            {
                return false;
            }
            _context.Enderecos.Remove(endereco);
            _context.SaveChanges();
            return true;
        }
        public Endereco GetById(int id)
        {
            var endereco = _context.Enderecos.SingleOrDefault(e => e.Id == id);
            return endereco;
        }

        public List<Endereco> GetAll()
        {
            var usuarios = _context.Enderecos.ToList();
            return usuarios;
        }
   



        public bool CheckDuplicity(Endereco value)
        {
            var endereco = _context.Enderecos.SingleOrDefault(e => e.IdUsuario == value.Id && e.CEP == value.CEP);
            if (endereco == null)
            {
                return false;
            }
            return true;
        }

    }
}
