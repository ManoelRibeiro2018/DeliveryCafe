using DeliveryCafe.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeliveryCafe.API.Interface.DTO
{
    public interface IEnderecoDTOInterface
    {
        EnderecoDTO Insert(EnderecoDTO model);
        bool Update(int id, EnderecoDTO model);
        bool Delete(int id);
    }
}
