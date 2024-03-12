using Entity.Concrete;

namespace Bussnies.Abstract;

public interface IPostService
{
    Task Add(Post post);
    Task Delete(Post post);
    Task Update(Post post);
    List<Post> GetAll();
    Task GetById(int id);
}