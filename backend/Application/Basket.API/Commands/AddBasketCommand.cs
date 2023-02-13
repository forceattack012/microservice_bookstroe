using Basket.Models;
using Bookstore.Api.Enum.Basket;
using Bookstore.Domain.Entities;
using Bookstore.Domain.Repositories;
using Bookstore.Domain.Responses;
using MediatR;
using StackExchange.Redis.KeyspaceIsolation;
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
            private readonly Bookstore.Domain.Repositories.ILogger _logger;

            public AddBasketCommandHandler(IBasketRepository basketRepository, Bookstore.Domain.Repositories.ILogger logger)
            {
                _basketRepository = basketRepository;
                _logger = logger;
            }

            public async Task<Response<Bookstore.Domain.Entities.Basket>> Handle(AddBasketCommand request, CancellationToken cancellationToken)
            {
                if (string.IsNullOrEmpty(request.UserName))
                {
                    _logger.LogWarning("request is empty");
                    return new Response<Bookstore.Domain.Entities.Basket>()
                    {
                        StatusCode = (int)HttpStatusCode.BadRequest,
                        Message = BasketErrorMessage.USER_REQUIRED,
                        IsSuccess = false
                    };
                }

                if (request.Books?.Count == 0 || request.Books == null)
                {
                    _logger.LogWarning("request is empty");
                    return new Response<Bookstore.Domain.Entities.Basket>()
                    {
                        StatusCode = (int)HttpStatusCode.BadRequest,
                        Message = "Books is required",
                        IsSuccess = false
                    };
                }

                var basket = new Bookstore.Domain.Entities.Basket
                {
                    UsertName = request.UserName,
                    Books = request.Books,
                };

                try
                {
                    var oldBasket = await _basketRepository.GetBasketByUserName(request.UserName, cancellationToken);

                    if (oldBasket.Books != null)
                    {
                        foreach (var book in oldBasket.Books)
                        {
                            basket.Books.Add(book);
                        }
                    }

                    for (int i = 0; i < basket.Books.Count; i++)
                    {
                        basket.Books[i].Id = i + 1;
                    }

                    await _basketRepository.AddBasket(basket, cancellationToken);
                }
                catch(Exception ex)
                {
                    _logger.LogDebug(ex.Message, ex);
                    throw;
                }

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
