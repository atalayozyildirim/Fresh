using System.Security.Claims;
using Bussnies.Abstract;
using Entity.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

namespace Bussiness.Concrete;

public class UserManager : IUserService
{
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly UserManager<Users> _userManager;
    
    public UserManager(IHttpContextAccessor httpContextAccessor, UserManager<Users> userManager)
    {
        _httpContextAccessor = httpContextAccessor;
        _userManager = userManager;
    }
    public async Task<Users> GetUserById()
    {
        var userId = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        var user = await _userManager.FindByIdAsync(userId);
        return user;
    }
}