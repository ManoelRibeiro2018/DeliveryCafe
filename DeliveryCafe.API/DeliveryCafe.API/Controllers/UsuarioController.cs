using DeliveryCafe.API.Interface.DTO;
using DeliveryCafe.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace DeliveryCafe.API.Controllers
{
    [Route("api/usuarios")]
    public class UsuarioController : Controller
    {
        private readonly IUsuarioService _context;
        public UsuarioController(IUsuarioService context)
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
          
            var usuario = _context.Insert(model);

            return StatusCode(201, usuario);
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

        [HttpPut("Login")]
        public IActionResult Login(string email, string role)
        {
          var login =   _context.Login(email, role);
            return Ok(login);
        }

    }
}
