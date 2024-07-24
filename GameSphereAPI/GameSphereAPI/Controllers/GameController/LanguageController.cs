using GameSphereAPI.Data.Services.LanguageServices;
using GameSphereAPI.Models.Site_Models.Game_Related;
using GameSphereAPI.Models.Viewmodels.Game___Related;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GameSphereAPI.Controllers.GameController
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class LanguageController : ControllerBase
    {
        private readonly ILanguageService _languageService;

        public LanguageController(ILanguageService languageService)
        {
            _languageService = languageService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Language>>> GetAll()
        {
            var languages = await _languageService.GetLanguages();
            return Ok(languages);
        }

        [HttpGet("{ID}")]
        public async Task<ActionResult<Language>> Get(int ID)
        {
            var language = await _languageService.Get(ID);
            if (language == null)
            {
                return NotFound("Language not found");
            }
            return Ok(language);
        }

        [HttpPost]
        public async Task<ActionResult<Language>> Post(CreateLanguageDTO model)
        {
            if(ModelState.IsValid)
            {
                var language = await _languageService.Post(model);
                if (language == null)
                {
                    return BadRequest("Failed to create language");
                }

                return Ok(language);
            }

            return BadRequest("Check your inputs");

        }

        [HttpPut("{ID}")]
        public async Task<ActionResult<Language>> Put(int ID, UpdateLanguageDTO model)
        {
            var language = await _languageService.Put(ID, model);
            if (language == null)
            {
                return NotFound("Language not found");
            }
            return Ok(language);
        }

        [HttpDelete("{ID}")]
        public async Task<ActionResult<string>> Delete(int ID)
        {
            var result = await _languageService.Delete(ID);
            if (result == null)
            {
                return NotFound("Language not found");
            }
            return Ok(result);
        }
    }
}