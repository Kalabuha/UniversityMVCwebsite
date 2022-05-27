using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Task20.Entities.Base;

namespace Task20.Entities
{
    public class GroupEntity : BaseEntity
    {
        [Column("Description"), Required, MaxLength(300)]
        public string Description { get; set; } = default!;

        [Column("Creation_date"), Required]
        public DateTime CreationDate { get; set; }

        [Column("Course_id")]
        public int CourseId { get; set; }
        public CourseEntity Course { get; set; } = default!;

        [Column("Leader_id")]
        public int? LeaderId { get; set; }
        public TeacherEntity? Leader { get; set; }

        public ICollection<StudentEntity>? Students { get; set; }

    }
}
