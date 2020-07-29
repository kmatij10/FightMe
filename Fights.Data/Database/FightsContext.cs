using Microsoft.EntityFrameworkCore;
using Fights.Data.Entities;
using System;

namespace Fights.Data.Database
{
    public class FightsContext : DbContext
    {
        public FightsContext(DbContextOptions<FightsContext> options)
            : base(options)
        { }

        public DbSet<City> Cities { get; set; }
        public DbSet<Fight> Fights { get; set; }
        public DbSet<Donation> Donations { get; set; }
        public DbSet<Swipe> Swipes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<City>().HasData(
                new City
                {
                    Id = 1,
                    Name = "Zagreb"
                },
                new City
                {
                    Id = 2,
                    Name = "Krk"
                }
            );
            modelBuilder.Entity<Fight>().HasData(
                new Fight
                {
                    Id = 1,
                    Address = "Vukovarska 238",
                    User1Id = 1,
                    User2Id = 2,
                    CityId = 1
                },
                new Fight
                {
                    Id = 2,
                    Address = "Ohridska 23",
                    User1Id = 4,
                    User2Id = 5,
                    CityId = 2
                }
            );
            modelBuilder.Entity<Donation>().HasData(
                new Donation
                {
                    Id = 1,
                    UserId = 1,
                    FightId = 1,
                    Amount = 22.4m
                },
                new Donation
                {
                    Id = 2,
                    UserId = 2,
                    FightId = 1,
                    Amount = 12.4m
                }
            );
            modelBuilder.Entity<Swipe>().HasData(
                new Swipe
                {
                    Id = 1,
                    IsSuperSwipe = 1,
                    User1Id = 1,
                    User2Id = 2
                },
                new Swipe
                {
                    Id = 2,
                    IsSuperSwipe = 0,
                    User1Id = 4,
                    User2Id = 5
                }
            );
        }
    }
}
