using EagleMonitoring.Api.Model;

namespace EagleMonitoring.Api.Abstract;

public interface IEagleService : IBaseService<Eagle>
{
    Task<IEnumerable<Eagle>> GetByLocationAsync(string location);
    Task<IEnumerable<Eagle>> GetByTagNumberAsync(string tagNumber);
}