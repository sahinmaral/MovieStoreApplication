using AutoMapper;

using Microsoft.EntityFrameworkCore;

using MovieStoreAppWebAPI.Entities;
using MovieStoreAppWebAPI.Exceptions;
using MovieStoreAppWebAPI.Operations.DatabaseOperation;
using MovieStoreAppWebAPI.Operations.FilmOperation.Read;
using MovieStoreAppWebAPI.Operations.UserOperation.Read;

namespace MovieStoreAppWebAPI.Operations.OrderOperation.Read
{
    public class ReadOrderCommand
    {
        private readonly IMovieStoreDbContext _context;
        private readonly IMapper _mapper;
        public ReadOrderViewModel Model { get; set; } = new ReadOrderViewModel();
        public ReadOrderCommand(IMovieStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public List<ReadOrderByCustomerViewModel> GetCustomerOrdersByCustomerId()
        {
            CheckIfCustomerExists();

            var customerOrders = _context.Orders
                    .Include(o => o.User)
                    .Include(o => o.Film)
                        .ThenInclude(f => f.Genre)
                    .Include(o => o.Film)
                        .ThenInclude(f => f.Director)
                    .Include(o => o.Film)
                        .ThenInclude(f => f.Players)
                    .Where(o => o.User.Id == Model.Customer.Id).ToList();

            return _mapper.Map<List<ReadOrderByCustomerViewModel>>(customerOrders);
        }

        private void CheckIfCustomerExists()
        {
            User? searchedCustomer = _context.Users.SingleOrDefault(x => x.Id == Model.Customer.Id);

            if (searchedCustomer == null)
                throw new EntityNullException(typeof(User));
        }
    }

    public class ReadOrderViewModel
    {
        public int Id { get; set; }
        public ReadFilmViewModel Film { get; set; } = new ReadFilmViewModel();
        public DateTime OrderedDate { get; set; }
        public ReadUserViewModel Customer { get; set; } = new ReadUserViewModel();
    }

    public class ReadOrderByCustomerViewModel
    {
        public int Id { get; set; }
        public ReadFilmViewModel Film { get; set; } = new ReadFilmViewModel();
        public DateTime OrderedDate { get; set; }
        public bool IsDeleted { get; set; }
    }
}
