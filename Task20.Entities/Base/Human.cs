using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Task20.Entities.Base
{
    public abstract class Human : BaseEntity
    {
        [Column("Sacond_name"), Required, MaxLength(20)]
        public string SacondName { get; set; } = default!;

        [Column("Last_name"), Required, MaxLength(20)]
        public string LastName { get; set; } = default!;

        [Column("Date_birth"), Required]
        public DateTime DateBirth { get; set; }
    }
}
