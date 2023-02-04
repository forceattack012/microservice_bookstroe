using Book.DTOs;
using Bookstore.Domain.Repositories;
using Bookstore.Domain.Responses;
using MediatR;
using System.Net;

namespace Book.API.Queries
{
    public class GetLastestIdQuery : IRequest<Response<BookDTO>>
    {
    }

    public class GetLastestIdQueryHandle : IRequestHandler<GetLastestIdQuery, Response<BookDTO>>
    {
        private readonly IBookRepository _repository;

        public GetLastestIdQueryHandle(IBookRepository repository)
        {
            _repository = repository;
        }

        public Task<Response<BookDTO>> Handle(GetLastestIdQuery request, CancellationToken cancellationToken)
        {
            int bookId = _repository.GetLastBookId();
            Response<BookDTO> response = new Response<BookDTO>()
            {
                IsSuccess= true,
                StatusCode = (int)HttpStatusCode.OK,
                Data = new BookDTO()
                {
                    Id = bookId,
                }
            };
            return Task.FromResult(response);
        }
    }
}
