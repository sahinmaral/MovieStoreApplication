using MovieStoreAppWebAPI.Entities;
using MovieStoreAppWebAPI.Exceptions;
using MovieStoreAppWebAPI.Operations.DatabaseOperation;

namespace MovieStoreAppWebAPI.Operations.PlayerOperation.Update
{
    public class UpdatePlayerCommand
    {
        private readonly IMovieStoreDbContext _dbContext;

        public UpdatePlayerViewModel Model { get; set; } = new UpdatePlayerViewModel();

        public UpdatePlayerCommand(IMovieStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Handle()
        {
            Player updatedPlayer = CheckIfPlayerExists();

            updatedPlayer.Name = Model.Name != default ? Model.Name : updatedPlayer.Name;
            updatedPlayer.Surname = Model.Surname != default ? Model.Surname : updatedPlayer.Surname;

            _dbContext.SaveChanges();
        }

        private Player CheckIfPlayerExists()
        {
            Player? searchedPlayer = _dbContext.Players
                .SingleOrDefault(x => x.Id == Model.Id);

            if (searchedPlayer == null)
            {
                throw new EntityNullException(typeof(Player));
            }

            return searchedPlayer;
        }
    }

    public class UpdatePlayerViewModel
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Surname { get; set; }
    }
}
