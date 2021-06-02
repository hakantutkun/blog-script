using BlogScript.DataAccess.Abstract;
using BlogScript.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlogScript.DataAccess.Concrete.EFCore.Repositories
{
    public class EfAppUserRepositor : EFGenericRepository<AppUser>, IAppUserDal
    {
    }
}
