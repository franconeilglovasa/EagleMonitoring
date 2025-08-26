using Microsoft.Extensions.Diagnostics.HealthChecks;
using System.ComponentModel.DataAnnotations;

namespace EagleMonitoring.Api.Model;

public class Eagle
{
    [Key]
    public int Id { get; set; }

    [Required]
    [MaxLength(100)]
    public string Name { get; set; }

    [Required]
    [MaxLength(50)]
    public string TagNumber { get; set; }

    [Required]
    [MaxLength(10)]
    public string Gender { get; set; }

    public DateTime DateOfBirth { get; set; }

    [MaxLength(200)]
    public string Location { get; set; }

    // Navigation properties
    public ICollection<HealthRecord> HealthRecords { get; set; }
    public ICollection<FeedingLog> FeedingLogs { get; set; }
    public ICollection<EagleAssignment> EagleAssignments { get; set; }
}
