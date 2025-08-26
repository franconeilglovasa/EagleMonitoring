using EagleMonitoring.Api.Model;

namespace EagleMonitoring.Api.Abstract;

public interface IFeedingLogService : IBaseService<FeedingLog>
{
    Task<IEnumerable<FeedingLog>> GetByEagleIdAsync(int eagleId);
    Task<IEnumerable<FeedingLog>> GetByFeederIdAsync(int feederId);
    Task<IEnumerable<FeedingLog>> GetByDateRangeAsync(DateTime startDate, DateTime endDate);
}