using AutoMapper;

using Microsoft.AspNetCore.Mvc;

using MovieStoreAppWebAPI.ActionFilters;
using MovieStoreAppWebAPI.Operations.DatabaseOperation;
using MovieStoreAppWebAPI.Operations.DirectorOperation.Create;
using MovieStoreAppWebAPI.Operations.DirectorOperation.Delete;
using MovieStoreAppWebAPI.Operations.DirectorOperation.Read;

using MovieStoreAppWebAPI.Operations.DirectorOperation.Update;
using MovieStoreAppWebAPI.Operations.PlayerOperation.Create;

namespace MovieStoreAppWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DirectorsController : ControllerBase
    {
        private readonly IMovieStoreDbContext _context;
        private readonly IMapper _mapper;
        public DirectorsController(IMovieStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            ReadDirectorCommand command = new ReadDirectorCommand(_context, _mapper);

            return Ok(command.GetAll());
        }

        [Validate(typeof(CreateDirectorViewModelValidator))]
        [HttpPost]
        public IActionResult Add([FromBody] CreateDirectorViewModel viewModel)
        {
            CreateDirectorCommand command = new CreateDirectorCommand(_context, _mapper)
            {
                Model = viewModel
            };

            command.Handle();

            return Ok();
        }

        [Validate(typeof(DeleteDirectorViewModelValidator))]
        [HttpDelete]
        public IActionResult Delete([FromQuery] DeleteDirectorViewModel viewModel)
        {
            DeleteDirectorCommand command = new DeleteDirectorCommand(_context)
            {
                Model = viewModel
            };

            command.Handle();

            return Ok();
        }

        [Validate(typeof(UpdateDirectorViewModelValidator))]
        [HttpPut]
        public IActionResult Update([FromBody] UpdateDirectorViewModel viewModel)
        {
            UpdateDirectorCommand command = new UpdateDirectorCommand(_context)
            {
                Model = viewModel,
            };

            command.Handle();

            return Ok();
        }

    }
}
