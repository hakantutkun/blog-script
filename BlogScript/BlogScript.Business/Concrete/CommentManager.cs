using BlogScript.Business.Abstract;
using BlogScript.DataAccess.Abstract;
using BlogScript.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlogScript.Business.Concrete
{
    public class CommentManager : GenericManager<Comment>, ICommentService
    {
        private readonly IGenericDal<Comment> _genericDal;

        public CommentManager(IGenericDal<Comment> genericDal) : base(genericDal)
        {
            _genericDal = genericDal;
        }
    }
}
