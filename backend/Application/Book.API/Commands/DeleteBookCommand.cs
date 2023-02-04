using Bookstore.Domain.Repositories;
using Bookstore.Domain.Responses;
using MediatR;
using System.Net;

namespace Book.Commands
{
    public class DeleteBookCommand : IRequest<Response<string>>
    {
        public int Id { get; set; }
    }
    public class DeleteBookCommandHandler : IRequestHandler<DeleteBookCommand, Response<string>>
    {
        private readonly IBookRepository _bookRepository;

        public DeleteBookCommandHandler(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task<Response<string>> Handle(DeleteBookCommand request, CancellationToken cancellationToken)
        {
            await _bookRepository.DeleteBook(request.Id, cancellationToken);
            return new Response<string>()
            {
                IsSuccess = true,
                StatusCode = (int)HttpStatusCode.OK,
                Message = "Delete successful",
            };
        }
    }
}
