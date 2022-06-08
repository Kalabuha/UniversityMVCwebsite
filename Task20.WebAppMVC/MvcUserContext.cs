using Task20.ServicesApi;

namespace Task20.WebAppMVC
{
    internal class MvcUserContext : IUserContext
    {
        private readonly string? _userName;

        public MvcUserContext(IHttpContextAccessor accessor)
        {
            _userName = accessor.HttpContext?.User.Identity?.Name;
        }

        public string? UserName => _userName;
    }
}
