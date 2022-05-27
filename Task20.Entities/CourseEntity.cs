using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Task20.Entities.Base;

namespace Task20.Entities
{
    public class CourseEntity : BaseEntity
    {
        [Column("Description"), Required, MaxLength(1000)]
        public string Description { get; set; } = default!;

        [Column("Creation_date"), Required]
        public DateTime CreationDate { get; set; }

        [Column("Leader_id")]
        public int? LeaderId { get; set; }
        public TeacherEntity? Leader { get; set; }

        public ICollection<GroupEntity>? Groups { get; set; }
    }
}
