using AutoFixture;
using AutoMapper;
using FakeItEasy;
using FluentAssertions;
using GameSphereAPI.Controllers.GameController;
using GameSphereAPI.Data.Services.LanguageServices;
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
    public class LanguageControllerTests
    {
        private readonly IFixture _fixture;
        private readonly ILanguageService _languageService;
        private readonly LanguageController _languageController;

        public LanguageControllerTests()
        {
            _fixture = CustomizationConfig.CreateCustomizations();
            _languageService = _fixture.Freeze<ILanguageService>();
            _languageController = new LanguageController(_languageService);
        }

        [Fact]
        public async void LanguageController_GetAll()
        {
            // Arrange
            var languages = _fixture.CreateMany<Language>(5).ToList();
            A.CallTo(() => _languageService.GetLanguages()).Returns(Task.FromResult(languages));

            // Act
            var result = await _languageController.GetAll();

            // Assert
            var okResult = result.Result as OkObjectResult;
            okResult.Should().NotBeNull();
            okResult.Value.Should().BeAssignableTo<List<Language>>();

            var returnedLanguages = okResult.Value as List<Language>;
            returnedLanguages.Should().HaveCount(5);
        }

        [Fact]
        public async void LanguageController_Get()
        {
            // Arrange
            var language = _fixture.Create<Language>();
            A.CallTo(() => _languageService.Get(language.ID)).Returns(Task.FromResult(language));

            // Act
            var result = await _languageController.Get(language.ID);

            // Assert
            var okResult = result.Result as OkObjectResult;
            okResult.Should().NotBeNull();

            var returnedLanguage = okResult?.Value as Language;
            returnedLanguage.Should().NotBeNull();
            returnedLanguage.Should().Be(language);
        }

        [Fact]
        public async void LanguageController_Post()
        {
            // Arrange
            var createLanguageDTO = _fixture.Create<CreateLanguageDTO>();
            var language = _fixture.Create<Language>();
            A.CallTo(() => _languageService.Post(createLanguageDTO)).Returns(Task.FromResult(language));

            // Act
            var result = await _languageController.Post(createLanguageDTO);

            // Assert
            var okResult = result.Result as OkObjectResult;
            okResult.Should().NotBeNull();

            var returnedLanguage = okResult.Value as Language;
            returnedLanguage.Should().NotBeNull();
            returnedLanguage.Should().Be(language);
        }

        [Fact]
        public async void LanguageController_Put()
        {
            // Arrange
            var id = _fixture.Create<int>();
            var updateLanguageDTO = _fixture.Create<UpdateLanguageDTO>();
            var updatedLanguage = _fixture.Create<Language>();
            A.CallTo(() => _languageService.Put(id, updateLanguageDTO)).Returns(Task.FromResult(updatedLanguage));

            // Act
            var result = await _languageController.Put(id, updateLanguageDTO);

            // Assert
            var okResult = result.Result as OkObjectResult;
            okResult.Should().NotBeNull();

            var returnedLanguage = okResult?.Value as Language;
            returnedLanguage.Should().NotBeNull();
            returnedLanguage.Should().Be(updatedLanguage);
        }

        [Fact]
        public async void LanguageController_Delete()
        {
            // Arrange
            var id = _fixture.Create<int>();
            var expectedOutput = "Successfully deleted";
            A.CallTo(() => _languageService.Delete(id)).Returns(Task.FromResult(expectedOutput));

            // Act
            var result = await _languageController.Delete(id);

            // Assert
            var okResult = result.Result as OkObjectResult;
            okResult.Should().NotBeNull();
            okResult.Value.Should().BeAssignableTo<string>();

            var returnedValue = okResult.Value as string;
            returnedValue.Should().NotBeNull();
            returnedValue.Should().Be(expectedOutput);
        }


    }
}
