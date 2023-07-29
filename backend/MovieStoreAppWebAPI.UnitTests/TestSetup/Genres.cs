using MovieStoreAppWebAPI.Entities;
using MovieStoreAppWebAPI.Operations.DatabaseOperation;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieStoreAppWebAPI.UnitTests.TestSetup
{
    public static class Genres
    {
        public static void AddGenres(this MovieStoreInMemoryDbContext context)
        {
            context.Genres.AddRange(
                new Genre() { Name = "Action", Id = 1 },
                new Genre() { Name = "Adventure", Id = 2 });

            context.SaveChanges();
        }
    }
}
