using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PizzaShopAPI.Interfaces.Services;
using PizzaShopAPI.Models;
using PizzaShopAPI.Models.DTO;
using PizzaShopAPI.Services;

namespace PizzaShopAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PizzaController : ControllerBase
    {
        private readonly IPizzaServices _pizzaService;
        public PizzaController(IPizzaServices pizzaService)
        {
            _pizzaService = pizzaService;
        }

        [Authorize]
        [HttpGet]
        [Route("GetAllAvailablePizzas")]
        [ProducesResponseType(typeof(Pizza), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<Pizza>> Get()
        {
            try
            {
                IEnumerable<Pizza> result = await _pizzaService.GetPizzas();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return Unauthorized(new ErrorModel(401, ex.Message));
            }
        }
    }
}
