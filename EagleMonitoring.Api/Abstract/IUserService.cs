using EagleMonitoring.Api.Model;

namespace EagleMonitoring.Api.Abstract;

public interface IUserService : IBaseService<User>
{
    Task<User> GetByEmailAsync(string email);
    Task<bool> EmailExistsAsync(string email);
}