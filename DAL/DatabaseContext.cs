using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json; 
using System.IO;

namespace DAL
{
    public class DatabaseContext : DbContext
    {
        private readonly string _connectionString = "Host=containers-us-west-130.railway.app;Port=6863;Database=railway;Username=postgres;Password=TreVp11YYL5CfhezPcvY";

        /*public DatabaseContext(string connectionString)
        {
            _connectionString = connectionString;
        }*/

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseNpgsql(_connectionString);
            }
        }
        public DbSet<Persona> Personas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Persona>().ToTable("Persona");
        }

        public void InsertarPersona(Persona persona)
        {
            Personas.Add(persona);
            SaveChanges();
        }
    }
}