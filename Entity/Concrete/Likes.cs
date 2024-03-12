using Core.DataAccsess;
using Entity.Abstract;

namespace Entity.Concrete;

public class Likes: Ilike, IEntity
{
  public int Id { get; set; }
  public int UserId { get; set; }
  public int PostId { get; set; }
  public int PostUserId { get; set; } = 0;
  public bool Like { get; set; }
}