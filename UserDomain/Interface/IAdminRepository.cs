using UserDomain.Entities;

namespace UserDomain.Interface;

public interface IAdminRepository : IRepository<Admins>
{
    Task<Admins> GetByEmailAsync(string email);
    Task<bool> ExistsByEmailAsync(string email);
}
