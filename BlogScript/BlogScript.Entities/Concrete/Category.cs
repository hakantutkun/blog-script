using BlogScript.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlogScript.Entities.Concrete
{
    public class Category : IBlogEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<CategoryBlog> CategoryBlogs { get; set; }
    }
}
