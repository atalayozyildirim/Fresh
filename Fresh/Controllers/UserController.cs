using System.IdentityModel.Tokens.Jwt;
using Bussiness.Concrete;
using Entity.Concrete;
using Fresh.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Fresh.Controllers;

[ApiController]
public class UserController : ControllerBase
{
    private UserManager<Users> _userManager;
    
    public UserController(UserManager<Users> userManager)
    {
        _userManager = userManager;
    }
    
    [Authorize]
    [HttpGet("api/user")]
    public  IActionResult GetUser()
    {
        // tokeni headerdan alıyoruz
        var token = HttpContext.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();

        if (token == null)
        {
            return Unauthorized();
        }

        // tokeni  çöz
        var handler = new JwtSecurityTokenHandler();
        var jwtToken= handler.ReadJwtToken(token);
        
        // emaili alıyoruz sub claimden 
        var emailClaim  = jwtToken.Claims.FirstOrDefault(c => c.Type == JwtRegisteredClaimNames.Sub);
        
        
        if (emailClaim == null)
        {
            return Unauthorized();
        }
        //veritabanından kullanıcıyı al
        var user = _userManager.Users.SingleOrDefault(x => x.Email == emailClaim.Value);
       
        if (user == null)
        {
            return NotFound();
        }

        var userDto = new UserModel
        {
            id = user.Id,
            Email = user.Email,
            normalizedEmail = user.NormalizedEmail,
            UserName = user.UserName,
            phoneNumber = user.PhoneNumber,
            emailConfrimed = user.EmailConfirmed.ToString(),
            accessFailedCount = user.AccessFailedCount,
            phoneNumberConfirmed = user.PhoneNumberConfirmed.ToString(),
            twoFactorEnabled = user.TwoFactorEnabled.ToString(),
            lockoutEnd = user.LockoutEnd.ToString(),
            lockoutEnabled = user.LockoutEnabled.ToString()
        };
      
        return Ok(userDto);
    }
}