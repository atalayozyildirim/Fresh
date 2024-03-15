using Entity.Concrete;

namespace Bussnies.Abstract;

public interface ICommentService
{
    void Add(Comment comment);
    void Update(Comment comment);
    void Delete(Comment comment);
    List<Comment> GetAll();
}