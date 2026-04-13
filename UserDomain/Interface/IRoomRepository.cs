using UserDomain.Entities;

namespace UserDomain.Interface;

public interface IRoomRepository : IRepository<Rooms>
{
    Task<IEnumerable<Rooms>> GetByRoomNameAsync(string roomName);
}
