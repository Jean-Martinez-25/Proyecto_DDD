using DDD_SOLID.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD_SOLID.Infrastructure.Persistence
{
    public class AppDbContext: DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Customer> Customers => Set<Customer>();
        public DbSet<Call> Calls => Set<Call>();
        public DbSet<Agent> Agents => Set<Agent>();
        public DbSet<TimeSlot> TimeSlots => Set<TimeSlot>();
        public DbSet<Schedule> Schedules => Set<Schedule>();
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.HasKey(c => c.Id);
                entity.Property(c => c.FullName).IsRequired().HasMaxLength(100);
                entity.Property(c => c.Email).IsRequired().HasMaxLength(100);
                entity.Property(c => c.PhoneNumber).IsRequired().HasMaxLength(200);
                entity.Property(c => c.CreatedAt).IsRequired();
            });

            modelBuilder.Entity<Call>(entity =>
            {
                entity.HasKey(c => c.Id);
                entity.Property(c => c.Subject).IsRequired().HasMaxLength(200);
                entity.Property(c => c.Notes).IsRequired().HasMaxLength(1000);
                entity.Property(c => c.Timestamp).IsRequired();
                entity.HasOne(c => c.Customer)
                    .WithMany()
                    .HasForeignKey(c => c.CustomerId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<Agent>(entity => { 
                entity.HasKey(a => a.Id);
                entity.Property(a => a.FullName).IsRequired().HasMaxLength(200);
                entity.Property(a => a.Email).IsRequired().HasMaxLength(100);
                entity.Property(a => a.Role).IsRequired().HasMaxLength(50);
            });

            modelBuilder.Entity<TimeSlot>(entity => {
                entity.HasKey(t => t.Id);
                entity.Property(t => t.Name).IsRequired().HasMaxLength(100);
                entity.Property(t => t.StartTime).IsRequired();
                entity.Property(t => t.EndTime).IsRequired();
                entity.Property(t => t.IsAvalibe).IsRequired();
            });

            modelBuilder.Entity<Schedule>(entity => {
                entity.HasKey(s => s.Id);
                entity.Property(s => s.Status).IsRequired().HasMaxLength(50);
                entity.Property(s => s.Creation).IsRequired();

                entity.HasOne(s => s.Agent)
                    .WithMany(a => a.Schedules)
                    .HasForeignKey(s => s.AgentId)
                    .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(s => s.Customer)
                    .WithMany()
                    .HasForeignKey(s => s.CustomerId)
                    .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(s => s.TimeSlot)
                    .WithMany(t => t.Schedules)
                    .HasForeignKey(s => s.TimeSlotId)
                    .OnDelete(DeleteBehavior.Cascade);
            });
        }
    }
}


