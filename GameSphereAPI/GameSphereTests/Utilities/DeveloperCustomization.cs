using AutoFixture;
using GameSphereAPI.Models.Site_Models.Game_Related;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameSphereTests.Utilities
{
    public class DeveloperCustomization : ICustomization
    {
        public void Customize(IFixture fixture)
        {
            fixture.Customize<Developer>(c => c
                .Without(d => d.AppUser)
                .Without(d => d.GameDeveloper));
        }
    }
}