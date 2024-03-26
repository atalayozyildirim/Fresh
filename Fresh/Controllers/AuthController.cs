using Entity.Concrete;
using Fresh.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using Microsoft.AspNetCore.Authorization;

namespace Fresh.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly SignInManager<Users> _signInManager;
    private readonly UserManager<Users> _userManager;
    private readonly IConfiguration _configuration;


    public AuthController(SignInManager<Users> signInManager, UserManager<Users> userManager,IConfiguration configuration)
    {
        _signInManager = signInManager;
        _userManager = userManager;
        _configuration = configuration;
    }
 
    private string GenerateRefreshToken()
    {
        var randomNumber = new byte[32];
        using var rng = RandomNumberGenerator.Create();
        rng.GetBytes(randomNumber);
        return Convert.ToBase64String(randomNumber);
    }

    private string GenareteJwtToken(Users user)
    {
        var claims = new[]
        {
            new Claim(JwtRegisteredClaimNames.Sub, user.Email),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        };
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
        
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
        
        var token = new JwtSecurityToken("https://localhost:5226/auth/login",
            "https://localhost:5226/auth/login",
            claims,
            expires: DateTime.Now.AddMinutes(30),
            signingCredentials: creds);
        
        return new JwtSecurityTokenHandler().WriteToken(token);
    }
    [HttpGet]
    [AllowAnonymous]
    [Route("/auth/test")]
    public async Task<IActionResult> Auth()
    {
        return Ok("s");
    }
    
    [HttpPost]
    [AllowAnonymous]
    [Route("/auth/register")]
    public async Task<IActionResult> Register([FromBody] RegisterModel model)
    {
        
        var refresh = GenerateRefreshToken();
        
        var users = new Users { Email = model.Email, UserName = model.UserName, PhoneNumber = model.phoneNumber };
        users.RefreshToken = refresh;
        
        if (string.IsNullOrEmpty(model.Password))
        {
            return BadRequest(new { message = "Parola boş olamaz" });
        }

        var exitUser = await _userManager.FindByEmailAsync(model.Email);
        if (exitUser != null)
        {
            return BadRequest(new { message = "Bu email adresi kullanılmaktadır" });
        }

        var result = await _userManager.CreateAsync(users, model.Password);

        if (!result.Succeeded)
        {
            return BadRequest(new { message = result.Errors });
        }
        return Ok(new { meesage = "Kullanıcı oluştu !", user = users });
    }

    [HttpPost]
    [AllowAnonymous]
    [Route("/auth/login")]
    public async Task<IActionResult> Login([FromBody] LoginModel model)
    {

        if (model == null)
        {
            return BadRequest(new { message = "Gelen veri boş olamaz !" });
        }
        var user = await _userManager.FindByEmailAsync(model.Email);

        if (user == null)
        {
            return BadRequest(new { message = "Kullanıcı bulunamadı !" });
        }


        var result = await _signInManager.CheckPasswordSignInAsync(user, model.Password, lockoutOnFailure: false);

        if (result.IsNotAllowed)
        {
            return BadRequest(new { message = "Kullanıcı yetkisiz!" });
        }
        if (!result.Succeeded)
        {
            return BadRequest(new { message = result.ToString() });
        }
        var claims = new[]
            {
            // EMAİL SAKLIYOR 
            new Claim(JwtRegisteredClaimNames.Sub, model.Email),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };
        // SECRET KEY
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
        // CREDENTIALS
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
        // TOKEN
        var token = new JwtSecurityToken("https://localhost:5226/auth/login",
            "https://localhost:5226/auth/login",
            claims,
            expires: DateTime.Now.AddMinutes(30),
            signingCredentials: creds);

        return Ok(new { token = new JwtSecurityTokenHandler().WriteToken(token), refreshToken = user.RefreshToken});
    }
    [HttpGet]
    [Route("/auth/logout")]
    public async Task<IActionResult> Logout()
    {
        await _signInManager.SignOutAsync();
        return Ok(new { message = "Çıkış yapıldı" });
    }

    [HttpPost]
    [Route("/auth/refresh")]
    public async Task<IActionResult> Refresh([FromBody] TokenModel model)
    {
        var user = _userManager.Users.SingleOrDefault(u => u.RefreshToken == model.RefreshToken);

       if (user == null)
       {
           return BadRequest();
       }
       var newToken = GenareteJwtToken(user);
       var refresh = GenerateRefreshToken();

       return new ObjectResult(new
       {
           token = newToken,
           refreshToken = refresh
       });
    }
}