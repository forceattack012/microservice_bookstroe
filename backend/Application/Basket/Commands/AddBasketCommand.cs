using Basket.Models;
using Bookstore.Domain.Entities;
using Bookstore.Domain.Repositories;
using MediatR;
using System.Net;

namespace Basket.Commands
{
    public class AddBasketCommand : IRequest<Response<Bookstore.Domain.Entities.Basket>>
    {
        public string UserName { get; set; }
        public List<Book> Books { get; set; }

        public AddBasketCommand(string userName, List<Book> books)
        {
            UserName = userName;
            Books = books;
        }

        public class AddBasketCommandHandler : IRequestHandler<AddBasketCommand, Response<Bookstore.Domain.Entities.Basket>>
        {
            private readonly IBasketRepository _basketRepository;

            public AddBasketCommandHandler(IBasketRepository basketRepository)
            {
                _basketRepository = basketRepository;
            }

            public async Task<Response<Bookstore.Domain.Entities.Basket>> Handle(AddBasketCommand request, CancellationToken cancellationToken)
            {
                if (string.IsNullOrEmpty(request.UserName))
                {
                    return new Response<Bookstore.Domain.Entities.Basket>()
                    {
                        StatusCode = (int)HttpStatusCode.BadRequest,
                        Message = "Username is required",
                        IsSuccess = false
                    };
                }

                if (request.Books?.Count == 0 || request.Books == null)
                {
                    return new Response<Bookstore.Domain.Entities.Basket>()
                    {
                        StatusCode = (int)HttpStatusCode.BadRequest,
                        Message = "Books is required",
                        IsSuccess = false
                    };
                }

                var oldBasket = await _basketRepository.GetBasketByUserName(request.UserName, cancellationToken);
                var basket = new Bookstore.Domain.Entities.Basket
                {
                    Books = request.Books,
                    UsertName = request.UserName,
                };
                
                if(oldBasket.Books != null)
                {
                    foreach (var book in oldBasket.Books)
                    {
                        basket.Books.Add(book);
                    }
                }

                await _basketRepository.AddBasket(basket, cancellationToken);

                return new Response<Bookstore.Domain.Entities.Basket>() 
                {
                    StatusCode = (int)HttpStatusCode.OK,
                    Message = "",
                    IsSuccess = true,
                    Data = basket
                };
            }
        }
    }
}
