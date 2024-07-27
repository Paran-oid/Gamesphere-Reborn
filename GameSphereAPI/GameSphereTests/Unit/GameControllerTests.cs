using AutoFixture;
using AutoFixture.AutoFakeItEasy;
using AutoFixture.Xunit2;
using FakeItEasy;
using FluentAssertions;
using GameSphereAPI.Controllers.GameController;
using GameSphereAPI.Data.Services.GameServices;
using GameSphereAPI.Models.Site_Models.Game_Related;
using GameSphereTests.Utilities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameSphereTests.Unit
{
    public class GameControllerTests
    {
        private readonly IFixture _fixture;
        private readonly IGameService _gameService;
        private readonly GameController _gameController;


        public GameControllerTests()
        {

            _fixture = new Fixture()
                .Customize(new AutoFakeItEasyCustomization())
                //Date customization cuz dateonly doesnt work
                .Customize(new DateOnlyCustomization())
                //game customization to avoid circular error
                .Customize(new GameCustomization());


            _gameService = _fixture.Freeze<IGameService>();
            _gameController = new GameController(_gameService);
        }

        [Fact]
        public async void PhoneController_GetAll()
        {
            //Arrange
            var games = _fixture.CreateMany<Game>(5).ToList();

            A.CallTo(() => _gameService.GetGames()).Returns(Task.FromResult((List<Game>)games));

            //Act

            var result = await _gameController.GetAll();

            //Assert

            var okResult = result.Result as OkObjectResult;
            okResult.Should().NotBeNull();
            okResult.Value.Should().BeAssignableTo<List<Game>>();

            var test = okResult.Value as List<Game>;
            test.Should().HaveCount(5);


            var returnPhones = Assert.IsAssignableFrom<IEnumerable<Game>>(okResult.Value);
            Assert.Equal(5, returnPhones.Count());
        }

    }

}

