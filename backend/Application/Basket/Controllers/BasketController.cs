using Basket.Commands;
using Basket.Models;
using Basket.Queries;
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

        [HttpGet("{userName}")]
        public async Task<IActionResult> GetBasketByUsername(string userName, CancellationToken cancellationToken) 
        {
            var result = await _mediator.Send(new GetBasketQuery()
            {
                userName= userName,
            }, cancellationToken);

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateBasket([FromBody] BasketRequest bookRequest, CancellationToken cancellation)
        {
            var result = await _mediator.Send(new AddBasketCommand(bookRequest.UserName, bookRequest.Books), cancellation);
            return Ok(result);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteBasket(string userName, string id, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(new RemoveBasketCommand(userName,id), cancellationToken);
            return Ok(result);
        } 
    }
}
