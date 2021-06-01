using DeliveryCafe.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeliveryCafe.API.Interface.Domain
{
    public interface IEnderecoInterface
    {
        Endereco Insert(Endereco model);
        bool Update(int id, Endereco model);
        bool Delete(int id);
        Endereco GetById(int id);
        List<Endereco> GetAll();
        bool CheckDuplicityAddress(string cep);
    }
}
