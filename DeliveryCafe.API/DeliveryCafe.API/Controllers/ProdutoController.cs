using DeliveryCafe.API.Interface.DTO;
using DeliveryCafe.API.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeliveryCafe.API.Controllers
{
    [Route("api/produtos")]
    public class ProdutoController: Controller
    {
        private readonly IProdutoDTOInterface _produtoDTOInterface;
        public ProdutoController(IProdutoDTOInterface produtoDTOInterface)
        {
            _produtoDTOInterface = produtoDTOInterface;
        }
        
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var produto = _produtoDTOInterface.GetById(id);
            if (produto == null)
            {
                return NoContent();
            }
            return Ok(produto);
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var produtos = _produtoDTOInterface.GetAll();
            if (produtos == null)
            {
                return NoContent();
            }
            return Ok(produtos);
        }


        [HttpPost]
        public IActionResult Insert([FromBody] ProdutoDTO model)
        {
            var produto = _produtoDTOInterface.Insert(model);
            return CreatedAtAction(

                nameof(_produtoDTOInterface.GetById),
                new { produto.Id },
                produto
                );
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] ProdutoDTO model)
        {
            var produto = _produtoDTOInterface.Update(id, model);
            if (!produto)
            {
                return NotFound();
            }
            return Ok();
        }

        [HttpDelete("id")]
        public IActionResult Delete(int id)
        {
            var produto = _produtoDTOInterface.Delete(id);
            if (!produto)
            {
                return NotFound();
            }
            return Ok();
        }

    }
}
