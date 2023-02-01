using Bookstore.Domain.Responses;
using MediatR;

namespace Book.Commands
{
    public class CreateBookCommand : IRequest<Response<string>>
    {
    }
}
