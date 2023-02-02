using Book.DTOs;
using Bookstore.Domain.Repositories;
using Bookstore.Domain.Responses;
using MediatR;
using System.Net;

namespace Book.Queries
{
    public class GetBookQuery : IRequest<Response<List<BookDTO>>>
    {
        public int Page { get; set; }
        public int PageSize { get; set; }
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
            var books = _bookRepository.GetBooks();
            var count = books.Count();
            var bookDtos = books.Select(r => new BookDTO()
            {
                Id= r.Id,
                Name = r.Name,
                Pages= r.Pages,
                Price= r.Price,
                Published= r.Published,
                Qty = r.Qty,
                Image = r.Image,
                Language = r.Language,
                Authors = r.Authors,
                ISBN = r.ISBN,
                Descripttion = r.Description,
                Rating = r.Rating,
            })
            .Skip((request.Page - 1) * request.PageSize)
            .Take(request.PageSize)
            .ToList();

            var totalPages = (int)Math.Ceiling((double)count / request.PageSize);

            var response = new Response<List<BookDTO>>()
            {
                StatusCode = (int)HttpStatusCode.OK,
                IsSuccess = true,
                Data = bookDtos,
                TotalPage = totalPages,
            };

            return response;
        }
    }
}
