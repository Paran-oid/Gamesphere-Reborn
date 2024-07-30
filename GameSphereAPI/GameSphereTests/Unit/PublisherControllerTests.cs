using AutoFixture;
using AutoMapper;
using FakeItEasy;
using FluentAssertions;
using GameSphereAPI.Controllers.GameController;
using GameSphereAPI.Data.Services.GameServices;
using GameSphereAPI.Data.Services.PublisherServices;
using GameSphereAPI.Models.Site_Models.Game_Related;
using GameSphereAPI.Models.Viewmodels.Game___Related;
using GameSphereTests.Utilities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameSphereTests.Unit
{
    public class PublisherControllerTests
    {
        private readonly IFixture _fixture;
        private readonly IPublisherService _publisherService;
        private readonly PublisherController _publisherController;
        private readonly IMapper _mapper;

        public PublisherControllerTests()
        {
            _fixture = CustomizationConfig.CreateCustomizations();

            _publisherService = _fixture.Freeze<IPublisherService>();
            _mapper = _fixture.Freeze<IMapper>();

            _publisherController = new PublisherController(_publisherService);
        }

        [Fact]
        public async void PublisherController_GetAll()
        {
            // Arrange
            var publishers = _fixture.CreateMany<Publisher>(5).ToList();
            A.CallTo(() => _publisherService.GetPublishers()).Returns(Task.FromResult(publishers));

            // Act
            var result = await _publisherController.GetAll();

            // Assert
            var okResult = result.Result as OkObjectResult;
            okResult.Should().NotBeNull();
            okResult.Value.Should().BeAssignableTo<List<Publisher>>();

            var returnedPublishers = okResult.Value as List<Publisher>;
            returnedPublishers.Should().HaveCount(5);
        }

        [Fact]
        public async void PublisherController_Get()
        {
            // Arrange
            var publisher = _fixture.Create<Publisher>();
            A.CallTo(() => _publisherService.Get(publisher.ID)).Returns(Task.FromResult(publisher));

            // Act
            var result = await _publisherController.Get(publisher.ID);

            // Assert
            var okResult = result.Result as OkObjectResult;
            okResult.Should().NotBeNull();

            var returnPublisher = okResult?.Value as Publisher;
            returnPublisher.Should().NotBeNull();
            returnPublisher.Should().Be(publisher);
        }

        [Fact]
        public async void PublisherController_Post()
        {
            // Arrange
            var createPublisherDTO = _fixture.Create<CreatePublisherDTO>();
            var publisher = _fixture.Create<Publisher>();
            A.CallTo(() => _publisherService.Post(createPublisherDTO)).Returns(Task.FromResult(publisher));

            // Act
            var result = await _publisherController.Post(createPublisherDTO);

            // Assert
            var okResult = result.Result as OkObjectResult;
            okResult.Should().NotBeNull();

            var returnedPublisher = okResult.Value as Publisher;
            returnedPublisher.Should().NotBeNull();
            returnedPublisher.Should().Be(publisher);
        }

        [Fact]
        public async void PublisherController_Put()
        {
            // Arrange
            var id = _fixture.Create<int>();
            var updatePublisherDTO = _fixture.Create<UpdatePublisherDTO>();
            var updatedPublisher = _fixture.Create<Publisher>();
            A.CallTo(() => _publisherService.Put(id, updatePublisherDTO)).Returns(Task.FromResult(updatedPublisher));

            // Act
            var result = await _publisherController.Put(id, updatePublisherDTO);

            // Assert
            var okResult = result.Result as OkObjectResult;
            okResult.Should().NotBeNull();

            var returnPublisher = okResult?.Value as Publisher;
            returnPublisher.Should().NotBeNull();
            returnPublisher.Should().Be(updatedPublisher);
        }

        [Fact]
        public async void PublisherController_Delete()
        {
            // Arrange
            var id = _fixture.Create<int>();
            var expectedOutput = "Successfully deleted";
            A.CallTo(() => _publisherService.Delete(id)).Returns(Task.FromResult(expectedOutput));

            // Act
            var result = await _publisherController.Delete(id);

            // Assert
            var okResult = result.Result as OkObjectResult;
            okResult.Should().NotBeNull();
            okResult.Value.Should().BeAssignableTo<string>();

            var returnedValue = okResult.Value as string;
            returnedValue.Should().NotBeNull();
            returnedValue.Should().Be(expectedOutput);
            returnedValue.Should().StartWith("S");
        }


    }
}
