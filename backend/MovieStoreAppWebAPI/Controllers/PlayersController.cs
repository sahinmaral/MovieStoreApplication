using AutoMapper;

using Microsoft.AspNetCore.Mvc;

using MovieStoreAppWebAPI.ActionFilters;
using MovieStoreAppWebAPI.Operations.DatabaseOperation;
using MovieStoreAppWebAPI.Operations.GenreOperation.Update;
using MovieStoreAppWebAPI.Operations.PlayerOperation.Create;
using MovieStoreAppWebAPI.Operations.PlayerOperation.Delete;
using MovieStoreAppWebAPI.Operations.PlayerOperation.Read;
using MovieStoreAppWebAPI.Operations.PlayerOperation.Update;

namespace MovieStoreAppWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayersController : ControllerBase
    {
        private readonly IMovieStoreDbContext _context;
        private readonly IMapper _mapper;

        public PlayersController(IMovieStoreDbContext dbContext, IMapper mapper)
        {
            _context = dbContext;
            _mapper = mapper;
        }

        [Validate(typeof(DeletePlayerViewModelValidator))]
        [HttpDelete]
        public IActionResult Delete([FromBody]DeletePlayerViewModel viewModel)
        {
            DeletePlayerCommand command = new DeletePlayerCommand(_context)
            {
                Model = viewModel
            };

            command.Delete();

            return Ok();
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            ReadPlayerCommand command = new ReadPlayerCommand(_context, _mapper);

            return Ok(command.GetAll());
        }

        [Validate(typeof(CreatePlayerViewModelValidator))]
        [HttpPost]
        public IActionResult Add([FromBody] CreatePlayerViewModel viewModel)
        {
            CreatePlayerCommand command = new CreatePlayerCommand(_context, _mapper)
            {
                Model = viewModel
            };

            command.Handle();

            return Ok();
        }

        [Validate(typeof(UpdatePlayerViewModelValidator))]
        [HttpPut]
        public IActionResult Update([FromBody] UpdatePlayerViewModel viewModel)
        {
            UpdatePlayerCommand command = new UpdatePlayerCommand(_context)
            {
                Model = viewModel,
            };

            command.Handle();

            return Ok();
        }
    }
}
