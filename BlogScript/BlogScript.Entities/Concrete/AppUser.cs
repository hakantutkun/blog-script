using BlogScript.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlogScript.Entities.Concrete
{
    public class AppUser : IBlogEntity
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public List<Blog> Blogs { get; set; }
    }
}
