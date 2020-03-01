using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using StellarClothing.ShoppingCart.Api.Domain;

namespace StellarClothing.ShoppingCart.Api.Controllers
{
    [Route("api/shoppingcart")]
    [ApiController]
    public class ShoppingCartController : ControllerBase
    {
        private IShoppingCartRepository _repository;
        private ILogger _logger;
        public ShoppingCartController(IShoppingCartRepository repository, ILoggerFactory factory)
        {
            _repository = repository;
            _logger = factory.CreateLogger<ShoppingCartController>();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var shoppingCart = await _repository.GetByID(id);

            return Ok(shoppingCart);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]Domain.ShoppingCart cart)
        {
            await _repository.Update(cart);

            return Ok();
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _repository.Delete(id);
        }
    }
}