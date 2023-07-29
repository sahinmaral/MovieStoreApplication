using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MovieStoreAppWebAPI.Entities;
using MovieStoreAppWebAPI.Operations.DatabaseOperation;
using MovieStoreAppWebAPI.Operations.PlayerOperation.Read;

namespace MovieStoreAppWebAPI.Operations.DirectorOperation.Read
{
    public class ReadDirectorCommand
    {
        private readonly IMovieStoreDbContext _context;
        private readonly IMapper _mapper;
        public ReadDirectorCommand(IMovieStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<ReadDirectorViewModel> GetAll()
        {
            List<Director> directors = _context.Directors
                .ToList();

            List<ReadDirectorViewModel> viewModels = _mapper.Map<List<ReadDirectorViewModel>>(directors);

            return viewModels;
        }
    }

    public class ReadDirectorViewModel
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Surname { get; set; }
    }
}
