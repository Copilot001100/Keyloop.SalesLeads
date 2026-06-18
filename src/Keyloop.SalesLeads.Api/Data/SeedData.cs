using Keyloop.SalesLeads.Api.Models;

namespace Keyloop.SalesLeads.Api.Data;

public static class SeedData
{
    public static void Initialize(AppDbContext context)
    {
        var leads = new List<Lead>
        {
            new Lead
            {
                Name = "John Smith",
                Email = "john.smith@email.com",
                Phone = "+1-555-0123",
                VehicleInterest = "Toyota Camry 2025",
                Status = "New",
                Source = "Website",
                CreatedDate = DateTime.UtcNow.AddDays(-5),
                Activities = new List<LeadActivity>
                {
                    new LeadActivity { Type = "Email", Notes = "Sent brochure", Timestamp = DateTime.UtcNow.AddDays(-4) }
                }
            },
            new Lead
            {
                Name = "Emma Johnson",
                Email = "emma.j@email.com",
                Phone = "+1-555-0456",
                VehicleInterest = "Honda CR-V Hybrid",
                Status = "Contacted",
                Source = "Website",
                CreatedDate = DateTime.UtcNow.AddDays(-12),
                Activities = new List<LeadActivity>
                {
                    new LeadActivity { Type = "Call", Notes = "Discussed financing options", Timestamp = DateTime.UtcNow.AddDays(-10) },
                    new LeadActivity { Type = "Meeting", Notes = "Showroom visit scheduled", Timestamp = DateTime.UtcNow.AddDays(-2) }
                }
            },
            new Lead
            {
                Name = "Michael Brown",
                Email = "michael.b@email.com",
                Phone = "+1-555-0789",
                VehicleInterest = "Ford Mustang",
                Status = "Qualified",
                Source = "Website",
                CreatedDate = DateTime.UtcNow.AddDays(-3)
            }
        };

        context.Leads.AddRange(leads);
        context.SaveChanges();
    }
}
