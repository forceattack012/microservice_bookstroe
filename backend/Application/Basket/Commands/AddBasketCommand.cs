using Basket.Models;
using Bookstore.Api.Enum.Basket;
using Bookstore.Domain.Entities;
using Bookstore.Domain.Repositories;
using Bookstore.Domain.Responses;
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
                        Message = BasketErrorMessage.USER_REQUIRED,
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
                    UsertName = request.UserName,
                    Books = request.Books,
                };
                
                if(oldBasket.Books != null)
                {
                    foreach (var book in oldBasket.Books)
                    {
                        basket.Books.Add(book);
                    }
                }

                for(int i=0; i<basket.Books.Count; i++)
                {
                    basket.Books[i].Id = i + 1;
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
