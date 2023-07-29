using AutoMapper;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using MovieStoreAppWebAPI.ActionFilters;
using MovieStoreAppWebAPI.Operations.DatabaseOperation;
using MovieStoreAppWebAPI.Operations.UserOperation.Delete;
using MovieStoreAppWebAPI.Operations.UserOperation.Read;

namespace MovieStoreAppWebAPI.Controllers
{
    [Authorize(Roles = "Admin")]
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IMovieStoreDbContext _dbContext;
        private readonly IMapper _mapper;

        public UsersController(IMovieStoreDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }


        [Validate(typeof(DeleteUserViewModelValidator))]
        [HttpDelete]
        public IActionResult DeleteUser([FromBody]DeleteUserViewModel viewModel)
        {
            DeleteUserCommand command = new DeleteUserCommand(_dbContext)
            {
                Model = viewModel
            };

            command.Handle();

            return Ok();
        }

        [HttpGet]
        public IActionResult GetUsers()
        {
            ReadUserCommand command = new ReadUserCommand(_dbContext, _mapper);

            List<ReadUserViewModel> viewModels = command.GetAll();

            return Ok(viewModels);
        }

    }
}
