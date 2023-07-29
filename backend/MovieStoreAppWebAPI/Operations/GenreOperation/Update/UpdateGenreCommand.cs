using AutoMapper;

using Microsoft.EntityFrameworkCore;

using MovieStoreAppWebAPI.Entities;
using MovieStoreAppWebAPI.Exceptions;
using MovieStoreAppWebAPI.Operations.DatabaseOperation;

using System.IO;

namespace MovieStoreAppWebAPI.Operations.GenreOperation.Update
{
    public class UpdateGenreCommand
    {
        private readonly IMovieStoreDbContext _dbContext;

        public UpdateGenreViewModel Model { get; set; } = new UpdateGenreViewModel();

        public UpdateGenreCommand(IMovieStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Handle()
        {
            Genre updatedGenre = CheckIfGenreExists();

            updatedGenre.Name = Model.Name != default ? Model.Name : updatedGenre.Name;

            _dbContext.SaveChanges();
        }

        private Genre CheckIfGenreExists()
        {
            Genre? searchedGenre = _dbContext.Genres
                .SingleOrDefault(x => x.Id == Model.Id);

            if (searchedGenre == null)
                throw new EntityNullException(typeof(Genre));

            return searchedGenre;
        }
    }

    public class UpdateGenreViewModel
    {
        public int Id { get; set; }
        public string? Name { get; set; }
    }
}
