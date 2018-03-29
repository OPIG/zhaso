using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Zhaso
{
    public abstract class TreeConfiguration<T> : RecordConfiguration<T> where T : TreeEntity<T>
    {
        public override void Configure(EntityTypeBuilder<T> builder)
        {
            builder.Property(x => x.Path).HasMaxLength(500);
            builder.HasOne(x => x.Parent)
                .WithMany(x => x.Children)
                .HasForeignKey(x => x.ParentId)
                .OnDelete(DeleteBehavior.Restrict);
            base.Configure(builder);
        }
    }
}
