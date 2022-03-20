using KeoghsKata.Database;

namespace KeoghsKata.Services
{
    public interface IServiceBase
    {
        public DatabaseContext GetContext();
    }
}