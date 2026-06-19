using Microsoft.EntityFrameworkCore;
using UserDomain.Entities;
using UserDomain.Interface;

namespace Infrastructure.Repositories;

public class ImageRepository : Repository<Images>, IImageRepository
{
    public ImageRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Images>> GetByRoomIdAsync(int roomId)
    {
        return await _dbSet
            .Include(i => i.Room)
            .Where(i => i.RoomId == roomId)
            .ToListAsync();
    }
}
