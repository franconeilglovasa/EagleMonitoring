using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EagleMonitoring.Api.Model;

public class FeedingLog
{
    [Key]
    public int Id { get; set; }

    [ForeignKey("Eagle")]
    public int EagleId { get; set; }

    [ForeignKey("User")]
    public int FeederId { get; set; }

    [Required]
    public DateTime FeedingTime { get; set; }

    [Required]
    [MaxLength(100)]
    public string FoodType { get; set; }

    [Required]
    [Column(TypeName = "decimal(18,2)")]
    public decimal Quantity { get; set; }

    public string Notes { get; set; }

    // Navigation properties
    public Eagle Eagle { get; set; }
    public User Feeder { get; set; }
}
