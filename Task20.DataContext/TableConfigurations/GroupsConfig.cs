using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Task20.Entities;

namespace Task20.DataContext.TableConfigurations
{
    internal class GroupsConfig : IEntityTypeConfiguration<GroupEntity>
    {
        public void Configure(EntityTypeBuilder<GroupEntity> builder)
        {
            builder
                .HasOne(g => g.Leader)
                .WithOne(t => t.Group)
                .HasForeignKey<GroupEntity>(g => g.LeaderId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            builder
                .HasOne(g => g.Course)
                .WithMany(c => c.Groups)
                .HasForeignKey(g => g.CourseId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
