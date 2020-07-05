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
    }
}
