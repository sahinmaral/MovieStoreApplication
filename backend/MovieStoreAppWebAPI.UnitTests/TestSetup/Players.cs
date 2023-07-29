using MovieStoreAppWebAPI.Entities;
using MovieStoreAppWebAPI.Operations.DatabaseOperation;

namespace MovieStoreAppWebAPI.UnitTests.TestSetup
{
    public static class Players
    {
        public static void AddPlayers(this MovieStoreInMemoryDbContext context)
        {
            context.Players.AddRange(
                                new Player() { Name = "Elizabeth", Surname = "Olsen", Id = 1 },
                                new Player() { Name = "Scarlett", Surname = "Johansson", Id = 2 },
                                new Player() { Name = "Tom", Surname = "Cruise", Id = 3 },
                                new Player() { Name = "Jim", Surname = "Carrey", Id = 4 },
                                new Player() { Name = "Will", Surname = "Smith", Id = 5 },
                                new Player() { Name = "Robert Downey", Surname = "Jr.", Id = 6 },
                                new Player() { Name = "Johnny", Surname = "Depp", Id = 7 },
                                new Player() { Name = "Brad", Surname = "Pitt", Id = 8 },
                                new Player() { Name = "Angelina", Surname = "Jolie", Id = 9 },
                                new Player() { Name = "Leonardo", Surname = "DiCaprio", Id = 10 },
                                new Player() { Name = "Clint", Surname = "Eastwood", Id = 11 },
                                new Player() { Name = "Hugh", Surname = "Jackman", Id = 12 },
                                new Player() { Name = "Matt", Surname = "Damon", Id = 13 },
                                new Player() { Name = "Elizabeth", Surname = "Debicki", Id = 14 },
                                new Player() { Name = "Robert", Surname = "Pattinson", Id = 15 },
                                new Player() { Name = "John David", Surname = "Washington", Id = 16 },
                                new Player() { Name = "Kenneth", Surname = "Branagh", Id = 17 },
                                new Player() { Name = "Clémence", Surname = "Poésy", Id = 18 },
                                new Player() { Name = "Anne", Surname = "Hathaway", Id = 19 },
                                new Player() { Name = "Jessica", Surname = "Chastain", Id = 20 },
                                new Player() { Name = "Michael", Surname = "Caine", Id = 21 },
                                new Player() { Name = "Matthew", Surname = "McConaughey", Id = 22 },
                                new Player() { Name = "Heath", Surname = "Ledger", Id = 23 },
                                new Player() { Name = "Christian", Surname = "Bale", Id = 24 },
                                new Player() { Name = "Aaron", Surname = "Eckhart", Id = 25 }
                );

            context.SaveChanges();
        }
    }
}
