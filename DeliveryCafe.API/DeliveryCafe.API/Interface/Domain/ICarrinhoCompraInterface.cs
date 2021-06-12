using DeliveryCafe.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeliveryCafe.API.Interface.Domain
{
    public interface ICarrinhoCompraInterface
    {
        CarrinhoCompra Insert(CarrinhoCompra model);
        bool Update(CarrinhoCompra model);
        bool Delete(int id);

    }
}
