using DeliveryCafe.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeliveryCafe.API.Interface.Domain
{
    public interface IProdutoInterface
    {
        Produto Insert(Produto model);
        bool Update(int id, Produto model);
        bool Delete(int id);
        Produto GetById(int id);
        List<Produto> GetAll();
    }
}
