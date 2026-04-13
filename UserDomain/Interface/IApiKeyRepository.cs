using UserDomain.Entities;

namespace UserDomain.Interface;

public interface IApiKeyRepository : IRepository<ApiKeys>
{
    Task<ApiKeys> GetByServiceNameAsync(string serviceName);
}
