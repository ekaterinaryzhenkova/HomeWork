using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace WebService1.Entity4.DbModels
{
    public class InfoContext : DbContext
    {
        public InfoContext(DbContextOptions<InfoContext> options)
            : base(options) { }
        public DbSet<DbCustomer> Customers { get; set; }
        public DbSet<DbPhoneNumber> Numbers { get; set; }

        protected  override void OnConfiguring(DbContextOptionsBuilder optionbuilder)
        {
            optionbuilder.UseSqlServer("Server=localhost\\SQLEXPRESS;Database = InfoContext;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder optionsbuilder)
        {
            optionsbuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
