using System;
using Microsoft.EntityFrameworkCore;
using EFSamurai.Domain;
using System.Data.SqlClient;

namespace EFSamurai.Data
{
    public class SamuraiContext :DbContext

    {
        public DbSet<Samurai> Samurais { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder opitionsBuilder)
        {
            opitionsBuilder.UseSqlServer(
                @"Server = (localdb)\MSSQLLocalDB;) " +
                @"Database=EFSamurai; " +
                @"Trusted_Connection = True; " );
        }

        public DbSet<Quote> Quotes { get; set; }
        public DbSet<SecretIdentity> SecretIdentities { get; set; }
        public DbSet<SamuraiBattle> SamuraiBattles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SamuraiBattle>()
                .HasKey(c => new {c.SamuraiId, c.BattleId});
        }

        public DbSet<BattleLog> BattleLogs { get; set; }
        public DbSet<BattleEvent> BattleEvents { get; set; }
    }
}
