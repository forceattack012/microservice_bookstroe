using Basket.Commands;
using Bookstore.Api.Enum.Basket;
using Bookstore.Domain.Entities;
using Bookstore.Domain.Repositories;
using Moq;
using System.Net;
using static Basket.Commands.AddBasketCommand;

namespace Bookstore.Test.Basket
{
    public class TestCreateBasket
    {
        [Fact]
        public async Task TestAddBasketWhenUserNameEmpty_ShouldBadRequestAsync()
        {
            string userName = string.Empty;
            List<Book> books = new List<Book>();
            var repo = new Mock<IBasketRepository>();
            var command = new AddBasketCommand(userName, books);
            var handler = new AddBasketCommandHandler(repo.Object);
            var result = await handler.Handle(command, CancellationToken.None);

            var message = BasketErrorMessage.USER_REQUIRED;

            Assert.Equal((int)HttpStatusCode.BadRequest, result.StatusCode);
            Assert.Equal(message, result.Message);
            Assert.False(result.IsSuccess);
        }

        [Fact]
        public async Task TestAddBasketWhenBookEmpty_ShouldBadRequestAsync()
        {
            string userName = "John";
            List<Book> books = null;
            var command = new AddBasketCommand(userName, books);
            var repo = new Mock<IBasketRepository>();
            var handler = new AddBasketCommandHandler(repo.Object);
            var result = await handler.Handle(command, CancellationToken.None);

            var message = BasketErrorMessage.BOOK_IS_REQUIRED;

            Assert.Equal((int)HttpStatusCode.BadRequest, result.StatusCode);
            Assert.Equal(message, result.Message);
            Assert.False(result.IsSuccess);
        }

        [Fact]
        public async Task TestWhenAddBaketSuccess_ShouldReturnOk()
        {
            string userName = "John";
            List<Book> books = new List<Book>()
            {
                new Book()
                {
                    Name = "Attack on Titan",
                    ISBN = "1000-000-000",
                    Price = 250
                },
                new Book()
                {
                    Name = "Naruto",
                    ISBN = "1000-000-123",
                    Price = 250
                }
            };

            var repo = new Mock<IBasketRepository>();
            repo.Setup(r => r.GetBasketByUserName(It.IsAny<string>(), CancellationToken.None)).ReturnsAsync(new Domain.Entities.Basket()
            {
                UsertName = userName,
                Books = new List<Book>()
                {
                    new Book()
                    {
                        Name = "JOJO",
                        ISBN = "2000-011-235",
                        Price = 300,
                    }
                }
            });
            repo.Setup(r => r.AddBasket(It.IsAny<Domain.Entities.Basket>(), CancellationToken.None));

            var command = new AddBasketCommand(userName, books);
            var handler = new AddBasketCommandHandler(repo.Object);
            var result = await handler.Handle(command, CancellationToken.None);

            decimal total = 800;
            decimal wantCount = 3;

            repo.Verify(r => r.GetBasketByUserName(It.IsAny<string>(), CancellationToken.None), Times.Once);
            repo.Verify(r => r.AddBasket(It.IsAny<Domain.Entities.Basket>(), CancellationToken.None), Times.Once);

            Assert.True(result.IsSuccess);
            Assert.Empty(result.Message);
            Assert.Equal(total, result.Data.Total);
            Assert.Equal(wantCount, result.Data.Books.Count);
            Assert.Equal(3, result.Data.Books[2].Id);
        }
    }
}