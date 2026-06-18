using System.ComponentModel.DataAnnotations;

namespace Keyloop.SalesLeads.Api.Models;

public class Lead
{
    public int Id { get; set; }

    [Required]
    [StringLength(100)]
    public string Name { get; set; } = string.Empty;

    [Required]
    [EmailAddress]
    public string Email { get; set; } = string.Empty;

    [Phone]
    public string? Phone { get; set; }

    public string? VehicleInterest { get; set; }
    public string Status { get; set; } = "New"; // New, Contacted, Qualified, Closed
    public string? Source { get; set; } = "Website";
    public DateTime CreatedDate { get; set; } = DateTime.UtcNow;

    public List<LeadActivity> Activities { get; set; } = new();
}
