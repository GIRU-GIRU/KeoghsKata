using KeoghsKata.Database;
using Microsoft.Extensions.Logging.Abstractions;

namespace KeoghsKata.Services
{
    public class DatabaseServiceBase : IDatabaseServiceBase
    {

        private readonly IServiceScopeFactory _scopeFactory;
        protected readonly ILogger _logger;

       public DatabaseServiceBase(IServiceScopeFactory scopeFactory, ILogger<NullLogger> logger)
       {
           _scopeFactory = scopeFactory;
           _logger = logger;
       }

        public DatabaseContext GetContext()
        {
            var scope = _scopeFactory.CreateAsyncScope();

            var db = scope.ServiceProvider.GetService<DatabaseContext>();

            return db;
        }
    }
}
