using DeliveryCafe.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeliveryCafe.API.Interface.DTO
{
    public interface IUsuarioDTOInterface
    {
        UsuarioDTO Insert(UsuarioDTO model);
        bool Update(int id, UsuarioDTO model);
        bool Delete(int id);
        UsuarioDTO GetById(int id);
        List<UsuarioDTO> GetAll();
    }
}
