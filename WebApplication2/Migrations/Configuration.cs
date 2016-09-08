namespace WebApplication2.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using WebApplication2.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<WebApplication2.Models.AppDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(WebApplication2.Models.AppDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
                context.Contacts.AddOrUpdate(
                    new Contact { FirstName = "John", LastName = "Doe", Knickname = "Squ", PhoneNumber = "1112223332",  DateOfBirth = DateTime.Parse("1980-09-01") },
                    new Contact { FirstName = "Sotiris", LastName = "Alonso", Knickname = "Doe", PhoneNumber = "1111111",  DateOfBirth = DateTime.Parse("1982-10-01") },
                    new Contact { FirstName = "Spiros", LastName = "Mixos", Knickname = "Hui", PhoneNumber = "123111",  DateOfBirth = DateTime.Parse("2003-07-21") },
                    new Contact { FirstName = "Vagelis", LastName = "Barzdukas", Knickname = "Lui", PhoneNumber = "12312312",  DateOfBirth = DateTime.Parse("1960-05-01") },
                    new Contact { FirstName = "Yannis", LastName = "Varoufakis", Knickname = "Dui", PhoneNumber = "12312112",  DateOfBirth = DateTime.Parse("1945-12-23") },
                    new Contact { FirstName = "Peggy", LastName = "Karra", Knickname = "Bobos", PhoneNumber = "333211212",  DateOfBirth = DateTime.Parse("2000-09-01") },
                    new Contact { FirstName = "Nikos", LastName = "Panou", Knickname = "Babis", PhoneNumber = "1112223332",  DateOfBirth = DateTime.Parse("1985-09-01") },
                    new Contact { FirstName = "Kostas", LastName = "Papatheodorou", Knickname = "Lola", PhoneNumber = "1112223332",  DateOfBirth = DateTime.Parse("1985-04-25") }
                );
            //
        }
    }
}
