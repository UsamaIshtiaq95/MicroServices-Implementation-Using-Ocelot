
using UserDomain.Entities;
namespace UserDomain.Interface;
public interface IUserRepository
{
    Task<int> GetByEmailAsync(string email);
    Task<Users> GetLoginAsync(string email);
    Task AddAsync(Users user);
    Task<int> UpdateDetailsAsync(Users user);
}
