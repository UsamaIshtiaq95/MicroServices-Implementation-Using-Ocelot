using Microsoft.EntityFrameworkCore;
using UserDomain.Entities;
using UserDomain.Interface;

namespace Infrastructure.Repositories;

public class LogRepository : Repository<Logs>, ILogRepository
{
    public LogRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Logs>> GetByUserIdAsync(int userId)
    {
        return await _dbSet
            .Include(l => l.User)
            .Where(l => l.UserId == userId)
            .OrderByDescending(l => l.CreatedAt)
            .ToListAsync();
    }
}
