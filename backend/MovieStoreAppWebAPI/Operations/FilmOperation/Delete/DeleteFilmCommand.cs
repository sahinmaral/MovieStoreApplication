using MovieStoreAppWebAPI.Entities;
using MovieStoreAppWebAPI.Exceptions;
using MovieStoreAppWebAPI.Operations.DatabaseOperation;

namespace MovieStoreAppWebAPI.Operations.FilmOperation.Delete
{
    public class DeleteFilmCommand
    {
        private readonly IMovieStoreDbContext _dbContext;
        public DeleteFilmViewModel Model { get; set; } = new DeleteFilmViewModel();

        public DeleteFilmCommand(IMovieStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Handle()
        {
            Film searchedFilm = CheckIfFilmExists();

            _dbContext.Films.Remove(searchedFilm);
            _dbContext.SaveChanges();
        }

        private Film CheckIfFilmExists()
        {
            Film? searchedFilm = _dbContext.Films.SingleOrDefault(x => x.Id == Model.Id);

            if (searchedFilm == null)
                throw new EntityNullException(typeof(Film));

            return searchedFilm;
        }
    }

    public class DeleteFilmViewModel
    {
        public int Id { get; set; }
    }
}
