using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace PersistenceLayer
{
    public class MyContext : DbContext
    {
        protected readonly IConfiguration iConfig;

        public DbSet<User> Users { get; set; }

        public MyContext(DbContextOptions<MyContext> options, IConfiguration iConf)
        : base(options)
        {
            iConfig = iConf;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseNpgsql(iConfig.GetConnectionString("DefaultConnection"), b => b.MigrationsAssembly("RestApi"));
        }
    }
}
