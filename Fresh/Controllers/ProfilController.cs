using Bussnies.Abstract;
using Entity.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Fresh.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProfilController : ControllerBase
{
    private readonly IProfileService _profileService;


    public ProfilController(IProfileService profileService)
    {
        _profileService = profileService;
    }
    
    [Route("/profile")]
    [AllowAnonymous]
    [HttpGet]
    public IActionResult Index()
    {
        return Ok("ProfilController");
    }
    
    [Route("/add")]
    [HttpPost]
    public IActionResult Add(Profile profile)
    {
        _profileService.Add(profile);       
        return Ok("ProfilController");
    }

    [Route("/update")]
    [HttpPut]
    public IActionResult Update(Profile profile)
    {
        _profileService.Update(profile);
        return Ok("ProfilController");
    }

}