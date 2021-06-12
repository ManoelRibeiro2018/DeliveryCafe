using DeliveryCafe.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeliveryCafe.API.Interface.Domain
{
    public interface IPedidoInterface
    {
        Pedido Insert(Pedido model);
        bool Update(int id, Pedido model);
        bool Delete(int id);
        Pedido GetById(int id);
        List<Pedido> GetAll();
    }
}
