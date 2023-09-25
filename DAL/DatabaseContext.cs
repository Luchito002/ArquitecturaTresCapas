using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json; 
using System.IO;

namespace DAL
{
    public class DatabaseContext : DbContext
    {
        //Cadena de conexión
        private readonly string _connectionString = "Host=containers-us-west-130.railway.app;Port=6863;Database=railway;Username=postgres;Password=TreVp11YYL5CfhezPcvY";

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseNpgsql(_connectionString);
            }
        }

        //Agregar objetos para mapear en la base de datos
        public DbSet<Persona> Personas { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Persona>().ToTable("Persona");
            modelBuilder.Entity<Usuario>().ToTable("Usuario");
        }
    }
}