using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.DataAccsess;
using Entity.Abstract;

namespace Entity.Concrete
{
    public class Post: IPost, IEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        
        public string user_id { get; set; }
      
    }
}
