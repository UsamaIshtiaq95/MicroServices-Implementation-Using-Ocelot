using Microsoft.EntityFrameworkCore;
using UserDomain.Entities;
using UserDomain.Interface;

namespace Infrastructure.Repositories;

public class ApiKeyRepository : Repository<ApiKeys>, IApiKeyRepository
{
    public ApiKeyRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<ApiKeys> GetByServiceNameAsync(string serviceName)
    {
        return await _dbSet.FirstOrDefaultAsync(k => k.ServiceName == serviceName);
    }
}
