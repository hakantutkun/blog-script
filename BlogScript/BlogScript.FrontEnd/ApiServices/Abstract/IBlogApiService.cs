using BlogScript.FrontEnd.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogScript.FrontEnd.ApiServices.Abstract
{
    public interface IBlogApiService
    {
        Task<List<BlogListModel>> GetAllAsync();
    }
}
