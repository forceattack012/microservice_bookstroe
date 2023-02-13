using Basket.Infrastructure.Context;
using Basket.Models;
using Bookstore.Domain.Repositories;
using Bookstore.Domain.Responses;
using MediatR;

namespace Basket.Commands
{
    public class RemoveBasketCommand : IRequest<Response<Bookstore.Domain.Entities.Basket>>
    {
        public string UserName { get; set; }
        public string Id { get; set; }

        public RemoveBasketCommand(string UserName, string Id)
        {
            this.UserName = UserName;
            this.Id = Id;
        }
    }

    public class RemoveBasketHanlder : IRequestHandler<RemoveBasketCommand, Response<Bookstore.Domain.Entities.Basket>>
    {
        private readonly IBasketRepository _repository;
        private readonly Bookstore.Domain.Repositories.ILogger _logger;

        public RemoveBasketHanlder(IBasketRepository repository, Bookstore.Domain.Repositories.ILogger logger)
        {
            _repository = repository;
            _logger = logger;
        }

        public async Task<Response<Bookstore.Domain.Entities.Basket>> Handle(RemoveBasketCommand request, CancellationToken cancellationToken)
        {
            if(string.IsNullOrEmpty(request.Id) || string.IsNullOrEmpty(request.UserName)) 
            {
                return new Response<Bookstore.Domain.Entities.Basket>
                {
                    StatusCode = 400,
                    IsSuccess = false,
                    Message = "id or username is empty"
                };
            }

            var basket = await _repository.GetBasketByUserName(request.UserName, cancellationToken);
            if (basket == null)
            {
                return new Response<Bookstore.Domain.Entities.Basket>()
                {
                    StatusCode = 404,
                    IsSuccess = false,
                    Message = "Basket is not found",
                };
            } 
            else if(basket?.Books.Count == 0)
            {
                return new Response<Bookstore.Domain.Entities.Basket>()
                {
                    StatusCode = 404,
                    IsSuccess = false,
                    Message = "Book is not found",
                };
            }

            try
            {
                var indexBookRemoved = basket.Books.FindIndex(r => Convert.ToString(r.Id) == request.Id);
                if (indexBookRemoved == -1)
                {
                    return new Response<Bookstore.Domain.Entities.Basket>()
                    {
                        StatusCode = 404,
                        IsSuccess = false,
                        Message = "id is not found"
                    };
                }

                basket.Books.RemoveAt(indexBookRemoved);
                await _repository.AddBasket(basket, cancellationToken);
            }
            catch(Exception ex)
            { 
                _logger.LogDebug($"{basket} \n"+ ex.Message, ex);
                throw;
            }

            return new Response<Bookstore.Domain.Entities.Basket>()
            {
                StatusCode = 200,
                IsSuccess = true,
                Data = basket
            };
        }
    }
}
