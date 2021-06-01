using DeliveryCafe.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeliveryCafe.API.Interface.Domain
{
    public interface IProdutoInterface
    {
        Produto Insert(Produto produto);
        bool Update(int id, Produto produto);
        bool Delete(int id);
        Produto GetById(int id);
        List<Produto> GetAll();
    }
}
