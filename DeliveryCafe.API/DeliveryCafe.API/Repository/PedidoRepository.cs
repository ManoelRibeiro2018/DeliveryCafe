using DeliveryCafe.API.Interface.Domain;
using DeliveryCafe.API.Models;
using DeliveryCafe.API.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DeliveryCafe.API.Repository
{
    public class PedidoRepository : IPedidoInterface
    {
        private readonly DeliveryContext _deliveryContext;
        public PedidoRepository(DeliveryContext deliveryContext)
        {
            _deliveryContext = deliveryContext;
        }
        public Pedido Insert(Pedido model)
        {

            //var produto = _deliveryContext.Produtos.Where(p => p.Id == model.Id);

            //var pedido = _deliveryContext.Pedidos
            //    .Include(p => p.CarrinhoCompra)
            //    .ThenInclude(c => c.Id);
            //_deliveryContext.Pedidos.Add(model);
            //_deliveryContext.SaveChanges();
            //return model;

            throw new NotImplementedException();
        }

        public bool Update(int id, Pedido model)
        {
            throw new NotImplementedException();
        }
        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Pedido> GetAll()
        {
            throw new NotImplementedException();
        }

        public Pedido GetById(int id)
        {
            throw new NotImplementedException();
        }

        
    }
}
