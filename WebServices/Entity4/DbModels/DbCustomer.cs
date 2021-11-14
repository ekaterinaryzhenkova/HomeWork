using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;

namespace WebService1.Entity4.DbModels
{
    public class DbCustomer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }

        public IEnumerable<DbPhoneNumber> Numbers { get; set; } //string
    }

    internal class DbCustomerConfiguration : IEntityTypeConfiguration<DbCustomer>
    {
        public void Configure(EntityTypeBuilder<DbCustomer> builder)
        {
            builder.ToTable("Customers");
            builder.HasKey(x => x.Id);
        }
    }
}
