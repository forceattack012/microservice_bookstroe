using Basket.Commands;
using Bookstore.Domain.Repositories;
using Moq;
using System.Net;

namespace Bookstore.Test.Basket
{
    public class TestDeleteBasket
    {
        [Fact]
        public async Task TestItemIdAndUsernameEmptyShouldReturnBadRequest()
        {
            //Given
            var mockRepo = new Mock<IBasketRepository>();
            var command = new RemoveBasketCommand(string.Empty, string.Empty);
            
            //Then
            var handler = new RemoveBasketHanlder(mockRepo.Object);
            var result = await handler.Handle(command, CancellationToken.None);

            //Assert
            Assert.NotNull(result);
            Assert.Equal((int)HttpStatusCode.BadRequest, result.StatusCode);

        }

        [Fact]
        public async Task TestBookNotfoundShouldReturnNotFound()
        {
            //Given
            var mockRepo = new Mock<IBasketRepository>();
            mockRepo.Setup(r => r.GetBasketByUserName(It.IsAny<string>(), CancellationToken.None));
            var command = new RemoveBasketCommand("1", "2");

            //Then
            var handler = new RemoveBasketHanlder(mockRepo.Object);
            var result = await handler.Handle(command, CancellationToken.None);

            //Assert
            Assert.NotNull(result);
            Assert.Equal((int)HttpStatusCode.NotFound, result.StatusCode);

        }

        [Fact]
        public async Task TestRemoveBookSucess()
        {
            //Given
            var mockRepo = new Mock<IBasketRepository>();
            mockRepo.Setup(r => r.GetBasketByUserName(It.IsAny<string>(), CancellationToken.None)).ReturnsAsync(new Domain.Entities.Basket()
            {
                UsertName = "1",
                Books = new List<Domain.Entities.Book>()
                {
                    new Domain.Entities.Book()
                    {
                        Id = 3,
                    },
                    new Domain.Entities.Book()
                    {
                        Id = 2,
                    }
                }
            });
            var command = new RemoveBasketCommand("1", "2");

            //Then
            var handler = new RemoveBasketHanlder(mockRepo.Object);
            var result = await handler.Handle(command, CancellationToken.None);

            //Assert
            Assert.NotNull(result);
            Assert.Equal((int)HttpStatusCode.OK, result.StatusCode);
            Assert.True(result.IsSuccess);
        }
    }
}
