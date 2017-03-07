using Microsoft.EntityFrameworkCore;
using FisherInsuranceApi.Models;
using Microsoft.EntityFrameworkCore.Design;
using Npgsql.EntityFrameworkCore.PostgreSQL;

namespace FisherInsuranceApi.Data
{
    public class FisherContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connection = "User ID=fisher-user;Password=12345 ;Host=localhost;Port=5432;Database=<fisher-insurance>;Pooling=true;";
            
            optionsBuilder.UseNpgsql(connection);
        }

        public DbSet<Claim> Claims { get; set; }
        public DbSet<Quote> Quotes { get; set; }

    }
}