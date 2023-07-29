using AutoMapper;

using MovieStoreAppWebAPI.Entities;
using MovieStoreAppWebAPI.Operations.DatabaseOperation;

using System;
using System.Collections.Generic;
using System.Linq;

namespace MovieStoreAppWebAPI.Operations.GenreOperation.Create
{
    public class CreateGenreCommand
    {
        private readonly IMovieStoreDbContext _dbContext;
        private readonly IMapper _mapper;

        public CreateGenreViewModel Model { get; set; } = new CreateGenreViewModel();
        public CreateGenreCommand(IMovieStoreDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public void Handle()
        {
            CheckIfGenreAlreadyExists();

            Genre newGenre = _mapper.Map<Genre>(Model);

            _dbContext.Genres.Add(newGenre);

            _dbContext.SaveChanges();
        }


        private void CheckIfGenreAlreadyExists()
        {
            Genre? searchedGenre = _dbContext.Genres.SingleOrDefault(x => x.Name == Model.Name);

            if (searchedGenre != null)
            {
                throw new InvalidOperationException("Böyle bir tür zaten var");
            }
        }

    }

    public class CreateGenreViewModel
    {
        public string? Name { get; set; }
    }
}
