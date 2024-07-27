using AutoFixture;
using AutoFixture.Kernel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameSphereTests.Utilities
{
    public class DateOnlyCustomization : ICustomization
    {
        public void Customize(IFixture fixture)
        {
            fixture.Customizations.Add(new DateOnlySpecimenBuilder());
        }
    }

    public class DateOnlySpecimenBuilder : ISpecimenBuilder
    {
        public object Create(object request, ISpecimenContext context)
        {
            if (request == typeof(DateOnly))
            {
                var random = new Random();
                var year = random.Next(1900, 2100);
                var month = random.Next(1, 13);
                var day = random.Next(1, 29);
                return new DateOnly(year, month, day);
            }

            return new NoSpecimen();
        }
    }


}
