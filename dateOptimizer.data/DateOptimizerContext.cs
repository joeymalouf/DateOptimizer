using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using dateOptimizer.data.entities;

namespace dateOptimizer.data
{
    public class DateOptimizerContext : DbContext
    {
        // For migrations
        public DateOptimizerContext() 
            : this(new DbContextOptionsBuilder<DateOptimizerContext>().UseNpgsql("User Id=postgres;Password=jubjub67;Host=localhost;Port=5432;Database=dateOptimizer").Options) { }

        // Inject in Startup
        public DateOptimizerContext(DbContextOptions<DateOptimizerContext> options) : base(options) { }

        public DbSet<UsernamePasswordEntity> Credentials { get; set; }

        public string ProviderName => base.Database.ProviderName;

        public void Migrate()
        {
            this.Database.Migrate();
        }

        public async Task<int> SaveChangesAsync()
        {
            return await base.SaveChangesAsync();
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<UsernamePasswordEntity>().HasKey(m => m.Username);

            base.OnModelCreating(builder);
        }

    }
}