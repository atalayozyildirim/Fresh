using Bussnies.Abstract;
using DataAccsess.Abstract;
using Entity.Concrete;

namespace Bussiness.Concrete;

public class LikeManager : IlikeService
{
    private readonly ILikeDal _likeDal;
    private readonly IUserService _userService;

    public LikeManager(ILikeDal likeDal, IUserService userService)
    {
        _likeDal = likeDal;
        _userService = userService;
    }
    public void AddLike(int postId, int userId)
    {

        var like = new Likes()
        {
            PostId = postId,
            UserId = userId
        };

        _likeDal.Add(like);
    }

    public void RemoveLike(int postId, int userId)
    {
        var like = _likeDal.Get(l => l.PostId == postId && l.UserId == userId);
        if (like != null)
        {
            _likeDal.Delete(like);
        }
    }
}