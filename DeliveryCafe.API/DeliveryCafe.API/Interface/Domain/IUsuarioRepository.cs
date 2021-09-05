using DeliveryCafe.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeliveryCafe.API
{
    public interface IUsuarioRepository
    {
        Usuario Insert(Usuario model);
        bool Update(int id, Usuario model);
        bool Delete(int id);
        Usuario GetById(int id);
        List<Usuario> GetAll();
        Usuario GetUsuarioByEmailAndPassword(string email, string senha);

    }
}
