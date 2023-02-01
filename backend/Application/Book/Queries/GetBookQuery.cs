using Book.DTOs;
using Bookstore.Domain.Repositories;
using Bookstore.Domain.Responses;
using MediatR;
using System.Net;

namespace Book.Queries
{
    public class GetBookQuery : IRequest<Response<List<BookDTO>>>
    {
    }

    public class GetBookQueryHandler : IRequestHandler<GetBookQuery, Response<List<BookDTO>>>
    {
        private IBookRepository _bookRepository;
        public GetBookQueryHandler(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task<Response<List<BookDTO>>> Handle(GetBookQuery request, CancellationToken cancellationToken)
        {
            var books = await _bookRepository.GetBooks();
            var bookDtos = books.Select(r => new BookDTO()
            {
                Language = r.Language,
                Authors = r.Authors,

            }).ToList();

            var response = new Response<List<BookDTO>>()
            {
                StatusCode = (int)HttpStatusCode.OK,
                IsSuccess = true,
                Data = bookDtos,
            };

            return response;
        }
    }
}
