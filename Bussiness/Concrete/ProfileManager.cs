using Bussiness.utils.Rules;
using Bussnies.Abstract;
using DataAccsess.Abstract;
using Entity.Concrete;

namespace Bussiness.Concrete;

public class ProfileManager: IProfileService
{
    private  readonly IProfilDal  _profileDal;
    private readonly ProfileValidator _profileValidator;
    private readonly IUserService _userManager;
    
    public ProfileManager(IProfilDal profileDal,ProfileValidator profileValidator,IUserService userService)
    {
        _profileDal = profileDal;
        _profileValidator = profileValidator;
        _userManager = userService;
    }
   
    public void Add(Profile profile)
    {
        if (profile == null) throw new ArgumentNullException(nameof(profile));
        var user = _userManager.GetUserById();
        
        if(user == null) throw new Exception("User not found");

        profile.UserId = user.Result.Id;
       
            
        var valideResult = _profileValidator.Validate(profile);
        
        if(valideResult.IsValid) _profileDal.Add(profile);
        else throw new Exception(valideResult.Errors.ToString());
    }

    public void Update(Profile profile)
    {
        if(profile == null) throw new ArgumentNullException(nameof(profile));
        
        var updateProfile = _profileDal.Get(p => p.Id == profile.Id);
        if(updateProfile == null) throw new Exception("Profile not found");
        
         updateProfile.FirstName = profile.FirstName;
         updateProfile.LastName = profile.LastName;
         updateProfile.Content = profile.Content;
         updateProfile.ProfileImage = profile.ProfileImage;
         
        
        var valideResult = _profileValidator.Validate(profile);
            
    }

    public void Delete(Profile profile)
    {
        if(profile == null) throw new ArgumentNullException(nameof(profile));
        
        var deleteProfile = _profileDal.Get(p => p.Id == profile.Id);
        if(deleteProfile == null) throw new Exception("Profile not found");
        
        _profileDal.Delete(deleteProfile);
        
    }

    public List<Profile> GetAll()
    {
        return _profileDal.GetAll();
    }

    public void GetById(string id)
    {
       if(id == null) throw new ArgumentNullException(nameof(id));
       
       _profileDal.Get(p => p.UserId == id);
    }
}

