using AutoFixture;
using GameSphereAPI.Models.Site_Models.Game_Related;
using GameSphereAPI.Models.Viewmodels.Game___Related;
using Microsoft.AspNetCore.Mvc.Testing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace GameSphereTests.Integration
{
    public class LanguageControllerIntegrationTests : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly IFixture _fixture;
        private readonly WebApplicationFactory<Program> _webApplication;

        public LanguageControllerIntegrationTests(WebApplicationFactory<Program> webApplication)
        {
            _fixture = new Fixture();
            _webApplication = webApplication;
        }

        [Fact]
        public async Task LanguageController_GetAllReturnsSuccess()
        {
            // Arrange
            var client = _webApplication.CreateClient();

            // Act
            var response = await client.GetAsync("Language/GetAll");

            // Assert
            response.EnsureSuccessStatusCode();
        }

        [Fact]
        public async Task LanguageController_GetReturnsSuccess()
        {
            // Arrange
            var client = _webApplication.CreateClient();

            // Act
            var response = await client.GetAsync("Language/Get/1");

            // Assert
            response.EnsureSuccessStatusCode();
        }

        [Fact]
        public async Task LanguageController_PostReturnsSuccess()
        {
            // Arrange

            var client = _webApplication.CreateClient();
            var languageToCreate = _fixture.Create<CreateLanguageDTO>();

            // Act
            var response = await client.PostAsJsonAsync("Language/Post", languageToCreate);
            var createdLanguage = await response.Content.ReadFromJsonAsync<Language>();

            if (createdLanguage.ID == null)
            {
                Assert.Fail("Created language ID is null");
            }

            // Assert
            response.EnsureSuccessStatusCode();
            await client.DeleteAsync($"Language/Delete/{createdLanguage.ID}");
        }
        [Fact]
        public async Task LanguageController_PutReturnsSuccess()
        {
            // Arrange
            var client = _webApplication.CreateClient();
            var languageToCreate = _fixture.Create<CreateLanguageDTO>();
            var languageToUpdate = _fixture.Create<UpdateLanguageDTO>();

            // Act
            // Create a new language
            var createResponse = await client.PostAsJsonAsync("Language/Post", languageToCreate);
            createResponse.EnsureSuccessStatusCode();
            var createdLanguage = await createResponse.Content.ReadFromJsonAsync<Language>();

            // Ensure the created language has an ID
            if (createdLanguage?.ID == null)
            {
                Assert.Fail("Created language ID is null");
            }

            // Update the language
            var response = await client.PutAsJsonAsync($"Language/Put/{createdLanguage.ID}", languageToUpdate);

            // Assert
            response.EnsureSuccessStatusCode();

            // Cleanup
            await client.DeleteAsync($"Language/Delete/{createdLanguage.ID}");
        }

        [Fact]
        public async Task LanguageController_DeleteReturnsSuccess()
        {
            // Arrange
            var client = _webApplication.CreateClient();
            var languageToCreate = _fixture.Create<CreateLanguageDTO>();

            // Act
            // Create a new language
            var createResponse = await client.PostAsJsonAsync("Language/Post", languageToCreate);
            createResponse.EnsureSuccessStatusCode();
            var createdLanguage = await createResponse.Content.ReadFromJsonAsync<Language>();

            // Ensure the created language has an ID
            if (createdLanguage?.ID == null)
            {
                Assert.Fail("Created language ID is null");
            }

            // Delete the language
            var response = await client.DeleteAsync($"Language/Delete/{createdLanguage.ID}");

            // Assert
            response.EnsureSuccessStatusCode();
        }
    }
}




