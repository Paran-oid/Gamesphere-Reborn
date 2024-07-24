using GameSphereAPI.Models.Site_Models.Game_Related;
using GameSphereAPI.Models.Viewmodels.Game___Related;

namespace GameSphereAPI.Data.Services.LanguageServices
{
    public interface ILanguageService
    {
        public Task<List<Language>> GetLanguages();

        public Task<Language?> Get(int ID);

        public Task<Language?> Post(CreateLanguageDTO model);

        public Task<Language?> Put(int ID, UpdateLanguageDTO model);

        public Task<string?> Delete(int ID);
    }
}