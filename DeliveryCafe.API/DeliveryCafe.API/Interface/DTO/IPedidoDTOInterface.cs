using DeliveryCafe.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeliveryCafe.API.Interface.DTO
{
    public interface IPedidoDTOInterface
    {
        PedidoDTO Insert(PedidoDTO model);
        bool Update(int id, PedidoDTO model);
        bool Delete(int id);
        PedidoDTO GetById(int id);
        List<PedidoDTO> GetAll();
    }
}
