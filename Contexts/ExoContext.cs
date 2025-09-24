using Exo.WebApi.Models;
using Microsoft.EntityFrameworkCore;
using System.Data.SqlClient;
using Microsoft.Data.SqlClient;

namespace Exo.WebApi.Contexts
{
    public class ExoContext : DbContext
    {
        public ExoContext() { 
        }
        
        public ExoContext(DbContextOptions<ExoContext> options) : base(options) { 
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                // Connection string to your SQL Server database
                var connectionString = "Server=DESKTOP-9MT8QQF\\SQLEXPRESS;Database=ExoApi;User Id=sa;Password=12345;";
                optionsBuilder.UseSqlServer(connectionString);
            }
        }
        public DbSet<Projeto> Projetos { get; set; }
    }
}