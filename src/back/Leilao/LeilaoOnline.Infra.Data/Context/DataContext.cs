using LeilaoOnline.Domain.Entities;
using LeilaoOnline.Infra.Data.Configs;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;


namespace LeilaoOnline.Infra.Data.Context
{
    public class DataContext : DbContext
    {
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Domain.Entities.Leilao> Leilao { get; set; }
        private readonly IConfiguration _configuration;

        public DataContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_configuration.GetConnectionString("db"));
            optionsBuilder.UseLazyLoadingProxies();

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {            
            modelBuilder.ApplyConfiguration(new UsuarioConfig());
            modelBuilder.ApplyConfiguration(new LeilaoConfig());
        }
    }
}
