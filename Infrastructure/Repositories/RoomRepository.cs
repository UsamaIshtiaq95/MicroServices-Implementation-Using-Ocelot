using Microsoft.EntityFrameworkCore;
using UserDomain.Entities;
using UserDomain.Interface;

namespace Infrastructure.Repositories;

public class RoomRepository : Repository<Rooms>, IRoomRepository
{
    public RoomRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Rooms>> GetByRoomNameAsync(string roomName)
    {
        return await _dbSet.Where(r => r.RoomName.Contains(roomName)).ToListAsync();
    }
}
