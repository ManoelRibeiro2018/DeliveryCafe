using DeliveryCafe.API.Interface.Domain;
using DeliveryCafe.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace DeliveryCafe.API.Controllers
{
    [Route("api/pedidos")]
    public class PedidoController: Controller
    {
        private readonly IPedidoInterface _pedidoInterface;

        public PedidoController(IPedidoInterface pedidoInterface)
        {
            _pedidoInterface = pedidoInterface;
        }

        [HttpPost]
        public IActionResult Post([FromBody] Pedido model)
        {
            var pedido = _pedidoInterface.Insert(model);
            return Ok();
        }
    }
}
