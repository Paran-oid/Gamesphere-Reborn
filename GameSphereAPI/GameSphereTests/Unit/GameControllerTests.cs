using AutoFixture;
using AutoFixture.AutoFakeItEasy;
using AutoFixture.Xunit2;
using AutoMapper;
using FakeItEasy;
using FluentAssertions;
using GameSphereAPI.Controllers.GameController;
using GameSphereAPI.Data.Services.GameServices;
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
    public class GameControllerTests
    {
        private readonly IFixture _fixture;
        private readonly IGameService _gameService;
        private readonly GameController _gameController;
        private readonly IMapper _mapper;


        public GameControllerTests()
        {

            _fixture = new Fixture()
                .Customize(new AutoFakeItEasyCustomization())
                //Date customization cuz dateonly doesnt work
                .Customize(new DateOnlyCustomization())
                //game customization to avoid circular error
                .Customize(new GameCustomization());


            _gameService = _fixture.Freeze<IGameService>();
            _mapper = _fixture.Freeze<IMapper>();

            _gameController = new GameController(_gameService);
        }

        [Fact]
        public async void GameController_GetAll()
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

            var returnedGames = okResult.Value as List<Game>;
            returnedGames.Should().HaveCount(5);


            var returnGames = Assert.IsAssignableFrom<IEnumerable<Game>>(returnedGames);
            Assert.Equal(5, returnGames.Count());
        }

        [Fact]
        public async void GameController_Get()
        {
            //Arrange
            var game = _fixture.Create<Game>();

            A.CallTo(() => _gameService.Get(game.ID)).Returns(Task.FromResult((Game?)game));

            //Act
            var result = await _gameController.Get(game.ID);

            //Assert

            var okResult = result.Result as OkObjectResult;
            okResult.Should().NotBeNull();

            var returnGame = okResult?.Value as Game;
            returnGame.Should().NotBeNull();
            returnGame.Should().BeAssignableTo<Game?>();

            Assert.IsType<Game>(returnGame);
        }

        [Fact]
        public async void GameController_Post()
        {
            //Arrange
            var fakeGameDTO = _fixture.Create<CreateGameDTO>();
            var gameDTO = _fixture.Create<CreateGameDTO>();
            Game? game = _mapper.Map<Game>(gameDTO);

            A.CallTo(() => _gameService.Post(gameDTO)).Returns(Task.FromResult((Game)game));

            //Act

            var result = await _gameController.Post(gameDTO);

            //Assert

            var okResult = result.Result as OkObjectResult;
            okResult.Should().NotBeNull();


            var returnedGame = okResult.Value as Game;
            returnedGame.Should().NotBeNull();
            returnedGame.Should().Be(game);
            returnedGame.Should().BeAssignableTo<Game>();
            returnedGame.Should().NotBe(fakeGameDTO);

        }
    }

}

