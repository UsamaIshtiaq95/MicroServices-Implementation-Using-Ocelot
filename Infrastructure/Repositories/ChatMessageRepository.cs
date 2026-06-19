using Microsoft.EntityFrameworkCore;
using UserDomain.Entities;
using UserDomain.Interface;

namespace Infrastructure.Repositories;

public class ChatMessageRepository : Repository<ChatMessages>, IChatMessageRepository
{
    public ChatMessageRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<ChatMessages>> GetByChatIdAsync(int chatId)
    {
        return await _dbSet
            .Include(cm => cm.Chat)
            .Where(cm => cm.ChatId == chatId)
            .OrderBy(cm => cm.CreatedAt)
            .ToListAsync();
    }
}
