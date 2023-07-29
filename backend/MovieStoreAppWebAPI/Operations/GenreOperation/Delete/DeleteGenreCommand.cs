﻿using MovieStoreAppWebAPI.Entities;
using MovieStoreAppWebAPI.Exceptions;
using MovieStoreAppWebAPI.Operations.DatabaseOperation;

namespace MovieStoreAppWebAPI.Operations.GenreOperation.Delete
{
    public class DeleteGenreCommand
    {
        private readonly IMovieStoreDbContext _dbContext;
        public DeleteGenreViewModel Model { get; set; } = new DeleteGenreViewModel();

        public DeleteGenreCommand(IMovieStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Handle()
        {
            Genre searchedGenre = CheckIfGenreExists(Model.Id);

            _dbContext.Genres.Remove(searchedGenre);
            _dbContext.SaveChanges();
        }

        private Genre CheckIfGenreExists(int id)
        {
            Genre? searchedGenre = _dbContext.Genres.SingleOrDefault(x => x.Id == id);

            if (searchedGenre == null)
                throw new EntityNullException(typeof(Genre));

            return searchedGenre;
        }
    }

    public class DeleteGenreViewModel
    {
        public int Id { get; set; }
    }
}
