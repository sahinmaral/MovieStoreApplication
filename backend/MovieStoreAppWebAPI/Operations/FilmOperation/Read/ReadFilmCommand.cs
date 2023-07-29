using AutoMapper;

using Microsoft.EntityFrameworkCore;

using MovieStoreAppWebAPI.Entities;
using MovieStoreAppWebAPI.Operations.DatabaseOperation;
using MovieStoreAppWebAPI.Operations.DirectorOperation.Read;
using MovieStoreAppWebAPI.Operations.GenreOperation.Read;
using MovieStoreAppWebAPI.Operations.PlayerOperation.Read;

namespace MovieStoreAppWebAPI.Operations.FilmOperation.Read
{
    public class ReadFilmCommand
    {
        private readonly IMovieStoreDbContext _context;
        private readonly IMapper _mapper;
        public ReadFilmCommand(IMovieStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<ReadFilmViewModel> GetAll()
        {
            List<Film> films = _context.Films
                .Include(x=>x.Director)
                .Include(x=>x.Genre)
                .Include(x => x.Players)
                .ToList();

            List<ReadFilmViewModel> viewModels = _mapper.Map<List<ReadFilmViewModel>>(films);

            return viewModels;
        }
    }

    public class ReadFilmViewModel
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public DateTime PublishedDate { get; set; }
        public decimal Price { get; set; }
        public string? About { get; set; }
        public ReadGenreViewModel Genre { get; set; } = new ReadGenreViewModel();
        public ReadDirectorViewModel Director { get; set; } = new ReadDirectorViewModel();
        public List<ReadPlayerViewModel> Players { get; set; } = new List<ReadPlayerViewModel>();
    }

}
