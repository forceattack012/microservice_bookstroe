using Book.Commands;
using Book.Models;
using Book.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Book.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BookController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public IActionResult GetBook([FromQuery] int page, int pageSize, CancellationToken cancellationToken)
        {
            return Ok(_mediator.Send(new GetBookQuery()
            {
                Page = page == 0 ? 1 : page,
                PageSize = pageSize == 0 ? 10 : pageSize,
            }, cancellationToken));
        }
 

        [HttpPost]
        public async Task<IActionResult> AddBook([FromBody] BookRequest bookRequest, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(new CreateBookCommand()
            {
                Book = new BookRequest().ConvertToBook(bookRequest)
            }, cancellationToken);
            return StatusCode(response.StatusCode, response);
        }

        [HttpPatch]
        public async Task<IActionResult> UpdateBook([FromBody] BookRequest bookRequest)
        {
            return StatusCode(201, "");
        }
    }
}
