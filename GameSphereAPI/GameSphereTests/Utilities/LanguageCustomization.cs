using AutoFixture;
using GameSphereAPI.Models.Site_Models.Game_Related;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameSphereTests.Utilities
{
    internal class LanguageCustomization : ICustomization
    {
        public void Customize(IFixture fixture)
        {
            fixture.Customize<Language>(c => c
                .Without(l => l.GameLanguages));
        }
    }
}