using System;
using System.Collections.Generic;
using System.Text;

namespace MyEstate.Application.Tests
{
    class EstateDataProvider
    {
        public static Dictionary<int, Domain.Entities.Estate> EstatesForChechConteinsInDb()
        {
            var dictionary = new Dictionary<int, Domain.Entities.Estate>();

            var estateId1 = new Domain.Entities.Estate()
            {
                Id = 1,
                Country = "Ukraine",
                City = "Lviv",
                Title = "First Estate",
                Description = "Its my first estate in db",
                Price = 10000,
                Square = 100,
                Street = "Shevhenka",
                Floors = 4,
                Rooms = 4,
                Owner = new Domain.Entities.User() { Id = 3 },
                Created = new DateTime(2000, 01, 01),
                IsActive = true
            };
            
            dictionary.Add(estateId1.Id, estateId1);

            return dictionary;
        }

        public static List<Domain.Entities.Estate> EstateWithoutIDToAdd()
        {
            var estatewithoutId = new List<Domain.Entities.Estate>();

            var estate1 = new Domain.Entities.Estate()
            {
                Country = "Ukraine",
                City = "Lviv",
                Title = "Title",
                Description = "Its my second estate",
                Price = 10000,
                Square = 100,
                Street = "Shevhenka",
                Floors = 4,
                Rooms = 4,
                Owner = new Domain.Entities.User() { Id = 3 },
                Created = new DateTime(2010, 10, 10),
                IsActive = true
            };

            estatewithoutId.Add(estate1);

            return estatewithoutId;
        }
    }
}
