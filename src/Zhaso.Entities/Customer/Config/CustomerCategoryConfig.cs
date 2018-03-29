using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Zhaso.Entities
{
  
    public class CustomerCategoryConfig : RecordConfiguration<CustomerCategory>
    {
        public override void Configure(EntityTypeBuilder<CustomerCategory> builder)
        {
            builder.ToTable("CustomerCategories");
            builder.Property(o => o.Category).HasMaxLength(50);
            builder.HasOne(o => o.Customer)
               .WithMany(o => o.CustomerCategories)
               .HasForeignKey(o => o.CustomerId);
            base.Configure(builder);
        }
    }
}
