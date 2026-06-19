using UserDomain.Entities;
using UserDomain.Interface;

namespace Infrastructure.Repositories;

public class ContextRepository : Repository<Contexts>, IContextRepository
{
    public ContextRepository(AppDbContext context) : base(context)
    {
    }
}
