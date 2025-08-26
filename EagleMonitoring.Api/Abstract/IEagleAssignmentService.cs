using EagleMonitoring.Api.Model;

namespace EagleMonitoring.Api.Abstract;

public interface IEagleAssignmentService : IBaseService<EagleAssignment>
{
    Task<IEnumerable<EagleAssignment>> GetByEagleIdAsync(int eagleId);
    Task<IEnumerable<EagleAssignment>> GetByFeederIdAsync(int feederId);
    Task<IEnumerable<EagleAssignment>> GetActiveAssignmentsAsync();
    Task DeactivateAssignmentAsync(int assignmentId);
}