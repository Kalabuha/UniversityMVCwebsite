using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Task20.Entities.Base
{
    public abstract class BaseEntity : IEntity
    {
        public int Id { get; set; }

        [Column("Name"), Required, MaxLength(50)]
        public string Name { get; set; } = default!;
    }
}
