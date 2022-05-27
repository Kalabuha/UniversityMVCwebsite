using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Task20.Entities.Base;

namespace Task20.Entities
{
    public class TeacherEntity : Human
    {
        [Column("Experience"), Required, MaxLength(1000)]
        public string Experience { get; set; } = default!;

        public GroupEntity? Group { get; set; }
        public CourseEntity? Course { get; set; }
    }
}
