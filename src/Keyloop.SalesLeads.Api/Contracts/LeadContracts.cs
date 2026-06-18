using System.ComponentModel.DataAnnotations;
using Keyloop.SalesLeads.Api.Models;

namespace Keyloop.SalesLeads.Api.Contracts;

public class LeadResponse
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string? Phone { get; set; }
    public string? VehicleInterest { get; set; }
    public string Status { get; set; } = string.Empty;
    public string? Source { get; set; }
    public DateTime CreatedDate { get; set; }
    public List<LeadActivityResponse> Activities { get; set; } = new();
}

public class LeadActivityResponse
{
    public int Id { get; set; }
    public string Type { get; set; } = string.Empty;
    public string Notes { get; set; } = string.Empty;
    public DateTime Timestamp { get; set; }
    public ActivityPerformedBy PerformedBy { get; set; }
}

public class CreateActivityRequest
{
    public string Type { get; set; } = string.Empty;
    public string Notes { get; set; } = string.Empty;
    public ActivityPerformedBy? PerformedBy { get; set; }
}

public class CreateLeadRequest
{
    [Required]
    [StringLength(100)]
    public string Name { get; set; } = string.Empty;

    [Required]
    [EmailAddress]
    public string Email { get; set; } = string.Empty;

    [Phone]
    public string? Phone { get; set; }

    public string? VehicleInterest { get; set; }
    public string Status { get; set; } = "New";
    public string? Source { get; set; } = "Website";
}
