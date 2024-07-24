using AutoMapper;
using GameSphereAPI.Models.Site_Models.Game_Related;
using GameSphereAPI.Models.Viewmodels.Game___Related;
using Microsoft.EntityFrameworkCore;

namespace GameSphereAPI.Data.Services.LanguageServices
{
    public class LanguageService : ILanguageService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public LanguageService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<Language>> GetLanguages()
        {
            return await _context.Languages.ToListAsync();
        }

        public async Task<Language?> Get(int ID)
        {
            return await _context.Languages.FirstOrDefaultAsync(l => l.ID == ID);
        }

        public async Task<Language?> Post(CreateLanguageDTO model)
        {
            var language = _mapper.Map<Language>(model);

            _context.Languages.Add(language);
            await _context.SaveChangesAsync();

            return language;
        }

        public async Task<Language?> Put(int ID, UpdateLanguageDTO model)
        {
            var language = await _context.Languages.FirstOrDefaultAsync(l => l.ID == ID);

            if (language == null)
            {
                return null;
            }

            _mapper.Map(model, language);

            await _context.SaveChangesAsync();

            return language;
        }

        public async Task<string?> Delete(int ID)
        {
            var language = await _context.Languages.FirstOrDefaultAsync(l => l.ID == ID);

            if (language == null)
            {
                return null;
            }

            _context.Languages.Remove(language);
            await _context.SaveChangesAsync();

            return "Successfully deleted";
        }
    }
}