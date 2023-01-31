using Basket.Infrastructure.Context;
using Basket.Models;
using Bookstore.Domain.Repositories;
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

        public RemoveBasketHanlder(IBasketRepository repository)
        {
            _repository = repository;
        }

        public async Task<Response<Bookstore.Domain.Entities.Basket>> Handle(RemoveBasketCommand request, CancellationToken cancellationToken)
        {
            if(request.Id == null || request.UserName == null) 
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

            return new Response<Bookstore.Domain.Entities.Basket>()
            {
                StatusCode = 200,
                IsSuccess = true,
                Data = basket
            };
        }
    }
}
