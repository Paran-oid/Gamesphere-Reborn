using AutoFixture;
using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameSphereAPI;
using Microsoft.AspNetCore.Mvc.Testing;
using GameSphereTests.Utilities;
using GameSphereAPI.Models.Site_Models.Game_Related;
using System.Net.Http.Json;
using FluentAssertions;
using GameSphereAPI.Models.Viewmodels.Game___Related;

namespace GameSphereTests.Integration
{
    public class GameControllerIntegrationTests : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly IFixture _fixture;
        //We created a fake builder here to test on
        private readonly WebApplicationFactory<Program> _webApplicationFactory;

        public GameControllerIntegrationTests(WebApplicationFactory<Program> webApplicationFactory)
        {
            //basically me creating a fixture instance with lots of customizations
            _fixture = CustomizationConfig.CreateCustomizations();
            _webApplicationFactory = webApplicationFactory;
        }

        [Fact]
        public async Task GameController_GetAllReturnsSuccess()
        {
            // Arrange
            var client = _webApplicationFactory.CreateClient();

            // Act
            var response = await client.GetAsync("Game/GetAll");
            var content = response.Content.ReadAsStringAsync();

            // Assert 
            response.EnsureSuccessStatusCode();
            content.Should().NotBeNull();
        }

        [Fact]
        public async Task GameController_GetReturnsSuccess()
        {
            // Arrange
            var client = _webApplicationFactory.CreateClient();

            // Act
            var response = await client.GetAsync("Game/Get/2");

            //Assert
            response.EnsureSuccessStatusCode();
        }

        [Fact]
        public async Task GameController_PostReturnsSuccess()
        {
            // Arrange
            var client = _webApplicationFactory.CreateClient();
            var model = _fixture.Create<CreateGameDTO>();


            // Act
            var response = await client.PostAsJsonAsync("Game/Post", model);

            // Assert
            response.EnsureSuccessStatusCode();
            response.Content.Should().NotBeNull();

            var createdGame = await response.Content.ReadFromJsonAsync<Game>();

            if (createdGame.ID == null)
            {
                Assert.Fail("Created game ID is null");
            }

            await client.DeleteAsync($"Game/Delete/{createdGame.ID}");
        }

        [Fact]
        public async Task GameController_PutReturnsSuccess()
        {
            // Arrange
            var client = _webApplicationFactory.CreateClient();
            var fakeGame = _fixture.Create<CreateGameDTO>();
            var model = _fixture.Create<UpdateGameDTO>();

            // Act

            //create fake game
            var createResponse = await client.PostAsJsonAsync($"Game/Post", fakeGame);
            createResponse.EnsureSuccessStatusCode();
            var createdGame = await createResponse.Content.ReadFromJsonAsync<Game>();

            if (createdGame.ID == null)
            {
                Assert.Fail("Created game ID is null");
            }

            //update fake game
            var response = await client.PutAsJsonAsync($"Game/Put/{createdGame.ID}", model);

            //delete fake game
            await client.DeleteAsync($"Game/Delete/{createdGame.ID}");

            //Assert
            response.EnsureSuccessStatusCode();

        }

        [Fact]
        public async Task GameController_DeleteReturnsSuccess()
        {
            // Arrange
            var client = _webApplicationFactory.CreateClient();
            var fakeGame = _fixture.Create<CreateGameDTO>();


            // Act
            //create fake game
            var createResponse = await client.PostAsJsonAsync($"Game/Post", fakeGame);
            createResponse.EnsureSuccessStatusCode();
            var createdGame = await createResponse.Content.ReadFromJsonAsync<Game>();

            if (createdGame.ID == null)
            {
                Assert.Fail("Created game ID is null");
            }

            //delete fake game
            var response = await client.DeleteAsync($"Game/Delete/{createdGame.ID}");

            // Assert
            response.EnsureSuccessStatusCode();

        }
    }
}
