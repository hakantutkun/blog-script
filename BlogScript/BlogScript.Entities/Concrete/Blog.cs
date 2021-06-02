using BlogScript.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlogScript.Entities.Concrete
{
    public class Blog : IBlogEntity
    {
        public int  Id { get; set; }
        public string Title { get; set; }
        public string ShortDescription { get; set; }
        public string Description { get; set; }
        public string ImagePath { get; set; }
        public DateTime PostedTime { get; set; }
        public List<CategoryBlog> CategoryBlogs { get; set; }
        public List<Comment> Comments { get; set; }

        public int AppUserId { get; set; }
        public AppUser AppUser { get; set; }

    }
}
