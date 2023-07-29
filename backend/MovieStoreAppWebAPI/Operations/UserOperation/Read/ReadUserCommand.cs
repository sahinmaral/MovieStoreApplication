using AutoMapper;

using Microsoft.EntityFrameworkCore;

using MovieStoreAppWebAPI.Entities;
using MovieStoreAppWebAPI.Operations.DatabaseOperation;
using MovieStoreAppWebAPI.Operations.GenreOperation.Read;

namespace MovieStoreAppWebAPI.Operations.UserOperation.Read
{
    public class ReadUserCommand
    {
        private readonly IMovieStoreDbContext _context;
        private readonly IMapper _mapper;
        public ReadUserViewModel Model { get; set; } = new ReadUserViewModel();
        public ReadUserCommand(IMovieStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<ReadUserViewModel> GetAll()
        {
            List<User> customers = _context.Users
                .Include(x=>x.FavouriteGenres)
                .ToList();

            List<ReadUserViewModel> viewModels = _mapper.Map<List<ReadUserViewModel>>(customers);

            return viewModels;
        }

    }

    public class ReadUserViewModel
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public string? Email { get; set; }
        public List<ReadGenreViewModel> FavouriteGenres { get; set; } = new List<ReadGenreViewModel>();
    }
}
