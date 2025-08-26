using EagleMonitoring.Api.Abstract;
using EagleMonitoring.Api.Data;
using EagleMonitoring.Api.Model;
using Microsoft.EntityFrameworkCore;

namespace EagleMonitoring.Api.Service;

public class HealthRecordService : BaseService<HealthRecord>, IHealthRecordService
{
    public HealthRecordService(EagleManagementContext context) : base(context) { }

    public async Task<IEnumerable<HealthRecord>> GetByEagleIdAsync(int eagleId)
    {
        return await _context.HealthRecords
            .Where(hr => hr.EagleId == eagleId)
            .OrderByDescending(hr => hr.RecordDate)
            .ToListAsync();
    }

    public async Task<IEnumerable<HealthRecord>> GetByDateRangeAsync(DateTime startDate, DateTime endDate)
    {
        return await _context.HealthRecords
            .Where(hr => hr.RecordDate >= startDate && hr.RecordDate <= endDate)
            .OrderByDescending(hr => hr.RecordDate)
            .ToListAsync();
    }
}