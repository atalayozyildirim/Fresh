using Bussiness.utils.Rules;
using Bussnies.Abstract;
using DataAccsess.Abstract;
using Entity.Concrete;

namespace Bussiness.Concrete;

public class PostManager: IPostService
{
    private IPostDal _postDal;
    private PostValidator _postValidator;
    
    public PostManager(IPostDal postDal, PostValidator postValidator)
    {
        _postDal = postDal;
        _postValidator = postValidator;
    }
    
    public  async Task Add(Post post)
    {
        var verifed = _postValidator.Validate(post);
        if (verifed.IsValid == false)
        {
            throw new Exception("Post is not valid");
        }
        _postDal.Add(post);
        
    }

    public async Task  Delete(Post post)
    {
        var verifed = _postValidator.Validate(post);
        if (verifed.IsValid == false)
        {
            throw new Exception("Post is not valid");
        }
        _postDal.Delete(post);
    }

    public async  Task  Update(Post post)
    {
        var verifed = _postValidator.Validate(post);
        if (verifed.IsValid == false)
        {
            throw new Exception("Post is not valid");
        }
         _postDal.Update(post);
    }

    public List<Post> GetAll()
    {
      return  _postDal.GetAll();
    }

    public async Task GetById(int id)
    {
        _postDal.GetById(id);
    }
}