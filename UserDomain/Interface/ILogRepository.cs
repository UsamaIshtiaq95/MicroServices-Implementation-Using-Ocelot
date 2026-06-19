using UserDomain.Entities;

namespace UserDomain.Interface;

public interface ILogRepository : IRepository<Logs>
{
    Task<IEnumerable<Logs>> GetByUserIdAsync(int userId);
}
