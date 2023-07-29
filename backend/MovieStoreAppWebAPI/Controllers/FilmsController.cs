using AutoMapper;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using MovieStoreAppWebAPI.ActionFilters;
using MovieStoreAppWebAPI.Operations.DatabaseOperation;
using MovieStoreAppWebAPI.Operations.FilmOperation.Create;
using MovieStoreAppWebAPI.Operations.FilmOperation.Delete;
using MovieStoreAppWebAPI.Operations.FilmOperation.Read;
using MovieStoreAppWebAPI.Operations.FilmOperation.Update;
using MovieStoreAppWebAPI.Services.Logging;

namespace MovieStoreAppWebAPI.Controllers
{
    [Authorize(Roles = "Admin")]
    [Route("api/[controller]")]
    [ApiController]
    public class FilmsController : ControllerBase
    {
        private readonly IMovieStoreDbContext _context;
        private readonly IMapper _mapper;
        public FilmsController(IMovieStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            ReadFilmCommand command = new ReadFilmCommand(_context,_mapper);

            return Ok(command.GetAll());
        }

        [Validate(typeof(CreateFilmViewModelValidator))]
        [HttpPost]
        public IActionResult Add([FromBody]CreateFilmViewModel viewModel)
        {
            CreateFilmCommand command = new CreateFilmCommand(_context, _mapper)
            {
                Model = viewModel
            };

            command.Handle();

            return Ok();
        }

        [Validate(typeof(DeleteFilmViewModelValidator))]
        [HttpDelete]
        public IActionResult Delete([FromQuery]DeleteFilmViewModel viewModel)
        {
            DeleteFilmCommand command = new DeleteFilmCommand(_context)
            {
                Model = viewModel
            };

            command.Handle();

            return Ok();
        }

        [Validate(typeof(UpdateFilmViewModelValidator))]
        [HttpPut]
        public IActionResult Update([FromBody] UpdateFilmViewModel viewModel)
        {
            UpdateFilmCommand command = new UpdateFilmCommand(_context)
            {
                Model = viewModel,
            };

            command.Handle();

            return Ok();
        }

    }
}
