using UserDomain.Entities;

namespace UserDomain.Interface;

public interface IChatMessageRepository : IRepository<ChatMessages>
{
    Task<IEnumerable<ChatMessages>> GetByChatIdAsync(int chatId);
}
