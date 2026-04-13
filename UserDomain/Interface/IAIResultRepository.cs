using UserDomain.Entities;

namespace UserDomain.Interface;

public interface IAIResultRepository : IRepository<AIResults>
{
    Task<IEnumerable<AIResults>> GetByChatIdAsync(int chatId);
}
