using Entity.Concrete;

namespace Bussnies.Abstract;

public interface IProfileService
{
    void Add(Profile profile);
    void Update(Profile profile);
    void Delete(Profile profile); 
    List<Profile> GetAll();
    void GetById(string id);
    
}