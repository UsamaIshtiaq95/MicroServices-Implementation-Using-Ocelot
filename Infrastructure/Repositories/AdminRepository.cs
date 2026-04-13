using Microsoft.EntityFrameworkCore;
using UserDomain.Entities;
using UserDomain.Interface;

namespace Infrastructure.Repositories;

public class AdminRepository : Repository<Admins>, IAdminRepository
{
    public AdminRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<Admins> GetByEmailAsync(string email)
    {
        return await _dbSet.FirstOrDefaultAsync(a => a.Email == email);
    }

    public async Task<bool> ExistsByEmailAsync(string email)
    {
        return await _dbSet.AnyAsync(a => a.Email == email);
    }
}
