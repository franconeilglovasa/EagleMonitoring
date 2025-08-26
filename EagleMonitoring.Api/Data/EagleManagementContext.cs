using EagleMonitoring.Api.Model;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace EagleMonitoring.Api.Data;

public class EagleManagementContext : DbContext
{
    public EagleManagementContext(DbContextOptions<EagleManagementContext> options) : base(options)
    {
    }

    public DbSet<User> Users { get; set; }
    public DbSet<Eagle> Eagles { get; set; }
    public DbSet<HealthRecord> HealthRecords { get; set; }
    public DbSet<FeedingLog> FeedingLogs { get; set; }
    public DbSet<EagleAssignment> EagleAssignments { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // You can add additional configuration here if needed
        // For example, setting up indexes or additional constraints

        modelBuilder.Entity<User>()
            .HasIndex(u => u.Email)
            .IsUnique();

        modelBuilder.Entity<Eagle>()
            .HasIndex(e => e.TagNumber)
            .IsUnique();
    }
}