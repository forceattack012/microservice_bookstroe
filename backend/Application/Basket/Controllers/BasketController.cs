using Basket.Commands;
using Basket.Models;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Basket.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasketController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BasketController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateBasket([FromBody] BookRequest bookRequest, CancellationToken cancellation)
        {
            var result = await _mediator.Send(new AddBasketCommand(bookRequest.UserName, bookRequest.Books), cancellation);
            return Ok(result);
        }
    }
}
