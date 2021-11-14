using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace WebService1.Entity4.DbModels
{
    public class DbPhoneNumber
    {
        public int PhoneId { get; set; } //guid
        public int CustomerId { get; set; } //guid
        public string Number { get; set; }
        public DbCustomer Customer { get; set; }
    }
    internal class DbPnoneNumberConfiguration : IEntityTypeConfiguration<DbPhoneNumber>
    {
        public void Configure(EntityTypeBuilder<DbPhoneNumber> builder)
        {
            builder.ToTable("PhoneNumbers");
            builder.HasKey(x => x.PhoneId);
            builder
                .HasOne(number => number.Customer)
                .WithMany(customer => customer.Numbers);
        }
    }
}
