using DeliveryCafe.API.Interface.DTO;
using DeliveryCafe.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace DeliveryCafe.API.Controllers
{
    [Route("api/enderecos")]
    public class EnderecoController: Controller
    {
        private readonly IEnderecoDTOInterface _enderecoDTOInterface;

        public EnderecoController(IEnderecoDTOInterface enderecoDTOInterface)
        {
            _enderecoDTOInterface = enderecoDTOInterface;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var enderecos = _enderecoDTOInterface.GetAll();
            if (enderecos == null)
            {
                return NoContent();
            }
            return Ok(enderecos);
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var endereco = _enderecoDTOInterface.GetById(id);
            if (endereco == null)
            {
                return NoContent();
            }
            return Ok(endereco);
        }


        [HttpPost]
        public IActionResult Insert([FromBody] EnderecoDTO model)
        {
            var endereco = _enderecoDTOInterface.Insert(model);
         
            return CreatedAtAction(
                nameof(GetById),
                new { endereco.Id },
                endereco                
                );
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id , [FromBody] EnderecoDTO model)
        {
            var endereco = _enderecoDTOInterface.Update(id, model);
            if (!endereco)
            {
                return NotFound();
            }
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var endereco = _enderecoDTOInterface.Delete(id);
            if (!endereco)
            {
                return NotFound();
            }
            return Ok();
        }
    }
}
