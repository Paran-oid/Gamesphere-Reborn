using GameSphereAPI.Models.Site_Models.Game_Related;
using GameSphereAPI.Models.Viewmodels.Game___Related;

namespace GameSphereAPI.Data.Services.PublisherServices
{
    public interface IPublisherService
    {
        public Task<List<Publisher>> GetPublishers();

        public Task<Publisher?> Get(int ID);

        public Task<Publisher?> Post(CreatePublisherDTO model);

        public Task<Publisher?> Put(int ID, UpdatePublisherDTO model);

        public Task<string?> Delete(int ID);
    }
}