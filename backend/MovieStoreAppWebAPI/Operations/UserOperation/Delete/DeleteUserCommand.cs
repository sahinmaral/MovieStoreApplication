using MovieStoreAppWebAPI.Entities;
using MovieStoreAppWebAPI.Exceptions;
using MovieStoreAppWebAPI.Operations.DatabaseOperation;

namespace MovieStoreAppWebAPI.Operations.UserOperation.Delete
{
    public class DeleteUserCommand
    {
        private readonly IMovieStoreDbContext _dbContext;

        public DeleteUserViewModel Model { get; set; } = new DeleteUserViewModel();
        public DeleteUserCommand(IMovieStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Handle()
        {
            User searchedUser = CheckIfUserExists();

            _dbContext.Users.Remove(searchedUser);
            _dbContext.SaveChanges();
        }

        private User CheckIfUserExists()
        {
            User? searchedUser = _dbContext.Users.SingleOrDefault(x => x.Id == Model.Id);

            if (searchedUser == null)
                throw new EntityNullException(typeof(User));

            return searchedUser;
        }
    }

    public class DeleteUserViewModel
    {
        public int Id { get; set; }
    }
}
