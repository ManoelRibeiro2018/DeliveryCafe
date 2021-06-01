using DeliveryCafe.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeliveryCafe.API.Interface.DTO
{
    public interface IProdutoDTOInterface
    {
        ProdutoDTO Insert(ProdutoDTO model);
        bool Update(int id, ProdutoDTO model);
        bool Delete(int id);
        ProdutoDTO GetById(int id);
        List<ProdutoDTO> GetAll();
    }
}
