using AutoMapper;

using Microsoft.EntityFrameworkCore;

using MovieStoreAppWebAPI.Entities;
using MovieStoreAppWebAPI.Exceptions;
using MovieStoreAppWebAPI.Operations.DatabaseOperation;

using System.Runtime.Serialization;

namespace MovieStoreAppWebAPI.Operations.OrderOperation.Create
{
    public class CreateOrderCommand
    {
        private readonly IMovieStoreDbContext _dbContext;
        private readonly IMapper _mapper;
        public CreateOrderViewModel Model { get; set; } = new CreateOrderViewModel();
        public CreateOrderCommand(IMovieStoreDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public void Handle()
        {
            User customer = CheckIfCustomerExists();
            Film film = CheckIfFilmExists();

            CheckIfCustomerAlreadyOrderedFilm();

            Order newOrder = new Order()
            {
                Film = film,
                User = customer,
            };

            _dbContext.Orders.Add(newOrder);
            _dbContext.SaveChanges();
        }

        private User CheckIfCustomerExists()
        {
            User? searchedCustomer = _dbContext.Users
                .SingleOrDefault(x => x.Username == Model.UserUsername);

            if (searchedCustomer == null)
                throw new EntityNullException(typeof(User));

            return searchedCustomer;
        }

        private Film CheckIfFilmExists()
        {
            Film? searchedFilm = _dbContext.Films
                .SingleOrDefault(x => x.Id == Model.FilmId);

            if (searchedFilm == null)
                throw new EntityNullException(typeof(Film));

            return searchedFilm;
        }

        private void CheckIfCustomerAlreadyOrderedFilm()
        {
            Order? searchedOrder = _dbContext.Orders
                .Include(o => o.Film)
                .Include(o => o.User)
                .SingleOrDefault(o => o.Film.Id == Model.FilmId && o.User.Username == Model.UserUsername);

            if (searchedOrder != null)
                throw new Exception("Zaten bu filmi satın aldınız");
        }

    }

    public class CreateOrderViewModel
    {
        public int FilmId { get; set; }
        [IgnoreDataMember]
        public string? UserUsername { get; set; }
    }
}
