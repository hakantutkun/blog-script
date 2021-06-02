using BlogScript.DataAccess.Abstract;
using BlogScript.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlogScript.Business.Concrete
{
    public class CategoryManager : GenericManager<Category>, ICategoryDal
    {
        private readonly IGenericDal<Category> _genericDal;
        public CategoryManager(IGenericDal<Category> genericDal) : base(genericDal)
        {
            _genericDal = genericDal;
        }
    }
}
