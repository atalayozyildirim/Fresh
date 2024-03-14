using Bussiness.utils.Rules;
using Bussnies.Abstract;
using Core.DataAccsess;
using DataAccsess.Abstract;
using Entity.Concrete;
using Microsoft.AspNetCore.Http.HttpResults;

namespace Bussiness.Concrete;

public class PostManager : IPostService
{
    private readonly IPostDal _postDal;
    private readonly PostValidator _postValidator;

    public PostManager(IPostDal postDal, PostValidator postValidator)
    {
        _postDal = postDal;
        _postValidator = postValidator;
    }
    public void Add(Post post)
    {
        var a = _postValidator.Validate(post);
        if (!a.IsValid)
        {
            throw new Exception(a.Errors.ToString());
        }
        _postDal.Add(post);

    }

    public void Delete(Post post)
    {

        if (post == null) throw new ArgumentNullException("post is null");
        
        var data = _postDal.Get(p => p.id == post.id);
        if (data == null) throw new ArgumentNullException("Boyle bir post yok");
        _postDal.Delete(data);
    }

    public List<Post> GetAll()
    {
        return _postDal.GetAll();
    }

    public void GetById(int id)
    {
        if(id == null) throw new ArgumentNullException("id is null");
        _postDal.GetById(id);
    }

    public void Update(Post post)
    {
        // mola 
        if (post == null) throw new ArgumentNullException(nameof(post));

        var data = _postDal.Get(p => p.id == post.id);

        if (data == null) throw new ArgumentNullException("Boyle bir post yok");


        data.Title = post.Title;
        data.Content = post.Content;

        var validationResult = _postValidator.Validate(post);
        if (!validationResult.IsValid)
        {
            throw new Exception("alidationResult.Errors.ToString()");
        }
        _postDal.Update(data);
    }


}
