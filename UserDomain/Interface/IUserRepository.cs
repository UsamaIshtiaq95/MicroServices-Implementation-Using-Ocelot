
using UserDomain.Entities;
namespace UserDomain.Interface;
public interface IUserRepository
{
    Task<int> GetByEmailAsync(string email);
    Task<EntityModels> GetLoginAsync(string email);
    Task AddAsync(EntityModels user);
    Task<int> UpdateDetailsAsync(EntityModels user);
}
