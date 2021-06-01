using DeliveryCafe.API.Interface.DTO;
using DeliveryCafe.API.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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

        [HttpPost]
        public IActionResult Insert([FromBody] EnderecoDTO model)
        {
            _enderecoDTOInterface.Insert(model);
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id , [FromBody] EnderecoDTO model)
        {
            var endereco = _enderecoDTOInterface.Update(id, model);
            if (!endereco)
            {
                return BadRequest();
            }
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var endereco = _enderecoDTOInterface.Delete(id);
            if (!endereco)
            {
                return BadRequest();
            }

            return Ok();
        }
    }
}
