using GameSphereAPI.Models.Site_Models.Game_Related;
using GameSphereAPI.Models.Viewmodels.Game___Related;

namespace GameSphereAPI.Data.Services.GameServices
{
    public interface IGameService
    {
        public Task<List<Game>> GetGames();

        public Task<Game?> Get(int ID);

        public Task<Game?> Post(CreateGameDTO model);

        public Task<string?> AddPublisherToGame(int GameID, int PublisherID);

        public Task<string?> AddLanguageToGame(int GameID, int LanguageID);

        public Task<string?> AddDeveloperToGame(int GameID, int DeveloperID);

        public Task<string?> AddTagToGame(int GameID, int TagID);

        public Task<string?> AddGenreToGame(int GameID, int GenreID);

        public Task<Game?> Put(int ID, UpdateGameDTO model);

        public Task<string?> RemovePublisherFromGame(int GameID, int PublisherID);

        public Task<string?> RemoveLanguageFromGame(int GameID, int LanguageID);

        public Task<string?> RemoveDeveloperFromGame(int GameID, int DeveloperID);

        public Task<string?> RemoveTagFromGame(int GameID, int TagID);

        public Task<string?> RemoveGenreFromGame(int GameID, int GenreID);
        public Task<string?> Delete(int ID);

    }
}