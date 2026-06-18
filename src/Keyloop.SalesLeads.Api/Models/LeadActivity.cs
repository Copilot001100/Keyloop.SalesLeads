using System.Text.Json.Serialization;

namespace Keyloop.SalesLeads.Api.Models;

public class LeadActivity
{
    public int Id { get; set; }
    public int LeadId { get; set; }
    [JsonIgnore]
    public Lead Lead { get; set; } = null!;

    public string Type { get; set; } = string.Empty; // Call, Email, Meeting, Note, etc.
    public string Notes { get; set; } = string.Empty;
    public DateTime Timestamp { get; set; } = DateTime.UtcNow;
    public ActivityPerformedBy PerformedBy { get; set; } = ActivityPerformedBy.SalesRep;
}
