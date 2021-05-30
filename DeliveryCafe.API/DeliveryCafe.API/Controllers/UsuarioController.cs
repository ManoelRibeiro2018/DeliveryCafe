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
        private readonly IUsuarioInterface _context;
        public UsuarioController(IUsuarioInterface context)
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
        public IActionResult Insert([FromBody] Usuario model)
        {
            var usuario = _context.Insert(model);
            if (usuario != null)
            {
                return NoContent();
            }

            return CreatedAtAction(
                nameof(GetById),
                new { model.Id },
                model);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var usuario = _context.Delete(id);
            if (!usuario)
            {
                return NotFound();
            }
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] Usuario model)
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
