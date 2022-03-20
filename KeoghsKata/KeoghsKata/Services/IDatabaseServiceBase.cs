using KeoghsKata.Database;

namespace KeoghsKata.Services
{
    public interface IDatabaseServiceBase
    {
        public DatabaseContext GetContext();
    }
}