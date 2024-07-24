using Microsoft.EntityFrameworkCore;
using GameSphereAPI.Models.Site_Models.Game_Related;
using GameSphereAPI.Models.Site_Models.Game_Related.Relationships;
using GameSphereAPI.Models.Viewmodels.Game___Related;
using AutoMapper;

namespace GameSphereAPI.Data.Services.GameServices
{
    public class GameService : IGameService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public GameService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<Game>> GetGames()
        {
            var games = await _context.Games.ToListAsync();
            return (games);
        }

        public async Task<Game?> Get(int ID)
        {
            var game = await _context.Games.FirstOrDefaultAsync(x => x.ID == ID);

            return game;
        }

        public async Task<Game?> Post(CreateGameDTO model)
        {
            var game = _mapper.Map<Game>(model);

            _context.Games.Add(game);
            await _context.SaveChangesAsync();

            return game;
        }

        public async Task<string?> AddPublisherToGame(int GameID, int PublisherID)
        {
            var game = await _context.Games.FirstOrDefaultAsync(g => g.ID == GameID);
            if (game == null)
            {
                return "Game not found";
            }

            var publisher = await _context.Publishers.FirstOrDefaultAsync(p => p.ID == PublisherID);

            if (publisher == null)
            {
                return "Publisher not found";
            }

            var relationship = await _context.GamePublishers.FirstOrDefaultAsync(
                r => r.GameID == GameID &&
                     r.PublisherID == PublisherID);

            if (relationship == null)
            {
                relationship = new GamePublisher
                {
                    GameID = GameID,
                    PublisherID = PublisherID
                };

                _context.GamePublishers.Add(relationship);
                await _context.SaveChangesAsync();

                return "Relationship added successfully";
            }

            return "Relationship already exists";
        }

        public async Task<string?> AddLanguageToGame(int GameID, int LanguageID)
        {
            var game = await _context.Games.FirstOrDefaultAsync(g => g.ID == GameID);
            if (game == null)
            {
                return "Game not found";
            }

            var language = await _context.Languages.FirstOrDefaultAsync(l => l.ID == LanguageID);

            if (language == null)
            {
                return "Language not found";
            }

            var relationship = await _context.GameLanguages.FirstOrDefaultAsync(
                r => r.GameID == GameID &&
                     r.LanguageID == LanguageID);

            if (relationship == null)
            {
                relationship = new GameLanguage
                {
                    GameID = GameID,
                    LanguageID = LanguageID
                };

                _context.GameLanguages.Add(relationship);
                await _context.SaveChangesAsync();

                return "Relationship added successfully";
            }

            return "Relationship already exists";
        }

        public async Task<string?> AddDeveloperToGame(int GameID, int DeveloperID)
        {
            var game = await _context.Games.FirstOrDefaultAsync(g => g.ID == GameID);
            if (game == null)
            {
                return "Game not found";
            }

            var developer = await _context.Developers.FirstOrDefaultAsync(d => d.ID == DeveloperID);

            if (developer == null)
            {
                return "Developer not found";
            }

            var relationship = await _context.GameDevelopers.FirstOrDefaultAsync(
                r => r.GameID == GameID &&
                     r.DeveloperID == DeveloperID);

            if (relationship == null)
            {
                relationship = new GameDeveloper
                {
                    GameID = GameID,
                    DeveloperID = DeveloperID
                };

                _context.GameDevelopers.Add(relationship);
                await _context.SaveChangesAsync();

                return "Relationship added successfully";
            }

            return "Relationship already exists";
        }

        public async Task<string?> AddTagToGame(int GameID, int TagID)
        {
            var game = await _context.Games.FirstOrDefaultAsync(g => g.ID == GameID);
            if (game == null)
            {
                return "Game not found";
            }

            var tag = await _context.Tags.FirstOrDefaultAsync(t => t.ID == TagID);

            if (tag == null)
            {
                return "Tag not found";
            }

            var relationship = await _context.GameTags.FirstOrDefaultAsync(
                r => r.GameID == GameID &&
                     r.TagID == TagID);

            if (relationship == null)
            {
                relationship = new GameTag
                {
                    GameID = GameID,
                    TagID = TagID
                };

                _context.GameTags.Add(relationship);
                await _context.SaveChangesAsync();

                return "Relationship added successfully";
            }

            return "Relationship already exists";
        }

