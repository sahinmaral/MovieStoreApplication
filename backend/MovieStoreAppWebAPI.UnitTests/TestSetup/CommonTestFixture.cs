using AutoMapper;

using Microsoft.EntityFrameworkCore;

using MovieStoreAppWebAPI.Common;
using MovieStoreAppWebAPI.Operations.DatabaseOperation;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieStoreAppWebAPI.UnitTests.TestSetup
{
    public class CommonTextFixture
    {
        public MovieStoreInMemoryDbContext Context { get; set; }
        public IMapper Mapper { get; set; }

        public CommonTextFixture()
        {
            var options = new DbContextOptionsBuilder<MovieStoreInMemoryDbContext>().UseInMemoryDatabase(databaseName: "MovieStoreAppDb").Options;

            Context = new MovieStoreInMemoryDbContext(options);

            Context.Database.EnsureCreated();

            Context.AddGenres();
            Context.AddDirectors();
            Context.AddPlayers();
            Context.AddFilms();

            Mapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MapProfile>();
            }).CreateMapper();
        }
    }
}
