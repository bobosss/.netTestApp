
using WebApplication2.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace WebApplication2.Models
{
    public class AppDbContext : DbContext
    {

        public AppDbContext() : base("name=DemoAppConnectionString")
        {
        }

        public DbSet<Contact> Contacts { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Configurations.Add(new ContactEntityConfiguration());
        }

    }
}