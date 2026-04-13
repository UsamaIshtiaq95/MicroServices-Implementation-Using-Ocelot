using UserDomain.Entities;

namespace UserDomain.Interface;

public interface IChatRepository : IRepository<Chats>
{
    Task<IEnumerable<Chats>> GetByUserIdAsync(int userId);
    Task<IEnumerable<Chats>> GetByRoomIdAsync(int roomId);
}
