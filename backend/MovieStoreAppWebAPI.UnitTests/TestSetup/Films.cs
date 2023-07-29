using MovieStoreAppWebAPI.Entities;
using MovieStoreAppWebAPI.Operations.DatabaseOperation;

namespace MovieStoreAppWebAPI.UnitTests.TestSetup
{
    public static class Films
    {
        public static void AddFilms(this MovieStoreInMemoryDbContext context)
        {
            context.Films.AddRange(new Film()
            {
                Id = 2,
                Director = context.Directors.Single(x => x.Id == 1),
                Genre = context.Genres.Single(x => x.Id == 4),
                Name = "Interstellar",
                Price = 200,
                PublishedDate = new DateTime(2020, 8, 26),
                About = "When Earth becomes uninhabitable in the future, a farmer and ex-NASA pilot, Joseph Cooper, is tasked to pilot a spacecraft, along with a team of researchers, to find a new planet for humans.",
                Players = new List<Player>()
                {
                    context.Players.Single(x => x.Id == 13),
                    context.Players.Single(x => x.Id == 19),
                    context.Players.Single(x => x.Id == 20),
                    context.Players.Single(x => x.Id == 21),
                    context.Players.Single(x => x.Id == 22)
                }
            });
        }
    }
}
