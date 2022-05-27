namespace Task20.Models.Base
{
    public abstract class ManModel : BaseModel
    {
        public string Firstname { get; set; } = default!;
        public string Middlename { get; set; } = default!;
        public string Lastname { get; set; } = default!;
        public DateTime DateBirth { get; set; }
    }
}
