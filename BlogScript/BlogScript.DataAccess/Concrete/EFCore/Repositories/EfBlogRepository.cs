using BlogScript.DataAccess.Abstract;
using BlogScript.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlogScript.DataAccess.Concrete.EFCore.Repositories
{
    public class EfBlogRepository : EFGenericRepository<Blog>, IBlogDal
    {
    }
}
