using DeliveryCafe.API.Interface.Domain;
using DeliveryCafe.API.Models;
using DeliveryCafe.API.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeliveryCafe.API.Repository
{
    public class CarrinhoCompraRepository : ICarrinhoCompraInterface
    {
        private readonly DeliveryContext _deliveryContext;

        public CarrinhoCompraRepository(DeliveryContext deliveryContext)
        {
            _deliveryContext = deliveryContext;
        }
        public CarrinhoCompra Insert(CarrinhoCompra model)
        {
            var produto = _deliveryContext.Produtos.SingleOrDefault(p=> p.Id ==  model.IdProduto);
            if (produto == null)
            {
                return null;
            }

            if (model.Qtd !<= produto.Qtd)
            {
                return null;
            }

            model.Total = model.Produto.Preco
                                   * model.Qtd;

            var compra = _deliveryContext.CarrinhoCompras.Add(model);
            _deliveryContext.SaveChanges();
            return model;
        }

        public bool Update(CarrinhoCompra model)
        {
            throw new NotImplementedException();
        }
        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

      
    }
}
