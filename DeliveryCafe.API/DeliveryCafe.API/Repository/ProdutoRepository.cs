using DeliveryCafe.API.Interface.Domain;
using DeliveryCafe.API.Models;
using DeliveryCafe.API.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeliveryCafe.API.Repository
{
    public class ProdutoRepository : IProdutoInterface
    {
        private readonly DeliveryContext _deliveryContext;

        public ProdutoRepository(DeliveryContext deliveryContext)
        {
            _deliveryContext = deliveryContext;
        }
        public List<Produto> GetAll()
        {
            return _deliveryContext.Produtos.ToList();
        }

        public Produto GetById(int id)
        {
            return _deliveryContext.Produtos.SingleOrDefault(p => p.Id == id);
        }

        public Produto Insert(Produto model)
        {
            _deliveryContext.Produtos.Add(model);
            _deliveryContext.SaveChanges();
            return GetById(model.Id);
        }

        public bool Update(int id, Produto model)
        {
            var produto = _deliveryContext.Produtos.SingleOrDefault(p => p.Id == id);
            if (produto == null)
            {
                return false;
            }
            produto.Update(model.Nome, model.Preco, model.Qtd);
            _deliveryContext.SaveChanges();
            return true;
        }
        public bool Delete(int id)
        {
            var produto = _deliveryContext.Produtos.SingleOrDefault(p => p.Id == id);
            if (produto == null)
            {
                return false;
            }
            _deliveryContext.Produtos.Remove(produto);
            _deliveryContext.SaveChanges();
            return true;
        }
    }
}
