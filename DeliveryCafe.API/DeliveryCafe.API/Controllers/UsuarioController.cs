using DeliveryCafe.API.Interface.DTO;
using DeliveryCafe.API.Models;
using DeliveryCafe.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeliveryCafe.API.Controllers
{
    [Route("api/usuarios")]
    public class UsuarioController : Controller
    {
        private readonly IUsuarioDTOInterface _context;
        public UsuarioController(IUsuarioDTOInterface context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var usuarios = _context.GetAll();
            return Ok(usuarios);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var usuario = _context.GetById(id);
            if (usuario == null)
            {
                return NoContent();
            }
            return Ok(usuario);
        }

        [HttpPost]
        public IActionResult Insert([FromBody] UsuarioDTO model)
        {
            if (!ModelState.IsValid)
            {
                var mensage = ModelState.SelectMany(erro => erro.Value.Errors).Select(mensage => mensage.ErrorMessage);
                return BadRequest(mensage);
            }
            var usuario = _context.Insert(model);

            return CreatedAtAction(
                nameof(GetById),
                new { usuario.Id },
                usuario);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var usuario = _context.Delete(id);
            if (!usuario)
            {
                return NotFound();
            }
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] UsuarioDTO model)
        {
            var usuario = _context.Update(id, model);
            if (!usuario)
            {
                return NotFound();
            }
            return Ok();
        }

    }
}
