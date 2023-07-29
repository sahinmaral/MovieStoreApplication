using MovieStoreAppWebAPI.Entities;
using MovieStoreAppWebAPI.Operations.DatabaseOperation;

namespace MovieStoreAppWebAPI.UnitTests.TestSetup
{
    public static class Directors
    {
        public static void AddDirectors(this MovieStoreInMemoryDbContext context)
        {
            context.Directors.AddRange(
                new Director() { Name = "Christopher", Surname = "Nolan", Id = 1 },
                new Director() { Name = "Quentin", Surname = "Tarantino", Id = 2 });

            context.SaveChanges();
        }
    }
}
