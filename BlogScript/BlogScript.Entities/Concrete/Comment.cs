using BlogScript.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlogScript.Entities.Concrete
{
    public class Comment : IBlogEntity
    {
        public int Id { get; set; }
        public string AuthorName { get; set; }
        public string AuthorEmail { get; set; }
        public string Description { get; set; }
        public DateTime PostedTime { get; set; }
        public int? ParentCommentId { get; set; }
        public Comment ParentComment { get; set; }
        public List<Comment> SubComments { get; set; }
    }
}
