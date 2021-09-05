using DeliveryCafe.API.Interface.DTO;
using DeliveryCafe.API.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeliveryCafe.API.Controllers
{
    [Authorize]
    [Route("api/produtos")]
    public class ProdutoController: Controller
    {
        private readonly IProdutoDTOInterface _produtoDTOInterface;
        public ProdutoController(IProdutoDTOInterface produtoDTOInterface)
        {
            _produtoDTOInterface = produtoDTOInterface;
        }
        
        [HttpGet("{id}")]
        [Authorize(Roles = "Funcionario")]
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
        [Authorize(Roles = "Funcionario")]
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
        [Authorize(Roles = "Funcionario")]
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
        [Authorize(Roles = "Funcionario")]
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
        [Authorize(Roles = "Funcionario")]
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
