using EagleMonitoring.Api.Model;

namespace EagleMonitoring.Api.Abstract;

public interface IHealthRecordService : IBaseService<HealthRecord>
{
    Task<IEnumerable<HealthRecord>> GetByEagleIdAsync(int eagleId);
    Task<IEnumerable<HealthRecord>> GetByDateRangeAsync(DateTime startDate, DateTime endDate);
}
