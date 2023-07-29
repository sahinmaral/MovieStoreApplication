using AutoMapper;

using MovieStoreAppWebAPI.Entities;
using MovieStoreAppWebAPI.Operations.DatabaseOperation;

namespace MovieStoreAppWebAPI.Operations.PlayerOperation.Read
{
    public class ReadPlayerCommand
    {
        private readonly IMovieStoreDbContext _context;
        private readonly IMapper _mapper;
        public ReadPlayerCommand(IMovieStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<ReadPlayerViewModel> GetAll()
        {
            List<Player> players = _context.Players
                .ToList();

            List<ReadPlayerViewModel> viewModels = _mapper.Map<List<ReadPlayerViewModel>>(players);

            return viewModels;
        }
    }

    public class ReadPlayerViewModel
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Surname { get; set; }
    }
}
