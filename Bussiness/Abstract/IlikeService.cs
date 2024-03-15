namespace Bussnies.Abstract;

public interface IlikeService
{
    void AddLike(int postId, int userId);
    void RemoveLike(int postId, int userId);

}