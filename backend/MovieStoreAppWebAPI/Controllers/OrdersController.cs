using AutoMapper;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using MovieStoreAppWebAPI.ActionFilters;
using MovieStoreAppWebAPI.Operations.DatabaseOperation;
using MovieStoreAppWebAPI.Operations.OrderOperation.Create;
using MovieStoreAppWebAPI.Operations.OrderOperation.Delete;
using MovieStoreAppWebAPI.Operations.OrderOperation.Read;
using MovieStoreAppWebAPI.Operations.UserOperation.Read;

using System.Security.Claims;

namespace MovieStoreAppWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IMovieStoreDbContext _dbContext;
        private readonly IMapper _mapper;
        public OrdersController(IMovieStoreDbContext dbContext, IMapper mapper, IHttpContextAccessor httpContextAccessor)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
        }


        [Validate(typeof(ReadUserViewModelValidator))]
        [HttpGet("getCustomerOrdersByCustomerId")]
        public IActionResult GetCustomerOrdersByCustomerId([FromQuery] int id)
        {
            ReadOrderCommand command = new ReadOrderCommand(_dbContext, _mapper)
            {
                Model = new ReadOrderViewModel() 
                { 
                    Customer = new ReadUserViewModel() { Id = id } 
                }
            };

            List<ReadOrderByCustomerViewModel> viewModels = command.GetCustomerOrdersByCustomerId();

            return Ok(viewModels);
        }

        [Authorize(Roles = "Customer")]
        [Validate(typeof(CreateOrderViewModelValidator))]
        [HttpPost("buyFilm")]
        public IActionResult BuyFilm([FromBody]CreateOrderViewModel viewModel)
        {
            string usernameClaim = _httpContextAccessor.HttpContext?.User.FindFirstValue(ClaimTypes.Name); 

            viewModel.UserUsername = usernameClaim;

            CreateOrderCommand command = new CreateOrderCommand(_dbContext, _mapper)
            {
                Model = viewModel
            };

            command.Handle();

            return Ok();
        }

        [Validate(typeof(DeleteOrderViewModelValidator))]
        [HttpDelete("deleteOrder")]
        public IActionResult DeleteOrder([FromBody]DeleteOrderViewModel viewModel)
        {
            DeleteOrderCommand command = new DeleteOrderCommand(_dbContext)
            {
                Model = viewModel
            };

            command.Handle();

            return Ok();
        }
    }
}
