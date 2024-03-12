using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.DataAccsess;
using Entity.Abstract;

namespace Entity.Concrete
{
    public class Post: IPost, IEntity
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime CreatedDate { get; set; }
        public int UserId { get; set; }
    }
}
