using AutoFixture;
using FluentAssertions;
using GameSphereAPI.Models.Site_Models.Game_Related;
using GameSphereAPI.Models.User;
using GameSphereAPI.Models.Viewmodels.Game___Related;
using Microsoft.AspNetCore.Mvc.Testing;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Xunit;

namespace GameSphereTests.Integration
{
    public class PublisherControllerIntegrationTests : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly IFixture _fixture;
        private readonly WebApplicationFactory<Program> _webApplicationFactory;

        public PublisherControllerIntegrationTests(WebApplicationFactory<Program> webApplicationFactory)
        {
            _fixture = new Fixture();
            _webApplicationFactory = webApplicationFactory;
        }

        [Fact]
        public async Task PublisherController_GetAllReturnsSuccess()
        {
            // Arrange
            var client = _webApplicationFactory.CreateClient();

            // Act
            var response = await client.GetAsync("Publisher/GetAll");

            // Assert
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            content.Should().NotBeNullOrEmpty();
        }

        [Fact]
        public async Task PublisherController_GetReturnsSuccess()
        {
            // Arrange
            var client = _webApplicationFactory.CreateClient();

            // Act
            var response = await client.GetAsync("Publisher/Get/1");

            // Assert
            response.EnsureSuccessStatusCode();
        }

        [Fact]
        public async Task PublisherController_PostReturnsSuccess()
        {
            // Arrange
            var client = _webApplicationFactory.CreateClient();
            var publisherToCreate = _fixture.Create<CreatePublisherDTO>();
            var dummyUser = _fixture.Create<AppUser>();
            publisherToCreate.UserID = dummyUser.Id;

            // Act
            var response = await client.PostAsJsonAsync("Publisher/Post", publisherToCreate);
            var createdPublisher = await response.Content.ReadFromJsonAsync<Publisher>();

            // Assert
            response.EnsureSuccessStatusCode();

            // Cleanup
            if (createdPublisher?.ID != null)
            {
                await client.DeleteAsync($"Publisher/Delete/{createdPublisher.ID}");
            }
        }

        [Fact]
        public async Task PublisherController_PutReturnsSuccess()
        {
            // Arrange
            var client = _webApplicationFactory.CreateClient();
            var publisherToCreate = _fixture.Create<CreatePublisherDTO>();
            var publisherToUpdate = _fixture.Create<UpdatePublisherDTO>();

            // Act
            // Create a new publisher
            var createResponse = await client.PostAsJsonAsync("Publisher/Post", publisherToCreate);
            createResponse.EnsureSuccessStatusCode();
            var createdPublisher = await createResponse.Content.ReadFromJsonAsync<Publisher>();

            // Ensure the created publisher has an ID
            if (createdPublisher?.ID == null)
            {
                Assert.Fail("Created publisher ID is null");
            }

            // Update the publisher
            var response = await client.PutAsJsonAsync($"Publisher/Put/{createdPublisher.ID}", publisherToUpdate);

            // Assert
            response.EnsureSuccessStatusCode();

            // Cleanup
            await client.DeleteAsync($"Publisher/Delete/{createdPublisher.ID}");
        }

        [Fact]
        public async Task PublisherController_DeleteReturnsSuccess()
        {
            // Arrange
            var client = _webApplicationFactory.CreateClient();
            var publisherToCreate = _fixture.Create<CreatePublisherDTO>();

            // Act
            // Create a new publisher
            var createResponse = await client.PostAsJsonAsync("Publisher/Post", publisherToCreate);
            createResponse.EnsureSuccessStatusCode();
            var createdPublisher = await createResponse.Content.ReadFromJsonAsync<Publisher>();

            // Ensure the created publisher has an ID
            if (createdPublisher?.ID == null)
            {
                Assert.Fail("Created publisher ID is null");
            }

            // Delete the publisher
            var response = await client.DeleteAsync($"Publisher/Delete/{createdPublisher.ID}");

            // Assert
            response.EnsureSuccessStatusCode();
        }
    }
}

