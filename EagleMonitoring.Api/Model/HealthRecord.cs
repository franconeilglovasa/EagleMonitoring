using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EagleMonitoring.Api.Model;

public class HealthRecord
{
    [Key]
    public int Id { get; set; }

    [ForeignKey("Eagle")]
    public int EagleId { get; set; }

    [Required]
    public DateTime RecordDate { get; set; }

    [Required]
    [Column(TypeName = "decimal(18,2)")]
    public decimal Weight { get; set; }

    public string Observations { get; set; }

    public string VetNotes { get; set; }

    // Navigation property
    public Eagle Eagle { get; set; }
}
