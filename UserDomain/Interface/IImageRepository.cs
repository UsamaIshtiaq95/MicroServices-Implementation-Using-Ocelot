using UserDomain.Entities;

namespace UserDomain.Interface;

public interface IImageRepository : IRepository<Images>
{
    Task<IEnumerable<Images>> GetByRoomIdAsync(int roomId);
}
