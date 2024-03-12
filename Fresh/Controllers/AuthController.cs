using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Text.Json.Serialization;
using Bussiness.utils.Rules;
using Entity.Concrete;
using FluentValidation;
using Fresh.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace Fresh.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly SignInManager<Users> _signInManager;
    private readonly UserManager<Users> _userManager;
   

    public AuthController(SignInManager<Users> signInManager, UserManager<Users> userManager)
    {
        _signInManager = signInManager;
        _userManager = userManager;
      
    }

    [HttpGet]
    [Route("/auth/test")]
    public async Task<IActionResult> Auth()
    {
        return Ok("s");
    }

    [HttpPost]
    [Route("/auth/register")]
    public async Task<IActionResult> Register([FromBody] RegisterModel model)
    {
        var users = new Users { Email = model.Email, UserName = model.UserName, PhoneNumber = model.phoneNumber };
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
        
        
        var result = await _signInManager.CheckPasswordSignInAsync(user, model.Password, lockoutOnFailure:false);

        if(result.IsNotAllowed)
        {
            return BadRequest(new { message = "Kullanıcı yetkisiz!" });
        }
        if (!result.Succeeded)
        {
            return BadRequest(new { message =  result.ToString() });
        }
        var claims = new[]
            {
            // EMAİL SAKLIYOR 
            new Claim(JwtRegisteredClaimNames.Sub, model.Email),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };
            // SECRET KEY
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("PqmoBU-XeuJWdal_cUJac_YfYNttWJxJOKIMXtFDL8A"));
            // CREDENTIALS
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            // TOKEN
            var token = new JwtSecurityToken("https://localhost:5226",
                "Fresh",
                claims,
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: creds);
            
        return Ok(new { token = new JwtSecurityTokenHandler().WriteToken(token) });
    }
}