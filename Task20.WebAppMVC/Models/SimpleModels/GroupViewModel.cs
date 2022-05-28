using Task20.Models;
using Task20.Services.Resources;

namespace Task20.WebAppMVC.Models.SimpleModels
{
    public class GroupViewModel
    {
        public GroupModel Group { get; set; } = default!;
        public GroupData? GroupData { get; set; }
    }
}
