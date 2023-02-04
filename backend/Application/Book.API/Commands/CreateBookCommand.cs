using Book.API.Mapping;
using Book.Models;
using Bookstore.Domain.Repositories;
using Bookstore.Domain.Responses;
using MediatR;
using System.Net;

namespace Book.Commands
{
    public class CreateBookCommand : IRequest<Response<string>>
    {
        public BookRequest BookRequest { get; set; }
    }

    public class CreateBookCommandHandler : IRequestHandler<CreateBookCommand, Response<string>>
    {
        private readonly IBookRepository bookRepository;

        public CreateBookCommandHandler(IBookRepository bookRepository)
        {
            this.bookRepository = bookRepository;
        }

        public async Task<Response<string>> Handle(CreateBookCommand request, CancellationToken cancellationToken)
        {
            var bookLastestId = this.bookRepository.GetLastBookId();
            bookLastestId = bookLastestId + 1;
            await bookRepository.AddBook(MapService.ConvertToBook(request.BookRequest, bookLastestId));

            return new Response<string>()
            {
                StatusCode = (int)HttpStatusCode.Created,
                IsSuccess = true,
                Data = "",
                Message = "Create Sucessful"
            };
        }
    }
}
