using Xunit;
using FluentAssertions;
using Moq;
using WebCarDealership.Requests;
using CarDealership.Data.Repository;
using WebCarDealership.Controllers;
using System.Threading.Tasks;
using CarDealership.Data.Models;
using Microsoft.AspNetCore.Mvc;

namespace Testing
{
    public class OrderControllerTests
    {
        private readonly Mock<IRepository> repoMock;
        private readonly OrderController controllerSut;
        public OrderControllerTests()
        {
            repoMock = new Mock<IRepository>();
            controllerSut = new OrderController(repoMock.Object);
        }

        [Fact]
        public async Task GivenRequestModelWithInvalidCarOfferId_WhenCallingPost_ThenGetNotFound()
        {
            //Arrange
            repoMock.Setup(repo => repo.GetCarOfferById(It.IsAny<int>())).ReturnsAsync((CarOffer)null);
            var requestModel = new OrderRequestModel();

            //Act
            var result = await controllerSut.Post(requestModel);

            //Assert
            result.Should().BeOfType<NotFoundObjectResult>();

        }

        [Fact]
        public async Task GivenValidRequestModel_WhenCarOfferStockNotSufficient_ThenGetBadRequest()
        {
            //Arrange
            var requestModel = new OrderRequestModel()
            {
                Quantity = 2
            };

            var carOffer = new CarOffer()
            {
                AvailableStock = 1
            };

            repoMock.Setup(repo => repo.GetCarOfferById(It.IsAny<int>())).ReturnsAsync(carOffer);

            //Act
            var result = await controllerSut.Post(requestModel);

            //Assert
            result.Should().BeOfType<BadRequestObjectResult>();
        }

        /*[Fact]

        public async Task GivenValidRequestModel_WhenPersitingModelInDb_ThenReturnOk()
        {

        }
       */
    }
}