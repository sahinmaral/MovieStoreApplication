using AutoMapper;

using MovieStoreAppWebAPI.Entities;
using MovieStoreAppWebAPI.Operations.DatabaseOperation;

using System;
using System.Collections.Generic;
using System.Linq;

namespace MovieStoreAppWebAPI.Operations.DirectorOperation.Create
{
    public class CreateDirectorCommand
    {
        private readonly IMovieStoreDbContext _dbContext;
        private readonly IMapper _mapper;

        public CreateDirectorViewModel Model { get; set; } = new CreateDirectorViewModel();
        public CreateDirectorCommand(IMovieStoreDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public void Handle()
        {
            CheckIfDirectorAlreadyExists();

            Director newDirector = _mapper.Map<Director>(Model);

            _dbContext.Directors.Add(newDirector);

            _dbContext.SaveChanges();
        }


        private Director CheckIfDirectorAlreadyExists()
        {
            Director? searchedDirector = _dbContext.Directors.SingleOrDefault(x => x.Name == Model.Name);

            if (searchedDirector == null)
            {
                throw new InvalidOperationException("Böyle bir yönetmen zaten var");
            }

            return searchedDirector;
        }

    }

    public class CreateDirectorViewModel
    {
        public string? Name { get; set; }
        public string? Surname { get; set; }
    }
}
