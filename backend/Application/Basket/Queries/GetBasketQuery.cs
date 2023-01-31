using Basket.Models;
using Bookstore.Api.Enum.Basket;
using Bookstore.Domain.Repositories;
using MediatR;
using System.Net;

namespace Basket.Queries
{
    public class GetBasketQuery : IRequest<Response<Bookstore.Domain.Entities.Basket>>
    {
        public string userName { get; set; }
    }
    public class GetBasketQueryHandler : IRequestHandler<GetBasketQuery, Response<Bookstore.Domain.Entities.Basket>>
    {
        private IBasketRepository _repository;

        public GetBasketQueryHandler(IBasketRepository repository)
        {
            _repository = repository;
        }

        public async Task<Response<Bookstore.Domain.Entities.Basket>> Handle(GetBasketQuery request, CancellationToken cancellationToken)
        {
            if(string.IsNullOrEmpty(request.userName)) 
            {
                return new Response<Bookstore.Domain.Entities.Basket>()
                {
                    StatusCode = (int)HttpStatusCode.BadRequest,
                    IsSuccess = false,
                    Message = BasketErrorMessage.USER_REQUIRED
                };
            }

            var basket = await _repository.GetBasketByUserName(request.userName);
            if(basket?.Books?.Count == 0)
            {
                return new Response<Bookstore.Domain.Entities.Basket>()
                {
                    StatusCode = (int)HttpStatusCode.NotFound,
                    IsSuccess = false,
                    Message = BasketErrorMessage.BASTKET_EMPTY
                };
            }

            return new Response<Bookstore.Domain.Entities.Basket>()
            {
                StatusCode = (int)HttpStatusCode.OK,
                IsSuccess = true,
                Data = basket
            };
        }
    }
}
