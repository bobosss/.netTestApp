using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication2.Models;
using System.Data.Entity.ModelConfiguration;

public class ContactEntityConfiguration : EntityTypeConfiguration<Contact>
{
    public ContactEntityConfiguration()
    {


        HasKey<int>(s => s.Id);

        Property(p => p.FirstName)
                .HasMaxLength(100);

        Property(p => p.LastName)
                .HasMaxLength(100);

        Property(p => p.Knickname)
                .IsOptional()
                .HasMaxLength(20);

        //Greek PhoneNumbers is 10 digits
        Property(p => p.PhoneNumber)
                .HasMaxLength(10);

    }
}