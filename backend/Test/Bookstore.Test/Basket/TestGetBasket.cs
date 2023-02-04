using Basket.Queries;
using Bookstore.Api.Enum.Basket;
using Bookstore.Domain.Repositories;
using Moq;
using System.Net;


namespace Bookstore.Test.Basket
{
    public class TestGetBasket
    {
        [Fact]
        public async Task TestUsernameEmptyShouldBadRequest()
        {
            //Given
            var request = new GetBasketQuery()
            {
                userName = string.Empty,
            };
            var repo = new Mock<IBasketRepository>();
            var query = new GetBasketQueryHandler(repo.Object);

            //When
            var errorMessage = BasketErrorMessage.USER_REQUIRED;
            var response = await query.Handle(request, CancellationToken.None);

            //Asset
            Assert.False(response.IsSuccess);
            Assert.Equal((int)HttpStatusCode.BadRequest, response.StatusCode);
            Assert.Equal(errorMessage, response.Message);
            Assert.Null(response.Data);
        }

        [Fact]
        public async Task TestBooksEmptyShouldReturnNotFound()
        {
            //Given
            var request = new GetBasketQuery()
            {
                userName = "dxxxxx",
            };
            var repo = new Mock<IBasketRepository>();
            repo.Setup(r => r.GetBasketByUserName(It.IsAny<string>(), CancellationToken.None)).ReturnsAsync(new Domain.Entities.Basket()
            {
                Books = new List<Domain.Entities.Book>(),
            });
            var query = new GetBasketQueryHandler(repo.Object);

            //When
            var errorMessage = BasketErrorMessage.BASTKET_EMPTY;
            var response = await query.Handle(request, CancellationToken.None);

            //Asset
            Assert.False(response.IsSuccess);
            Assert.Equal((int)HttpStatusCode.NotFound, response.StatusCode);
            Assert.Equal(errorMessage, response.Message);
            Assert.Null(response.Data);
        }

        [Fact]
        public async Task TestGetBooksShouldReturnOKWithBooks()
        {
            string userName = "ggggg";
            //Given
            var request = new GetBasketQuery()
            {
                userName = userName,
            };
            var repo = new Mock<IBasketRepository>();
            repo.Setup(r => r.GetBasketByUserName(It.IsAny<string>(), CancellationToken.None)).ReturnsAsync(new Domain.Entities.Basket()
            {
                UsertName = userName,
                Books = new List<Domain.Entities.Book>()
                {
                    new Domain.Entities.Book()
                    {
                        ISBN = "123",
                        Id= 1,
                        Name = "xxxaa",
                        Price = 1000,
                        Qty = 10
                    },
                    new Domain.Entities.Book()
                    {
                        ISBN = "saaz1",
                        Id= 2,
                        Name = "xxxaazzzs",
                        Price = 1000,
                        Qty = 10
                    }
                },
            }); 
            var query = new GetBasketQueryHandler(repo.Object);
            var response = await query.Handle(request, CancellationToken.None);

            //Asset
            Assert.True(response.IsSuccess);
            Assert.Equal((int)HttpStatusCode.OK, response.StatusCode);
            Assert.NotNull(response.Data);
            Assert.Equal(20, response.Data.Count);
            Assert.Equal(20000, response.Data.Total);
        }
    }
}
