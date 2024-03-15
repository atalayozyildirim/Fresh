using Bussiness.utils.Rules;
using Bussnies.Abstract;
using DataAccsess.Abstract;
using Entity.Concrete;

namespace Bussiness.Concrete;

public class CommentManager : ICommentService
{
    private ICommentDal _commentDal;
    private CommentValidator _commentValidator;
    private IPostService _postService;

    public CommentManager(ICommentDal commentDal, CommentValidator commentValidator, IPostService postService)
    {
        _commentDal = commentDal;
        _commentValidator = commentValidator;
        _postService = postService;
    }
   
    public void Add(Comment comment)
    {
        var result = _commentValidator.Validate(comment);
        var post = _postService.GetById(comment.PostId);
        
        
        if(post == null) throw new Exception("Post is not found!");
        if (comment == null && !result.IsValid)
        {
        throw new Exception("Comment is not valid!");
        }
        _commentDal.Add(comment);

    }

    public void Update(Comment comment)
    {
        var a = _commentDal.Get(x => x.Id == comment.Id);
        
        a.Content = comment.Content ?? throw new Exception("Content is not found!");
        
        if (a == null) throw new Exception("Comment is not found!");
        _commentDal.Update(a);

    }

    public void Delete(Comment comment)
    {
        var a = _commentDal.Get(x => x.Id == comment.Id);
        if (a == null) throw new Exception("Comment is not found!");
        _commentDal.Delete(comment);
    }

    public List<Comment> GetAll()
    {
        throw new NotImplementedException();
    }
}