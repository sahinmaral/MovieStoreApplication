using AutoMapper;

using MovieStoreAppWebAPI.Entities;
using MovieStoreAppWebAPI.Operations.DatabaseOperation;

namespace MovieStoreAppWebAPI.Operations.PlayerOperation.Create
{
    public class CreatePlayerCommand
    {
        private readonly IMovieStoreDbContext _dbContext;
        private readonly IMapper _mapper;

        public CreatePlayerViewModel Model { get; set; } = new CreatePlayerViewModel();
        public CreatePlayerCommand(IMovieStoreDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public void Handle()
        {
            CheckIfPlayerAlreadyExists();

            Player newPlayer = _mapper.Map<Player>(Model);

            _dbContext.Players.Add(newPlayer);

            _dbContext.SaveChanges();
        }


        private Player CheckIfPlayerAlreadyExists()
        {
            Player? searchedPlayer = _dbContext.Players.SingleOrDefault(x => x.Name == Model.Name);

            if (searchedPlayer == null)
            {
                throw new InvalidOperationException("Böyle bir oyuncu zaten var");
            }

            return searchedPlayer;
        }

    }

    public class CreatePlayerViewModel
    {
        public string? Name { get; set; }
        public string? Surname { get; set; }
    }
}
