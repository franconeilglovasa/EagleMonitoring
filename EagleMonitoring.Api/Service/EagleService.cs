using EagleMonitoring.Api.Abstract;
using EagleMonitoring.Api.Data;
using EagleMonitoring.Api.Model;
using Microsoft.EntityFrameworkCore;

namespace EagleMonitoring.Api.Service;


public class EagleService : BaseService<Eagle>, IEagleService
{
    public EagleService(EagleManagementContext context) : base(context) { }

    public async Task<IEnumerable<Eagle>> GetByLocationAsync(string location)
    {
        return await _context.Eagles
            .Where(e => e.Location.Contains(location))
            .ToListAsync();
    }

    public async Task<IEnumerable<Eagle>> GetByTagNumberAsync(string tagNumber)
    {
        return await _context.Eagles
            .Where(e => e.TagNumber == tagNumber)
            .ToListAsync();
    }
}