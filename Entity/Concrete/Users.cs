using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.DataAccsess;
using Entity.Abstract;
using Microsoft.AspNetCore.Identity;

namespace Entity.Concrete
{
    public class Users :IdentityUser, IEntity
    {
    }
}
