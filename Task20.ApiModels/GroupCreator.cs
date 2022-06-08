using System.ComponentModel.DataAnnotations;

namespace Task20.ApiModels
{
    public class GroupCreator
    {
        [Required, MaxLength(50)]
        public string Name { get; set; } = default!;

        [Required, MaxLength(300)]
        public string Description { get; set; } = default!;

        [Required]
        public int CourseId { get; set; }

        public int? LeaderId { get; set; }
    }
}
