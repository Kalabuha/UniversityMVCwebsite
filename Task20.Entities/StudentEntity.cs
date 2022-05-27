using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Task20.Entities.Base;

namespace Task20.Entities
{
    public class StudentEntity : Human
    {
        [Column("Date_admission_to_university"), Required]
        public DateTime DateAdmission { get; set; }

        [Column("Group_id"), Required]
        public int GroupId { get; set; }
        public GroupEntity Group { get; set; } = default!;
    }
}
