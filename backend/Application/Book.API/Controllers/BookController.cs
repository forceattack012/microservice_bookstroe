using Book.API.Queries;
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
        public async Task<IActionResult> GetBookAsync([FromQuery] int page, int pageSize, CancellationToken cancellationToken)
        {
            return Ok(await _mediator.Send(new GetBookQuery()
            {
                Page = page == 0 ? 1 : page,
                PageSize = pageSize == 0 ? 10 : pageSize,
            }, cancellationToken));
        }

        [HttpGet("lastest")]
        public async Task<IActionResult> GetLastestIdAsync( CancellationToken cancellationToken)
        {
            return Ok(await _mediator.Send(new GetLastestIdQuery(), cancellationToken));
        }


        [HttpPost]
        public async Task<IActionResult> AddBook([FromBody] BookRequest bookRequest, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(new CreateBookCommand()
            {
                BookRequest = bookRequest
            }, cancellationToken);
            return StatusCode(response.StatusCode, response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBook(int id, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(new DeleteBookCommand() { Id = id }, cancellationToken);
            return StatusCode(response.StatusCode, response);
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> UpdateBook(int id, [FromBody] BookRequest bookRequest, CancellationToken cancellationToken)
        {
            var res = await _mediator.Send(new UpdateBookCommand()
            {
                Id = id,
                BookRequest = bookRequest,

            }, cancellationToken);
            return StatusCode(res.StatusCode, res);
        }
    }
}
