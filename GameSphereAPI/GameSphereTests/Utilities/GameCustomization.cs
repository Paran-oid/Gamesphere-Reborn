using AutoFixture;
using AutoFixture.Kernel;
using GameSphereAPI.Models.Site_Models.Game_Related;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameSphereTests.Utilities
{
    public class GameCustomization : ICustomization
    {
        public void Customize(IFixture fixture)
        {
            fixture.Customize<Game>(c => c
                .Without(g => g.Reviews)
                .Without(g => g.DLCs)
                .Without(g => g.Achievements)
                .Without(g => g.GameDevelopers)
                .Without(g => g.GameGenres)
                .Without(g => g.GameLanguages)
                .Without(g => g.GamePublishers)
                .Without(g => g.GameTags)
                .Without(g => g.Languages)
                .Without(g => g.News)
                .Without(g => g.Publishers));

        }
    }
}
