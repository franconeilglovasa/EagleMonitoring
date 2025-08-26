using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EagleMonitoring.Api.Model;

public class EagleAssignment
{
    [Key]
    public int Id { get; set; }

    [ForeignKey("Eagle")]
    public int EagleId { get; set; }

    [ForeignKey("User")]
    public int FeederId { get; set; }

    [Required]
    public DateTime AssignmentDate { get; set; }

    [Required]
    public bool IsActive { get; set; }

    // Navigation properties
    public Eagle Eagle { get; set; }
    public User Feeder { get; set; }
}
