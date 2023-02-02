using Book.Models;
using Bookstore.Domain.Repositories;
using Bookstore.Domain.Responses;
using MediatR;
using System.Net;

namespace Book.Commands
{
    public class CreateBookCommand : IRequest<Response<string>>
    {
        public Bookstore.Domain.Entities.Book Book;
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
            await bookRepository.AddBook(request.Book);
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
