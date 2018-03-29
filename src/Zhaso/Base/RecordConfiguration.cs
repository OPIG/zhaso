using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Zhaso
{
    public abstract class RecordConfiguration<T> : EntityConfiguration<T> where T : RecordEntity
    {
        public override void Configure(EntityTypeBuilder<T> builder)
        {
            builder.Property(x => x.CreateTime).IsRequired();
            builder.Property(x => x.UpdateTime).IsRequired();
            builder.Property(x => x.CreateUser).IsRequired().HasMaxLength(50);
            builder.Property(x => x.UpdateUser).IsRequired().HasMaxLength(50);
            builder.Property(x => x.Deleted).IsRequired();
            base.Configure(builder);
        }
    }
}
