using System.ComponentModel.DataAnnotations;

namespace Task20.ApiModels
{
    public class GroupUpdater
    {
        [MaxLength(50)]
        public string? Name { get; set; }

        [MaxLength(300)]
        public string? Description { get; set; }

        public int? CourseId { get; set; }

        public int? LeaderId { get; set; }

        public bool IsWhetherUpdatesNeedApplied
        {
            get
            {
                if (Name == null && Description == null && CourseId == null && LeaderId == null)
                {
                    return false;
                }

                return true;
            }
        }
    }
}
