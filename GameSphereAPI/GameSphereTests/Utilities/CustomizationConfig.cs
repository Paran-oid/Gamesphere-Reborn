using AutoFixture;
using AutoFixture.AutoFakeItEasy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameSphereTests.Utilities
{
    public class CustomizationConfig
    {
        public static IFixture CreateCustomizations()
        {
            var fixture = new Fixture()
                .Customize(new AutoFakeItEasyCustomization())
                //Date customization cuz dateonly doesnt work
                .Customize(new DateOnlyCustomization())
                //game customization to avoid circular error
                .Customize(new GameCustomization())
                .Customize(new PublisherCustomization())
                .Customize(new LanguageCustomization())
                .Customize(new DeveloperCustomization())
                .Customize(new TagCustomization())
                .Customize(new GenreCustomization());
            return fixture;
        }
    }
}