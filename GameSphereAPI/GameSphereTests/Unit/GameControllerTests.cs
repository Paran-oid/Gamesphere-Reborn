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
using Microsoft.AspNetCore.Mvc;
using GameSphereTests.Utilities;

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
            _fixture = CustomizationConfig.CreateCustomizations();

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

        [Fact]
        public async void GameController_AddPublisherToGame()
        {
            //Arrange
            var game = _fixture.Create<Game>();
            var publisher = _fixture.Create<Publisher>();
            var expectedOutput = "Relationship added successfully";

            A.CallTo(() => _gameService.AddPublisherToGame(game.ID, publisher.ID)).Returns(Task.FromResult((string)expectedOutput));

            //Act

            var result = await _gameController.AddPublisherToGame(game.ID, publisher.ID);

            //Assert
            var okResult = result.Result as OkObjectResult;
            okResult.Should().NotBeNull();

            var output = okResult.Value as string;
            output.Should().NotBeNull();
            output.Should().BeAssignableTo<string>();
            output.Should().Be(expectedOutput);
            output.Should().StartWith("R");
        }

        [Fact]
        public async void GameController_AddLanguageToGame()
        {
            // Arrange
            var game = _fixture.Create<Game>();
            var language = _fixture.Create<Language>();
            var expectedOutput = "Relationship added successfully";

            A.CallTo(() => _gameService.AddLanguageToGame(game.ID, language.ID)).Returns(Task.FromResult((string)expectedOutput));

            // Act
            var result = await _gameController.AddLanguageToGame(game.ID, language.ID);

            // Assert
            var okResult = result.Result as OkObjectResult;
            okResult.Should().NotBeNull();

            var output = okResult.Value as string;
            output.Should().NotBeNull();
            output.Should().BeAssignableTo<string>();
            output.Should().Be(expectedOutput);
            output.Should().StartWith("R");
        }

        [Fact]
        public async void GameController_AddDeveloperToGame()
        {
            // Arrange
            var game = _fixture.Create<Game>();
            var developer = _fixture.Create<Developer>(); // Ensure you have a Developer class
            var expectedOutput = "Relationship added successfully";

            A.CallTo(() => _gameService.AddDeveloperToGame(game.ID, developer.ID)).Returns(Task.FromResult((string)expectedOutput));

            // Act
            var result = await _gameController.AddDeveloperToGame(game.ID, developer.ID);

            // Assert
            var okResult = result.Result as OkObjectResult;
            okResult.Should().NotBeNull();

            var output = okResult.Value as string;
            output.Should().NotBeNull();
            output.Should().BeAssignableTo<string>();
            output.Should().Be(expectedOutput);
            output.Should().StartWith("R");
        }

        [Fact]
        public async void GameController_AddGenreToGame()
        {
            // Arrange
            var game = _fixture.Create<Game>();
            var genre = _fixture.Create<Genre>(); // Ensure you have a Genre class
            var expectedOutput = "Relationship added successfully";

            A.CallTo(() => _gameService.AddGenreToGame(game.ID, genre.ID)).Returns(Task.FromResult((string)expectedOutput));

            // Act
            var result = await _gameController.AddGenreToGame(game.ID, genre.ID);

            // Assert
            var okResult = result.Result as OkObjectResult;
            okResult.Should().NotBeNull();

            var output = okResult.Value as string;
            output.Should().NotBeNull();
            output.Should().BeAssignableTo<string>();
            output.Should().Be(expectedOutput);
            output.Should().StartWith("R");
        }

        [Fact]
        public async void GameController_AddTagToGame()
        {
            // Arrange
            var game = _fixture.Create<Game>();
            var tag = _fixture.Create<Tag>(); // Ensure you have a Tag class
            var expectedOutput = "Relationship added successfully";

            A.CallTo(() => _gameService.AddTagToGame(game.ID, tag.ID)).Returns(Task.FromResult((string)expectedOutput));

            // Act
            var result = await _gameController.AddTagToGame(game.ID, tag.ID);

            // Assert
            var okResult = result.Result as OkObjectResult;
            okResult.Should().NotBeNull();

            var output = okResult.Value as string;
            output.Should().NotBeNull();
            output.Should().BeAssignableTo<string>();
            output.Should().Be(expectedOutput);
            output.Should().StartWith("R");
        }

        [Fact]
        public async void GameController_Put()
        {
            // Arrange
            Game oldGame = _fixture.Create<Game>();
            UpdateGameDTO updatedGameDTO = _fixture.Create<UpdateGameDTO>();
            Game newGame = _mapper.Map<Game>(updatedGameDTO);

            A.CallTo(() => _gameService.Put(oldGame.ID, updatedGameDTO)).Returns(Task.FromResult(((Game)newGame)));

            //Act

            var result = await _gameController.Put(oldGame.ID, updatedGameDTO);

            //Assert

            var okResult = result.Result as OkObjectResult;
            okResult.Should().NotBeNull();

            var output = okResult.Value as Game;
            output.Should().NotBeNull();
            output.Should().BeAssignableTo<Game>();
            output.Should().Be(newGame);
            output.Should().NotBe(oldGame);
            output.Should().NotBeOfType<Publisher>();
        }
    }
}