﻿using Domain;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Persistance
{
    public class DataContext: IdentityDbContext<AppUser>
    {
        public DataContext(DbContextOptions options):base(options)
        {
            
        }
        public DbSet<Value> Values {get; set;}
        public DbSet<Activity> Activities {get; set;}
        public DbSet<UserActivity> UserActivities { get; set; }

        protected override void OnModelCreating(ModelBuilder builder){
           base.OnModelCreating(builder);
            builder.Entity<Value>()
                .HasData(
                    new Value { ID = 1, Name = "Value 101"},
                    new Value { ID = 2, Name = "Value 102"},
                    new Value { ID = 3, Name = "Value 103"}
                );
            builder.Entity<UserActivity>(x=>x.HasKey(ua => new { ua.AppUserId, ua.ActivityId }));
            builder.Entity<UserActivity>()
                .HasOne(a => a.AppUser)
                .WithMany(u => u.UserActivities)
                .HasForeignKey(a => a.AppUserId);
            builder.Entity<UserActivity>()
                .HasOne(u => u.Activity)
                .WithMany(a => a.UserActivities)
                .HasForeignKey(a => a.ActivityId);
        }
    }
}
