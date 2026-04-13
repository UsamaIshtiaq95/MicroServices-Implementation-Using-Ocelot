using Microsoft.EntityFrameworkCore;
using UserDomain.Entities;
using UserDomain.Interface;

namespace Infrastructure.Repositories;

public class AIResultRepository : Repository<AIResults>, IAIResultRepository
{
    public AIResultRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<AIResults>> GetByChatIdAsync(int chatId)
    {
        return await _dbSet
            .Include(r => r.Chat)
            .Where(r => r.ChatId == chatId)
            .OrderByDescending(r => r.CreatedAt)
            .ToListAsync();
    }
}
