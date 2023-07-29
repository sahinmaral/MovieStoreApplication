using MovieStoreAppWebAPI.Entities;
using MovieStoreAppWebAPI.Exceptions;
using MovieStoreAppWebAPI.Operations.DatabaseOperation;

namespace MovieStoreAppWebAPI.Operations.DirectorOperation.Delete
{
    public class DeleteDirectorCommand
    {
        private readonly IMovieStoreDbContext _dbContext;
        public DeleteDirectorViewModel Model { get; set; } = new DeleteDirectorViewModel();

        public DeleteDirectorCommand(IMovieStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Handle()
        {
            Director searchedDirector = CheckIfDirectorExists();

            _dbContext.Directors.Remove(searchedDirector);
            _dbContext.SaveChanges();
        }

        private Director CheckIfDirectorExists()
        {
            Director? searchedDirector = _dbContext.Directors.SingleOrDefault(x => x.Id == Model.Id);

            if (searchedDirector == null)
                throw new EntityNullException(typeof(Director));

            return searchedDirector;
        }
    }

    public class DeleteDirectorViewModel
    {
        public int Id { get; set; }
    }
}
