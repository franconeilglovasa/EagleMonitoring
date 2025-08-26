using EagleMonitoring.Api.Abstract;
using EagleMonitoring.Api.Data;
using EagleMonitoring.Api.Model;
using Microsoft.EntityFrameworkCore;

namespace EagleMonitoring.Api.Service;

public class FeedingLogService : BaseService<FeedingLog>, IFeedingLogService
{
    public FeedingLogService(EagleManagementContext context) : base(context) { }

    public async Task<IEnumerable<FeedingLog>> GetByEagleIdAsync(int eagleId)
    {
        return await _context.FeedingLogs
            .Where(fl => fl.EagleId == eagleId)
            .OrderByDescending(fl => fl.FeedingTime)
            .ToListAsync();
    }

    public async Task<IEnumerable<FeedingLog>> GetByFeederIdAsync(int feederId)
    {
        return await _context.FeedingLogs
            .Where(fl => fl.FeederId == feederId)
            .OrderByDescending(fl => fl.FeedingTime)
            .ToListAsync();
    }

    public async Task<IEnumerable<FeedingLog>> GetByDateRangeAsync(DateTime startDate, DateTime endDate)
    {
        return await _context.FeedingLogs
            .Where(fl => fl.FeedingTime >= startDate && fl.FeedingTime <= endDate)
            .OrderByDescending(fl => fl.FeedingTime)
            .ToListAsync();
    }
}