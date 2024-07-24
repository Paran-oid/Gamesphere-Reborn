using AutoMapper;
using GameSphereAPI.Models.Site_Models.Game_Related;
using GameSphereAPI.Models.Viewmodels.Game___Related;
using Microsoft.EntityFrameworkCore;

namespace GameSphereAPI.Data.Services.PublisherServices
{
    public class PublisherService : IPublisherService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public PublisherService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<Publisher>> GetPublishers()
        {
            return await _context.Publishers.ToListAsync();
        }

        public async Task<Publisher?> Get(int ID)
        {
            return await _context.Publishers.FirstOrDefaultAsync(p => p.ID == ID);
        }

        public async Task<Publisher?> Post(CreatePublisherDTO model)
        {
            var publisher = _mapper.Map<Publisher>(model);

            _context.Publishers.Add(publisher);
            await _context.SaveChangesAsync();

            return publisher;
        }

        public async Task<Publisher?> Put(int ID, UpdatePublisherDTO model)
        {
            var publisher = await _context.Publishers.FirstOrDefaultAsync(p => p.ID == ID);

            if (publisher == null)
            {
                return null;
            }

            _mapper.Map(model, publisher);

            await _context.SaveChangesAsync();

            return publisher;
        }

        public async Task<string?> Delete(int ID)
        {
            var publisher = await _context.Publishers.FirstOrDefaultAsync(p => p.ID == ID);

            if (publisher == null)
            {
                return null;
            }

            _context.Publishers.Remove(publisher);
            await _context.SaveChangesAsync();

            return "Successfully deleted";
        }
    }
}