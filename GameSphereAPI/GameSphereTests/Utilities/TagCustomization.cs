using AutoFixture;
using GameSphereAPI.Models.Site_Models.Game_Related;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameSphereTests.Utilities
{
    public class TagCustomization : ICustomization
    {
        public void Customize(IFixture fixture)
        {
            fixture.Customize<Tag>(c => c
                .Without(t => t.GameTags));
        }
    }
}