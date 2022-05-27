using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Task20.Entities;

namespace Task20.DataContext.TableConfigurations
{
    internal class CoursesConfig : IEntityTypeConfiguration<CourseEntity>
    {
        public void Configure(EntityTypeBuilder<CourseEntity> builder)
        {
            builder
                .HasOne(c => c.Leader)
                .WithOne(c => c.Course)
                .HasForeignKey<CourseEntity>(c => c.LeaderId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        }
    }
}
