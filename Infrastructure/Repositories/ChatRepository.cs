using Microsoft.EntityFrameworkCore;
using UserDomain.Entities;
using UserDomain.Interface;

namespace Infrastructure.Repositories;

public class ChatRepository : Repository<Chats>, IChatRepository
{
    public ChatRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Chats>> GetByUserIdAsync(int userId)
    {
        return await _dbSet
            .Include(c => c.Room)
            .Include(c => c.Context)
            .Include(c => c.ChatMessages)
            .Include(c => c.AIResults)
            .Where(c => c.UserId == userId)
            .ToListAsync();
    }

    public async Task<IEnumerable<Chats>> GetByRoomIdAsync(int roomId)
    {
        return await _dbSet
            .Include(c => c.Room)
            .Include(c => c.Context)
            .Include(c => c.ChatMessages)
            .Include(c => c.AIResults)
            .Where(c => c.RoomId == roomId)
            .ToListAsync();
    }
}
