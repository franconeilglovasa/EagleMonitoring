using EagleMonitoring.Api.Abstract;
using EagleMonitoring.Api.Data;
using EagleMonitoring.Api.Model;
using Microsoft.EntityFrameworkCore;

namespace EagleMonitoring.Api.Service;

public class EagleAssignmentService : BaseService<EagleAssignment>, IEagleAssignmentService
{
    public EagleAssignmentService(EagleManagementContext context) : base(context) { }

    public async Task<IEnumerable<EagleAssignment>> GetByEagleIdAsync(int eagleId)
    {
        return await _context.EagleAssignments
            .Where(ea => ea.EagleId == eagleId)
            .OrderByDescending(ea => ea.AssignmentDate)
            .ToListAsync();
    }

    public async Task<IEnumerable<EagleAssignment>> GetByFeederIdAsync(int feederId)
    {
        return await _context.EagleAssignments
            .Where(ea => ea.FeederId == feederId)
            .OrderByDescending(ea => ea.AssignmentDate)
            .ToListAsync();
    }

    public async Task<IEnumerable<EagleAssignment>> GetActiveAssignmentsAsync()
    {
        return await _context.EagleAssignments
            .Where(ea => ea.IsActive)
            .ToListAsync();
    }

    public async Task DeactivateAssignmentAsync(int assignmentId)
    {
        var assignment = await GetByIdAsync(assignmentId);
        if (assignment != null)
        {
            assignment.IsActive = false;
            await UpdateAsync(assignment);
        }
    }

    public override async Task<EagleAssignment> CreateAsync(EagleAssignment assignment)
    {
        // Deactivate any existing active assignments for this eagle
        var activeAssignments = await _context.EagleAssignments
            .Where(ea => ea.EagleId == assignment.EagleId && ea.IsActive)
            .ToListAsync();

        foreach (var activeAssignment in activeAssignments)
        {
            activeAssignment.IsActive = false;
        }

        assignment.IsActive = true;
        return await base.CreateAsync(assignment);
    }
}