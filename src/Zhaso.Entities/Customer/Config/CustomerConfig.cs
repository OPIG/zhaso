using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Zhaso.Entities
{
  
    public class CustomerConfig : RecordConfiguration<Customer>
    {
        public override void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.ToTable("Customers");
            builder.Property(o => o.Name).HasMaxLength(150);
            builder.Property(o => o.ShortName).HasMaxLength(50);
            builder.Property(o => o.EnglishName).HasMaxLength(150);
            builder.Property(o => o.Telphone).HasMaxLength(50);
            builder.Property(o => o.Prince).HasMaxLength(50);
            builder.Property(o => o.City).HasMaxLength(50);
            builder.Property(o => o.Address).HasMaxLength(500);
            builder.Property(o => o.Email).HasMaxLength(100);
            builder.Property(o => o.LegalPerson).HasMaxLength(50);
            builder.Property(o => o.Category).HasMaxLength(500);

            base.Configure(builder);
        }
    }
}
