
using UserDomain.Entities;

namespace UserDomain.Interface;
public interface ITokenService
{
    string CreateToken(Users user);
}