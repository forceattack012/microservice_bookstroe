using Book.API.Mapping;
using Book.Models;
using Bookstore.Domain.Repositories;
using Bookstore.Domain.Responses;
using MediatR;
using System.Net;

namespace Book.Commands
{
    public class UpdateBookCommand : IRequest<Response<string>>
    {
        public int Id { get; set; }
        public BookRequest BookRequest { get; set; }   
    }

    public class UpdateBookCommandHandler : IRequestHandler<UpdateBookCommand, Response<string>>
    {
        private readonly IBookRepository _bookRepository;

        public UpdateBookCommandHandler(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task<Response<string>> Handle(UpdateBookCommand request, CancellationToken cancellationToken)
        {
            var book = MapService.ConvertToBook(request.BookRequest, request.Id);
            await _bookRepository.UpdateBook(book);
            return new Response<string>()
            {
                StatusCode = (int)HttpStatusCode.OK,
                IsSuccess = true,
                Message = "Update Successful",
            };
        }
    }
}
