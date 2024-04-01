using Core.DataAccsess;
using Entity.Abstract;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entity.Concrete
{
    public class Post : IPost, IEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string id { get; set; }
        public string Title { get; set; }
        
        public string Author { get; set; }
        public string Content { get; set; }
        public string image { get; set; }
        public string url { get; set; }
        public DateTime CreateDate { get; set; }
        public string user_id { get; set; }

    }
}
