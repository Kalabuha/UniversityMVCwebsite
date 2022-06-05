using System.ComponentModel.DataAnnotations;

namespace Task20.WebAppMVC.Models.SimpleModels
{
    public class SignUpViewModel
    {
        [Required, StringLength(60)]
        public string Login { get; set; } = default!;


        [Required, StringLength(30)]
        [DataType(DataType.Password)]
        public string Password { get; set; } = default!;

        [Required, StringLength(30)]
        [DataType(DataType.Password)]
        public string RepeatPassword { get; set; } = default!;
    }
}
