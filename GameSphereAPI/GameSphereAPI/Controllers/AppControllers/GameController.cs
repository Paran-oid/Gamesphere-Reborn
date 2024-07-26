using GameSphereAPI.Data.Services.GameServices;
using GameSphereAPI.Models.Site_Models.Game_Related;
using GameSphereAPI.Models.Viewmodels.Game___Related;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GameSphereAPI.Controllers.GameController
{
    [ApiController]
    [Route("/[controller]/[action]")]
    public class GameController : ControllerBase
    {
        private readonly IGameService _gameService;

        public GameController(
            IGameService gameService)
        {
            _gameService = gameService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Game>>> GetAll()
        {
            var games = await _gameService.GetGames();

            return games;
        }

        [HttpGet("{ID}")]
        public async Task<ActionResult<Game>> Get(int ID)
        {
            var game = await _gameService.Get(ID);

            if (game == null)
            {
                return NotFound("Game not found");
            }


            return Ok(game);
        }

        [HttpPost]
        public async Task<ActionResult<Game?>> Post(CreateGameDTO model)
        {
            if (ModelState.IsValid)
            {
                var game = await _gameService.Post(model);

                if (game == null)
                {
                    return BadRequest("Please check your credentials");
                }


                return Ok(game);
            }

            return BadRequest("Check your inputs");
        }

        [HttpPost("game={GameID}&publisher={PublisherID}")]
        public async Task<ActionResult<string>> AddPublisherToGame(int GameID, int PublisherID)
        {
            var result = await _gameService.AddPublisherToGame(GameID, PublisherID);

            if (result == null)
            {
                return Conflict("We couldn't add publisher to game");
            }

            return Ok(result);
        }

        [HttpPost("game={GameID}&language={LanguageID}")]
        public async Task<ActionResult<string>> AddLanguageToGame(int GameID, int LanguageID)
        {
            var result = await _gameService.AddLanguageToGame(GameID, LanguageID);

            if (result == null)
            {
                return Conflict("We couldn't add language to game");
            }

            return Ok(result);
        }

        [HttpPost("game={GameID}&developer={DeveloperID}")]
        public async Task<ActionResult<string>> AddDeveloperToGame(int GameID, int DeveloperID)
        {
            var result = await _gameService.AddDeveloperToGame(GameID, DeveloperID);

            if (result == null)
            {
                return Conflict("We couldn't add developer to game");
            }

            return Ok(result);
        }

        [HttpPost("game={GameID}&genre={GenreID}")]
        public async Task<ActionResult<string>> AddGenreToGame(int GameID, int GenreID)
        {
            var result = await _gameService.AddGenreToGame(GameID, GenreID);

            if (result == null)
            {
                return Conflict("We couldn't add genre to game");
            }

            return Ok(result);
        }

        [HttpPost("game={GameID}&tag={TagID}")]
        public async Task<ActionResult<string>> AddTagToGame(int GameID, int TagID)
        {
            var result = await _gameService.AddTagToGame(GameID, TagID);

            if (result == null)
            {
                return Conflict("We couldn't add tag to game");
            }

            return Ok(result);
        }

        [HttpPut("{ID}")]
        public async Task<ActionResult<Game?>> Put(int ID, UpdateGameDTO model)
        {
            var game = await _gameService.Put(ID, model);

            if (game == null)
            {
                return NotFound("Game not found");
            }


            return Ok(game);
        }

        [HttpDelete("game={GameID}&publisher={PublisherID}")]
        public async Task<ActionResult<string>> RemovePublisherFromGame(int GameID, int PublisherID)
        {
            var result = await _gameService.RemovePublisherFromGame(GameID, PublisherID);

            if (result == null)
            {
                return Conflict("We couldn't remove publisher from game");
            }

            return Ok(result);
        }

        [HttpDelete("game={GameID}&language={LanguageID}")]
        public async Task<ActionResult<string>> RemoveLanguageFromGame(int GameID, int LanguageID)
        {
            var result = await _gameService.RemoveLanguageFromGame(GameID, LanguageID);

            if (result == null)
            {
                return Conflict("We couldn't remove language from game");
            }

            return Ok(result);
        }

        [HttpDelete("game={GameID}&developer={DeveloperID}")]
        public async Task<ActionResult<string>> RemoveDeveloperFromGame(int GameID, int DeveloperID)
        {
            var result = await _gameService.RemoveDeveloperFromGame(GameID, DeveloperID);

            if (result == null)
            {
                return Conflict("We couldn't remove developer from game");
            }

            return Ok(result);
        }

        [HttpDelete("game={GameID}&genre={GenreID}")]
        public async Task<ActionResult<string>> RemoveGenreFromGame(int GameID, int GenreID)
        {
            var result = await _gameService.RemoveGenreFromGame(GameID, GenreID);

            if (result == null)
            {
                return Conflict("We couldn't remove genre from game");
            }

            return Ok(result);
        }

        [HttpDelete("game={GameID}&tag={TagID}")]
        public async Task<ActionResult<string>> RemoveTagFromGame(int GameID, int TagID)
        {
            var result = await _gameService.RemoveTagFromGame(GameID, TagID);

            if (result == null)
            {
                return Conflict("We couldn't remove tag from game");
            }

            return Ok(result);
        }

        [HttpDelete("{ID}")]
        public async Task<ActionResult<string>> Delete(int ID)
        {
            var result = await _gameService.Delete(ID);
            if (result == null)
            {
                return NotFound("Game not found");
            }

            return result;
        }


    }
}