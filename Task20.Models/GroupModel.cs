using Task20.Models.Base;

namespace Task20.Models
{
    public class GroupModel : BaseModel
    {
        public string Name { get; set; } = default!;
        public string Description { get; set; } = default!;
        public DateTime CreationDate { get; set; }
        public int CourseId { get; set; }
        public int? LeaderId { get; set; }
    }
}
