using AutoMapper;

using MovieStoreAppWebAPI.Entities;
using MovieStoreAppWebAPI.Operations.DatabaseOperation;

namespace MovieStoreAppWebAPI.Operations.GenreOperation.Read
{
    public class ReadGenreCommand
    {
        private readonly IMovieStoreDbContext _context;
        private readonly IMapper _mapper;
        public ReadGenreCommand(IMovieStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<ReadGenreViewModel> GetAll()
        {
            List<Genre> genres = _context.Genres
                .ToList();

            List<ReadGenreViewModel> viewModels = _mapper.Map<List<ReadGenreViewModel>>(genres);

            return viewModels;
        }
    }

    public class ReadGenreViewModel
    {
        public int Id { get; set; }
        public string? Name { get; set; }
    }
}
