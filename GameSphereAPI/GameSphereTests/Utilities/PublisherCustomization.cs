using AutoFixture;
using GameSphereAPI.Models.Site_Models.Game_Related;
using GameSphereAPI.Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameSphereTests.Utilities
{
    public class PublisherCustomization : ICustomization
    {
        public void Customize(IFixture fixture)
        {
            fixture.Customize<Publisher>(c => c
                .Without(p => p.AppUser)
                .Without(p => p.GamePublishers));
        }
    }
}