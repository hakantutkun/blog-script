using BlogScript.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlogScript.Entities.Concrete
{
    public class CategoryBlog : IBlogEntity
    {
        public int Id { get; set; }
        public int BlogId { get; set; }
        public Blog Blog { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
