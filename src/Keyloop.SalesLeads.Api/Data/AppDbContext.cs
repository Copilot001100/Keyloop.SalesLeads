using Microsoft.EntityFrameworkCore;
using Keyloop.SalesLeads.Api.Models;

namespace Keyloop.SalesLeads.Api.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Lead> Leads => Set<Lead>();
    public DbSet<LeadActivity> LeadActivities => Set<LeadActivity>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<LeadActivity>()
            .HasOne(a => a.Lead)
            .WithMany(l => l.Activities)
            .HasForeignKey(a => a.LeadId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<LeadActivity>()
            .Property(a => a.PerformedBy)
            .HasConversion<string>();
    }
}
