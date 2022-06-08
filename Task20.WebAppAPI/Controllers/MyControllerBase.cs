using Microsoft.AspNetCore.Mvc;

namespace Task20.WebAppAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MyControllerBase : ControllerBase
    {
        protected string? GetLoggedUser()
        {
            if(HttpContext.Request.Headers.TryGetValue("X-User-Name", out var userNameHeader))
            {
                string? userName = userNameHeader;
                if(!string.IsNullOrEmpty(userName))
                    return userName;
            }
            return null;
        }

        protected string GetRequiredLoggedUser()
        {
            return GetLoggedUser() ?? throw new Exception("Незарегистрированный пользователь! Тебе здесь не рады!");
        }
    }
}
