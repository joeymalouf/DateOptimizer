using System;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using dateOptimizer.data.entities;
using Microsoft.EntityFrameworkCore;
namespace dateOptimizer.data
{
    public class DateOptimizerContext : DbContext
    {
        // For migrations
        public DateOptimizerContext() 
            : this(new DbContextOptionsBuilder<DateOptimizerContext>().UseNpgsql("User Id=postgres;Password=jubjub67;Host=localhost;Port=5432;Database=dateOptimizer").Options) { }

        // Inject in Startup
        public DateOptimizerContext(DbContextOptions<DateOptimizerContext> options) : base(options)
        { 
            
        }

        public DbSet<DayRangeEntitity> AppraisalPercentages { get; set; }
        public DbSet<CountyInfoEntity> CountyInfo { get; set; }

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
            builder.Entity<DayRangeEntitity>().HasKey(m => m.Fip);

            base.OnModelCreating(builder);
        }

    }
}