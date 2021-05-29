using DeliveryCafe.API.Persistence;
using DeliveryCafe.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeliveryCafe.API.Repository
{
    public class UsuarioRepository : IUsuarioInterface
    {
        private readonly DeliveryContext _deliveryContext;

        public UsuarioRepository(DeliveryContext deliveryContext)
        {
            _deliveryContext = deliveryContext;
        }

        public Usuario Insert(Usuario model)
        {
            if (CheckDuplicityCpf(model.Cpf))
            {
                return null;
            }

            _deliveryContext.Usuarios.Add(model);
            _deliveryContext.SaveChanges();
            return model;
        }

        public bool Update(int id, Usuario model)
        {
            var usuario = _deliveryContext.Usuarios.SingleOrDefault(u => u.Id == id);
            if (usuario == null)
            {
                return false;
            }
            _deliveryContext.Update(model);
            _deliveryContext.SaveChanges();
            return true;
        }
        public bool Delete(int id)
        {
            var usuario = _deliveryContext.Usuarios.SingleOrDefault(u => u.Id == id);

            if (usuario == null)
            {
                return false;
            }

            _deliveryContext.Usuarios.Remove(usuario);
            _deliveryContext.SaveChanges();
            return true;
        }

        public List<Usuario> GetAll()
        {
            IQueryable<Usuario> usuarios = _deliveryContext.Usuarios
                .Include(u => u.Pedidos);
            return  usuarios.ToList();
        }

        public  Usuario GetById(int id)
        {
            IQueryable<Usuario> usuario = _deliveryContext.Usuarios
                .Include(u => u.Pedidos);

            return  usuario.SingleOrDefault();
        }

        public  bool CheckDuplicityCpf(string cpf)
        {      
            var usuario =   _deliveryContext.Usuarios.SingleOrDefault(u => u.Cpf == cpf);
            return usuario != null;
        }
    }
}
