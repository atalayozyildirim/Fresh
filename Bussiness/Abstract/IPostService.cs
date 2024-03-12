using Entity.Concrete;

namespace Bussnies.Abstract;

public interface IPostService
{
    void Add(Post post);
    void Delete(Post post);
    void Update(Post post);
    List<Post> GetAll();
    void GetById(int id);
}