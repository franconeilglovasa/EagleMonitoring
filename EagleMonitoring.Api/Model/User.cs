using System.ComponentModel.DataAnnotations;

namespace EagleMonitoring.Api.Model;
public class User
{
    [Key]
    public int Id { get; set; }

    [Required]
    [MaxLength(100)]
    public string Name { get; set; }

    [Required]
    [MaxLength(100)]
    [EmailAddress]
    public string Email { get; set; }

    [Required]
    public string PasswordHash { get; set; }

    [Required]
    [MaxLength(20)]
    public string Role { get; set; } // "Admin" or "Feeder"

    // Navigation properties
    public ICollection<EagleAssignment> EagleAssignments { get; set; }
    public ICollection<FeedingLog> FeedingLogs { get; set; }
}
