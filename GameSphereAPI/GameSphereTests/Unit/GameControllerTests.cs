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
        [Fact]
        public async void GameController_Delete()
        {
            // Arrange

            var game = _fixture.Create<Game>();
            var expectedOutput = "Successfully deleted";

            A.CallTo(() => _gameService.Delete(game.ID)).Returns(Task.FromResult((string)expectedOutput));

            //Act

            var result = await _gameController.Delete(game.ID);

            //Assert
            var okResult = result.Result as OkObjectResult;
            okResult.Should().NotBeNull();
            okResult.Value.Should().BeAssignableTo<string>();

            string returnedValue = okResult.Value as string;
            returnedValue.Should().BeEquivalentTo(expectedOutput);
            returnedValue.Should().Be(expectedOutput);
            returnedValue.Should().StartWith("S");
            returnedValue.Should().NotBeNull();


        }
        [Fact]
        public async void GameController_RemovePublisherFromGame()
        {
            // arrange

            var publisher = _fixture.Create<Publisher>();
            var game = _fixture.Create<Game>();

            string expectedResult = "Relationship deleted";

            A.CallTo(() => _gameService.RemovePublisherFromGame(game.ID, publisher.ID)).Returns(Task.FromResult((string)expectedResult));

            // act
            var result = await _gameController.RemovePublisherFromGame(game.ID, publisher.ID);

            // assert
            var okResult = result.Result as OkObjectResult;
            okResult.Should().NotBeNull();
            okResult.Value.Should().BeAssignableTo<string>();

            var returnedValue = okResult.Value as string;
            returnedValue.Should().NotBeNull();
            returnedValue.Should().Be(expectedResult);
            Assert.Equal(returnedValue.Length, expectedResult.Length);
            Assert.EndsWith("d", expectedResult[expectedResult.Length - 1].ToString());

        }

        [Fact]
        public async void GameController_RemoveLanguageFromGame()
        {
            // Arrange
            var language = _fixture.Create<Language>();
            var game = _fixture.Create<Game>();

            string expectedResult = "Relationship deleted";

            A.CallTo(() => _gameService.RemoveLanguageFromGame(game.ID, language.ID)).Returns(Task.FromResult((string)expectedResult));

            // Act
            var result = await _gameController.RemoveLanguageFromGame(game.ID, language.ID);

            // Assert
            var okResult = result.Result as OkObjectResult;
            okResult.Should().NotBeNull();
            okResult.Value.Should().BeAssignableTo<string>();

            var returnedValue = okResult.Value as string;
            returnedValue.Should().NotBeNull();
            returnedValue.Should().Be(expectedResult);
            Assert.Equal(returnedValue.Length, expectedResult.Length);
            Assert.EndsWith("d", expectedResult[expectedResult.Length - 1].ToString());
        }

        [Fact]
        public async void GameController_RemoveDeveloperFromGame()
        {
            // Arrange
            var developer = _fixture.Create<Developer>();
            var game = _fixture.Create<Game>();

            string expectedResult = "Relationship deleted";

            A.CallTo(() => _gameService.RemoveDeveloperFromGame(game.ID, developer.ID)).Returns(Task.FromResult((string)expectedResult));

            // Act
            var result = await _gameController.RemoveDeveloperFromGame(game.ID, developer.ID);

            // Assert
            var okResult = result.Result as OkObjectResult;
            okResult.Should().NotBeNull();
            okResult.Value.Should().BeAssignableTo<string>();

            var returnedValue = okResult.Value as string;
            returnedValue.Should().NotBeNull();
            returnedValue.Should().Be(expectedResult);
            Assert.Equal(returnedValue.Length, expectedResult.Length);
            Assert.EndsWith("d", expectedResult[expectedResult.Length - 1].ToString());
        }

        [Fact]
        public async void GameController_RemoveGenreFromGame()
        {
            // Arrange
            var genre = _fixture.Create<Genre>();
            var game = _fixture.Create<Game>();

            string expectedResult = "Relationship deleted";

            A.CallTo(() => _gameService.RemoveGenreFromGame(game.ID, genre.ID)).Returns(Task.FromResult((string)expectedResult));

            // Act
            var result = await _gameController.RemoveGenreFromGame(game.ID, genre.ID);

            // Assert
            var okResult = result.Result as OkObjectResult;
            okResult.Should().NotBeNull();
            okResult.Value.Should().BeAssignableTo<string>();

            var returnedValue = okResult.Value as string;
            returnedValue.Should().NotBeNull();
            returnedValue.Should().Be(expectedResult);
            Assert.Equal(returnedValue.Length, expectedResult.Length);
            Assert.EndsWith("d", expectedResult[expectedResult.Length - 1].ToString());
        }



        [Fact]
        public async void GameController_RemoveTagFromGame()
        {
            // Arrange
            var tag = _fixture.Create<Tag>();
            var game = _fixture.Create<Game>();

            string expectedResult = "Relationship deleted";

            A.CallTo(() => _gameService.RemoveTagFromGame(game.ID, tag.ID)).Returns(Task.FromResult((string)expectedResult));

            // Act
            var result = await _gameController.RemoveTagFromGame(game.ID, tag.ID);

            // Assert
            var okResult = result.Result as OkObjectResult;
            okResult.Should().NotBeNull();
            okResult.Value.Should().BeAssignableTo<string>();

            var returnedValue = okResult.Value as string;
            returnedValue.Should().NotBeNull();
            returnedValue.Should().Be(expectedResult);
            Assert.Equal(returnedValue.Length, expectedResult.Length);
            Assert.EndsWith("d", expectedResult[expectedResult.Length - 1].ToString());
        }
    }
}