        public async Task<string?> AddGenreToGame(int GameID, int GenreID)
        {
            var game = await _context.Games.FirstOrDefaultAsync(g => g.ID == GameID);
            if (game == null)
            {
                return "Game not found";
            }

            var genre = await _context.Genres.FirstOrDefaultAsync(g => g.ID == GenreID);

            if (genre == null)
            {
                return "Genre not found";
            }

            var relationship = await _context.GameGenres.FirstOrDefaultAsync(
                r => r.GameID == GameID &&
                     r.GenreID == GenreID);

            if (relationship == null)
            {
                relationship = new GameGenre
                {
                    GameID = GameID,
                    GenreID = GenreID
                };

                _context.GameGenres.Add(relationship);
                await _context.SaveChangesAsync();

                return "Relationship added successfully";
            }

            return "Relationship already exists";
        }
        public async Task<Game?> Put(int ID, UpdateGameDTO model)
        {
            var game = await _context.Games.FirstOrDefaultAsync(g => g.ID == ID);

            if (game == null)
            {
                return null;
            }

            _mapper.Map<Game>(model);
            await _context.SaveChangesAsync();

            return game;
        }


        public async Task<string?> RemovePublisherFromGame(int GameID, int PublisherID)
        {
            var relationship = await _context.GamePublishers
                .FirstOrDefaultAsync(gp => gp.GameID == GameID && gp.PublisherID == PublisherID);

            if (relationship == null)
            {
                return null;
            }

            _context.GamePublishers.Remove(relationship);
            await _context.SaveChangesAsync();

            return "Relationship deleted";
        }

        public async Task<string?> RemoveLanguageFromGame(int GameID, int LanguageID)
        {
            var relationship = await _context.GameLanguages
                .FirstOrDefaultAsync(gl => gl.GameID == GameID && gl.LanguageID == LanguageID);

            if (relationship == null)
            {
                return null;
            }

            _context.GameLanguages.Remove(relationship);
            await _context.SaveChangesAsync();

            return "Relationship deleted";
        }

        public async Task<string?> RemoveDeveloperFromGame(int GameID, int DeveloperID)
        {
            var relationship = await _context.GameDevelopers
                .FirstOrDefaultAsync(gd => gd.GameID == GameID && gd.DeveloperID == DeveloperID);

            if (relationship == null)
            {
                return null;
            }

            _context.GameDevelopers.Remove(relationship);
            await _context.SaveChangesAsync();

            return "Relationship deleted";
        }

        public async Task<string?> RemoveTagFromGame(int GameID, int TagID)
        {
            var relationship = await _context.GameTags
                .FirstOrDefaultAsync(gt => gt.GameID == GameID && gt.TagID == TagID);

            if (relationship == null)
            {
                return null;
            }

            _context.GameTags.Remove(relationship);
            await _context.SaveChangesAsync();

            return "Relationship deleted";
        }

        public async Task<string?> RemoveGenreFromGame(int GameID, int GenreID)
        {
            var relationship = await _context.GameGenres
                .FirstOrDefaultAsync(gg => gg.GameID == GameID && gg.GenreID == GenreID);

            if (relationship == null)
            {
                return null;
            }

            _context.GameGenres.Remove(relationship);
            await _context.SaveChangesAsync();

            return "Relationship deleted";
        }

        public async Task<string?> Delete(int ID)
        {
            var game = await _context.Games.FirstOrDefaultAsync(g => g.ID == ID);

            if (game == null)
            {
                return null;
            }

            _context.Games.Remove(game);
            await _context.SaveChangesAsync();

            return "Successfully deleted";
        }
    }
}