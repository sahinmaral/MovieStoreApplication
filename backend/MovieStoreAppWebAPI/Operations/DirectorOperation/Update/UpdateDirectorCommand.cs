using AutoMapper;

using Microsoft.EntityFrameworkCore;

using MovieStoreAppWebAPI.Entities;
using MovieStoreAppWebAPI.Exceptions;
using MovieStoreAppWebAPI.Operations.DatabaseOperation;

using System.IO;

namespace MovieStoreAppWebAPI.Operations.DirectorOperation.Update
{
    public class UpdateDirectorCommand
    {
        private readonly IMovieStoreDbContext _dbContext;

        public UpdateDirectorViewModel Model { get; set; } = new UpdateDirectorViewModel();

        public UpdateDirectorCommand(IMovieStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Handle()
        {
            Director updatedDirector = CheckIfDirectorExists();

            updatedDirector.Name = Model.Name != default ? Model.Name : updatedDirector.Name;
            updatedDirector.Surname = Model.Surname != default ? Model.Surname : updatedDirector.Surname;

            _dbContext.SaveChanges();
        }

        private Director CheckIfDirectorExists()
        {
            Director? searchedDirector = _dbContext.Directors
                .SingleOrDefault(x => x.Id == Model.Id);

            if (searchedDirector == null)
                throw new EntityNullException(typeof(Director));

            return searchedDirector;
        }
    }

    public class UpdateDirectorViewModel
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Surname { get; set; }
    }
}
